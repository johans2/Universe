using System;
using System.Reflection;

namespace Universe.Test
{
    public static class TestHelper
    {
        public static Object getField(object instance, String name)
        {
            Type t = instance.GetType();

            FieldInfo f = t.GetField(name, BindingFlags.Instance
                                   | BindingFlags.NonPublic
                                   | BindingFlags.Public);

            return f.GetValue(instance);
        }

        public static Object executeMethod(object instance, String name, params object[] paramList)
        {
            Type t = instance.GetType();

            Type[] paramTypes = new Type[paramList.Length];

            for (int i = 0; i < paramList.Length; i++)
                paramTypes[i] = paramList[i].GetType();

            MethodInfo m = t.GetMethod(name, BindingFlags.Instance
                                     | BindingFlags.NonPublic
                                     | BindingFlags.Public,
                                    null,
                                    paramTypes,
                                    null);

            return m.Invoke(instance, paramList);
        }

    }
}
