using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonCL
{
    public class MessageEventArgs : EventArgs
    {
        public readonly ChatMessage msg;
        public string MessageTypeStr;
        public string Text;
        public MessageEventArgs(ChatMessage m)
        {
            msg = m;
            MessageTypeStr = m.GetType().Name;
            if (m is TextMessage)
            {
                Text = ((TextMessage)m).Text;
            }
            //Logger.Print("INFO: MessageEventArgs was created with msg type=" + MessageTypeStr + "    " + m.GetType().Name);
        }
    }
}
