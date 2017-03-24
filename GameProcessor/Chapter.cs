using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Util;

namespace GameProcessor
{
    public class Chapter
    {
        public Dictionary<string, Room> Rooms = new Dictionary<string, Room>();
        public Dictionary<string, GameObject> Objects = new Dictionary<string, GameObject>();
        public Dictionary<string, AChapterExecutionNode<AChapterConfigElement>> ExecNodes = new Dictionary<string, AChapterExecutionNode<AChapterConfigElement>>();
        
        private static Regex nameRx = new Regex("^(.+):\"(.+)\"$", RegexOptions.Compiled);
        public AChapterConfigElement ResolveNameReference(string name)
        {


            return null;
        }

        public override string ToString()
        {
            string s = Environment.NewLine;
            s += "Rooms: " + Rooms.ToReadable() + Environment.NewLine;
            s += "Objects: " + Objects.ToReadable() + Environment.NewLine;
            s += "ExecNodes: " + ExecNodes.ToReadable() + Environment.NewLine;

            return s;
        }
    }
}
