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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            State.FillTest();
            Synchronize();
        }

        void Synchronize()
        {
            playlistDGV.DataSource = State.CurrentPlaylist.GetVideos();
            for (int i = 0; i < playlistDGV.Rows.Count; i++)
                playlistDGV.Rows[i].Cells[0].Value = i;
        }

        private void playlistDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (playlistDGV.Columns[e.ColumnIndex].Name == "indexColumn")
                e.Value = (e.RowIndex + 1).ToString();
        }

        private void playlistDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var value = playlistDGV.Rows[e.RowIndex].Cells["indexColumn"].Value;

            if (value == null)
                return;

            var oldIndex = e.RowIndex;
            var newIndex = Int32.Parse(value.ToString()) - 1;
            State.CurrentPlaylist.Move(oldIndex, newIndex);
            Synchronize();
        }

        private void playlistDGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int index = 0;
            if (!Int32.TryParse(playlistDGV.Rows[e.RowIndex].Cells["indexColumn"].EditedFormattedValue.ToString(), out index) 
                || index < 1 
                || index > playlistDGV.Rows.Count
              )
                e.Cancel = true;
        }
    }
}
