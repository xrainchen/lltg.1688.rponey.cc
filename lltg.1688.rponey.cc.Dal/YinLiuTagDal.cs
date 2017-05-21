using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using lltg._1688.rponey.cc.Model.Entity;
using Rponey.DbHelper;
using RPoney;

namespace lltg._1688.rponey.cc.Dal
{
    public class YinLiuTagDal
    {
        public long Add(YinLiuTagEntity model)
        {
            var description = "添加引流标签";
            try
            {
                var sql = @"INSERT INTO [dbo].[YinLiuTag]([Name],[Type],[ProductUserId],[Sort],[CreatedTime])
     VALUES(@Name,@Type,@ProductUserId,@Sort,@CreatedTime)";
                var parameter = new List<SqlParameter>
                {
                    new SqlParameter("@Name", SqlDbType.NVarChar) {Value = model.Name},
                    new SqlParameter("@Type", SqlDbType.Int) {Value = (int) model.Type},
                    new SqlParameter("@ProductUserId", SqlDbType.BigInt) {Value = model.ProductUserId},
                    new SqlParameter("@Sort", SqlDbType.Int) {Value = model.Sort},
                    new SqlParameter("@CreatedTime", SqlDbType.NVarChar) {Value = DateTime.Now}
                };
                return DataBaseManager.MainDb().ExecuteScalar(sql, parameter.ToArray()).CLong(0, false);
            }
            catch (Exception ex)
            {
                RPoney.Log.LoggerManager.Error(GetType().Name, $"{description}异常");
                return -1;
            }
        }
    }
}
