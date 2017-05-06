using System.Collections.Generic;
using lltg._1688.rponey.cc.Model.Entity;

namespace lltg._1688.rponey.cc.Dal
{
    #region 抽象层

    public abstract class EntityDal<T> : IEntityDal<T> where T : IEntity
    {
        public abstract bool Add(T entity);

        public abstract bool Update(T entity);

        public abstract IList<T> Get(T entity);
    }

    public abstract class IdentityDal<T> : EntityDal<T>, IIdentityDal<T> where T : IIdentityEntity
    {
        public abstract T Get(long id);
        public abstract bool Delete(long id);
        public abstract bool Exist(long id);
    }
    #endregion
}
