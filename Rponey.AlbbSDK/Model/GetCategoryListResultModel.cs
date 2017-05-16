using System.Collections.Generic;
using Newtonsoft.Json;
using Rponey.AlbbSDK.Model.Category;

namespace Rponey.AlbbSDK.Model
{
    /// <summary>
    /// 类目列表
    /// </summary>
    public class GetCategoryListResultModel
    {
        /// <summary>
        /// 类目列表
        /// </summary>
        [JsonProperty(PropertyName = "categoryInfo")]
        public IList<CategoryInfoModel> CategoryInfo { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        [JsonProperty(PropertyName = "errorMsg")]
        public string ErrorMsg { get; set; }
    }
}
