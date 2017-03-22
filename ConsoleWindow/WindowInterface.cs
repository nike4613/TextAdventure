using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ConsoleWindow
{
    public delegate string dSetTitle(string newTitle);

    public class WindowInterface
    {

        private string lel = log4netInit.lel;

        public static WindowInterface inst;

        public static AutoResetEvent InitEvent = new AutoResetEvent(false);

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private MainWindow window;

        public WindowInterface(MainWindow win)
        {
            window = win;

            log.Debug(win);

            log.Debug("WindowInterface has been initialized");

            inst = this;
            InitEvent.Set();
        }

        public string Title
        {
            get
            {
                DispatcherOperation op = System.Windows.Application.Current.Dispatcher.BeginInvoke((dGetTitle)_GetTitle, new object[] { });
                op.Wait();
                return (string)op.Result;
            }
            set
            {
                DispatcherOperation op = System.Windows.Application.Current.Dispatcher.BeginInvoke((dSetTitle)_SetTitle, new object[] { value });
                op.Wait();
            }
        }
        private delegate string dGetTitle();
        private string _GetTitle() { return window.TitleBlock.Text; }
        private delegate void dSetTitle(string newTitle);
        private void _SetTitle(string newTitle) { window.TitleBlock.Text = newTitle; }

        public string Body
        {
            get
            {
                DispatcherOperation op = System.Windows.Application.Current.Dispatcher.BeginInvoke((dGetBody)_GetBody, new object[] { });
                op.Wait();
                return (string)op.Result;
            }
            set
            {
                DispatcherOperation op = System.Windows.Application.Current.Dispatcher.BeginInvoke((dSetBody)_SetBody, new object[] { value });
                op.Wait();
            }
        }
        private delegate string dGetBody();
        private string _GetBody() { return window.Body.Text; }
        private delegate void dSetBody(string s);
        private void _SetBody(string bod) { window.Body.Text = bod; }

    }
}
