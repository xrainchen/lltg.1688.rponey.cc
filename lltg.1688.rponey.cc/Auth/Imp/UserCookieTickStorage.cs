using System;
using System.Web;
using System.Web.Security;
using lltg._1688.rponey.cc.Bll;
using lltg._1688.rponey.cc.Model.ViewModel;
using Rponey.AlbbSDK.Utilty;

namespace lltg._1688.rponey.cc.Auth.Imp
{
    /// <summary>
    /// Cookie票据存储
    /// </summary>
    public class UserCookieTickStorage : ITicketStorage<ProductUserViewModel>
    {
        public void Cancellation()
        {
            FormsAuthentication.SignOut();
            if (HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                cookie.Expires = DateTime.Now.AddYears(-10);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }

            if (HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName + "Login"] != null)
            {
                var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName + "Login"];
                cookie.Expires = DateTime.Now.AddYears(-10);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        public ProductUserViewModel GetTicket()
        {
            if (HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                var cookie1 = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (cookie1 != null)
                {
                    var hash = cookie1.Value;
                    var ticket = FormsAuthentication.Decrypt(hash);
                    var user = ticket.UserData.DeserializeFromJson<ProductUserViewModel>();
                    if (user != null && user.Id > 0)
                        return user;
                }
                else
                {
                    var username = HttpContext.Current.User.Identity.Name;
                    var user = new ProductUserBll().GetProductUser(username);
                    SetTicket(user);
                    return user;
                }
            }
            HttpContext.Current.Response.Redirect(FormsAuthentication.LoginUrl);
            return null;
        }

        public void SetTicket(ProductUserViewModel model)
        {
            if (model == null) return;
            var cookieTime = DateTime.Now;
            var cookieExpiration = DateTime.Now.AddDays(1);
            var ticket = new FormsAuthenticationTicket(1, 
                model.ResourceOwner, cookieTime,
                cookieExpiration, true, model.SerializeToJson());
            var hash = FormsAuthentication.Encrypt(ticket);
            var cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
            HttpContext.Current.Response.Cookies.Add(cookie1);
        }
    }
}