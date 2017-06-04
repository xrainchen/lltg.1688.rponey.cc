using System;
using System.Web.Mvc;
using lltg._1688.rponey.cc.Bll;
using lltg._1688.rponey.cc.Model;
using lltg._1688.rponey.cc.Model.Entity;
using lltg._1688.rponey.cc.Model.Search;

namespace lltg._1688.rponey.cc.Controllers
{
    public class ProductOrderController : BaseController
    {
        private readonly Lazy<ProductOrderBll> _productOrderBll = new Lazy<ProductOrderBll>();
        // GET: ProductOrder
        public ActionResult Add()
        {
            var msg = string.Empty;
            for (var i = 0; i < 10; i++)
            {
                msg += _productOrderBll.Value.Add(new ProductOrderEntity()
                {
                    ProductUserId = CurrentUser.Id,
                    BuyDateTime = DateTime.Now.AddDays(i),
                    ProductName = "精准流量推广",
                    Price = 5000,
                    Unit = "月",
                    GP = "三个月",
                    CreatedTime = DateTime.Now,
                    OrderType = (i % 2 == 0) ? PublicEnum.ProductOrderTypeEnum.Buy : PublicEnum.ProductOrderTypeEnum.Renewal
                }) + ",";
            }
            return Content(msg);
        }

        public ActionResult GetOrderList(ProductOrderSearchParameter search)
        {
            search.Page = 1;
            search.PageSize = 5;
            search.ReturnList = _productOrderBll.Value.GetOrderList(search);
            return View(search);
        }
    }
}