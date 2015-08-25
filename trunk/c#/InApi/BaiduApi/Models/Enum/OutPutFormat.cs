using Base.Attribute;

namespace BaiduApi.Models.Enum
{
    public enum OutPutFormat
    {
        [EnumString("json")]
        Json,
        [EnumString("xml")]
        Xml
    }
}