﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Lsj.Util.Reflection
{
    public static class ReflectionHelper
    {
        public static FieldInfo[] GetAllNonPublicField(this Type type) => type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        public static T GetAttribute<T>(this MemberInfo type)
        {
            if (typeof(T).IsAssignableFrom(typeof(Attribute)))
            {
                var x = type.GetCustomAttributes(typeof(T), true);
                return x.Length > 0 ? (T)x[0] : default(T);

            }
            else
            {
                Log.Log.Default.Error(typeof(T).Name+" is not a Attribute");
                return default(T);
            }
        }
    }
}
