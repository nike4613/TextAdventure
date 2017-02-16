using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanitiesProject
{
    class Arguments : DynamicObject
    {
        
        private Dictionary<TwoForm<string, int>, string> arguments = new Dictionary<TwoForm<string, int>, string>();
        private int unordered = 0;

        public Arguments(string[] args)
        {
            int incv = 0;

            for (int index = 1; index < args.Length; index += 1)
            {
                string arg = args[index];//.Replace("-", "");
                if (arg.StartsWith("-"))
                {
                    arg = arg.Substring(1);
                    if (index + 1 < args.Length)
                        arguments.Add(arg, args[++index]);
                    else
                        arguments.Add(arg, "");
                }
                else
                {
                    arguments.Add(incv++, arg);
                }
            }

            unordered = incv;

        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            return false;
        }
        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
        {
            return false;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string name = binder.Name;

            return tryGetMemberImpl(name, out result);
        }
        private bool tryGetMemberImpl(string name, out object result)
        {
            if (name == "Length")
            {
                result = unordered;
                return true;
            }

            string outp = null;
            if (arguments.ContainsKey(name)) arguments.TryGetValue(name, out outp);

            result = outp;

            return true;
        }
        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            if (indexes.Length > 1) throw new IndexOutOfRangeException("Only one index expected!");
            object index = indexes[0];
            Type ityp = index.GetType();

            if (ityp == "".GetType()) return tryGetMemberImpl(index.ToString(), out result);

            if (ityp != (42).GetType()) throw new IndexOutOfRangeException("Index must be string or int!");

            int idx = (int)index;

            if (idx >= unordered) throw new IndexOutOfRangeException("Index is out of range!");

            string res;
            bool oval = arguments.TryGetValue(idx, out res);
            result = res;
            return oval;
        }

    }
}
