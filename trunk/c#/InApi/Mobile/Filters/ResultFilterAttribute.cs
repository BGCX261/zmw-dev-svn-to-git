using System.Web;
using System.Web.Mvc;
using Mobile.Work;

namespace Mobile.Filters
{
    /// <summary>
    /// AccessLogとか、ErrorLogを取得する
    /// </summary>
    public class ResultFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Controllerが実行後に、Accesslog、ErrorLogを記録
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
            {
                // エラーログを記入
                if (actionExecutedContext.Exception is ServiceException)
                {
                    var exception = actionExecutedContext.Exception as ServiceException;
                    actionExecutedContext.HttpContext.Response.Redirect("/Errors/Index?errorCode=" + exception.ErrorMessage);
                }
                else
                {
                     // 予期せぬ例外が発生している場合はエラー画面に遷移
                    actionExecutedContext.HttpContext.Response.Redirect("/Errors/");
                }
            }
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}