using System.Linq;
using System;

namespace zmw.dev.utils
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 入力値がなかった時のDateTimeオブジェクト
        /// </summary>
        private static readonly DateTime ZeroTime = new DateTime();

        /// <summary>
        /// 日本時間のTimeZoneInfo
        /// </summary>
        public static readonly TimeZoneInfo jstTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");

        /// <summary>
        /// コンピューター上の現在の日時を日本時刻 (JST) で表した System.DateTime オブジェクトを取得します。
        /// 下記の様に利用します
        /// 変換する場合(UTCであること)
        /// 　HogeDate.UtcToJapanStandardTime();
        /// 現在時刻を取得する場合
        /// 　DateTime.UtcNow.UtcToJapanStandardTime();
        /// </summary>
        /// <returns>日本時刻 (JST) で表した現在の日付と時刻を示す System.DateTime。</returns>
        public static DateTime UtcToJapanStandardTime(this DateTime date)
        {
            return TimeZoneInfo.ConvertTime(date.ToUniversalTime(), TimeZoneInfo.Utc, jstTimeZoneInfo);
        }

        /// <summary>
        /// コンピューター上の現在の日時を日本時刻 (JST) で表した日付を取得します。
        /// 下記の様に利用します
        /// 変換する場合(UTCであること)
        /// 　HogeDate.UtcToJapanStandardToday();
        /// 現在日付を取得する場合
        /// 　DateTime.UtcNow.UtcToJapanStandardToday();
        /// </summary>
        /// <param name="date"></param>
        /// <returns>日本時刻 (JST) で表した現在の日付を表す System.DateTime (ただし、時刻部分は 00:00:00)。</returns>
        public static DateTime UtcToJapanStandardToday(this DateTime date)
        {
            return date.UtcToJapanStandardTime().Date;
        }

        /// <summary>
        /// 対象のdateが初期値か否か
        /// </summary>
        /// <param name="date">対象の日付オブジェクト</param>
        /// <returns>true:初期値 / false:初期値じゃない</returns>
        public static bool IsInitialDateTime(this DateTime date)
        {
            return ZeroTime.CompareTo(date) == 0;
        }

        /// <summary>
        /// 対象のdateが有効か否か
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsValidDateTime(this DateTime date)
        {
            return (!IsInitialDateTime(date)) && (!IsLessMinYear(date));
        }

        /// <summary>
        /// 最小の西暦
        /// </summary>
        private const int MinYear = 1900;

        /// <summary>
        /// 対象日付がMinYear(1900年)よりも小さい場合にtrueを返します。
        /// </summary>
        /// <param name="targetDate">対象日付</param>
        /// <returns>true:小さい / false:小さくない</returns>
        public static bool IsLessMinYear(this DateTime targetDate)
        {
            return MinYear > targetDate.Year;
        }


        /// <summary>
        /// 差分日数取得
        /// </summary>
        /// <param name="from">日付from</param>
        /// <param name="to">日付to</param>
        /// <returns></returns>
        public static int DiffDays(this DateTime from, DateTime to)
        {
            return DiffDays(from, to, true);
        }

        /// <summary>
        /// 二つの日付の間隔(日付範囲)を求める
        /// 日付1 - 日付2の結果として差分日数が返る
        /// absの値がtrueの場合、常に0以上の値を返る
        /// </summary>
        /// <param name="from">日付from</param>
        /// <param name="to">日付to</param>
        /// <param name="abs">絶対値フラグ</param>
        /// <returns>二つの日付の間隔値</returns>
        public static int DiffDays(this DateTime from, DateTime to, bool abs)
        {
            var ts = to - from;
            return abs ? Math.Abs(ts.Days) : ts.Days;
        }

        /// <summary>
        /// 日付が未来日かどうか
        /// </summary>
        /// <param name="date">日付</param>
        /// <returns>未来日かどうか</returns>
        public static bool IsFuture(this DateTime date)
        {
            TimeSpan days = date.Date - DateTime.UtcNow.UtcToJapanStandardTime().Date;
            return days.Days > 0;
        }


        /// <summary>
        /// DateTime日付をstringに変換する
        /// </summary>
        /// <param name="date">日付</param>
        /// <returns>string、変換できない場合</returns>
        public static string ToShortDateNoSegmentString(this DateTime? date)
        {
            if (!date.HasValue)
            {
                return "";
            }
            return date.Value.ToString("yyyyMMdd");
        }

        public static string ToShortDateNoSegmentString(this DateTime date)
        {
            return date.ToString("yyyyMMdd");
        }

        /// <summary>
        /// 対象日が期間内かどうかのチェック
        /// </summary>
        /// <param name="date">対象日</param>
        /// <param name="longFrom">期間開始日</param>
        /// <param name="longTo">期間終了日</param>
        /// <returns>bool</returns>
        public static bool Between(this DateTime date, DateTime longFrom, DateTime longTo)
        {
            if (longTo.CompareTo(longFrom) < 0)
            {
                return false;
            }
            if (date.CompareTo(longFrom) < 0)
            {
                return false;
            }
            if (longTo.CompareTo(date) < 0)
            {
                return false;
            }
            return true;
        }
    }
}
