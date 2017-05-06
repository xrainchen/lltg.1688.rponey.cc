using lltg._1688.rponey.cc.Model.Entity;
using System.Collections.Generic;

namespace lltg._1688.rponey.cc.Dal
{
    #region 接口层
    /// <summary>
    /// 数据访问层基本接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityDal<T> where T : IEntity
    {
        bool Add(T entity);
        bool Update(T entity);
        IList<T> Get(T entity);
    }

    /// <summary>
    /// 唯一标识层
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IIdentityDal<T> : IEntityDal<T> where T : IEntity
    {
        T Get(long id);
        bool Delete(long id);
        bool Exist(long id);
    }
    #endregion
}
