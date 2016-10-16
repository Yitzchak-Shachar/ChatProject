using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace CommonCL
{
    public class Connection
    {
        public event EventHandler<MessageEventArgs> GotMessageEv;
        public event EventHandler<ConnectionEventArgs> ConnectionClosedEv;
        private TcpClient TcpClnt { get; set; }
        private Stream Stream { get; set; }
        private BinaryFormatter BinFormatter;

        public Thread ListenForIncMessagesThread;
        // for the server this variable holds the remote connected user details;
        //public User RemoteUser;
        private IPAddress iPAddress;
        public IPAddress IPAddress
        {
            get { return iPAddress; }
        }
        private ushort port;
        public ushort Port
        {
            get { return port; }
        }
     //   public int ConnectionID { get; set; }

        public bool IsConnected
        {
            get
            {
                if (TcpClnt != null && TcpClnt.Connected)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Connection constructor
        /// this constructor is usually called  by the client side application
        /// it assumes that TcpClient not provided , therfor build one
        /// </summary>
        public Connection()
            : this(new TcpClient())
        {

        }

        public Connection(TcpClient tc)
        {
          //  ConnectionID = 99;
            if (tc != null)
            {
                TcpClnt = tc;
            }

            else
            {
                //print some error to logger
                throw new Exception("NullReference");
            }

            if (tc.Connected)
            {
                //Logger.Print("ctor:Connection, LocalEndPoint=" + tc.Client.LocalEndPoint.ToString());
                //Logger.Print("ctor:Connection, RemoteEndPoint=" + tc.Client.RemoteEndPoint.ToString()); 
                ValidateNStoreIPandPort(tc.Client.LocalEndPoint.ToString());

                // since this constructor assumes TcpClient is delivered on call, 
                // it now initializes the Stream variables accordingly
                // after connected , initialize strem and r\w bin.formatter or serialization objects
                Stream = TcpClnt.GetStream();
                BinFormatter = new BinaryFormatter();
            }
        }

        public void ConnectToServer(IPEndPoint EP)
        {
            if (!TcpClnt.Connected)
            {
                TcpClnt.Connect(EP);
                Logger.Print("INFO: ConnectToserver succeeded to " + EP.Address.ToString() + ":" + EP.Port);
                // after connected , initialize strem and r\w bin.formatter or serialization objects
                Stream = TcpClnt.GetStream();
                BinFormatter = new BinaryFormatter();
            }
            else
            {
                // add code for:
                // 1) throw error that connection is already active
                // or 
                // 2) disconnect old connection and reconnect to new address
            }

        }

        public void Close()
        {
            TcpClnt.Close();
        }

        public void SendMessage(ChatMessage m)
        {
            if (TcpClnt.Connected && Stream != null)
            {
                    //    Logger.Print("Debug: Serializing msg obj "+m.ToString());

                BinFormatter.Serialize(Stream, m);
            }
        }

        public void WaitForMessages()
        {
            try
            {
                while (TcpClnt.Connected)
                {
                    if (Stream != null)
                    {
                        object obj = BinFormatter.Deserialize(Stream);
                        if (obj is ChatMessage && GotMessageEv != null)
                        {
                            GotMessageEv(this, new MessageEventArgs((ChatMessage)obj));
                            //Logger.Print("got msg: " + ((Message)obj));
                        }
                        else
                        {
                            // print warning , got strange input (not Message) on incomming stream
                        }

                    }
                    else
                    {
                        // print warning , incomming stream is null cant read messages
                        Logger.Print("Warning:incomming stream is null cant read messages");
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Print("Error: Connection fail on WaitForMessages with exp.info: " + e.Message);
                //Logger.Print("INFO: stream is null="+ (Stream==null) );
                //Logger.Print("INFO: GotMessage=" + (GotMessage).ToString());

                TcpClnt.Close();
                // throw e;
                if (ConnectionClosedEv != null)
                {
                    ConnectionClosedEv(this, new ConnectionEventArgs(this));
                }
            }
        }

        public bool ValidateNStoreIPandPort(string IPToValidate, string PortToValidate)
        {
            return (IPAddress.TryParse(IPToValidate, out iPAddress) && ushort.TryParse(PortToValidate, out port));
        }

        public bool ValidateNStoreIPandPort(string EPToValidate)
        {
            string[] splitedEP = EPToValidate.Split(':');
            string ipPart = splitedEP[0];
            string portPart = splitedEP[1];
            return ValidateNStoreIPandPort(ipPart, portPart);
        }

        static public bool ValidateIPandPort(string IPToValidate, string PortToValidate)
        {
            IPAddress tempIP;
            ushort tempPort;
            return (IPAddress.TryParse(IPToValidate, out tempIP) && ushort.TryParse(PortToValidate, out tempPort));
        }

        static public  bool ValidateServerIPnPort(string ip, string port)
        {
            int chkNumber;
            if (ip.Split('.').Length == 4 && int.TryParse(port, out chkNumber))
            {
                // check port is nuber of 0:65565
                if (chkNumber > ushort.MaxValue || chkNumber < ushort.MinValue)
                    return false;
                // check serverIp isvalid ip of format x.x.x.x while x is 0:255
                foreach (var nibble in ip.Split('.'))
                {
                    chkNumber = 0;
                    int.TryParse(nibble, out chkNumber);
                    if (chkNumber > ushort.MaxValue || chkNumber < ushort.MinValue)
                        return false;

                }
                return true;
            }
            else
                return false;
        }

        static public IPEndPoint ConvertIPandPortToIPEP(string IPToValidate, string PortToValidate)
        {
            IPAddress tmpIPAdd;
            int tmpInt;
            if (IPAddress.TryParse(IPToValidate, out tmpIPAdd) && int.TryParse(PortToValidate, out tmpInt))
            {
                return new IPEndPoint(tmpIPAdd, tmpInt);
            }
            else
                return null;

        }

        // dont forget:
        // - add destroctor that do : closes stream and other objects gracefully (eg steam.close())

    }
}
