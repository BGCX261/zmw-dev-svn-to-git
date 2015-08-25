using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace zmw.dev.utils
{
    public static class StringExtensions
    {
        public static bool ConvertToBool(this string value)
        {
            return !(value == null || "0".Equals(value) || "null".Equals(value));
        }

        /// <summary>
        /// 正の整数かどうか。
        /// </summary>
        /// <param name="str"></param>
        /// <returns>0と正の整数の場合、true</returns>
        /// <returns>それ以外の場合、false</returns>
        public static bool IsPositiveInteger(this string str)
        {
            bool rst = true;
            try
            {
                int num = int.Parse(str);
                if (num < 0)
                {
                    rst = false;
                }
            }
            catch (Exception)
            {
                rst = false;
            }
            return rst;
        }


        /// <summary>
        /// string日付DateTimeに変換する,変換できない場合、null日付を戻す
        /// </summary>
        /// <param name="date">変換前ストリング型日付</param>
        /// <param name="format">フォマント</param>
        /// <returns>DateTime、変換できない場合</returns>
        public static DateTime? ToDateTime(this string date, string format)
        {
            try
            {
                return DateTime.ParseExact(date, format, null);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// SQLServerの文字列照合順(Japanese_CI_AS)と同等な文字列比較をします
        /// ひらがなとカタカナを区別しない、全角と半角を区別しない、大文字と小文字を区別しない
        /// </summary>
        /// <param name="str1">自身の文字列</param>
        /// <param name="str2">比較対象の文字列</param>
        /// <returns></returns>
        public static bool EqualsJapaneseCIAS(this string str1, string str2)
        {
            CompareInfo ci = CultureInfo.CurrentCulture.CompareInfo;
            return ci.Compare(str1, str2,
                              CompareOptions.IgnoreKanaType
                              | CompareOptions.IgnoreWidth
                              | CompareOptions.IgnoreCase) == 0;
        }

        /// <summary>
        /// 単語の先頭を大文字に変換する
        /// </summary>
        /// <param name="str">this</param>
        /// <returns>変換する結果</returns>
        public static string ToTitleCase(this string str)
        {
            return ToTitleCase(str, (string[])null);
        }


        /// <summary>
        /// 単語の先頭を大文字に変換する
        /// </summary>
        /// <param name="str">this</param>
        /// <param name="replacedChar"> </param>
        /// <returns>変換する結果</returns>
        public static string ToTitleCase(this string str, string replacedChar)
        {
            return ToTitleCase(str, new[] { replacedChar });
        }

        /// <summary>
        /// 単語の先頭を大文字に変換する
        /// </summary>
        /// <param name="str">this</param>
        /// <param name="replacedChar"> </param>
        /// <returns>変換する結果</returns>
        public static string ToTitleCase(this string str, string[] replacedChar)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            string titleCase = textInfo.ToTitleCase(str);

            string result = titleCase;
            if (replacedChar != null)
            {
                result = replacedChar.Aggregate(result, (current, s) => current.Replace(s, String.Empty));
            }
            return result;
        }

        /// <summary>
        /// NullOrEmptyを判断する
        /// </summary>
        /// <param name="_this"></param>
        /// <returns>True：ヌルまたは空</returns>
        public static bool IsNullOrEmpty(this string _this)
        {
            return String.IsNullOrEmpty(_this);
        }

        /// <summary>
        /// 重複する
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="count">重複回数</param>
        /// <returns>重複結果</returns>
        public static string Repeat(this string _this, int count)
        {
            return Repeat(_this, count, String.Empty);
        }

        /// <summary>
        /// 重複する
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="count">重複回数</param>
        /// <param name="separator">分割</param>
        /// <returns>重複結果</returns>
        public static string Repeat(this string _this, int count, string separator)
        {
            if (count <= 0 || String.IsNullOrEmpty(_this))
            {
                return String.Empty;
            }
            var list = new List<string>();
            for (int i = 0; i < count; i++)
            {
                list.Add(_this);
            }
            return String.Join(separator, list);
        }

        /// <summary>
        /// 指定字が全部含めるかどうか
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="values">指定字</param>
        /// <returns>含めるかどうか</returns>
        public static bool ContainsAll(this string _this, params string[] values)
        {
            if (_this == null)
            {
                throw new NullReferenceException("String.ContainsAll() can not be called on a null value.");
            }
            for (int i = 0, l = values.Length; i < l; i++)
            {
                if (!_this.Contains(values[i]))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 指定字が任一含めるかどうか
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="values">指定字</param>
        /// <returns>含めるかどうか</returns>
        public static bool ContainsAny(this string _this, params string[] values)
        {
            if (_this == null)
            {
                throw new NullReferenceException("String.ContainsAny() can not be called on a null value.");
            }
            for (int i = 0, l = values.Length; i < l; i++)
            {
                if (_this.Contains(values[i]))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ストリングがバイナリーに転換
        /// </summary>
        /// <param name="_this">this</param>
        /// <returns>バイナリー値</returns>
        public static byte[] ToBinary(this string _this)
        {
            var encoding = new System.Text.UTF8Encoding();
            return encoding.GetBytes(_this);
        }

        public static string EncodeTo64(this string toEncode)
        {

            byte[] toEncodeAsBytes

                  = System.Text.Encoding.ASCII.GetBytes(toEncode);

            string returnValue

                  = Convert.ToBase64String(toEncodeAsBytes);

            return returnValue;

        }

        public static string DecodeFrom64(this string encodedData)
        {

            byte[] encodedDataAsBytes

                = Convert.FromBase64String(encodedData);

            string returnValue =

               System.Text.Encoding.ASCII.GetString(encodedDataAsBytes);

            return returnValue;

        }


        /// <summary>
        /// 指定された文字列に半角カナを含む場合、全角カナに変換して返します。
        /// このメソッドを使用する場合は、プロジェクトにMicrosoft.VisualBasicへの参照を追加してください。
        /// </summary>
        /// <param name="src">対象文字列</param>
        /// <returns></returns>
        public static string ConvertKana(string src)
        {
            return System.Text.RegularExpressions.Regex.Replace(src, "[\uFF61-\uFF9F]+", MatchKanaEvaluator);
        }

        private static string MatchKanaEvaluator(System.Text.RegularExpressions.Match m)
        {
            return Microsoft.VisualBasic.Strings.StrConv(m.Value, Microsoft.VisualBasic.VbStrConv.Wide, 1041);
        }

    }
}
