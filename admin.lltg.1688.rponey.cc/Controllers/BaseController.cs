using System.Web.Mvc;

namespace admin.lltg._1688.rponey.cc.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.RequestContext.HttpContext.Request.Headers
                .Add("Access-Control-Allow-Origin", "http://cms.rponey.cc");
        }
    }
}