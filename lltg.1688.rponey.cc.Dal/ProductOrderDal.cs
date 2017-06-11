using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using lltg._1688.rponey.cc.Model.Entity;
using lltg._1688.rponey.cc.Model.Search;
using lltg._1688.rponey.cc.Model.ViewModel;
using Rponey.DbHelper;
using RPoney;

namespace lltg._1688.rponey.cc.Dal
{
    public class ProductOrderDal
    {
        public long Add(ProductOrderEntity model)
        {
            var description = "添加产品订单";
            try
            {
                var sql = @"INSERT INTO [dbo].[ProductOrder]([ProductUserId],[BuyDateTime],[ProductName],[Price],[Unit],[GP],[CreatedTime],[OrderType])
Values(@ProductUserId,@BuyDateTime,@ProductName,@Price,@Unit,@GP,@CreatedTime,@OrderType);select @@Identity;";
                var sqlParameter = new List<SqlParameter>{
                new SqlParameter("@ProductUserId",SqlDbType.BigInt) {Value = model.ProductUserId},
                new SqlParameter("@BuyDateTime",SqlDbType.DateTime) {Value = model.BuyDateTime},
                new SqlParameter("@ProductName",SqlDbType.NVarChar) {Value = model.ProductName},
                new SqlParameter("@Price",SqlDbType.Decimal) {Value = model.Price},
                new SqlParameter("@Unit",SqlDbType.NVarChar) {Value = model.Unit},
                new SqlParameter("@GP",SqlDbType.NVarChar) {Value = model.GP},
                new SqlParameter("@CreatedTime",SqlDbType.DateTime) {Value = model.CreatedTime},
                new SqlParameter("@OrderType",SqlDbType.Int) {Value = (int)model.OrderType},
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

        public IList<ProductOrderViewModel> GetOrderList(SearchParameter search)
        {
            var description = "前台获取订购/续费动态列表";
            try
            {
                var tbName = "ProductOrder(nolock) po left join ProductUser(nolock) pu on po.ProductUserId=pu.Id";
                var filter = "po.*,pu.ResourceOwner as ProductUserName";
                var where = "";
                var orderBy = " po.BuyDateTime desc";
                var searchPara = search as ProductOrderSearchParameter;
                var sqlParameter = new List<SqlParameter>();
                var pageCount = DataBaseManager.GetCountString(tbName, where);
                RPoney.Log.LoggerManager.Debug(GetType().Name, $"{description}pageCount:{pageCount},参数:{search.SerializeToJSON()}");
                search.Count = DataBaseManager.MainDb().ExecuteScalar(pageCount, sqlParameter.ToArray()).CInt(0, false);
                if (search.Count > 0)
                {
                    var pageSql = DataBaseManager.GetPageString(tbName, filter, orderBy, where, search.Page, search.PageSize);
                    RPoney.Log.LoggerManager.Debug(GetType().Name, $"{description}pageSql:{pageSql},参数:{search.SerializeToJSON()}");
                    return RPoney.Data.ModelConvertHelper<ProductOrderViewModel>.ToModels(DataBaseManager.MainDb().ExecuteFillDataTable(pageSql, sqlParameter.ToArray()));
                }
                return Enumerable.Empty<ProductOrderViewModel>().ToList();
            }
            catch (Exception ex)
            {
                RPoney.Log.LoggerManager.Error(GetType().Name, $"{description}异常", ex);
                return Enumerable.Empty<ProductOrderViewModel>().ToList();
            }
        }

        /// <summary>
        /// 后台
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public IList<ProductOrderViewModel> GetList(SearchParameter search)
        {
            var description = "后台获取订购/续费动态列表";
            try
            {
                var tbName = "ProductOrder(nolock) po left join ProductUser(nolock) pu on po.ProductUserId=pu.Id";
                var filter = "po.*,pu.ResourceOwner as ProductUserName";
                var where = "";
                var orderBy = " po.BuyDateTime desc";
                var searchPara = search as ProductOrderSearchParameter;
                var sqlParameter = new List<SqlParameter>();
                if (searchPara != null)
                {
                    if (!string.IsNullOrWhiteSpace(searchPara.ProductUserName))
                    {
                        where += " and pu.ResourceOwner like @ProductUserName";
                        sqlParameter.Add(new SqlParameter("@ProductUserName", SqlDbType.NVarChar) {Value = $"%{searchPara.ProductUserName}%"});
                    }
                }
                var pageCount = DataBaseManager.GetCountString(tbName, where);
                RPoney.Log.LoggerManager.Debug(GetType().Name, $"{description}pageCount:{pageCount},参数:{search.SerializeToJSON()}");
                search.Count = DataBaseManager.MainDb().ExecuteScalar(pageCount, sqlParameter.ToArray()).CInt(0, false);
                if (search.Count > 0)
                {
                    var pageSql = DataBaseManager.GetPageString(tbName, filter, orderBy, where, search.Page, search.PageSize);
                    RPoney.Log.LoggerManager.Debug(GetType().Name, $"{description}pageSql:{pageSql},参数:{search.SerializeToJSON()}");
                    return RPoney.Data.ModelConvertHelper<ProductOrderViewModel>.ToModels(DataBaseManager.MainDb().ExecuteFillDataTable(pageSql, sqlParameter.ToArray()));
                }
                return Enumerable.Empty<ProductOrderViewModel>().ToList();
            }
            catch (Exception ex)
            {
                RPoney.Log.LoggerManager.Error(GetType().Name, $"{description}异常", ex);
                return Enumerable.Empty<ProductOrderViewModel>().ToList();
            }
        }
    }
}
