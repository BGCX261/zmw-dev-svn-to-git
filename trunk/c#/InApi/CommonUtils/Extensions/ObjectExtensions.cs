using System;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;

namespace CommonUtils.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// オブジェクトのプロパティの値を取得
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <param name="name">プロパティ名</param>
        /// <returns>プロパティの値</returns>
        public static dynamic GetPropertyValue(this object obj, string name)
        {
            if (obj == null)
            {
                return null;
            }
            try
            {
                return obj.GetType().GetProperty(name).GetGetMethod().Invoke(obj, null);
            }
            catch (Exception)
            {
                return null;
            }

        }


        /// <summary>
        /// オブジェクトのプロパティの値を設定
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <param name="name">プロパティ名</param>
        /// <param name="value">プロパティ値</param>
        public static void SetPropertyValue(this object obj, string name, object value)
        {
            obj.GetType().GetProperty(name).SetValue(obj, value, null);
        }


        public static NameValueCollection ConvertToCollection(this object obj, string excludedProperties, BindingFlags memberAccess)
        {
            var collection = new NameValueCollection();
            string[] excluded = null;
            if (!string.IsNullOrEmpty(excludedProperties))
            {
                excluded = excludedProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            MemberInfo[] miT = obj.GetType().GetMembers();
            foreach (MemberInfo field in miT)
            {
                string name = field.Name;

                // Skip over excluded properties
                if (string.IsNullOrEmpty(excludedProperties) == false
                    && excluded.Contains(name))
                {
                    continue;
                }

                if (field.MemberType == MemberTypes.Property)
                {
                    PropertyInfo sourceField = obj.GetType().GetProperty(name);
                    if (sourceField.CanRead)
                    {
                        var value = obj.GetPropertyValue(name);
                        if (value == null) { continue; }
                        collection.Add(name, value.ToString());
                    }
                }
            }
            return collection;
        }
    }
}
