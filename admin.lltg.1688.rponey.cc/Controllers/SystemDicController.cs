using System;
using System.Web.Mvc;
using admin.lltg._1688.rponey.cc.Common;
using lltg._1688.rponey.cc.Bll;
using lltg._1688.rponey.cc.Model.Entity;
using lltg._1688.rponey.cc.Model.Search;

namespace admin.lltg._1688.rponey.cc.Controllers
{
    public class SystemDicController : BaseController
    {
        private readonly Lazy<SystemDicBll> _systemDicBll = new Lazy<SystemDicBll>();
        // GET: SystemDic
        [HttpGet]
        public ActionResult List(SystemDicSearchParameter search)
        {
            search.ReturnList = _systemDicBll.Value.GetList(search);
            return View(search);
        }
        [HttpGet]
        public ActionResult Edit(SystemDicEntity entity)
        {
            var dic = _systemDicBll.Value.Get(entity.Id);
            return View(dic);
        }

        [HttpPost]
        public ActionResult Save(SystemDicEntity entity)
        {
            var dic = _systemDicBll.Value.Get(entity.Id);
            dic.Key = entity.Key;
            dic.Value = entity.Value;
            dic.Description = entity.Description;
            var description = "保存系统全局配置";
            if (_systemDicBll.Value.Update(dic))
            {
                return LayerHelper.SuccessAndClose("", $"{description}成功");
            }
            return LayerHelper.Warn($"{description}失败");
        }
    }
}