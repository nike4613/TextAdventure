using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProcessor
{
    class Text : AChapterConfigElement
    {
        public override void ProcessObjectRefs()
        {
            throw new NotImplementedException();
        }

        public override void SetProperty(string prop, string[] args, string value)
        {
            if (prop == "")
            {
                Name = args[0];
            }
        }

        public override void SetTextBlock(string block)
        {
            if (block.Length > 5) Description = block;
        }
    }
}
