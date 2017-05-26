using System;
using System.Web.Mvc;
using admin.lltg._1688.rponey.cc.Common;
using lltg._1688.rponey.cc.Bll;
using lltg._1688.rponey.cc.Model;
using lltg._1688.rponey.cc.Model.Entity;
using lltg._1688.rponey.cc.Model.Search;
using lltg._1688.rponey.cc.Model.ViewModel;

namespace admin.lltg._1688.rponey.cc.Controllers
{
    public class YinLiuTagManagerController : BaseController
    {
        private readonly Lazy<YinLiuTagBll> _yinLiuTagBll = new Lazy<YinLiuTagBll>();
        // GET: YinLiuTagManager
        public ActionResult List(YinLiuTagSerachParameter search)
        {
            search.ReturnList = _yinLiuTagBll.Value.GetList(search);
            return View(search);
        }

        [HttpGet]
        public ActionResult Edit(YinLiuTagViewModel model)
        {
            if (model.Id > 0)
            {
                model = _yinLiuTagBll.Value.GetView(model.Id);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Save(YinLiuTagViewModel model)
        {
            var description = "";
            var entity = new YinLiuTagEntity();
            if (model.Id > 0)//编辑
            {
                description = "保存标签";
                entity = _yinLiuTagBll.Value.Get(model.Id);
                entity.Name = model.Name;
            }
            else//添加
            {
                description = "添加标签";
                entity.Name = model.Name;
                entity.Type = PublicEnum.YinLiuTagTypeEnum.System;
            }
            var result = _yinLiuTagBll.Value.Save(entity);
            if (result)
            {
                return LayerHelper.SuccessAndClose("", $"{description}成功");
            }
            return LayerHelper.Warn($"{description}失败");
        }


    }
}