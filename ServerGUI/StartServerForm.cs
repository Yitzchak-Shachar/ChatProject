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

namespace ServerGUI
{
    public partial class StartServerForm : Form
    {
        public string ServerIP;
        public string ServerPort;
        public StartServerForm()
        {
            InitializeComponent();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {

            if (Connection.ValidateServerIPnPort(serverIPTxtbx.Text, serverPortTxtbx.Text))
            {
                ServerIP = serverIPTxtbx.Text;
                ServerPort = serverPortTxtbx.Text;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please enter a valid server IP and port");
            }
        }
    }
}
