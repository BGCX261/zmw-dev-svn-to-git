using System.Collections.Generic;

namespace CommonUtils.Extensions
{
    public static class ListExtensions
    {

        /// <summary>
        /// Stringリストに間隔を追加してStringを作成する
        /// </summary>
        /// <param name="list">ストリングリスト</param>
        /// <param name="addStr">間隔ストリング</param>
        /// <returns></returns>
        public static string Split(this ICollection<string> list, string addStr)
        {
            string rtn = "";
            var count = 0;
            foreach (var str in list)
            {
                if (string.IsNullOrEmpty(str)) continue;
                if (count == list.Count - 1)
                {
                    rtn += str;
                }
                else
                {
                    rtn += str + addStr;
                }
                count++;
            }

            return rtn;
        }
    }
}