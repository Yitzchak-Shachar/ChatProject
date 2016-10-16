
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCL;
using ClientBL;


namespace ClientTesterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-us");

            Logger.Print("**** welcome to ChatClient project tester ****");
            //ConsoleKeyInfo inp = Console.ReadKey();
            Client c;
            //Client c1;
            Logger.Print("\t\tpress key to connect to server");
            Console.ReadLine();
            string randID = System.DateTime.Now.Ticks.ToString();
            c = new Client(new User() { Name = "KUKU_" + randID.Substring(Math.Max(0, randID.Length - 4)) });
            c.ConnectToServer("127.0.0.1", "9000");

            Logger.Print("\t\tpress key to send msg");
            Console.ReadLine();
            c.SendMsg(new TextMessage() { Text = "and that is my txt1" });
            //c1 = new Client(new User() { Name = "MUMU"});
            //c1.ConnectToServer("127.0.0.1", "9000");
            //System.Threading.Thread.Sleep(2000);
            //c1.SendMsg(new ClientMessage() { Text = "and that is my txt2" });

            Logger.Print("\t\tpress key to Disconnect from server");
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
