using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
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
