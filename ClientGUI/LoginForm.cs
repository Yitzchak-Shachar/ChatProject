using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonCL;


namespace ClientGUI
{
    public partial class LoginForm : Form
    {
        public User UserDetails;
        public string ServerIP;
        public string ServerPort;
        public LoginForm()
        {
            InitializeComponent();
            UserDetails = new User() { Color = new Color() };
        }

        private void ColorBtn_Click(object sender, EventArgs e)
        {
            colorChkbx.BackColor = UserDetails.Color;
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                UserDetails.Color = colorDialog1.Color;
                colorChkbx.BackColor = UserDetails.Color;
            }

        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(serverIPTxtbx.Text) || !Connection.ValidateServerIPnPort(serverIPTxtbx.Text, serverPortTxtbx.Text))
            {
                MessageBox.Show("Please enter a valid server IP and port");
                return;
            }
            else
            {
                ServerIP = serverIPTxtbx.Text;
                ServerPort = serverPortTxtbx.Text;
            }
                if (string.IsNullOrWhiteSpace(nickNameTxtbx.Text))
            {
                MessageBox.Show("Please enter Nickname and choose color");
                return;
            }
            else
            {
                UserDetails.Name = nickNameTxtbx.Text;
            }


            if (UserDetails.Color == null)
            {
                MessageBox.Show("Please choose color");
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();

        }
       
    }
}
