using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using lltg._1688.rponey.cc.Model.Entity;
using lltg._1688.rponey.cc.Model.Search;
using lltg._1688.rponey.cc.Model.ViewModel;
using Rponey.DbHelper;
using RPoney;
using RPoney.Data.SqlClient;

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
     VALUES(@Name,@Type,@ProductUserId,@Sort,@CreatedTime);select @@IDENTITY;";
                var parameter = new List<SqlParameter>
                {
                    new SqlParameter("@Name", SqlDbType.NVarChar) {Value = model.Name},
                    new SqlParameter("@Type", SqlDbType.Int) {Value = (int) model.Type},
                    new SqlParameter("@ProductUserId", SqlDbType.BigInt) {Value = model.ProductUserId},
                    new SqlParameter("@Sort", SqlDbType.Int) {Value = model.Sort},
                    new SqlParameter("@CreatedTime", SqlDbType.DateTime) {Value = DateTime.Now}
                };
                return DataBaseManager.MainDb().ExecuteScalar(sql, parameter.ToArray()).CLong(0, false);
            }
            catch (Exception ex)
            {
                RPoney.Log.LoggerManager.Error(GetType().Name, $"{description}异常",ex);
                return -1;
            }
        }
        public bool Update(YinLiuTagEntity model)
        {
            var description = "更新引流标签";
            try
            {
                var sql = @"UPDATE [dbo].[YinLiuTag] 
SET [Name]=@Name,[Type]=Type,[ProductUserId]=@ProductUserId,[Sort]=@Sort,[CreatedTime]=@CreatedTime
Where Id=@Id
";
                var parameter = new List<SqlParameter>
                {
                    new SqlParameter("@Id", SqlDbType.BigInt) {Value = model.Id},
                    new SqlParameter("@Name", SqlDbType.NVarChar) {Value = model.Name},
                    new SqlParameter("@Type", SqlDbType.Int) {Value = (int) model.Type},
                    new SqlParameter("@ProductUserId", SqlDbType.BigInt) {Value = model.ProductUserId},
                    new SqlParameter("@Sort", SqlDbType.Int) {Value = model.Sort},
                    new SqlParameter("@CreatedTime", SqlDbType.DateTime) {Value = model.CreatedTime}
                };
                return DataBaseManager.MainDb().ExecuteNonQuery(sql, parameter.ToArray()) > 0;
            }
            catch (Exception ex)
            {
                RPoney.Log.LoggerManager.Error(GetType().Name, $"{description}异常",ex);
                return false;
            }
        }
        public IList<YinLiuTagViewModel> GetList(SearchParameter search)
        {
            var description = "获取系统标签";
            try
            {
                var searchParameter = search as YinLiuTagSerachParameter;
                if (searchParameter != null)
                {
                    var tbName = "YinLiuTag(nolock) ylt";
                    var filter = "ylt.*";
                    var where = "";
                    var orderBy = "ylt.Type asc,ylt.CreatedTime desc";
                    var sqlParameter = new List<SqlParameter>();
                    var sqlCount = DataBaseManager.GetCountString(tbName,where);
                    RPoney.Log.LoggerManager.Debug(GetType().Name, $"{description}sqlCount:{sqlCount},参数:{searchParameter.SerializeToJSON()}");
                    searchParameter.Count = DataBaseManager.MainDb().ExecuteScalar(sqlCount, sqlParameter.ToArray()).CInt(0, false);
                    if (searchParameter.Count <= 0)
                    {
                        RPoney.Log.LoggerManager.Debug(GetType().Name, $"{description}查找总数为0,参数:{searchParameter.SerializeToJSON()}");
                        return null;
                    }
                    var sql = DataBaseManager.GetPageString(tbName, filter, orderBy, where, searchParameter.Page, searchParameter.PageSize, searchParameter.IsAll);
                    RPoney.Log.LoggerManager.Debug(GetType().Name, $"{description}sql:{sql},参数:{searchParameter.SerializeToJSON()}");
                    return RPoney.Data.ModelConvertHelper<YinLiuTagViewModel>.ToModels(DataBaseManager.MainDb().ExecuteFillDataTable(sql, sqlParameter.ToArray()));
                }

                return null;
            }
            catch (Exception ex)
            {
                RPoney.Log.LoggerManager.Error(GetType().Name, $"{description}异常", ex);
                return null;
            }
        }
        public YinLiuTagEntity Get(long id)
        {
            var description = "获取系统标签";
            try
            {
                var tbName = "YinLiuTag(nolock) ylt";
                var filter = "ylt.*";
                var where = "ylt.Id=@Id";
                var sqlParameter = new List<SqlParameter> { new SqlParameter("@Id", SqlDbType.BigInt) { Value = id } };
                var sql = $"select top 1 {filter} from {tbName} where {where}";
                RPoney.Log.LoggerManager.Debug(GetType().Name, $"{description}sql:{sql},参数:id{id}");
                return RPoney.Data.ModelConvertHelper<YinLiuTagEntity>.ToModel(DataBaseManager.MainDb().ExecuteFillDataTable(sql, sqlParameter.ToArray()));
            }
            catch (Exception ex)
            {
                RPoney.Log.LoggerManager.Error(GetType().Name, $"{description}异常", ex);
                return null;
            }
        }
        public YinLiuTagViewModel GetView(long id)
        {
            var description = "获取系统标签视图";
            try
            {
                var tbName = "YinLiuTag(nolock) ylt";
                var filter = "ylt.*";
                var where = "ylt.Id=@Id";
                var sqlParameter = new List<SqlParameter> { new SqlParameter("@Id", SqlDbType.BigInt) { Value = id } };
                var sql = $"select top 1 {filter} from {tbName} where {where}";
                RPoney.Log.LoggerManager.Debug(GetType().Name, $"{description}sql:{sql},参数:id{id}");
                return RPoney.Data.ModelConvertHelper<YinLiuTagViewModel>.ToModel(DataBaseManager.MainDb().ExecuteFillDataTable(sql, sqlParameter.ToArray()));
            }
            catch (Exception ex)
            {
                RPoney.Log.LoggerManager.Error(GetType().Name, $"{description}异常", ex);
                return null;
            }
        }
    }
}
