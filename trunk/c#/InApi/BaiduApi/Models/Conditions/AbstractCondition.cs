using BaiduApi.Models.Enum;
using CommonUtils.Extensions;

namespace BaiduApi.Models.Conditions
{
    public abstract class AbstractCondition
    {
        public string Key { get; set; }

        public string Output
        {
            get { return OutPutFormat.Json.Name(); }
        }
    }
}