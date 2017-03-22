using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWindow
{
    class ConsoleOutput : log4net.Appender.ColoredConsoleAppender
    {

        private string lel = log4netInit.lel;

        private class LevCol : LevelColors
        {
            public LevCol(LevelColors lc)
            {
                ForeColor = lc.ForeColor;
                BackColor = lc.BackColor;
                ActivateOptions();
            }
            
            private ushort m_combinedColor = 0;
            /// <summary>
            /// Initialize the options for the object
            /// </summary>
            /// <remarks>
            /// <para>
            /// Combine the <see cref="ForeColor"/> and <see cref="BackColor"/> together.
            /// </para>
            /// </remarks>
            public override void ActivateOptions()
            {
                base.ActivateOptions();
                m_combinedColor = (ushort)((int)ForeColor + (((int)BackColor) << 4));
            }

            /// <summary>
            /// The combined <see cref="ForeColor"/> and <see cref="BackColor"/> suitable for 
            /// setting the console color.
            /// </summary>
            internal ushort CombinedColor
            {
                get { return m_combinedColor; }
            }
        }

        private Dictionary<Level, LevelColors> maps = new Dictionary<Level, LevelColors>();

        public new void AddMapping(LevelColors mapping)
        {

            maps.Add(mapping.Level,mapping);

        }

        protected override void Append(LoggingEvent evt)
        {

            LevelColors _;
            LevCol lcol;

            bool b = maps.TryGetValue(evt.Level, out _);
            
            ushort colorInfo = (ushort)Colors.White;

            IntPtr con = ConsoleManager.GetConsoleWindow();

            ConsoleManager.ConsoleBufferInfo bufferInfo;
            ConsoleManager.GetConsoleScreenBufferInfo(con, out bufferInfo);

            if (b)
            {
                lcol = new LevCol(_);
                colorInfo = lcol.CombinedColor;
            }

            ConsoleManager.SetConsoleTextAttribute(con, colorInfo);

            Layout.Format(Console.Out, evt);

            ConsoleManager.SetConsoleTextAttribute(con, bufferInfo.wAttributes);

            base.Append(evt);

        }

    }
}
