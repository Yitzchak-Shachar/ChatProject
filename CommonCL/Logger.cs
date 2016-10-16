using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCL
{
    public static class Logger
    {
        public static void Print(string txt)
        {
            Console.WriteLine("<*>"+txt);
        }
    }

}
