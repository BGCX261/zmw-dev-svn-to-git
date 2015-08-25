namespace BaiduApi.Models.Conditions
{
    public class GeocodingCondition : AbstractCondition
    {
        public string Location { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

    }
}