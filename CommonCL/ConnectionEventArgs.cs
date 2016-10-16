using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonCL
{
    public class ConnectionEventArgs : EventArgs
    {
        public Connection con;
        public ConnectionEventArgs(Connection c)
        {
            con = c;
        }
    }
}
