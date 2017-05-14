using Newtonsoft.Json;

namespace Rponey.AlbbSDK.Model.ApiProduct
{
    /// <summary>
    /// SKU属性信息
    /// </summary>
    public class SkuAttrInfoModel
    {
        /// <summary>
        /// sku属性ID
        /// </summary>
        [JsonProperty(PropertyName = "attributeId")]
        public long AttributeId { get; set; }
        /// <summary>
        /// sku值ID，1688不用关注
        /// </summary>
        [JsonProperty(PropertyName = "attValueId")]
        public long AttValueId { get; set; }
        /// <summary>
        /// sku值内容，国际站不用关注
        /// </summary>
        [JsonProperty(PropertyName = "attributeValue")]
        public string AttributeValue { get; set; }
        /// <summary>
        /// 自定义属性值名称，1688无需关注
        /// </summary>
        [JsonProperty(PropertyName = "customValueName")]
        public string CustomValueName { get; set; }
        /// <summary>
        /// sku图片
        /// </summary>
        [JsonProperty(PropertyName = "skuImageUrl")]
        public string SkuImageUrl { get; set; }
    }
}
