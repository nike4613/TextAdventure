using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProcessor
{
    public class Room : AChapterConfigElement
    {

        private bool readDesc = false;

        protected internal Dictionary<string, string> subitems_unproc = new Dictionary<string, string>();
        protected internal Dictionary<string, GameObject> subitems = new Dictionary<string, GameObject>();
        public Dictionary<string, GameObject> SubItems
        {
            get
            {
                return subitems;
            }
        }

        protected internal string desc_identifier = "";

        public override void SetProperty(string prop, string[] args, string value)
        {
            switch (prop) {
                case "":
                    {
                        Name = args[0];
                        Chapter.Rooms.Add(Name, this);
                    }
                    break;
                case "description":
                    {
                        if (value == "")
                            readDesc = true;
                        else
                            desc_identifier = value;
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
            }
        }

        public override void SetTextBlock(string block)
        {
            if (readDesc)
            {
                Description = block;
                readDesc = false;
            }
        }

        public override void ProcessObjectRefs()
        {
            throw new NotImplementedException();
        }
    }
}
