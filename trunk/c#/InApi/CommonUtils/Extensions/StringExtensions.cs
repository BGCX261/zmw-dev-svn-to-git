
using System;

namespace CommonUtils.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// ストリングの一部分取得
        /// </summary>
        /// <param name="str">ストリング</param>
        /// <param name="start">開始位置</param>
        /// <param name="length">長さ</param>
        /// <param name="min">マイナス長さ</param>
        /// <param name="plusString">後ろに追加する文字</param>
        /// <returns></returns>
        public static string Substring(this string str, int start, int length, int min, string plusString)
        {
            if (str.Length <= min)
            {
                return str;
            }
            length = str.Length < length ? str.Length : length;
            return str.Substring(start, length) + plusString;
        }


        /// <summary>
        /// ストリングの一部分取得
        /// </summary>
        /// <param name="str">ストリング</param>
        /// <param name="start">開始位置</param>
        /// <param name="length">長さ</param>
        /// <param name="min">マイナス長さ</param>
        /// <param name="plusString">後ろに追加する文字</param>
        /// <param name="isNarrow">半角モード</param>
        /// <returns></returns>
        public static string Substring(this string str, int start, int length, int min, string plusString, bool isNarrow)
        {
            if (isNarrow)
            {
                return MidB(str, start, length, min, plusString);
            }
            else
            {
                return Substring(str, start, length, min, plusString);
            }
        }

        /// <summary>
        /// ストリングの一部分取得(バイト単位)
        /// </summary>
        /// <param name="stTarget">ストリング</param>
        /// <param name="iStart">開始位置</param>
        /// <param name="iByteSize">長さ(バイト単位)</param>
        /// <param name="min">マイナス長さ(バイト単位)</param>
        /// <param name="plusString">後ろに追加する文字</param>
        /// <returns></returns>
        private static string MidB(string stTarget, int iStart, int iByteSize, int min, string plusString)
        {
            const string charsetName = "Shift_JIS";
            System.Text.Encoding hEncoding = System.Text.Encoding.GetEncoding(charsetName);
            byte[] btBytes = hEncoding.GetBytes(stTarget);

            if (btBytes.Length <= min)
                return stTarget;

            if (btBytes.Length < iByteSize)
                iByteSize = btBytes.Length;

            string retStr = hEncoding.GetString(btBytes, iStart, iByteSize);

            // 末尾の「・」を削除
            if (retStr.LastIndexOf("・") != -1)
            {
                retStr = retStr.Substring(0, retStr.Length - 1);
            }

            return retStr + plusString;
        }

        public static string ConvertBr(this string str)
        {
            return str == null ? "" : str.Replace("\n", "<br />").Replace("&lt;br&gt;", "<br />");
        }

        public static string Lowercase(this string str)
        {
            return Microsoft.VisualBasic.Strings.StrConv(str, Microsoft.VisualBasic.VbStrConv.Lowercase, 1041);
        }

        public static byte[] ToBinary(this string str)
        {
            return Convert.FromBase64String(str);
        }
    }
}