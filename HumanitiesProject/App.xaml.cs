using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ConsoleWindow;

namespace HumanitiesProject
{

    public delegate T ValueChanged<T>(string name, T old, T to) where T:class;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static App inst;

        //public static ILog log ;

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public App()
        {

            Thread.CurrentThread.Name = "UI";

            inst = this;

            string[] args = Environment.GetCommandLineArgs();

            Arguments arg = new Arguments(args);

            if (arg["console"] != null)
            {
                ConsoleManager.ShowConsoleWindow();
            }
        }

        Thread mainThread;

        private void MmainThread()
        {
            if (!WindowInterface.InitEvent.WaitOne(0))
            {
                log.Info("Waiting for a WindowInterface...");
                WindowInterface.InitEvent.WaitOne();
            }
            //WindowInterface.InitEvent.WaitOne();

            log.Info("Starting Main");
            EntryPoint.Main(Environment.GetCommandLineArgs());
            log.Debug("Main exited! Should we die?");

            log.Debug("Nah. USR4LYF");
        }

        public new void Run()
        {
            mainThread = new Thread(new ThreadStart(MmainThread));

            mainThread.Name = "Main";

            mainThread.Start();

            MainWindow = new MainWindow();

            Run(MainWindow);
        }

    }
}
