using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VixtapeManager
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
            Store.FillTest();
            //Store.Pull();
            Synchronize();
        }

        void Synchronize()
        {
            playlistDGV.DataSource = Store.CurrentPlaylist.GetVideos();
            for (int i = 0; i < playlistDGV.Rows.Count; i++)
                playlistDGV.Rows[i].Cells[0].Value = i;
        }

        private void playlistDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (playlistDGV.Columns[e.ColumnIndex].Name == "indexColumn")
                e.Value = (e.RowIndex + 1).ToString();
        }

        bool ValidateIndexCell(object cell)
        {
            return cell != null
                && (!int.TryParse(cell.ToString(), out int index)
                    || index < 1
                    || index > Store.CurrentPlaylist.Count
                );
        }

        private void playlistDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var value = playlistDGV.Rows[e.RowIndex].Cells["indexColumn"].Value;
            if (!ValidateIndexCell(value))
                return;
            var oldIndex = e.RowIndex;
            var newIndex = Int32.Parse(value.ToString()) - 1;
            Store.CurrentPlaylist.Move(oldIndex, newIndex);
            Synchronize();
        }

        private void playlistDGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            e.Cancel = ValidateIndexCell(playlistDGV.Rows[e.RowIndex].Cells["indexColumn"].EditedFormattedValue);
        }
    }
}
