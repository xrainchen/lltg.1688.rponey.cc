using System.Collections.Generic;
using Newtonsoft.Json;

namespace Rponey.AlbbSDK.Model.ApiProduct
{
    /// <summary>
    /// 商品销售信息，包含上传商品中跟销售相关的信息
    /// </summary>
    public class ProductSaleInfoModel
    {
        /// <summary>
        /// 是否支持网上交易。true：支持 false：不支持，国际站不需关注此字段
        /// </summary>
        [JsonProperty(PropertyName = "supportOnlineTrade")]
        public bool SupportOnlineTrade { get; set; }
        /// <summary>
        /// 是否支持混批，国际站无需关注此字段
        /// </summary>
        [JsonProperty(PropertyName = "mixWholeSale")]
        public bool MixWholeSale { get; set; }
        /// <summary>
        /// 销售方式，按件卖(normal)或者按批卖(batch)，1688站点无需关注此字段
        /// </summary>
        [JsonProperty(PropertyName = "saleType")]
        public string SaleType { get; set; }
        /// <summary>
        /// 是否价格私密信息，国际站无需关注此字段
        /// </summary>
        [JsonProperty(PropertyName = "priceAuth")]
        public bool PriceAuth { get; set; }
        /// <summary>
        /// 区间价格。按数量范围设定的区间价格
        /// </summary>
        [JsonProperty(PropertyName = "priceRanges")]
        public IList<ProductPriceRangeModel> PriceRanges { get; set; }
        /// <summary>
        /// 可售数量，国际站无需关注此字段
        /// </summary>
        [JsonProperty(PropertyName = "amountOnSale")]
        public double AmountOnSale { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        [JsonProperty(PropertyName = "unit")]
        public string Unit { get; set; }
        /// <summary>
        /// 最小起订量，范围是1-99999。1688无需处理此字段
        /// </summary>
        [JsonProperty(PropertyName = "minOrderQuantity")]
        public int MinOrderQuantity { get; set; }
        /// <summary>
        /// 每批数量
        /// </summary>
        [JsonProperty(PropertyName = "batchNumber")]
        public int BatchNumber { get; set; }
        /// <summary>
        /// 建议零售价，国际站无需关注
        /// </summary>
        [JsonProperty(PropertyName = "retailPrice")]
        public double RetailPrice { get; set; }
        /// <summary>
        /// 税率相关信息，内容由用户自定，国际站无需关注
        /// </summary>
        [JsonProperty(PropertyName = "attributeId")]
        public string Tax { get; set; }
        /// <summary>
        /// 售卖单位，如果为批量售卖，代表售卖的单位，例如1"手"=12“件"的"手"，国际站无需关注
        /// </summary>
        [JsonProperty(PropertyName = "attributeId")]
        public string SellUnit { get; set; }
        /// <summary>
        /// 普通报价-FIXED_PRICE("0"),SKU规格报价-SKU_PRICE("1"),SKU区间报价（商品维度）-SKU_PRICE_RANGE_FOR_OFFER("2"),SKU区间报价（SKU维度）-SKU_PRICE_RANGE("3")，国际站无需关注
        /// </summary>
        [JsonProperty(PropertyName = "attributeId")]
        public int QuoteType { get; set; }
    }
}
