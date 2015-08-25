using System;
using System.Reflection;
using Base.Attribute;

namespace CommonUtils.Extensions
{
    public static class EnumExtensions
    {        /// <summary>
        /// 対応するコードに転換
        /// </summary>
        /// <param name="value">Enumの値</param>
        /// <returns>対応するコード</returns>
        public static int ToCode(this Enum value)
        {
            return Convert.ToInt16(value);
        }

        /// <summary>
        /// 対応する(string)コードに転換
        /// </summary>
        /// <param name="value">Enumの値</param>
        /// <returns>対応する(string)コード</returns>
        public static string ToStringCode(this Enum value)
        {
            return Convert.ToString(value.ToCode());
        }

        /// <summary>
        /// String名称に転換
        /// </summary>
        /// <param name="value">Enumの値</param>
        /// <returns>string名称</returns>
        public static string ToStringValue(this Enum value)
        {
            return Convert.ToString(value);
        }


        /// <summary>
        /// 属性で指定された名前を取得します。
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string Name(this Enum e)
        {
            Type type = e.GetType();
            string name = Enum.GetName(type, e);
            FieldInfo info = type.GetField(name);
            var attributes = (EnumStringAttribute[])info.GetCustomAttributes(typeof(EnumStringAttribute), false);
            return (attributes.Length == 0) ? string.Empty : attributes[0].Name;
        }

        /// <summary>
        /// 属性で指定されたメッセージを取得します。
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string Message(this Enum e)
        {
            Type type = e.GetType();
            string name = Enum.GetName(type, e);
            FieldInfo info = type.GetField(name);
            var attributes = (EnumStringAttribute[])info.GetCustomAttributes(typeof(EnumStringAttribute), false);
            return (attributes.Length == 0) ? string.Empty : attributes[0].Message;
        }


        /// <summary>
        /// 属性で指定されたコードを取得します。
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static T Code<T>(this Enum e)
        {
            Type type = e.GetType();
            string name = Enum.GetName(type, e);
            FieldInfo info = type.GetField(name);
            var attributes = (EnumCodeAttribute[])info.GetCustomAttributes(typeof(EnumCodeAttribute), false);

            return (attributes.Length == 0) ? 0 : Convert.ChangeType(attributes[0].Code, typeof(T));
        }

    }
}
