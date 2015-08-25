using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaiduApi.Models
{
    public class Translate : Error
    {
        /// <summary>
        /// 实际采用的源语言（输入接口指定或者自动识别出的）
        /// </summary>
        [Required]
        public string From { get; set; }

        /// <summary>
        /// 实际采用的目标语言（输入接口指定或者自动识别出的） 
        /// </summary>
        [Required]
        public string To { get; set; }

        /// <summary>
        /// 结果体 
        /// </summary>
        public List<Trans> Trans_Result { get; set; }


        public string Query { get; set; }

    }

    public class Trans
    {
        /// <summary>
        ///原文 
        /// </summary>
        [Required]
        public string Src { get; set; }

        /// <summary>
        ///译文
        /// </summary>
        [Required]
        public string Dst { get; set; }
    }
}