using System;
using System.Web.Mvc;
using lltg._1688.rponey.cc.Bll;
using lltg._1688.rponey.cc.Model.Search;

namespace admin.lltg._1688.rponey.cc.Controllers
{
    public class ProductOrderController : BaseController
    {
        private readonly Lazy<ProductOrderBll> _productOrderBll = new Lazy<ProductOrderBll>();
        // GET: ProductOrder
        public ActionResult List(ProductOrderSearchParameter search)
        {
            search.ReturnList = _productOrderBll.Value.GetList(search);
            return View(search);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }
    }
}