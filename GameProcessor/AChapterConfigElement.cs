using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProcessor
{
    public abstract class AChapterConfigElement
    {
        public Chapter Chapter { get; protected internal set; }

        public string Name { get; protected internal set; }
        public string Description { get; protected internal set; }

        public abstract void SetProperty(string prop, string[] args, string value);
        public abstract void SetTextBlock(string block);

        public override string ToString()
        {
            return GetType().Name + "('" + Name + "': '" + Description + "')";
        }
    }
}
