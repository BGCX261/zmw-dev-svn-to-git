using System;
using System.Web.Mvc;
using CommonUtils.Extensions;
using Mobile.Dao.Holders;

namespace Mobile.Filters
{
    /// <summary>
    /// CurrentInfoHolderやObjectContextHolderの初期化と解除
    /// </summary>
    public class CurrentInfoFilterAttribute : ActionFilterAttribute
    {

        /// <summary>
        /// CurrentInfoHolderやObjectContextHolderの初期化をする
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            CurrentInfoHolder.Init();
            CurrentInfoHolder.BindDateTimeToThread(DateTime.UtcNow.UtcToJapanStandardTime());


            ObjectContextHolder.ObjectContext();
            base.OnActionExecuting(actionContext);
        }

        /// <summary>
        /// CurrentInfoHolderやObjectContextHolderの解除をする
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            CurrentInfoHolder.Clear();
            ObjectContextHolder.Dispose();
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}