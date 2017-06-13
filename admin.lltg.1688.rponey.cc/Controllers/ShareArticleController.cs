using System;
using System.Web.Mvc;
using admin.lltg._1688.rponey.cc.Common;
using lltg._1688.rponey.cc.Bll;
using lltg._1688.rponey.cc.Model.Entity;
using lltg._1688.rponey.cc.Model.Search;

namespace admin.lltg._1688.rponey.cc.Controllers
{
    public class ShareArticleController : BaseController
    {
        private readonly Lazy<ShareArticleBll> _shareArticleBll = new Lazy<ShareArticleBll>();
        // GET: ShareArticle

        public ActionResult List(ShareArticleSearchParameter searchParameter)
        {
            searchParameter.ReturnList = _shareArticleBll.Value.GetList(searchParameter);
            return View(searchParameter);
        }

        [HttpGet]
        public ActionResult Edit(ShareArticleEntity model)
        {
            return View(_shareArticleBll.Value.Get(model.Id) ?? new ShareArticleEntity());
        }
        [HttpPost]
        public ActionResult Save(ShareArticleEntity model)
        {
            var entity = _shareArticleBll.Value.Get(model.Id) ?? new ShareArticleEntity();
            entity.Title = model.Title;
            entity.ArticleUrl = model.ArticleUrl;
            entity.ArticleType = model.ArticleType;
            entity.Cover = model.Cover;
            if (entity.Id == 0)
            {
                entity.CreatedTime = DateTime.Now;
            }
            entity.UpdatedTime = DateTime.Now;
            var description = "保存分享文章";
            if (_shareArticleBll.Value.Save(entity))
            {
                return LayerHelper.SuccessAndClose("", $"{description}成功");
            }
            return LayerHelper.Warn($"{description}失败");
        }
    }
}