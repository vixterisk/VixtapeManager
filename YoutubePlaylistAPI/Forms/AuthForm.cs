using System;
using System.Windows.Forms;

namespace YoutubePlaylistAPI
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
            AuthOkayButton.Enabled = false;
        }

        private async void signInButton_Click(object sender, EventArgs e)
        {
            try
            {
                await Store.LoadUserPlaylistsAsync();
                playlistCB.DataSource = Store.UsersPlaylist;
                AuthOkayButton.Enabled = true;
                signInButton.Enabled = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private async void AuthOkayButton_Click(object sender, EventArgs e)
        {
            if (Store.UsersPlaylist == null)
                return;
            else
            {
                try
                {
                    var PlaylistModel = (PlaylistModel)playlistCB.SelectedItem;
                    await Store.LoadCurrentPlaylistVideosAsync(PlaylistModel);
                    DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void playlistCB_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = e.ListItem.ToString();
        }
    }
}
