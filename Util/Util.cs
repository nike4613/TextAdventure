using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public static class Util
    {
        public static StreamReader ToStream(this string str)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            StreamReader reader = new StreamReader(stream);

            stream.SetLength(str.Length);
            stream.Position = 0;

            writer.Write(str);
            writer.Flush();
            stream.Position = 0;

            return reader;
        }

        public static string IFormat(this string th, params object[] ps)
        {
            return string.Format(th, ps);
        }

        public static string ToReadable<T,K>(this Dictionary<T,K> dk)
        {
            var lines = dk.Select(kvp => "'" + kvp.Key.ToString() + "': " + kvp.Value.ToString());
            string s = "{" + string.Join(",", lines) + "}";
            return s;
        }
    }
}
