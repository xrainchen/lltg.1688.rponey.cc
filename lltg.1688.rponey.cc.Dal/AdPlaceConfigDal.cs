using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using lltg._1688.rponey.cc.Model.Entity;
using Rponey.DbHelper;
using RPoney;

namespace lltg._1688.rponey.cc.Dal
{
    public class AdPlaceConfigDal
    {
        public long Add(AdPlaceConfigEntity model)
        {
            var description = "添加广告位配置";
            try
            {
                var sql = @"INSERT INTO [dbo].[AdPlaceConfig]([ProductUserId],[Total],[Remain]) Values(@ProductUserId,@Total,@Remain);select @@Identity;";
                var sqlParameter = new List<SqlParameter>{
                new SqlParameter("@ProductUserId",SqlDbType.BigInt) {Value = model.ProductUserId},
                new SqlParameter("@Total",SqlDbType.Int) {Value = model.Total},
                new SqlParameter("@Remain",SqlDbType.Int) {Value = model.Remain}};
                RPoney.Log.LoggerManager.Debug(GetType().Name, $"{description}sql:{sql},参数:model{model.SerializeToJSON()}");
                return DataBaseManager.MainDb().ExecuteScalar(sql, sqlParameter.ToArray()).CLong(0, false);
            }
            catch (Exception ex)
            {
                RPoney.Log.LoggerManager.Error(GetType().Name, $"{description}异常", ex);
                return -1;
            }
        }
        public AdPlaceConfigEntity Get(long productUserId)
        {
            var description = "获取广告位配置";
            try
            {
                var sql = @"select TOP 1 * from  [dbo].[AdPlaceConfig](nolock) where ProductUserId=@ProductUserId";
                var sqlParameter = new List<SqlParameter>{
                new SqlParameter("@ProductUserId",SqlDbType.BigInt) {Value = productUserId}
                };
                RPoney.Log.LoggerManager.Debug(GetType().Name, $"{description}sql:{sql},参数:productUserId{productUserId}");
                return RPoney.Data.ModelConvertHelper<AdPlaceConfigEntity>.ToModel(DataBaseManager.MainDb().ExecuteFillDataTable(sql, sqlParameter.ToArray()));
            }
            catch (Exception ex)
            {
                RPoney.Log.LoggerManager.Error(GetType().Name, $"{description}异常", ex);
                return null;
            }
        }
    }
}
