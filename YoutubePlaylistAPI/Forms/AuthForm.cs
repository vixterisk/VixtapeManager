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
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private async void signInButton_Click(object sender, EventArgs e)
        {
            var controller = new YoutubeAPIController();
            await controller.Run();
            playlistCB.DataSource = Store.UsersPlaylist;
        }
    }
}
