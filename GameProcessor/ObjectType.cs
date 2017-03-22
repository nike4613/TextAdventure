using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProcessor
{
    class ClassTagAttribute : Attribute
    {
        public Type Type { get; private set; }

        public ClassTagAttribute(Type t)
        {
            Type = t;
        }
    }

    public enum ObjectType : byte
    {
        [ClassTag(typeof(Text))]
        [Description("text")]
        Text,
        [ClassTag(typeof(Room))]
        [Description("room")]
        Room,
        [ClassTag(typeof(GameObject))]
        [Description("object")]
        Object,

        [ClassTag(typeof(Type))]
        [Description(":::::")]
        FromName
    }

    public static class ObjectTypeMethods
    {
        private static Dictionary<string, ObjectType> cache = new Dictionary<string, ObjectType>();
        private static bool init = false;

        public static string GetName(this ObjectType t)
        {
            var type = t.GetType();
            var memInfo = type.GetMember(t.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            var description = ((DescriptionAttribute)attributes[0]).Description;

            return description;
        }

        public static Type GetReprType(this ObjectType t)
        {
            var type = t.GetType();
            var memInfo = type.GetMember(t.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(ClassTagAttribute), false);
            var description = ((ClassTagAttribute)attributes[0]).Type;

            return description;
        }

        static ObjectTypeMethods()
        {
            var mebInf = typeof(ObjectType).GetMember("FromName")[0];
        }

        public static ObjectType FromName(string n)
        {
            if (!init)
            {
                foreach (ObjectType ev in Enum.GetValues(typeof(ObjectType)))
                {
                    cache.Add(ev.GetName(), ev);
                }

                init = true;
            }

            ObjectType t = new ObjectType();
            cache.TryGetValue(n, out t);

            return t;
        }
    }
}
