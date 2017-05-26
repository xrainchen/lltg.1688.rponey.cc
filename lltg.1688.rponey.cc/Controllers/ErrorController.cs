using System.Web.Mvc;

namespace lltg._1688.rponey.cc.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult NoFound()
        {
            return View("_404");
        }
    }
}