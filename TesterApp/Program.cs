using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCL;
using ServerBL;


namespace ServerTesterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-us");

            Logger.Print("**** welcome to ChatServer project tester ****");
            //ConsoleKeyInfo inp = Console.ReadKey();

            Server s;
            s = new Server();
            s.NewClientConnectedEv += delegate(object o, ConnectionEventArgs cea) { Logger.Print("INFO: Server got new connection from :" + cea.con.IPAddress + ":" + cea.con.Port); };

            s.Start("127.0.0.1", "9000");
            //Console.ReadLine();
            //Console.ReadLine();



            Logger.Print("INFO: ***Server is Running***");
            Console.ReadLine();




            //do
            //{
            //    // Console.WriteLine("got key:"+inp.Key.ToString());
            //    switch (inp.Key)
            //    {
            //        case ConsoleKey.Escape:
            //            Console.WriteLine("Exiting...");
            //            break;
            //        case ConsoleKey.C :
            //            Console.WriteLine("create client");

            //            break;

            //    }


            //    inp = Console.ReadKey();
            //} while (inp.Key != ConsoleKey.Escape);


        }
    }
}
