using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using CommonCL;

namespace ClientBL
{
    public class Client
    {
        public User UserDetails { get; set; }
        private bool IsUserApproved = false; // this field indicated if the server confirmed the client IDmessage and updated the client ID
        private Connection Connection { get; set; }
        public event EventHandler<MessageEventArgs> ClientGotMessageEv;

        public void SendMsg(ChatMessage m)
        {
            if (m.SourceUser==null)
            {
                m.SourceUser = UserDetails;
            }
            if ((m is IdentificationMessage )|| IsUserApproved)
            {
                Connection.SendMessage(m);
            }
            else
            {              
                Logger.Print("cannot sendmsg  ,IsUserApproved=" + IsUserApproved);
            //enque or drop msg?
            }
        }

        public Client(User u)
        {
            UserDetails = u;
        }

        public void ConnectToServer(string ServerIP, string Port)
        {
            if (Connection.ValidateIPandPort(ServerIP, Port))
            {
                Connection = new Connection();
                Connection.ConnectionClosedEv+= ConnectionClosed;
                Connection.ConnectToServer(Connection.ConvertIPandPortToIPEP(ServerIP, Port));

                // when new connection established (new client just connected) , 
                // starts msg listening thread for that connection
                if (Connection.IsConnected)
                {
                    Connection.ListenForIncMessagesThread = new Thread(Connection.WaitForMessages);
                    Connection.ListenForIncMessagesThread.CurrentUICulture = new System.Globalization.CultureInfo("en-us");
                    Connection.ListenForIncMessagesThread.IsBackground = true;
              //      Connection.ListenForIncMessagesThread.Name = "ClientListenMessagesOn" + Connection.ConnectionID;
                  //  Connection.GotMessageEv += IsUserApproved;// delegate(object o, MessageEventArgs mea) { Logger.Print("INFO: client ID " + Connection.ConnectionID + " got msg: " + mea.Text + ",of type "+mea.MessageTypeStr); };
                    Connection.GotMessageEv += GotMessageOnConnection;
                    Connection.ListenForIncMessagesThread.Start();

                }
                else
                {
                    Logger.Print("Warning: couldnt start listen msgs , tcp connection is not connected");
                }
              //  Connection.GotMessageEv += GetClientIDFromServer;
                SendMsg(new IdentificationMessage(UserDetails));
            }
            else
            {
                Logger.Print("Error: Bad IP addres , failed to create Client object");
            }


        }
        public void DisconnectFromServer()
        {
            Connection.Close();
        }

        private void ConnectionClosed(object sender, ConnectionEventArgs e)
        {
         Logger.Print("Client Object got ConnectionClosedEv fired");
        }

        private void GotMessageOnConnection(object sender, MessageEventArgs e)
        {
            string msgType = e.msg.GetType().Name;
            string textToPrint = "";
            switch (msgType)
            {
                case "IdentificationMessage":
                    IdentificationMessage m = (e.msg as IdentificationMessage);
                    if ( m.SourceUser != null &&  m.SourceUser.Name == UserDetails.Name &&  m.Status )
                    {
                        IsUserApproved = true;
                        textToPrint = "Info: User connection approved by server";

                    }
        
                    break;
                case "TextMessage":
                    textToPrint="got text from user#" +((TextMessage)e.msg).SourceUser.Name +" saying "+ ((TextMessage)e.msg).Text;
                    if (ClientGotMessageEv!=null)
                    {
                        ClientGotMessageEv(this, e);
                    }
                    break;

                //case "ServerMessage":
                //    textToPrint = "client got msg from server text=" + ((TextMessage)e.msg).Text + " src is:" + ((Connection)sender).ConnectionID;

                //    break;
                //default:
                //    break;
            }
            Logger.Print("INFO: " + textToPrint);
        }
    }
}
