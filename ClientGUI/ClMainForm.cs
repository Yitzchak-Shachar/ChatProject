using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientBL;
using CommonCL;

namespace ClientGUI
{
    public partial class ClientGUIMainForm : Form
    {
        Client Client;
        public ClientGUIMainForm()
        {
            InitializeComponent();
            connectToServerToolStripMenuItem.Enabled = true;
            disconnectToolStripMenuItem.Enabled = false;
            SendBtn.Enabled = false;
            userInputTxtbx.Enabled = false;
        }

        private void connectToServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LoginForm lf = new LoginForm();
                lf.ShowDialog();
                if (lf.DialogResult != System.Windows.Forms.DialogResult.OK)
                    return;
                Client = new Client(lf.UserDetails);
                Client.ConnectToServer(lf.ServerIP,lf.ServerPort);
                richTextBox1.AppendText("Connected to server\n");
                Client.ClientGotMessageEv += ((s, o) => { AddTextToRichTextBox(o.msg.SourceUser.Name + ": " +  o.Text + "\n", o.msg.SourceUser.Color); });
                connectToServerToolStripMenuItem.Enabled = false;
                disconnectToolStripMenuItem.Enabled = true;
                SendBtn.Enabled = true;
                userInputTxtbx.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail connecting server\n" + ex.Message);
            }
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(userInputTxtbx.Text))
            {
                Client.SendMsg(new CommonCL.TextMessage() { SourceUser = Client.UserDetails, Text = userInputTxtbx.Text });
                AddTextToRichTextBox(Client.UserDetails.Name+": " + userInputTxtbx.Text + "\n",Client.UserDetails.Color );
                userInputTxtbx.Text = "";
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Client != null)
            {
                Client.DisconnectFromServer();

            }
            richTextBox1.AppendText("Disconnected from server\n");
            connectToServerToolStripMenuItem.Enabled = true;
            disconnectToolStripMenuItem.Enabled = false;
            SendBtn.Enabled = false;
            userInputTxtbx.Enabled = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disconnectToolStripMenuItem_Click(sender, e);
            this.Close();
        }

        private void AddTextToRichTextBox(string txt, Color c)
        {
            int curPos = richTextBox1.TextLength;
            Color curColor = richTextBox1.ForeColor;
            richTextBox1.AppendText(txt);
            richTextBox1.Select(curPos,txt.Length);
            richTextBox1.SelectionColor = c;
            richTextBox1.ScrollToCaret();
            richTextBox1.Select(richTextBox1.TextLength,0);
            richTextBox1.ForeColor = curColor;



        }

    }
}
