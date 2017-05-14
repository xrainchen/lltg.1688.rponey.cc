using Newtonsoft.Json;

namespace Rponey.AlbbSDK.Model.ApiProduct
{
    /// <summary>
    /// 商品扩展信息，国际站无需关注
    /// </summary>
    public class ProductExtendInfoModel
    {
        /// <summary>
        /// 扩展结构的key
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }
        /// <summary>
        /// 扩展结构的value
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}
