using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LD.Utilities.ExtensionMethods
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="ignoredFields"></param>
        public static void TrimAll<T>(this T entity, params string[] ignoredFields)
        {
            Dictionary<Type, PropertyInfo[]> trimProperties = new Dictionary<Type, PropertyInfo[]>();
            if (!trimProperties.TryGetValue(typeof(T), out PropertyInfo[] props))
            {
                props = typeof(T)
                          .GetProperties()
                          .Where(c => !ignoredFields.Contains(c.Name) &&
                                      c.CanWrite &&
                                      c.PropertyType == typeof(string))
                          .ToArray();

                trimProperties.Add(typeof(T), props);
            }

            foreach (PropertyInfo property in props)
            {
                string value = Convert.ToString(property.GetValue(entity, null), CultureInfo.InvariantCulture);
                if (!string.IsNullOrEmpty(value))
                {
                    property.SetValue(entity, value.Trim(), null);
                }
            }
        }
    }
}
