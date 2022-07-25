using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoutubePlaylistAPI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            var authForm = new AuthForm();
            authForm.ShowDialog();
            Synchronize();
        }

        void Synchronize()
        {
            if (Store.CurrentPlaylist != null)
                playlistDGV.DataSource = Store.CurrentPlaylist.GetVideos();
        }

        private void playlistDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (Store.CurrentPlaylist == null)
                return;
            if (playlistDGV.Columns[e.ColumnIndex].Name == "indexColumn")
                e.Value = (e.RowIndex + 1).ToString();
            if (playlistDGV.Columns[e.ColumnIndex].Name == "linkDataGridViewTextBoxColumn")
                e.Value = VideoModel.LinkPrefix + e.Value;
        }

        private void playlistDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var value = playlistDGV.Rows[e.RowIndex].Cells["indexColumn"].Value;
            if (!FormUtils.isIndexValueValid(value, Store.CurrentPlaylist.Count))
                return;

            var oldIndex = e.RowIndex;
            var newIndex = Convert.ToInt32(value) - 1;
            try {
                Store.MoveToNewPositionInCurrentPlaylist(oldIndex, newIndex);
            }
            catch (IndexOutOfRangeException ex) {
                MessageBox.Show(ex.Message);
            }
            Synchronize();
        }

        private void playlistDGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (Store.CurrentPlaylist == null)
                return;
            // TODO: исправить костыли с +1?
            e.Cancel = !FormUtils.isIndexValueValid(playlistDGV.Rows[e.RowIndex].Cells["indexColumn"].EditedFormattedValue, Store.CurrentPlaylist.Count + 1);
        }

        private async void ShowAddVideoButton_Click(object sender, EventArgs e)
        {
            var addVideoForm = new AddVideoForm();
            if (addVideoForm.ShowDialog(this) == DialogResult.OK) {
                var videoURL = addVideoForm.VideoURL;
                var index = addVideoForm.VideoIndex - 1;
                if (index == Store.CurrentPlaylist.Count)
                {
                    try
                    {
                        await Store.AddToCurrentPlaylistAsync(videoURL);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format("Unable To Add Video \n({0})", string.Join("\n", ex.Message)), "Error");
                    }
                }
                else
                {
                    try
                    {
                        await Store.InsertIntoCurrentPlaylistAsync(index, videoURL);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(String.Format("Unable To Insert Video \n({0})", string.Join("\n", ex.Message)), "Error");
                    }
                }
                Synchronize();
            }
            addVideoForm.Dispose();
        }

        private void playlistDGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                var selectedCells = new DataGridViewCell[playlistDGV.SelectedCells.Count];
                playlistDGV.SelectedCells.CopyTo(selectedCells, 0);
                var selectedRows = selectedCells.Select(x => x.RowIndex).Distinct().ToList().OrderByDescending(x => x);
                foreach (var currentSelectedRow in selectedRows)
                    Store.RemoveFromCurrentPlaylist(currentSelectedRow);
                Synchronize();
            }
        }
    }
}
