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

            log.Debug(win);

            log.Debug("WindowInterface has been initialized");
        }

        public string SetTitle(string title)
        {
            DispatcherOperation op = App.Current.Dispatcher.BeginInvoke( (dSetTitle) _SetTitle, new object[] { title } );
            op.Wait();

            return (String)op.Result;
        }

        public string GetTitle()
        {
            DispatcherOperation op = App.Current.Dispatcher.BeginInvoke((dGetTitle)_GetTitle, new object[] { });

            op.Wait();

            return (string) op.Result;
        }
        public string Title
        {
            get
            {
                DispatcherOperation op = App.Current.Dispatcher.BeginInvoke((dGetTitle)_GetTitle, new object[] { });
                op.Wait();
                return (string)op.Result;
            }
            set
            {
                DispatcherOperation op = App.Current.Dispatcher.BeginInvoke((dSetTitle)_SetTitle, new object[] { value });
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
                DispatcherOperation op = App.Current.Dispatcher.BeginInvoke((dGetBody)_GetBody, new object[] { });
                op.Wait();
                return (string)op.Result;
            }
            set
            {
                DispatcherOperation op = App.Current.Dispatcher.BeginInvoke((dSetBody)_SetBody, new object[] { value });
                op.Wait();
            }
        }
        private delegate string dGetBody();
        private string _GetBody() { return window.Body.Text; }
        private delegate void dSetBody(string s);
        private void _SetBody(string bod) { window.Body.Text = bod; }

    }
}
