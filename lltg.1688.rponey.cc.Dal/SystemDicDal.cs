using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using lltg._1688.rponey.cc.Model.Entity;
using Rponey.DbHelper;

namespace lltg._1688.rponey.cc.Dal
{
    public class SystemDicDal
    {
        public SystemDicEntity Get(string key)
        {
            var description = "获取系统字典配置";
            try
            {
                var sql = @"select TOP 1 * from  [dbo].[SystemDic](nolock) where [key]=@key";
                var sqlParameter = new List<SqlParameter>{
                new SqlParameter("@key",SqlDbType.VarChar) {Value = key}
                };
                RPoney.Log.LoggerManager.Debug(GetType().Name, $"{description}sql:{sql},参数:key{key}");
                return RPoney.Data.ModelConvertHelper<SystemDicEntity>.ToModel(DataBaseManager.MainDb().ExecuteFillDataTable(sql, sqlParameter.ToArray()));
            }
            catch (Exception ex)
            {
                RPoney.Log.LoggerManager.Error(GetType().Name, $"{description}异常", ex);
                return null;
            }
        }
    }
}
