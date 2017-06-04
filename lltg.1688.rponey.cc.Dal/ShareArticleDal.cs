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
    public class ShareArticleDal
    {
        public long Add(ShareArticleEntity model)
        {
            var description = "添加分享文章";
            try
            {
                var sql = @"INSERT INTO [dbo].[ShareArticle]([Title],[ArticleUrl],[ArticleType],[CreatedTime],[UpdatedTime],[Cover])
Values(@Title,@ArticleUrl,@ArticleType,@CreatedTime,@UpdatedTime,@Cover);select @@Identity;";
                var sqlParameter = new List<SqlParameter>{
                new SqlParameter("@Title",SqlDbType.NVarChar) {Value = model.Title},
                new SqlParameter("@ArticleUrl",SqlDbType.NVarChar) {Value = model.ArticleUrl},
                new SqlParameter("@ArticleType",SqlDbType.Int) {Value = model.ArticleType},
                new SqlParameter("@CreatedTime",SqlDbType.DateTime) {Value = model.CreatedTime},
                new SqlParameter("@UpdatedTime",SqlDbType.DateTime) {Value = model.UpdatedTime},
                new SqlParameter("@Cover",SqlDbType.NVarChar) {Value = model.Cover},
                };
                RPoney.Log.LoggerManager.Debug(GetType().Name, $"{description}sql:{sql},参数:model{model.SerializeToJSON()}");
                return DataBaseManager.MainDb().ExecuteScalar(sql, sqlParameter.ToArray()).CLong(0, false);
            }
            catch (Exception ex)
            {
                RPoney.Log.LoggerManager.Error(GetType().Name, $"{description}异常", ex);
                return -1;
            }
        }
        public IList<ShareArticleEntity> GetList(SearchParameter search)
        {
            var description = "获取分享文章列表";
            try
            {
                var tbName = "ShareArticle(nolock) sa";
                var filter = "sa.*";
                var where = "";
                var orderBy = " UpdatedTime desc";
                var sqlParameter = new List<SqlParameter>();
                var pageCount = DataBaseManager.GetCountString(tbName, where);
                RPoney.Log.LoggerManager.Debug(GetType().Name, $"{description}pageCount:{pageCount},参数:{search.SerializeToJSON()}");
                search.Count = DataBaseManager.MainDb().ExecuteScalar(pageCount, sqlParameter.ToArray()).CInt(0, false);
                if (search.Count > 0)
                {
                    var pageSql = DataBaseManager.GetPageString(tbName, filter, orderBy, where, search.Page, search.PageSize, search.IsAll);
                    RPoney.Log.LoggerManager.Debug(GetType().Name, $"{description}pageSql:{pageSql},参数:{search.SerializeToJSON()}");
                    return RPoney.Data.ModelConvertHelper<ShareArticleEntity>.ToModels(DataBaseManager.MainDb().ExecuteFillDataTable(pageSql, sqlParameter.ToArray()));
                }
                return Enumerable.Empty<ShareArticleEntity>().ToList();
            }
            catch (Exception ex)
            {
                RPoney.Log.LoggerManager.Error(GetType().Name, $"{description}异常", ex);
                return Enumerable.Empty<ShareArticleEntity>().ToList();
            }
        }

        public IList<ShareArticleEntity> GetRecommendShareArticle(SearchParameter search)
        {
            var description = "获取推荐分享文章";
            try
            {
                var tbName = "ShareArticle(nolock) sa";
                var filter = "sa.*";
                var where = "";
                var orderBy = " UpdatedTime desc";
                var searchPara = search as ShareArticleSearchParameter;
                var sqlParameter = new List<SqlParameter>();
                if (searchPara.ArticleType.HasValue)
                {
                    sqlParameter.Add(new SqlParameter("@ArticleType", SqlDbType.Int) { Value = (int)searchPara.ArticleType });
                }
                var pageCount = DataBaseManager.GetCountString(tbName, where);
                RPoney.Log.LoggerManager.Debug(GetType().Name, $"{description}pageCount:{pageCount},参数:{search.SerializeToJSON()}");
                search.Count = DataBaseManager.MainDb().ExecuteScalar(pageCount, sqlParameter.ToArray()).CInt(0, false);
                if (search.Count > 0)
                {
                    var pageSql = DataBaseManager.GetPageString(tbName, filter, orderBy, where, search.Page, search.PageSize);
                    RPoney.Log.LoggerManager.Debug(GetType().Name, $"{description}pageSql:{pageSql},参数:{search.SerializeToJSON()}");
                    return RPoney.Data.ModelConvertHelper<ShareArticleEntity>.ToModels(DataBaseManager.MainDb().ExecuteFillDataTable(pageSql, sqlParameter.ToArray()));
                }
                return Enumerable.Empty<ShareArticleEntity>().ToList();
            }
            catch (Exception ex)
            {
                RPoney.Log.LoggerManager.Error(GetType().Name, $"{description}异常", ex);
                return Enumerable.Empty<ShareArticleEntity>().ToList();
            }
        }
    }
}
