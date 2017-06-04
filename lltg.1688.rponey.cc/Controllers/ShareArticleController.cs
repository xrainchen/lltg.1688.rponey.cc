using System;
using System.Web.Mvc;
using lltg._1688.rponey.cc.Bll;
using lltg._1688.rponey.cc.Model;
using lltg._1688.rponey.cc.Model.Entity;
using lltg._1688.rponey.cc.Model.Search;

namespace lltg._1688.rponey.cc.Controllers
{
    public class ShareArticleController : BaseController
    {
        private readonly Lazy<ShareArticleBll> _shareArticleBll = new Lazy<ShareArticleBll>();
        // GET: ShareArticle

        
        public ActionResult YunYinGanHuo(ShareArticleSearchParameter search)
        {
            search.ArticleType = PublicEnum.ShareArticleTypeEnum.YunYinGanHuo;
            search.Page = 1;
            search.PageSize = 5;
            search.ReturnList = _shareArticleBll.Value.GetRecommendShareArticle(search);
            return View(search);
        }
        
        public ActionResult TuiGuangFangFaChuangShou(ShareArticleSearchParameter search)
        {
            search.ArticleType = PublicEnum.ShareArticleTypeEnum.TuiGuangFangFaChuangShou;
            search.Page = 1;
            search.PageSize = 5;
            search.ReturnList = _shareArticleBll.Value.GetRecommendShareArticle(search);
            return View(search);
        }

        public ActionResult Add()
        {
            var msg = string.Empty;
            for (var i = 0; i < 10; i++)
            {
                var entity = new ShareArticleEntity()
                {
                    Title = "手把手教你运营" + i,
                    ArticleType = PublicEnum.ShareArticleTypeEnum.YunYinGanHuo,
                    ArticleUrl = "http://www.cnblogs.com/xrainchen/category/893050.html",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now
                };
                if (i % 2 == 0)
                {
                    entity.ArticleType = PublicEnum.ShareArticleTypeEnum.TuiGuangFangFaChuangShou;
                }
                msg += _shareArticleBll.Value.Add(entity) + ",";
            }
            return Content(msg);
        }
    }
}