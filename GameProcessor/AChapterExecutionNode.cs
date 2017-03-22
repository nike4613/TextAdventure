using ConsoleWindow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProcessor
{
    public abstract class AChapterExecutionNode<T> where T : AChapterConfigElement
    {

        public Chapter Chapter { get; protected set; }

        public AChapterExecutionNode(T data)
        {
            
        }

        public abstract void Execute(WindowInterface interf, Inventory inv);

    }
}
