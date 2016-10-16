using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerBL
{
    public class UserContextEventArgs
    {
        public UserContext context;
        public UserContextEventArgs(UserContext ucontext)
        {
            context = ucontext;
        }
    }
}
