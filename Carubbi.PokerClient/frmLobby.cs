using System;
using System.Windows.Forms;

namespace Carubbi.PokerClient
{
    public partial class frmLobby : Form
    {
        public frmLobby()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLogin.Text))
            {
            }
        }
    }
}