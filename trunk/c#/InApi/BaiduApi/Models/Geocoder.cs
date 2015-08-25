namespace BaiduApi.Models
{
    public class Geocoder
    {
        /// <summary>
        /// 坐标
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// 位置的附加信息，是否精确查找’（1为精确查找，0为不精确查找）
        /// </summary>
        public short Precise { get; set; }

        /// <summary>
        /// 可信度
        /// </summary>
        public string Confidence { get; set; }

        /// <summary>
        /// 级别
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// 详细地址描述
        /// </summary>
        public string Formatted_Address { get; set; }

        /// <summary>
        /// 周围商圈
        /// </summary>
        public string Business { get; set; }

        /// <summary>
        /// 地址信息
        /// </summary>
        public AddressComponent AddressComponent { get; set; }

        /// <summary>
        /// 城市代码
        /// </summary>
        public string CityCode { get; set; }
    }
}