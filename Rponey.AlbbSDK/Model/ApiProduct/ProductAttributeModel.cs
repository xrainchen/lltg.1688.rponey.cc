using Newtonsoft.Json;

namespace Rponey.AlbbSDK.Model.ApiProduct
{
    /// <summary>
    /// 产品属性模型
    /// </summary>
    public class ProductAttributeModel
    {
        /// <summary>
        /// 属性ID
        /// </summary>
        [JsonProperty(PropertyName = "attributeID")]
        public long AttributeId { get; set; }

        /// <summary>
        /// 属性名称
        /// </summary>
        [JsonProperty(PropertyName = "attributeName")]
        public string AttributeName { get; set; }

        /// <summary>
        /// 属性值ID
        /// </summary>
        [JsonProperty(PropertyName = "valueID")]
        public long ValueId { get; set; }

        /// <summary>
        /// 属性值
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// 是否为自定义属性，国际站无需关注
        /// </summary>
        [JsonProperty(PropertyName = "isCustom")]
        public bool IsCustom { get; set; }
    }
}
