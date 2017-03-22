using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleWindow;

namespace GameProcessor
{
    class RoomExecutionNode : AChapterExecutionNode<Room>
    {
        public RoomExecutionNode(Room data) : base(data)
        {
        }

        public override void Execute(WindowInterface interf, Inventory inv)
        {
            throw new NotImplementedException();
        }
    }
}
