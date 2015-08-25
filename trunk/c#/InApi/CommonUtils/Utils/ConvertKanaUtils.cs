
namespace CommonUtils.Utils
{
    public static class ConvertKanaUtils
    {

        /// <summary>
        /// 指定された文字列に半角カナを含む場合、全角カナに変換して返します。
        /// このメソッドを使用する場合は、プロジェクトにMicrosoft.VisualBasicへの参照を追加してください。
        /// </summary>
        /// <param name="src">対象文字列</param>
        /// <returns></returns>
        public static string ConvertKana(string src)
        {
            if (string.IsNullOrEmpty(src))
            {
                return null;
            }
            return System.Text.RegularExpressions.Regex.Replace(src, "[\uFF61-\uFF9F]+", MatchKanaEvaluator);
        }

        private static string MatchKanaEvaluator(System.Text.RegularExpressions.Match m)
        {
            return Microsoft.VisualBasic.Strings.StrConv(m.Value, Microsoft.VisualBasic.VbStrConv.Wide, 1041);
        }

        /// <summary>
        /// 指定された文字列に全角カナを含む場合、半角カナに変換して返します。
        /// このメソッドを使用する場合は、プロジェクトにMicrosoft.VisualBasicへの参照を追加してください。
        /// </summary>
        /// <param name="src">対象文字列</param>
        /// <returns></returns>
        public static string ConvertKanaNarrow(string src)
        {
            if (string.IsNullOrEmpty(src))
            {
                return null;
            }
            return System.Text.RegularExpressions.Regex.Replace(src, "[\u30A1-\u30FC|「」。、！？；：]+", MatchKanaNarrowEvaluator);
        }

        private static string MatchKanaNarrowEvaluator(System.Text.RegularExpressions.Match m)
        {

            return Microsoft.VisualBasic.Strings.StrConv(m.Value, Microsoft.VisualBasic.VbStrConv.Narrow, 1041);
        }
    }
}
