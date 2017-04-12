using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Net.NetworkInformation;


namespace HelloWord
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Title = ("This my first C# Applcation");
            Console.WriteLine("hello world!");


            //This starts threads (Can be run at the same time as other code)
            Thread firstThread = new Thread(new ThreadStart(FirstThread));
            Thread secondThread = new Thread(new ThreadStart(SecondThread));

            firstThread.Start();
            secondThread.Start();
        }

        
        /// <summary>
        /// This is the FirstThread Function which contains all the code for the firstThread
        /// </summary>
        public static void FirstThread()
        {

            while (true)
            {
                Console.WriteLine("This is the first thread");
                Thread.Sleep(1000);
            }

        }


        /// <summary>
        /// Exmaple of another thread running along side main thread
        /// </summary>
        public static void SecondThread()
        {
            int counter = 0;

            while (counter != 11)
            {
                Console.WriteLine("This is the second thread");
                Thread.Sleep(1000);
                counter++;
            }
        }
    }
}
