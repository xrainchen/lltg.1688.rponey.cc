using System.Collections.Generic;
using Newtonsoft.Json;

namespace Rponey.AlbbSDK.Model.ApiProduct
{
    /// <summary>
    /// 商品SKU的信息
    /// </summary>
    public class ProductSkuInfoModel
    {
        /// <summary>
        /// SKU属性值，可填多组信息
        /// </summary>
        [JsonProperty(PropertyName = "attributes")]
        public IList<SkuAttrInfoModel> Attributes { get; set; }
        /// <summary>
        /// 指定规格的货号，国际站无需关注	
        /// </summary>
        [JsonProperty(PropertyName = "cargoNumber")]
        public string CargoNumber { get; set; }
        /// <summary>
        /// 可销售数量，国际站无需关注
        /// </summary>
        [JsonProperty(PropertyName = "amountOnSale")]
        public int AmountOnSale { get; set; }
        /// <summary>
        /// 建议零售价，国际站无需关注
        /// </summary>
        [JsonProperty(PropertyName = "retailPrice")]
        public double RetailPrice { get; set; }
        /// <summary>
        /// 报价时该规格的单价，国际站注意要点：含有SKU属性的在线批发产品设定具体价格时使用此值，若设置阶梯价格则使用priceRange
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public double Price { get; set; }
        /// <summary>
        /// 阶梯报价，1688无需关注
        /// </summary>
        [JsonProperty(PropertyName = "priceRange")]
        public IList<ProductPriceRangeModel> PriceRange { get; set; }
        /// <summary>
        /// 商品编码，1688无需关注
        /// </summary>
        [JsonProperty(PropertyName = "skuCode")]
        public string SkuCode { get; set; }
        /// <summary>
        /// skuId
        /// </summary>
        [JsonProperty(PropertyName = "skuId")]
        public long SkuId { get; set; }
        /// <summary>
        /// specId, 国际站无需关注
        /// </summary>
        [JsonProperty(PropertyName = "specId")]
        public string SpecId { get; set; }
    }
}
