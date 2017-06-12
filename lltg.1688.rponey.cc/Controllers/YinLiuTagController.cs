using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using lltg._1688.rponey.cc.Service;

namespace lltg._1688.rponey.cc.Controllers
{
    public class YinLiuTagController : BaseController
    {
        private readonly Lazy<YinLiuTagService> _yinLiuTagService = new Lazy<YinLiuTagService>();
        // GET: YinLiuTag

        [HttpPost]
        public ActionResult Save(IList<string> tags)
        {
            return Json(_yinLiuTagService.Value.Save(CurrentUser.Id, tags));
        }
    }
}