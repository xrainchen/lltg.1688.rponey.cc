using System;
using System.Web.Mvc;
using lltg._1688.rponey.cc.Auth;
using lltg._1688.rponey.cc.Bll;
using lltg._1688.rponey.cc.Model.Entity;
using lltg._1688.rponey.cc.Model.ViewModel;
using Rponey.AlbbSDK;
using RPoney;
using RPoney.Utilty.Extend;

namespace lltg._1688.rponey.cc.Controllers
{
    public class OAuthController : Controller
    {
        // GET: OAuth

        /// <summary>
        /// 授权回调入口 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public ActionResult Index(string code)
        {
            RPoney.Log.LoggerManager.Debug(GetType().Name, $"授权回调处理,code:{code}");
            try
            {
                var getToken = ApiCommon.GetToken(AppConfigBll.AppConfig.AppKey, AppConfigBll.AppConfig.AppSecrect, AppConfigBll.AppConfig.AppRediretUrl, code);
                if (null == getToken)
                {
                    return View("_Error");
                }
                RPoney.Log.LoggerManager.Debug(GetType().Name, $"查找商家token:{getToken.SerializeToJSON()}");
                var productUserToken = new T_ProductUserTokenEntity
                {
                    AliId = getToken.AliId,
                    MemberId = getToken.MemberId,
                    ResourceOwner = getToken.ResourceOwner,
                    AccessToken = getToken.AccessToken,
                    RefreshToken = getToken.RefreshToken,
                    ExpiresIn = getToken.ExpiresIn.CInt(0, false),
                    RefreshTokenTimeout = getToken.RefreshTokenTimeout.GetDateTimeFromUtc(DateTime.MinValue),
                    UpdateTime = DateTime.Now
                };
                RPoney.Log.LoggerManager.Debug(GetType().Name, $"进入授权回调处理,productUserToken:{productUserToken.SerializeToJSON()}");
                if (new T_ProductUserTokenBll().Save(productUserToken))
                {
                    var productUserBll = new ProductUserBll();
                    var user = productUserBll.GetProductUser(getToken.ResourceOwner);
                    if (null == user)
                    {
                        productUserBll.Add(new ProductUserEntity() { ResourceOwner = getToken.ResourceOwner });
                        user = productUserBll.GetProductUser(getToken.ResourceOwner);
                    }
                    if (null != user)
                    {
                        TicketStorageFactory.InstanceTicketStorage<ProductUserViewModel>().SetTicket(user);
                    }
                    return RedirectToAction("Index", "Home");
                }
                RPoney.Log.LoggerManager.Debug(GetType().Name, $"保存授权信息失败,code:{code}");
                return View("_Error");
            }
            catch (Exception ex)
            {
                RPoney.Log.LoggerManager.Error(GetType().Name, $"授权回调出错,code:{code}", ex);
                return View("_Error");
            }
        }


        public ActionResult Login()
        {
            var user = new ProductUserViewModel()
            {
                Id = 1,
                ResourceOwner = "xrainchen"
            };
            TicketStorageFactory.InstanceTicketStorage<ProductUserViewModel>().SetTicket(user);
            return RedirectToAction("Index", "Home");
        }
    }
}