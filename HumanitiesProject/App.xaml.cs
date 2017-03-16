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

        public static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public App()
        {
            
            inst = this;

            string[] args = Environment.GetCommandLineArgs();

            Arguments arg = new Arguments(args);

            if (arg["console"] != null)
            {
                ConsoleManager.ShowConsoleWindow();
            }

            WindowChanged += winCh;
            WindowInterfaceChanged += retNul;
        }

        Thread mainThread;

        AutoResetEvent winInterfE = new AutoResetEvent(false);

        private void MmainThread()
        {
            if (!winInterfE.WaitOne(0))
            {
                log.Info("Waiting for a WindowInterface...");
                winInterfE.WaitOne();
            }

            log.Info("Starting Main");
            EntryPoint.Main(Environment.GetCommandLineArgs());
            log.Debug("Main exited! Should we die?");

            log.Debug("Nah. USR4LYF");
        }

        public new void Run()
        {
            mainThread = new Thread(new ThreadStart(MmainThread));

            WindowInterfaceChanged += (string p, WindowInterface o, WindowInterface n) =>
            {
                winInterfE.Set();

                return null;
            };

            mainThread.Start();
            base.Run();
        }

        private MainWindow winCh(string s, MainWindow m, MainWindow w)
        {
            WindowInterface = new WindowInterface(Window);

            return null;
        }

        private T retNul<T>(string s, T m, T w) where T:class
        {
            return null;
        }

        private static MainWindow _window;
        public static ValueChanged<MainWindow> WindowChanged; 
        public static MainWindow Window
        {
            get
            {
                return _window;
            }
            set
            {
                MainWindow mwn = WindowChanged.Invoke("Window", _window, value);
                if (mwn != null) value = mwn;
                _window = value;
            }
        }

        private static WindowInterface _winInterf;
        public static ValueChanged<WindowInterface> WindowInterfaceChanged;
        public static WindowInterface WindowInterface
        {
            get
            {
                return _winInterf;
            }
            set
            {
                WindowInterface mwn = WindowInterfaceChanged.Invoke("WindowInterface", _winInterf, value);
                if (mwn != null) value = mwn;
                _winInterf = value;
            }
        }

    }
}
