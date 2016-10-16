using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CommonCL
{
    [Serializable]
    public class ChatMessage
    {
                public User SourceUser { get; set; }

    }

    [Serializable]
    public class TextMessage :ChatMessage
    {
        public string Text { get; set; }
   }

    //[Serializable]
    //public class ClientMessage : TextMessage
    //{

    //}
    //[Serializable]
    //public class ServerMessage : TextMessage
    //{
    //}

    [Serializable]
    public class IdentificationMessage : ChatMessage
    {
        public bool Status { get; set; } // Registration status
        public IdentificationMessage(User user)
        {
            SourceUser = user;
            Status = false; 
        }

    }

}
