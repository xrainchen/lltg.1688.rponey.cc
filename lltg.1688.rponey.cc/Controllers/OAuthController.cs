using System;
using System.Web.Mvc;
using lltg._1688.rponey.cc.Auth;
using lltg._1688.rponey.cc.Bll;
using lltg._1688.rponey.cc.Model.Entity;
using lltg._1688.rponey.cc.Model.ViewModel;
using Rponey.AlbbSDK;
using RPoney;

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
            try
            {
                RPoney.Log.LoggerManager.Error(GetType().Name, $"进入授权回调处理,code:{code}");
                var config = new AppConfigBll().GetAppConfig(Request.Url.Host);
                var getToken = ApiCommon.GetToken(config.AppKey, config.AppSecrect, config.AppRediretUrl, code);
                if (null == getToken)
                {
                    return View("_Error");
                }
                var productUserToken = new T_ProductUserTokenEntity
                {
                    AliId = getToken.AliId,
                    MemberId = getToken.MemberId,
                    ResourceOwner = getToken.ResourceOwner,
                    AccessToken = getToken.AccessToken,
                    RefreshToken = getToken.RefreshToken,
                    ExpiresIn = getToken.ExpiresIn.CInt(0, false),
                    RefreshTokenTimeout = getToken.RefreshTokenTimeout.CDateTime(DateTime.MinValue),
                    UpdateTime = DateTime.Now
                };
                RPoney.Log.LoggerManager.Error(GetType().Name, $"进入授权回调处理,productUserToken:{productUserToken.SerializeToJSON()}");
                return Content(productUserToken.SerializeToJSON());
                if (new T_ProductUserTokenBll().Save(productUserToken))
                {
                    //todo:用户是否存在  存在更新 不存在新增 做登录处理 
                    var user = new ProductUserBll().GetProductUser(getToken.MemberId);
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
    }
}