using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using CommonCL;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace ServerBL
{
    public class Server
    {
        //private List<Connection> ClientsConnections { get; set; }
        public List<UserContext> ConnectedUsers { get; set; }
        private TcpListener TcpListener;
        private IPEndPoint ServerLocalIPEP;
        public bool ServerIsUp { get; set; }
        private Thread ListenToNewConnectionsThread;
        public event EventHandler<ConnectionEventArgs> NewClientConnectedEv;
        public event EventHandler<UserContextEventArgs> NewClientLoginEv;

        private int ClientIDToken;

        public void Start(string IPAddress, string Port)
        {
            ServerLocalIPEP = Connection.ConvertIPandPortToIPEP(IPAddress, Port);
            if (ServerLocalIPEP != null)
            {
                ClientIDToken = 0;
                // ClientsConnections = new List<Connection>();
                ConnectedUsers = new List<UserContext>();
                ListenToNewConnectionsThread = new Thread(ListenToIncommingConnections);
                ListenToNewConnectionsThread.CurrentUICulture = new System.Globalization.CultureInfo("en-us");
                ListenToNewConnectionsThread.IsBackground = true;
                ListenToNewConnectionsThread.Name = "ServerListensForConnections";
                ServerIsUp = true;
                ListenToNewConnectionsThread.Start();
                Logger.Print("INFO: Server is UP");

            }
            else
                Logger.Print("Error: Server cannot work with IPnPort : " + IPAddress + ":" + Port);
        }

        public void Stop()
        {
            ServerIsUp = false;
            TcpListener.Stop();
        }

        private void ListenToIncommingConnections()
        {
            try
            {
                TcpListener = new TcpListener(ServerLocalIPEP);
                TcpListener.Start();
                while (ServerIsUp)
                {

                    Connection NewConnection = new Connection(TcpListener.AcceptTcpClient());
                    UserContext NewUserContext = new UserContext() { Connection = NewConnection, ID = ++ClientIDToken };
                    ConnectedUsers.Add(NewUserContext);
                    NewUserContext.Connection.ConnectionClosedEv += OnClientConnectionClose;


                    if (NewClientConnectedEv != null)
                    {
                        NewClientConnectedEv(this, new ConnectionEventArgs(NewUserContext.Connection));
                    }
                    //Logger.Print("Server got new incomming connection from"+NewConnection.IPAddress +":"+NewConnection.Port);

                    // when new connection established (new client just connected) , 
                    // starts msg listening thread for that connection
                    if (NewUserContext.Connection.IsConnected)
                    {
                        NewUserContext.Connection.ListenForIncMessagesThread = new Thread(NewUserContext.Connection.WaitForMessages);
                        NewUserContext.Connection.ListenForIncMessagesThread.CurrentUICulture = new System.Globalization.CultureInfo("en-us");
                        NewUserContext.Connection.ListenForIncMessagesThread.IsBackground = true;
                        NewUserContext.Connection.GotMessageEv += GotMessageOnConnection;
                        NewUserContext.Connection.ListenForIncMessagesThread.Name = "ServerListenMessagesOn" + NewUserContext.ID;
                        NewUserContext.Connection.ListenForIncMessagesThread.Start();
                        Logger.Print("INFO: new connection created, connID=" + NewUserContext.ID);

                    }
                    else
                    {
                        Logger.Print("Error: couldnt start listen msgs , tcp connection is not connected");
                    }
                }

            }
            catch (Exception e)
            {
                if (ServerIsUp)
                {

                    Logger.Print("Error: Got Exception [" + e.Message + "] while ServerIsUp=true");
                    // throw e;
                }

            }
            finally
            {
                TcpListener.Stop();
                ServerIsUp = false;
            }

        }

        private void GotMessageOnConnection(object sender, MessageEventArgs e)
        {
            string msgType = e.msg.GetType().Name;
            string textToPrint = "";
            switch (msgType)
            {
                case "IdentificationMessage":
                    textToPrint = "user " + ((IdentificationMessage)e.msg).SourceUser.Name + " got connected";
                    UserContext UserContextInActiveConnectionsList = ConnectedUsers.Single(uc => uc.Connection == (Connection)sender);
                    UserContextInActiveConnectionsList.User = ((IdentificationMessage)e.msg).SourceUser;

                    IdentificationMessage retMsg = (IdentificationMessage)e.msg;
                    retMsg.Status = true;
                    ((Connection)sender).SendMessage(retMsg);
                    if (NewClientLoginEv!=null)
                    {
                        NewClientLoginEv(sender , new UserContextEventArgs(UserContextInActiveConnectionsList));
                    }
                    break;
                case "TextMessage":
                    foreach (var item in ConnectedUsers.Where(uc => uc.Connection != (Connection)sender))
                    {
                        item.Connection.SendMessage(e.msg);
                    }
                    break;

                default:
                    break;
            }
            Logger.Print("INFO: " + textToPrint);
        }

        private void OnClientConnectionClose(object sender, ConnectionEventArgs cea)
        {
            ConnectedUsers.RemoveAll(uc => uc.Connection == (Connection)sender);
            Logger.Print("Server Object got ConnectionClosedEv fired, num of users=" + ConnectedUsers.Count);
        }

    }

    public class ConnectionsActivity
    {
        public ObservableCollection<ConnectionEvent> ConnEvList;
        public event Action ConEvListUpdated;
        public ConnectionsActivity()
        {
            ConnEvList = new ObservableCollection<ConnectionEvent>();
            ConnEvList.CollectionChanged += CollectionChangedAction;
        }

        private void CollectionChangedAction(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (ConEvListUpdated != null)
            {
                ConEvListUpdated();
            }
        }


    }

    public class ConnectionEvent
    {
        public UserContext userContext;
        public DateTime timeStamp;
    }



}
