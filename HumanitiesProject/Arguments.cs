using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanitiesProject
{
    class Arguments : IEnumerable<string>
    {
        
        private Dictionary<TwoForm<string, int>, string> arguments = new Dictionary<TwoForm<string, int>, string>();
        private int unordered = 0;

        public Arguments(string[] args)
        {
            arguments = new Dictionary<TwoForm<string, int>, string>();

            int incv = 0;

            for (int index = 1; index < args.Length; index++)
            {
                string arg = args[index];
                if (arg.StartsWith("-"))
                {
                    arg = arg.Substring(1);
                    if (index + 1 < args.Length)
                    {
                        arguments.Add(arg, args[++index]);
                    }
                    else
                    {
                        arguments.Add(arg, "");
                    }
                }
                else
                {
                    arguments.Add(incv++, arg);
                }
            }

            unordered = incv;
        }

        public string this[TwoForm<string, int> k]
        {
            get
            {
                string r;
                try
                {
                    r = arguments[k];
                }
                catch (KeyNotFoundException)
                {
                    r = null;
                }

                return r;
            }
        }

        public int Length
        {
            get
            {
                return unordered;
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
                yield return this[i];
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
