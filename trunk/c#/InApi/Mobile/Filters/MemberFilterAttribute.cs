using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Mobile.Filters
{
    /// <summary>
    /// ユーザ端末情報を取得、DBに照合して、対応機種か課金情報などを取得
    /// </summary>
    public class MemberFilterAttribute : ActionFilterAttribute
    {


        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {


            base.OnActionExecuting(actionContext);
        }


    }
}