namespace BaiduApi.Models.Conditions
{
    public class TranslateCondition
    {
        /// <summary>
        /// 源语言语种：语言代码或auto 
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// 目标语言语种：语言代码或auto 
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// 开发者在百度连接平台上注册得到的授权API key 
        /// </summary>
        public string Client_Id { get; set; }

        /// <summary>
        /// 待翻译内容
        /// </summary>
        public string Q { get; set; }
    }
}