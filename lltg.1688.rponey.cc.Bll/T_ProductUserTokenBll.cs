using System;
using lltg._1688.rponey.cc.Dal;
using lltg._1688.rponey.cc.Model.Entity;

namespace lltg._1688.rponey.cc.Bll
{
    public class T_ProductUserTokenBll : EntityBll<T_ProductUserTokenEntity>
    {
        public T_ProductUserTokenBll() : base(new T_ProductUserTokenDal()) { }
        private readonly Lazy<T_ProductUserTokenDal> t_productUserDal = new Lazy<T_ProductUserTokenDal>();
        public bool Save(T_ProductUserTokenEntity model)
        {
            return t_productUserDal.Value.Save(model);
        }
    }
}
