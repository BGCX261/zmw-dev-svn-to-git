
using System.Linq;

namespace zmw.dev.utils
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
            catch (System.Exception)
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
    }
}
