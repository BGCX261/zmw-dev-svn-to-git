using System;
using System.Linq;
using System.Reflection;

namespace zmw.dev.utils
{
    public static class BeanUtils
    {

        /// <summary>
        /// Copies the data of one object to another. The target object gets properties of the first. 
        /// Any matching properties (by name) are written to the target.
        /// </summary>
        /// <param name="source">The source object to copy from</param>
        /// <param name="target">The target object to copy to</param>
        public static void CopyObjectData(object source, object target)
        {
            CopyObjectData(source, target, String.Empty, BindingFlags.Public | BindingFlags.Instance);
        }

        /// <summary>
        /// Copies the data of one object to another. The target object gets properties of the first. 
        /// Any matching properties (by name) are written to the target.
        /// </summary>
        /// <param name="source">The source object to copy from</param>
        /// <param name="target">The target object to copy to</param>
        /// <param name="excludedProperties">A comma delimited list of properties that should not be copied</param>
        /// <param name="memberAccess">Reflection binding access</param>
        public static void CopyObjectData(object source, object target, string excludedProperties, BindingFlags memberAccess)
        {
            string[] excluded = null;
            if (!string.IsNullOrEmpty(excludedProperties))
            {
                excluded = excludedProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            }

            MemberInfo[] miT = target.GetType().GetMembers(memberAccess);
            foreach (MemberInfo field in miT)
            {
                string name = field.Name;

                // Skip over excluded properties
                if (string.IsNullOrEmpty(excludedProperties) == false
                    && excluded.Contains(name))
                {
                    continue;
                }


                if (field.MemberType == MemberTypes.Field)
                {
                    FieldInfo sourcefield = source.GetType().GetField(name);
                    if (sourcefield == null) { continue; }

                    object sourceValue = sourcefield.GetValue(source);
                    try
                    {
                        ((FieldInfo)field).SetValue(target, sourceValue);
                    }
                    catch (System.Exception)
                    {
                    }

                }
                else if (field.MemberType == MemberTypes.Property)
                {
                    var piTarget = field as PropertyInfo;
                    PropertyInfo sourceField = source.GetType().GetProperty(name, memberAccess);
                    if (sourceField == null) { continue; }

                    if (piTarget.CanWrite && sourceField.CanRead)
                    {
                        object targetValue = piTarget.GetValue(target, null);
                        object sourceValue = sourceField.GetValue(source, null);

                        if (sourceValue == null) { continue; }

                        if (sourceField.PropertyType.IsArray
                            && piTarget.PropertyType.IsArray)
                        {
                            CopyArray(source, target, memberAccess, piTarget, sourceField, sourceValue);
                        }
                        else
                        {
                            CopySingleData(source, target, memberAccess, piTarget, sourceField, targetValue, sourceValue);
                        }
                    }
                }
            }
        }

        private static void CopySingleData(object source, object target, BindingFlags memberAccess, PropertyInfo piTarget, PropertyInfo sourceField, object targetValue, object sourceValue)
        {
            //instantiate target if needed
            if (targetValue == null
                && piTarget.PropertyType.IsValueType == false
                && piTarget.PropertyType != typeof(string))
            {
                targetValue = Activator.CreateInstance(piTarget.PropertyType.IsArray ? piTarget.PropertyType.GetElementType() : piTarget.PropertyType);
            }

            if (piTarget.PropertyType.IsValueType == false
                && piTarget.PropertyType != typeof(string))
            {
                CopyObjectData(sourceValue, targetValue, "", memberAccess);
                piTarget.SetValue(target, targetValue, null);
            }
            else
            {
                if (piTarget.PropertyType.FullName == sourceField.PropertyType.FullName)
                {
                    object tempSourceValue = sourceField.GetValue(source, null);
                    piTarget.SetValue(target, tempSourceValue, null);
                }
                else
                {
                    CopyObjectData(piTarget, target, "", memberAccess);
                }
            }
        }

        private static void CopyArray(object source, object target, BindingFlags memberAccess, PropertyInfo piTarget, PropertyInfo sourceField, object sourceValue)
        {
            var sourceLength = (int)sourceValue.GetType().InvokeMember("Length", BindingFlags.GetProperty, null, sourceValue, null);
            var targetArray = Array.CreateInstance(piTarget.PropertyType.GetElementType(), sourceLength);
            var array = (Array)sourceField.GetValue(source, null);

            for (int i = 0; i < array.Length; i++)
            {
                object o = array.GetValue(i);
                object tempTarget = Activator.CreateInstance(piTarget.PropertyType.GetElementType());
                CopyObjectData(o, tempTarget, "", memberAccess);
                targetArray.SetValue(tempTarget, i);
            }
            piTarget.SetValue(target, targetArray, null);
        }

    }
}
