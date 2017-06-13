using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using lltg._1688.rponey.cc.Model.Entity;
using lltg._1688.rponey.cc.Model.Search;
using Rponey.DbHelper;
using RPoney;

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
        public SystemDicEntity Get(long id)
        {
            var description = "根据主键获取系统字典配置";
            try
            {
                var sql = @"select TOP 1 * from  [dbo].[SystemDic](nolock) where [Id]=@id";
                var sqlParameter = new List<SqlParameter>{
                new SqlParameter("@id",SqlDbType.VarChar) {Value = id}
                };
                RPoney.Log.LoggerManager.Debug(GetType().Name, $"{description}sql:{sql},参数:id{id}");
                return RPoney.Data.ModelConvertHelper<SystemDicEntity>.ToModel(DataBaseManager.MainDb().ExecuteFillDataTable(sql, sqlParameter.ToArray()));
            }
            catch (Exception ex)
            {
                RPoney.Log.LoggerManager.Error(GetType().Name, $"{description}异常", ex);
                return null;
            }
        }
        public IList<SystemDicEntity> GetList(SearchParameter search)
        {
            var description = "获取全局配置列表";
            try
            {
                var tbName = "[SystemDic](nolock)";
                var filter = "*";
                var orderBy = "[key] asc";
                var where = "";
                var searchParameter = search as SystemDicSearchParameter;
                var sqlParameter = new List<SqlParameter>();
                if (null != searchParameter)
                {
                    if (!string.IsNullOrWhiteSpace(searchParameter.Key))
                    {
                        where += " and [key]=@key";
                        sqlParameter.Add(new SqlParameter("@key", SqlDbType.VarChar) { Value = searchParameter.Key });
                    }
                }
                var pageCount = DataBaseManager.GetCountString(tbName, where);
                RPoney.Log.LoggerManager.Debug(GetType().Name, $"{description}pageCount:{pageCount},参数:{search.SerializeToJSON()}");
                search.Count = DataBaseManager.MainDb().ExecuteScalar(pageCount, sqlParameter.ToArray()).CInt(0, false);
                if (search.Count > 0)
                {
                    var pageSql = DataBaseManager.GetPageString(tbName, filter, orderBy, where, search.Page, search.PageSize, search.IsAll);
                    RPoney.Log.LoggerManager.Debug(GetType().Name, $"{description}pageSql:{pageSql},参数:{search.SerializeToJSON()}");
                    return RPoney.Data.ModelConvertHelper<SystemDicEntity>.ToModels(DataBaseManager.MainDb().ExecuteFillDataTable(pageSql, sqlParameter.ToArray()));
                }
                return Enumerable.Empty<SystemDicEntity>().ToList();
            }
            catch (Exception ex)
            {
                RPoney.Log.LoggerManager.Error(GetType().Name, $"{description}异常", ex);
                return Enumerable.Empty<SystemDicEntity>().ToList();
            }
        }

        public bool Update(SystemDicEntity entity)
        {
            var description = "更新系统字典配置";
            try
            {
                var sql = @"update [SystemDic] set [Key]=@Key,[Value]=@Value,Description=@Description where Id=@Id";
                var sqlParameter = new List<SqlParameter>{
                new SqlParameter("@Id",SqlDbType.VarChar) {Value = entity.Id},
                new SqlParameter("@Key",SqlDbType.VarChar) {Value = entity.Key},
                new SqlParameter("@Value",SqlDbType.VarChar) {Value = entity.Value},
                new SqlParameter("@Description",SqlDbType.VarChar) {Value = entity.Description},
                };
                RPoney.Log.LoggerManager.Debug(GetType().Name, $"{description}sql:{sql},参数:{entity.SerializeToJSON()}");
                return DataBaseManager.MainDb().ExecuteNonQuery(sql, sqlParameter.ToArray()) > 0;
            }
            catch (Exception ex)
            {
                RPoney.Log.LoggerManager.Error(GetType().Name, $"{description}异常", ex);
                return false;
            }
        }
    }
}
