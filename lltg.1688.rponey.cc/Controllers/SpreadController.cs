using System;
using System.Web.Mvc;
using lltg._1688.rponey.cc.Bll;
using lltg._1688.rponey.cc.Models;

namespace lltg._1688.rponey.cc.Controllers
{
    public class SpreadController : BaseController
    {
        private readonly Lazy<YinLiuTagBll> _yinLiuTagBll = new Lazy<YinLiuTagBll>();
        private readonly Lazy<AdPlaceConfigBll> _adPlaceConfigBll = new Lazy<AdPlaceConfigBll>();
        // GET: Spread
        public ActionResult Index(SpreadModel model)
        {
            model.YinLiuTagList = _yinLiuTagBll.Value.GetTagByProductUserId(CurrentUser.Id);
            model.AdPlaceConfig = _adPlaceConfigBll.Value.GetOrInsert(CurrentUser.Id);
            return View(model);
        }
    }
}