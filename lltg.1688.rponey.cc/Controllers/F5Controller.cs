using System.Web.Mvc;

namespace lltg._1688.rponey.cc.Controllers
{
    public class F5Controller : Controller
    {
        // GET: F5
        public ActionResult Index()
        {
            RPoney.Log.LoggerManager.Debug(GetType().Name, "Debug Test");
            RPoney.Log.LoggerManager.Error(GetType().Name, "Error Test");
            return Content("OK");
        }
    }
}