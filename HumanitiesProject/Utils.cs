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

        public override bool Equals(object obj)
        {
            if (obj.GetType() == GetType())
                return Equals((TwoForm<T, K>)obj);
            return false;
        }

        public bool Equals(TwoForm<T, K> b)
        {
            return isK == b.isK && ((isK && kval.Equals(b.kval)) || (!isK && tval.Equals(b.tval)));
        }

        public override int GetHashCode()
        {
            return isK ? kval.GetHashCode() : tval.GetHashCode();
        }
        public override string ToString()
        {
            return "TwoForm{" + (isK ? kval.ToString() : tval.ToString()) + "}";
        }
    }

}
