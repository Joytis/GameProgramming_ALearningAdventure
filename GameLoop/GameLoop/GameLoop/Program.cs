using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GameLoop
{
    static class Program
    {

        //Instantiates Fastloop
        static FastLoop _fastLoop = new FastLoop(GameLoop);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }

        static void GameLoop(double elapsedTime)
        {
            // Game Code goes here
            //input
            //process/
            //render
            System.Console.WriteLine("Loop");
        }
    }
}
