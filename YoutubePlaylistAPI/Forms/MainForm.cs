using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoutubePlaylistAPI
{
    // TODO: Color selected cells
    public partial class MainForm : Form
    {
        List<Tuple<int, int>> filteredItemIndex = new List<Tuple<int, int>>();
        int currentFilteredItemSelected = 0;
        public MainForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            Authorize();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Authorize();
        }

        private void Authorize()
        {
            var authForm = new AuthForm();
            authForm.ShowDialog();
            Synchronize(0);
            arrowButtonLeft.Enabled = false;
            arrowButtonRight.Enabled = false;
        }

        void Synchronize(int rowToFocus)
        {
            var playlistIsNotEmpty = Store.CurrentPlaylist != null;

            showAddVideoFormButton.Enabled = playlistIsNotEmpty;
            DeleteVideoButton.Enabled = playlistIsNotEmpty;
            ExportToCSVButton.Enabled = playlistIsNotEmpty;
            SynchronizeButton.Enabled = playlistIsNotEmpty;

            if (playlistIsNotEmpty)
            {
                playlistGB.Text = $"Current playlist: {Store.CurrentPlaylist.Title} (https://www.youtube.com/playlist?list={Store.CurrentPlaylist.Link})";
                descriptionRTB.Text = Store.CurrentPlaylist.Description;
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = Store.CurrentPlaylist;
                playlistDGV.DataSource = bindingSource;
                if (Store.CurrentPlaylist.Count > 0)
                    playlistDGV.CurrentCell = playlistDGV.Rows[rowToFocus].Cells[0];
            }
        }

        void ShowErrorMessage(string action, string message)
        {
            MessageBox.Show(message, $"Unable to {action} video");
        }

        private void playlistDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (Store.CurrentPlaylist == null)
                return;
            if (playlistDGV.Columns[e.ColumnIndex].Name == "indexColumn")
                e.Value = (e.RowIndex + 1).ToString();
            //if (playlistDGV.Columns[e.ColumnIndex].Name == "DateDataGridViewTextBoxColumn") 
            //{
            //    var value = (DateTime)e.Value;
            //    e.Value = value.ToString("dd/MM/yyyy");
            //}
        }

        private async void playlistDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var value = playlistDGV.Rows[e.RowIndex].Cells["indexColumn"].Value;
            if (!FormUtils.isIndexValueValid(value, Store.CurrentPlaylist.Count))
                return;

            var oldIndex = e.RowIndex;
            var newIndex = Convert.ToInt32(value) - 1;
            try {
                var videoURL = playlistDGV.Rows[oldIndex].Cells["linkDataGridViewTextBoxColumn"].Value.ToString();
                await Store.MoveToNewPositionInCurrentPlaylist(oldIndex, newIndex, videoURL);
            }
            catch (Exception ex) {
                ShowErrorMessage("move", ex.Message);
                return;
            }
            Synchronize(newIndex);
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
                        ShowErrorMessage("add", ex.Message);
                        return;
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
                        ShowErrorMessage("insert", ex.Message);
                        return;
                    }
                }
                Synchronize(index);
            }
            addVideoForm.Dispose();
        }

        private async void playlistDGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                await DeleteVideo(sender, e);
            }
        }

        private async void SynchronizeButton_Click(object sender, EventArgs e)
        {
            var selectedRow = playlistDGV.SelectedCells[0].RowIndex;
            // TODO обработать если плейлист уже удален
            await Store.LoadCurrentPlaylistVideosAsync(Store.CurrentPlaylist);
            Synchronize(selectedRow);
        }

        private void playlistDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (playlistDGV.Columns[e.ColumnIndex].Name == "linkDataGridViewTextBoxColumn")
            {
                var videoId = (string)playlistDGV.Rows[e.RowIndex].Cells["linkDataGridViewTextBoxColumn"].Value;
                try
                {
                    var index = videoId.LastIndexOf('/');
                    var urlTemplate = String.Format("https://www.youtube.com/watch?v={0}&list={1}", videoId.Substring(index + 1), Store.CurrentPlaylist.Link);
                    Process.Start(urlTemplate);
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("open", ex.Message);
                    return;
                }
            }
        }

        private void SetSearchLabelText()
        {
            var index = filteredItemIndex.Count > 0? currentFilteredItemSelected + 1 : 0;
            SearchLabel.Text = $"{index}/{filteredItemIndex.Count}";
        }

        // TODO: Clear search after every action
        // TODO: Add needed columns selection
        private void searchTB_TextChanged(object sender, EventArgs e)
        {
            filteredItemIndex.Clear();
            arrowButtonLeft.Enabled = false;
            arrowButtonRight.Enabled = false;
            currentFilteredItemSelected = 0;

            if (string.IsNullOrWhiteSpace(searchTB.Text))
                return;

            var seekValue = searchTB.Text.ToLower();

            var result = new List<Tuple<int, int>>();
            for (int i = 0; i < playlistDGV.RowCount; i++)
            {
                var row = playlistDGV.Rows[i];
                foreach (DataGridViewCell cell in row.Cells)
                {
                    var cellValue = cell.EditedFormattedValue.ToString();
                    if (cellValue.ToLower().Contains(seekValue))
                        result.Add(new Tuple<int, int>(i, cell.ColumnIndex));
                }
            }
            filteredItemIndex = result.Distinct().ToList();
            if (filteredItemIndex.Count > 0)
            {
                var firstFilteredRow = filteredItemIndex[0].Item1;
                var firstFilteredCell = filteredItemIndex[0].Item2;
                playlistDGV.CurrentCell = playlistDGV.Rows[firstFilteredRow].Cells[firstFilteredCell];
            }
            arrowButtonRight.Enabled = filteredItemIndex.Count > 1;
            SetSearchLabelText();
        }

        private void arrowButtonLeft_Click(object sender, EventArgs e)
        {
            currentFilteredItemSelected--;
            SelectNextFilteredItem();
            SetSearchLabelText();
        }

        private void arrowButtonRight_Click(object sender, EventArgs e)
        {
            currentFilteredItemSelected++;
            SelectNextFilteredItem();
            SetSearchLabelText();
        }
        private void SelectNextFilteredItem()
        {
            var firstFilteredRow = filteredItemIndex[currentFilteredItemSelected].Item1;
            var firstFilteredCell = filteredItemIndex[currentFilteredItemSelected].Item2;
            playlistDGV.CurrentCell = playlistDGV.Rows[firstFilteredRow].Cells[firstFilteredCell];
            arrowButtonLeft.Enabled = currentFilteredItemSelected > 0;
            arrowButtonRight.Enabled = filteredItemIndex.Count - 1 > currentFilteredItemSelected;
        }
        private void ExportToCSVButton_Click(object sender, EventArgs e)
        {

            try
            {
                using (var openFileDialog = new SaveFileDialog())
                {
                    openFileDialog.FileName = Store.CurrentPlaylist.Title;
                    openFileDialog.Filter = "csv files (*.csv)|*.csv";
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var filePath = openFileDialog.FileName;
                        var fileStream = openFileDialog.OpenFile();
                        using (var writer = new StreamWriter(fileStream))
                        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                        {
                            var selectedRow = playlistDGV.SelectedCells[0].RowIndex;
                            Synchronize(selectedRow);
                            var records = Store.CurrentPlaylist.GetVideos();
                            csv.WriteRecords(records);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private async void DeleteVideoButton_Click(object sender, EventArgs e)
        {
            await DeleteVideo(sender, e);
        }

        async Task DeleteVideo(object sender, EventArgs e)
        {
            var selectedCells = new DataGridViewCell[playlistDGV.SelectedCells.Count];
            playlistDGV.SelectedCells.CopyTo(selectedCells, 0);
            var selectedRows = selectedCells.Select(x => x.RowIndex).Distinct().ToList().OrderByDescending(x => x);
            foreach (var currentSelectedRow in selectedRows)
            {
                var videoURL = playlistDGV.Rows[currentSelectedRow].Cells["linkDataGridViewTextBoxColumn"].Value.ToString();
                try
                {
                    await Store.RemoveFromCurrentPlaylist(currentSelectedRow, videoURL);
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("remove", ex.Message);
                    return;
                }
            }
            var minSelectedRow = Math.Max(0, Math.Min(selectedRows.Min(), Store.CurrentPlaylist.Count - 1));
            Synchronize(minSelectedRow);
        }
    }
}
