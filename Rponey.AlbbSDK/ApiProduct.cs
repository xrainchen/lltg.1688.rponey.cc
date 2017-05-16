using System.Collections.Generic;
using Rponey.AlbbSDK.Model.ApiProduct;

namespace Rponey.AlbbSDK
{
    public class ApiProduct
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId">类目ID，国际站传入-1，返回所有商品列表</param>
        /// <param name="pageNo">页码。取值范围:大于零的整数;默认值为1，即返回第一页数据。</param>
        /// <param name="pageSize">返回列表结果集每页条数。取值范围:大于零的整数;最大值：30;</param>
        /// <param name="timeStamp">格式:yyyy-MM-dd HH:mm:ss；1、如果传了时间戳参数，则按增量返回，即返回按指定获取条件且对应商品信息的最近更新时间(GMTModified)晚于该时间戳的商品列表信息。2、如果没有传时间戳参数，则取所有的满足条件的商品信息。1688的时间目前只能支持精确到天。</param>
        /// <param name="webSite">站点信息，指定调用的API是属于国际站（alibaba）还是1688网站（1688）</param>
        /// <param name="endTimeStamp">格式:yyyy-MM-dd HH:mm:ss；1、如果传了时间戳参数，则按增量返回，即返回按指定获取条件且对应商品信息的最近更新时间(GMTModified)早于该时间戳的商品列表信息。2、如果没有传时间戳参数，则取所有的满足条件的商品信息。</param>
        /// <param name="accesstoken"></param>
        /// <param name="appKey"></param>
        /// <param name="appSecret"></param>
        /// <returns></returns>
        public static GetProductListResultModel GetList(string accesstoken, string appKey, string appSecret, long? categoryId, int pageNo, int pageSize, string timeStamp, string endTimeStamp, string webSite = "1688")
        {
            var dic = new Dictionary<string, object>();
            if (categoryId.HasValue)
                dic.Add("categoryId", categoryId);
            dic.Add("pageNo", pageNo);
            dic.Add("pageSize", pageSize);
            if (!string.IsNullOrWhiteSpace(timeStamp))
            {
                dic.Add("timeStamp", timeStamp);
            }
            if (!string.IsNullOrWhiteSpace(timeStamp))
            {
                dic.Add("endTimeStamp", endTimeStamp);
            }
            dic.Add("webSite", webSite);
            return ApiFacade.GetPostResult<GetProductListResultModel>(accesstoken, appKey, appSecret, dic, "com.alibaba.product", "alibaba.product.getList");
        }
    }
}
