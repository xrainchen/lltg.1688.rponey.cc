using System.Collections.Generic;
using Newtonsoft.Json;

namespace Rponey.AlbbSDK.Model.ApiProduct
{
    public class GetProductListResultModel
    {
        /// <summary>
        /// 商品列表
        /// </summary>
        [JsonProperty(PropertyName = "productInfos")]
        public IList<ProductInfoModel> ProductInfos { get; set; }
        /// <summary>
        /// 总条数
        /// </summary>
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        [JsonProperty(PropertyName = "currentPage")]
        public int CurrentPage { get; set; }
        /// <summary>
        /// 每页大小
        /// </summary>
        [JsonProperty(PropertyName = "pageSize")]
        public int PageSize { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        [JsonProperty(PropertyName = "errorMsg")]
        public string ErrorMsg { get; set; }
    }
}
