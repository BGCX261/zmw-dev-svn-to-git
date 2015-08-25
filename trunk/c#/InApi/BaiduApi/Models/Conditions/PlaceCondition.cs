using BaiduApi.Models.Enum;
using CommonUtils.Extensions;
using CommonUtils.Utils;

namespace BaiduApi.Models.Conditions
{
    public class PlaceCondition : AbstractCondition
    {
        public string Query { get; set; }
        public string Bounds { get; set; }
        public string Location { get; set; }
        public string Radius { get; set; }
        public string Region { get; set; }
        
    }

}