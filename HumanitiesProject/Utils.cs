using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanitiesProject
{
    public class TwoForm<T, K>
    {
        private T tval;
        private K kval;
        private bool isK = false;

        public TwoForm(T t, K k, bool ik)
        {
            tval = t;
            kval = k;
            isK = ik;
        }

        public TwoForm(T t) : this(t, default(K), false) { }
        public TwoForm(K k) : this(default(T), k, true) { }

        public static implicit operator TwoForm<T, K>(T t)
        {
            return new TwoForm<T, K>(t);
        }
        public static implicit operator TwoForm<T, K>(K k)
        {
            return new TwoForm<T, K>(k);
        }
    }
}
