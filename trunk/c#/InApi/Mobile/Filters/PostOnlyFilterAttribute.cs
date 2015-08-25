
using System.Web.Mvc;

namespace Mobile.Filters
{
    public class PostOnlyFilterAttribute : ActionFilterAttribute
    {
        public string Url { get; set; }
        /// <summary>
        /// リクエストがPost方式かどうか、判断して、非の場合指定されたページに遷移する。
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {

            // Post要非のAnnotationの取得
            object[] attrs = actionContext.Controller.GetType().GetCustomAttributes(typeof(PostOnlyFilterAttribute), true);
            object[] act = actionContext.ActionDescriptor.GetCustomAttributes(typeof(PostOnlyFilterAttribute), true);


            if (attrs.Length != 0 || act.Length != 0)
            {
                if (actionContext.HttpContext.Request.HttpMethod != "POST")
                {
                    if (attrs.Length != 0)
                    {
                        var attribute = attrs[0] as PostOnlyFilterAttribute;
                        if (!string.IsNullOrEmpty(attribute.Url))
                        {
                            actionContext.Result = new RedirectResult(attribute.Url);
                            return;
                        }
                    }
                    if (act.Length != 0)
                    {
                        var attribute = act[0] as PostOnlyFilterAttribute;
                        if (attribute != null && !string.IsNullOrEmpty(attribute.Url))
                        {
                            actionContext.Result = new RedirectResult(attribute.Url);
                            return;
                        }
                    }
                    // TOP画面に遷移
                    actionContext.Result = new RedirectResult("/Top?uid=NULLGWDOCOMO");
                }
            }

        }
    }
}