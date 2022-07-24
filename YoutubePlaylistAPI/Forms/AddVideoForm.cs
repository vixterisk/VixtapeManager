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
    public partial class AddVideoForm : Form
    {
        string videoURL;
        int videoIndex;
        public string VideoURL { get { return videoURL; } }
        public int VideoIndex { get { return videoIndex; } }
        public AddVideoForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            indexComboBox.Enabled = false;
            indexComboBox.Items.AddRange(Enumerable.Range(1, Store.CurrentPlaylist.Count + 1).Select(x => (object)x).ToArray());
            indexComboBox.SelectedIndex = Store.CurrentPlaylist.Count;
        }

        private void specifiedIndexCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            indexComboBox.Enabled = specifiedIndexCheckBox.Checked;
            if (!specifiedIndexCheckBox.Checked)
                indexComboBox.SelectedIndex = Store.CurrentPlaylist.Count;
        }

        private void AddVideoButton_Click(object sender, EventArgs e)
        {
            videoURL = urlTB.Text;
            videoIndex = int.Parse(indexComboBox.Text);
        }

        void ChangeAddVideoButtonEnablement()
        {
            AddVideoButton.Enabled = FormUtils.isIndexValueValid(indexComboBox.Text, Store.CurrentPlaylist.Count + 1) && !String.IsNullOrEmpty(urlTB.Text);
        }
        private void indexComboBox_TextChanged(object sender, EventArgs e)
        {
            ChangeAddVideoButtonEnablement();
        }

        private void urlTB_TextChanged(object sender, EventArgs e)
        {
            ChangeAddVideoButtonEnablement();
        }
    }
}
