using System;
using System.Web.Mvc;
using lltg._1688.rponey.cc.Auth;
using lltg._1688.rponey.cc.Bll;
using lltg._1688.rponey.cc.Model.ViewModel;

namespace lltg._1688.rponey.cc.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base

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