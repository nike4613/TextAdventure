using log4net;
using System;
using System.Reflection;

namespace HumanitiesProject
{
    public class EntryPoint
    {

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Main(string[] v)
        {
            log.Debug("In Main");
        }
    }
}