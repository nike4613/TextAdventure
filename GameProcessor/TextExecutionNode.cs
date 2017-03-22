using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleWindow;

namespace GameProcessor
{
    class TextExecutionNode : AChapterExecutionNode<Text>
    {
        public TextExecutionNode(Text data) : base(data)
        {
        }

        public override void Execute(WindowInterface interf, Inventory inv)
        {
            throw new NotImplementedException();
        }
    }
}
