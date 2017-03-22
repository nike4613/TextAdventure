using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Util;

namespace GameProcessor
{
    public class GameObject : AChapterConfigElement
    {

        public GameObject()
        {
            Inspectable = false;
            Useable = false;
        }

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected internal Dictionary<string, string> subitems_unproc = new Dictionary<string, string>();
        protected internal Dictionary<string, GameObject> subitems = new Dictionary<string, GameObject>();
        public Dictionary<string, GameObject> SubItems
        {
            get
            {
                return subitems;
            }
        }

        protected internal Dictionary<string, string> aliases = new Dictionary<string, string>();

        public bool Inspectable { get; protected internal set; }
        public bool Useable { get; protected internal set; }

        private static Regex itemRx = new Regex("\"(.+)\"x(\\d+)",
          RegexOptions.Compiled );
        public string ItemName { get; protected internal set; }
        public int ItemCount { get; protected internal set; }

        public string DoorTarget { get; protected internal set; }

        public override void SetProperty(string prop, string[] args, string value)
        {
            //log.DebugFormat("propn: '{0}', value: '{1}', args: '{2}'", prop, value, string.Join("','", args));

            switch (prop) {
                case "":
                    {
                        Name = args[0];
                        Chapter.Objects.Add(Name, this);
                    }
                    break;
                case "sub":
                    {
                        foreach (string s in args)
                        {
                            subitems_unproc.Add(s, value);
                        }
                    }
                    break;
                case "alias":
                    {
                        foreach (string s in args)
                        {
                            aliases.Add(s, value.Trim(new char[] { '"', ' ' }));
                        }
                    }
                    break;
                case "inspectable":
                    {
                        Inspectable = true;
                    }
                    break;
                case "useable":
                    {
                        Useable = true;
                    }
                    break;
                case "door":
                    {
                        DoorTarget = value;
                    }
                    break;
                case "item":
                    {
                        Match m = itemRx.Match(value);
                        if (m.Groups.Count != 3)
                        {
                            throw new ArgumentException("The value for an item definition must match {0}".IFormat(itemRx.ToString()));
                        }

                        ItemName = m.Groups[1].Value;
                        ItemCount = int.Parse(m.Groups[2].Value);
                    }
                    break;
            }
        }

        public override void SetTextBlock(string block)
        {
            if (block.Length > 5) Description = block;
        }
    }
}
