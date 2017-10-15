using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MongPipe.Core.Helpers
{
    public static class TypeExtensions
    {
        public static object GetDefaultValue(this TypeInfo t)
        {
            if (t.IsValueType)
                return Activator.CreateInstance(t.AsType());

            return null;
        }
    }

}
