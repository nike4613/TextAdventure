using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace HumanitiesProject
{
    public delegate string dSetTitle(string newTitle);

    public class WindowInterface
    {

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private MainWindow window;

        public WindowInterface(MainWindow win)
        {
            window = win;

            log.Debug("WindowInterface has been initialized");
        }

        private DispatcherOperation setTitleDop;
        /**
         * Sets the title of the console window. Note, this will return before the action can complete.
         * Returns the old title.
         */
        public string SetTitle(string title)
        {
            string old = GetTitle();

            DispatcherOperation op = System.Windows.Application.Current.Dispatcher.BeginInvoke( (dSetTitle) _SetTitle, new object[] { title } );
            setTitleDop = op;

            return old;
        }

        public string SetTitleSync(string title)
        {
            SetTitle(title);

            setTitleDop.Wait();

            return (string) setTitleDop.Result;
        }

        /**
         * DO NOT USE 
         */
        private delegate string dSetTitle(string newTitle);
        private string _SetTitle(string newTitle)
        {
            string old = GetTitle();
            window.TitleBlock.Text = newTitle;
            return old;
        }

        public string GetTitle()
        {
            return window.TitleBlock.Text;
        }

    }
}
