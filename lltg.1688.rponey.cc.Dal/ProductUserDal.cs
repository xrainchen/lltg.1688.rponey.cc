using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using lltg._1688.rponey.cc.Model.Entity;
using lltg._1688.rponey.cc.Model.ViewModel;

namespace lltg._1688.rponey.cc.Dal
{
    public class ProductUserDal
    {
        public ProductUserViewModel GetProductUser(string resourceOwner)
        {
            var description = "获取用户";
            try
            {
                var sql = "select * from ProductUser(nolock) where ResourceOwner=@ResourceOwner";
                var para = new List<SqlParameter>
            {
                new SqlParameter("@ResourceOwner", resourceOwner)
            };
                return RPoney.Data.ModelConvertHelper<ProductUserViewModel>.ToModel(Rponey.DbHelper.DataBaseManager.MainDb().ExecuteFillDataTable(sql, para.ToArray()));
            }
            catch (Exception ex)
            {
                RPoney.Log.LoggerManager.Error(GetType().Name, $"{description}异常", ex);
                return null;
            }
        }

        public bool Add(ProductUserEntity entity)
        {
            var description = "添加用户";
            try
            {
                var sql = "insert into ProductUser(ResourceOwner) values(@ResourceOwner)";
                var para = new List<SqlParameter>
            {
                new SqlParameter("@ResourceOwner", entity.ResourceOwner)
            };
                return Rponey.DbHelper.DataBaseManager.MainDb().ExecuteNonQuery(sql, para.ToArray()) > 0;
            }
            catch (Exception ex)
            {
                RPoney.Log.LoggerManager.Error(GetType().Name, $"{description}异常", ex);
                return false;
            }
        }
    }
}
