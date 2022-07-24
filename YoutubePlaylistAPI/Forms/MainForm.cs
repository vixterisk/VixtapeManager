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
            //Store.Pull();
            //Synchronize();
        }

        void Synchronize()
        {
            try { 
                playlistDGV.DataSource = Store.CurrentPlaylist.GetVideos();
            }
            catch (PlaylistNullException e) {
                MessageBox.Show(e.Message);
            }
        }

        private void playlistDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (playlistDGV.Columns[e.ColumnIndex].Name == "indexColumn")
                e.Value = (e.RowIndex + 1).ToString();
        }

        private void playlistDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var value = playlistDGV.Rows[e.RowIndex].Cells["indexColumn"].Value;
            if (!FormUtils.isIndexValueValid(value, Store.CurrentPlaylist.Count))
                return;

            var oldIndex = e.RowIndex;
            var newIndex = Convert.ToInt32(value) - 1;
            try {
                Store.CurrentPlaylist.Move(oldIndex, newIndex);
            }
            catch (IndexOutOfRangeException ex) {
                MessageBox.Show(ex.Message);
            }
            Synchronize();
        }

        private void playlistDGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            e.Cancel = !FormUtils.isIndexValueValid(playlistDGV.Rows[e.RowIndex].Cells["indexColumn"].EditedFormattedValue, Store.CurrentPlaylist.Count);
        }

        private void ShowAddVideoButton_Click(object sender, EventArgs e)
        {
            var addVideoForm = new AddVideoForm();
            if (addVideoForm.ShowDialog(this) == DialogResult.OK) {
                var videoURL = addVideoForm.VideoURL;
                var index = addVideoForm.VideoIndex - 1;
                if (index == Store.CurrentPlaylist.Count)
                    Store.CurrentPlaylist.Add(new VideoModel(videoURL, "Title", "Channel"));
                else
                    Store.CurrentPlaylist.Insert(index, new VideoModel(videoURL, "Title", "Channel"));
                Synchronize();
            }
            addVideoForm.Dispose();
        }

        private void signInButton_Click(object sender, EventArgs e)
        {

        }
    }
}
