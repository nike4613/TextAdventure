using log4net;
using System;
using System.Reflection;
using System.Threading;

namespace HumanitiesProject
{
    public class EntryPoint
    {

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static WindowInterface window;

        public static void Main(string[] v)
        {
            log.Debug("In Main");

            window = App.WindowInterface;

            log.Debug("Setting title");
            window.Title = "HOOOOO BOY";
            log.Debug("Title Set");

            log.Debug("Setting body");
            window.Body = "hErE wE gO";
            log.Debug("Body Set");

        }
    }
}