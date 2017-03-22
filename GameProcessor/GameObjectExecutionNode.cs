using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleWindow;

namespace GameProcessor
{
    class GameObjectExecutionNode : AChapterExecutionNode<GameObject>
    {
        public GameObjectExecutionNode(GameObject data) : base(data)
        {
        }

        public override void Execute(WindowInterface interf, Inventory inv)
        {
            throw new NotImplementedException();
        }
    }
}
