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
            await Store.LoadUserPlaylistsAsync();
            playlistCB.DataSource = Store.UsersPlaylist;
            AuthOkayButton.Enabled = true;
        }

        private async void AuthOkayButton_Click(object sender, EventArgs e)
        {
            if (Store.UsersPlaylist == null)
                return;
            else
            {
                var PlaylistModel = (PlaylistModel)playlistCB.SelectedItem;
                await Store.LoadCurrentPlaylistVideosAsync(PlaylistModel);
                DialogResult = DialogResult.OK;
            }
        }

        private void playlistCB_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = e.ListItem.ToString();
        }
    }
}
