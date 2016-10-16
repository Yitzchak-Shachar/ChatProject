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
using ServerBL;
namespace ServerGUI
{
    public partial class SrvMainForm : Form
    {
        Server s;
        public ConnectionsActivity ServerConnectionsActivities;
        BindingSource ConnActDVGbs = new BindingSource();

        StartServerForm sf;

        public SrvMainForm()
        {
            InitializeComponent();
            stopToolStripMenuItem.Enabled = false;
            connActivitiesDVG.Columns.Add("userContext", "userContext");
            connActivitiesDVG.Columns.Add("timeStamp", "timeStamp");

            //// remove before flight
            startToolStripMenuItem_Click(this, new EventArgs());


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopToolStripMenuItem_Click(sender, e);
            Close();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //// enable before flight

            //////sf = new StartServerForm();
            //////sf.ShowDialog();
            //////if (sf.DialogResult != System.Windows.Forms.DialogResult.OK)
            //////{
            //////    return;
            //////}

            s = new Server();
            ServerConnectionsActivities = new ConnectionsActivity();
            ServerConnectionsActivities.ConEvListUpdated += ServerConnectionsActivities_ConEvListUpdated;

            s.NewClientLoginEv += s_NewClientLoginEv;    // += s_NewClientConnectedEv; //;delegate(object o, ConnectionEventArgs cea) { Logger.Print("INFO: Server got new connection from :" + cea.con.IPAddress + ":" + cea.con.Port); };



            s.Start("127.0.0.1", "9000");
            stopToolStripMenuItem.Enabled = true;
            startToolStripMenuItem.Enabled = false;
        }

        void s_NewClientLoginEv(object sender, UserContextEventArgs e)
        {
           if (InvokeRequired)
            {
                Invoke((Action)delegate { s_NewClientLoginEv(sender, e); });
            }
            else
            {
                 ServerConnectionsActivities.ConnEvList.Add(new ConnectionEvent() { userContext = e.context, timeStamp = DateTime.Now });
            ConnActDVGbs.DataSource = ServerConnectionsActivities.ConnEvList;//.ToList<ServerBL.ConnectionEvent>();

           // DataTable t = ConnActDVGbs.DataSource;
            connActivitiesDVG.DataSource = ConnActDVGbs;// ServerConnectionsActivities.ConnEvList; // 
            connActivitiesDVG.Refresh();
            connActivitiesDVG.Show();
            }
        }



        void ServerConnectionsActivities_ConEvListUpdated()
        {
            //  connectionsActivityBindingSource.Add();
            //  ActiveConnectionsDGV.DataSource = ServerConnectionsActivities.ConnEvList;

        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stopToolStripMenuItem.Enabled = false;
            startToolStripMenuItem.Enabled = true;
            if (s != null)
            {
                s.Stop();

            }
        }
    }
}
