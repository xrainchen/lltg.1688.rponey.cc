using Newtonsoft.Json;

namespace Rponey.AlbbSDK.Model.ApiProduct
{
    /// <summary>
    /// 商品国际贸易信息
    /// </summary>
    public class ProductInternationalTradeInfoModel
    {
        /// <summary>
        /// FOB价格货币，参见FAQ 货币枚举值
        /// </summary>
        [JsonProperty(PropertyName = "fobCurrency")]
        public string FobCurrency { get; set; }
        /// <summary>
        /// FOB最小价格
        /// </summary>
        [JsonProperty(PropertyName = "fobMinPrice")]
        public string FobMinPrice { get; set; }
        /// <summary>
        /// FOB最大价格
        /// </summary>
        [JsonProperty(PropertyName = "fobMaxPrice")]
        public string FobMaxPrice { get; set; }
        /// <summary>
        /// FOB计量单位，参见FAQ 计量单位枚举值
        /// </summary>
        [JsonProperty(PropertyName = "productInfos")]
        public string FobUnitType { get; set; }
        /// <summary>
        /// 付款方式，参见FAQ 付款方式枚举值
        /// </summary>
        [JsonProperty(PropertyName = "paymentMethods")]
        public string[] PaymentMethods { get; set; }
        /// <summary>
        /// 最小起订量
        /// </summary>
        [JsonProperty(PropertyName = "minOrderQuantity")]
        public int MinOrderQuantity { get; set; }
        /// <summary>
        /// 最小起订量计量单位，参见FAQ 计量单位枚举值
        /// </summary>
        [JsonProperty(PropertyName = "minOrderUnitType")]
        public string MinOrderUnitType { get; set; }
        /// <summary>
        /// supplyQuantity
        /// </summary>
        [JsonProperty(PropertyName = "supplyQuantity")]
        public int SupplyQuantity { get; set; }
        /// <summary>
        /// 供货能力计量单位，参见FAQ 计量单位枚举值
        /// </summary>
        [JsonProperty(PropertyName = "supplyUnitType")]
        public string SupplyUnitType { get; set; }
        /// <summary>
        /// 供货能力周期，参见FAQ 时间周期枚举值
        /// </summary>
        [JsonProperty(PropertyName = "supplyPeriodType")]
        public string SupplyPeriodType { get; set; }
        /// <summary>
        /// 发货港口
        /// </summary>
        [JsonProperty(PropertyName = "deliveryPort")]
        public string DeliveryPort { get; set; }
        /// <summary>
        /// 发货期限
        /// </summary>
        [JsonProperty(PropertyName = "deliveryTime")]
        public string DeliveryTime { get; set; }
        /// <summary>
        /// 新发货期限
        /// </summary>
        [JsonProperty(PropertyName = "consignmentDate")]
        public int ConsignmentDate { get; set; }
        /// <summary>
        /// 常规包装
        /// </summary>
        [JsonProperty(PropertyName = "packagingDesc")]
        public string PackagingDesc { get; set; }
    }
}
