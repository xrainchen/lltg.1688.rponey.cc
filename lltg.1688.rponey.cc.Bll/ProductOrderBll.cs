using System;
using System.Collections.Generic;
using lltg._1688.rponey.cc.Dal;
using lltg._1688.rponey.cc.Model.Entity;
using lltg._1688.rponey.cc.Model.Search;
using lltg._1688.rponey.cc.Model.ViewModel;

namespace lltg._1688.rponey.cc.Bll
{
    public class ProductOrderBll
    {
        private readonly Lazy<ProductOrderDal> _productOrderDal = new Lazy<ProductOrderDal>();
        public long Add(ProductOrderEntity model)
        {
            return _productOrderDal.Value.Add(model);
        }

        public IList<ProductOrderViewModel> GetOrderList(SearchParameter search)
        {
            return _productOrderDal.Value.GetOrderList(search);
        }
    }
}
