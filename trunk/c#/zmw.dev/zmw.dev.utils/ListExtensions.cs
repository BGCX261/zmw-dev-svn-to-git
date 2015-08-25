using System.Collections.Generic;
using System.Linq;

namespace zmw.dev.utils
{
    public static class ListExtensions
    {

        /// <summary>
        /// Null許容型の値型のリストから値nullを取り除いて戻す
        /// </summary>
        /// <param name="list">Null許容型の値型のリスト</param>
        /// <returns></returns>
        public static List<T?> TrimNullAsSameType<T>(this List<T?> list) where T : struct
        {
            return list.FindAll(t => t.HasValue);
        }

        /// <summary>
        /// Null許容型の値型リストから値nullを取り除いて戻す
        /// </summary>
        /// <param name="list">非Null許容型のリスト</param>
        /// <returns></returns>
        public static List<T> TrimNull<T>(this List<T?> list) where T : struct
        {
            return (from item in list where item.HasValue select item.GetValueOrDefault()).ToList();
        }

        /// <summary>
        /// 参照型リストからnullを取り除いて戻す
        /// </summary>
        /// <param name="list">参照型のリスト</param>
        /// <returns></returns>
        public static List<T> TrimNull<T>(this List<T> list) where T : class
        {
            return list.FindAll(item => item != null);
        }
        /// <summary>
        /// stringリストから値null或いは””或いは”  ”を取り除いて戻す
        /// </summary>
        /// <param name="list">ストリングリスト</param>
        /// <returns>取り除いたリスト</returns>
        public static List<string> TrimNullOrEmpty(this List<string> list)
        {
            return list.FindAll(str => !string.IsNullOrEmpty(str));
        }

        /// <summary>
        /// リストが空かどうか判断
        /// </summary>
        /// <typeparam name="T">タイプ</typeparam>
        /// <param name="list">リスト</param>
        /// <returns>True：空</returns>
        public static bool IsEmpty<T>(this ICollection<T> list)
        {
            return list == null || list.Count <= 0;
        }


    }
}
