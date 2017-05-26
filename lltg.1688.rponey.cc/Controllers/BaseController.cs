using System;
using System.Collections.Generic;
using System.Web.Mvc;
using lltg._1688.rponey.cc.Auth;
using lltg._1688.rponey.cc.Bll;
using lltg._1688.rponey.cc.Model.Entity;
using lltg._1688.rponey.cc.Model.ViewModel;
using lltg._1688.rponey.cc.Models;
using Rponey.AlbbSDK;
using Rponey.AlbbSDK.Model.ApiCommon;
using RPoney;
using RPoney.Utilty.Extend;

namespace lltg._1688.rponey.cc.Controllers
{
    public class BaseController : Controller
    {
        private Lazy<T_ProductUserTokenBll> _productUserTokenBll = new Lazy<T_ProductUserTokenBll>();
        private Lazy<NavBll> _navBll = new Lazy<NavBll>();
        private ProductUserViewModel _user;
        protected ProductUserViewModel CurrentUser
        {
            get
            {
                if (_user == null)
                {
                    var tick = TicketStorageFactory.InstanceTicketStorage<ProductUserViewModel>();
                    _user = tick.GetTicket();
                    if (User.Identity.IsAuthenticated)
                    {
                        var username = User.Identity.Name;
                        _user = new ProductUserBll().GetProductUser(username);
                        tick.SetTicket(_user);
                    }
                }
                return _user;
            }
            set
            {
                _user = value;
                var tick = TicketStorageFactory.InstanceTicketStorage<ProductUserViewModel>();
                tick.SetTicket(_user);
            }
        }

        protected T_ProductUserTokenEntity GetProductUserToken()
        {
            var result = _productUserTokenBll.Value.GetByResourceOwner(CurrentUser.ResourceOwner);
            if (null == result)
                throw new Exception($"用户{CurrentUser.ResourceOwner}令牌信息不存在");
            if (result.UpdateTime.AddSeconds(result.ExpiresIn) > DateTime.Now.AddSeconds(-120))
            {
                return result;
            }
            //更新令牌
            GetTokenResultModel getToken = null;
            if (result.RefreshTokenTimeout.AddDays(-30) < DateTime.Now)
            {
                RPoney.Log.LoggerManager.Debug(GetType().Name, "更新刷新令牌");
                getToken = ApiCommon.GetToken(AppConfigBll.AppConfig.AppKey, AppConfigBll.AppConfig.AppSecrect, result.RefreshToken, result.AccessToken);
            }
            else
            {
                RPoney.Log.LoggerManager.Debug(GetType().Name, "使用刷新令牌换取accesstoken");
                getToken = ApiCommon.GetTokenByRefreshToKen(AppConfigBll.AppConfig.AppKey, AppConfigBll.AppConfig.AppSecrect, result.RefreshToken);
            }
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
            if (_productUserTokenBll.Value.Save(productUserToken))
            {
                return productUserToken;
            }
            return null;
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException(nameof(filterContext));
            }
            var inherit = true;
            if (!filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit) &&
                !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit))
            {
                if (CurrentUser == null)
                {
                    //无效用户
                    filterContext.Result = View("_NoPower");
                }
            }

            if (null != CurrentUser)
            {
                var controllerName = filterContext.RouteData.Values["controller"].ToString();
                var model = new FrameModel()
                {
                    CurrentUser = CurrentUser
                };
                var siteInfo = new SiteInfo()
                {
                    Name="精准站外流量推广",
                    Company="一七互动网络有限公司"

                };
                model.Navs = _navBll.Value.GetNavList(CurrentUser.Id);
                model.Site = siteInfo;
                ViewBag.Farame = model;
            }
        }


    }
}