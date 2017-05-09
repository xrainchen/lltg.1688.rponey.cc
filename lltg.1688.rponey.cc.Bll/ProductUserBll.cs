using System;
using lltg._1688.rponey.cc.Dal;
using lltg._1688.rponey.cc.Model.Entity;
using lltg._1688.rponey.cc.Model.ViewModel;

namespace lltg._1688.rponey.cc.Bll
{
    public class ProductUserBll
    {
        private readonly Lazy<ProductUserDal> _productUserDal = new Lazy<ProductUserDal>();
        public ProductUserViewModel GetProductUser(string resourceOwner)
        {
            return _productUserDal.Value.GetProductUser(resourceOwner);
        }

        public bool Add(ProductUserEntity entity)
        {
            return _productUserDal.Value.Add(entity);
        }
    }
}
