using System;
using System.Web.Mvc;
using lltg._1688.rponey.cc.Auth;
using lltg._1688.rponey.cc.Bll;
using lltg._1688.rponey.cc.Model.Entity;
using lltg._1688.rponey.cc.Model.ViewModel;
using Rponey.AlbbSDK;
using Rponey.AlbbSDK.Model.ApiCommon;
using RPoney;
using RPoney.Utilty.Extend;

namespace lltg._1688.rponey.cc.Controllers
{
    public class BaseController : Controller
    {
        private Lazy<T_ProductUserTokenBll> _productUserTokenBll = new Lazy<T_ProductUserTokenBll>();
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
            if (result.UpdateTime.AddSeconds(result.ExpiresIn) < DateTime.Now.AddSeconds(-120))
            {
                return result;
            }
            //更新令牌
            GetTokenResultModel getToken = null;
            if (result.RefreshTokenTimeout < DateTime.Now.AddDays(-30))
            {
                getToken = ApiCommon.GetToken(AppConfigBll.AppConfig.AppKey, AppConfigBll.AppConfig.AppSecrect, result.RefreshToken, result.AccessToken);
            }
            else
            {
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
        }
    }
}