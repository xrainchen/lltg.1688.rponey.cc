using System.Web.Mvc;
using lltg._1688.rponey.cc.Models;

namespace lltg._1688.rponey.cc.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index(MainModel model)
        {
            model.User = CurrentUser;
            return View(model);
        }
    }
}