using System;
using System.Windows.Forms;

namespace YoutubePlaylistAPI
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private async void signInButton_Click(object sender, EventArgs e)
        {
            await Store.LoadUserPlaylistsAsync();
            playlistCB.DataSource = Store.UsersPlaylist;
        }

        private async void AuthOkayButton_Click(object sender, EventArgs e)
        {
            if (Store.UsersPlaylist == null)
                return;
            else
            {
                var PlaylistModel = (PlaylistModel)playlistCB.SelectedItem;
                Store.CurrentPlaylist = PlaylistModel;
                await Store.LoadCurrentPlaylistVideosAsync();
                DialogResult = DialogResult.OK;
            }
        }
    }
}
