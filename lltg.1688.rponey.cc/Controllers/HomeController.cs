using System;
using System.Web.Mvc;
using lltg._1688.rponey.cc.Bll;
using lltg._1688.rponey.cc.Models;
using Rponey.AlbbSDK;

namespace lltg._1688.rponey.cc.Controllers
{
    public class HomeController : BaseController
    {
        private readonly Lazy<AdPlaceConfigBll> _adPlaceConfigBll = new Lazy<AdPlaceConfigBll>();
        // GET: Home
        public ActionResult Index(MainModel model)
        {
            model.User = CurrentUser;
            model.AdPlaceConfig = _adPlaceConfigBll.Value.GetOrInsert(CurrentUser.Id);
            return View(model);
        }

        [HttpPost]
        public ActionResult ProductList()
        {
            try
            {
                var token = GetProductUserToken();
                var productList = ApiProduct.GetList(token.AccessToken,
                    AppConfigBll.AppConfig.AppKey,
                    AppConfigBll.AppConfig.AppSecrect,
                    null,
                    1,
                    20,
                    null,
                    null);
                return Json(productList);
            }
            catch (Exception ex)
            {
                RPoney.Log.LoggerManager.Error(GetType().Name, "", ex);
                return new EmptyResult();
            }
        }

        [HttpPost]
        public ActionResult CategoryList()
        {
            try
            {
                var token = GetProductUserToken();
                var categoryList = ApiCategory.GetList(token.AccessToken,
                    AppConfigBll.AppConfig.AppKey,
                    AppConfigBll.AppConfig.AppSecrect,
                    0);
                return Json(categoryList);
            }
            catch (Exception ex)
            {
                RPoney.Log.LoggerManager.Error(GetType().Name, "", ex);
                return new EmptyResult();
            }
        }
    }
}