using Newtonsoft.Json;

namespace Rponey.AlbbSDK.Model.ApiProduct
{
    /// <summary>
    /// 商品物流信息
    /// </summary>
    public class ProductShippingInfoModel
    {
        /// <summary>
        /// 运费模板ID，1688使用两类特殊模板来标明使用：运费说明、 卖家承担运费的情况。此参数通过调用运费模板相关API获取
        /// </summary>
        [JsonProperty(PropertyName = "freightTemplateID")]
        public long FreightTemplateID { get; set; }
        /// <summary>
        /// 单位重量
        /// </summary>
        [JsonProperty(PropertyName = "unitWeight")]
        public double UnitWeight { get; set; }
        /// <summary>
        /// 尺寸，单位是厘米，长宽高范围是1-9999999。1688无需关注此字段
        /// </summary>
        [JsonProperty(PropertyName = "packageSize")]
        public string PackageSize { get; set; }
        /// <summary>
        /// 体积，单位是立方厘米，范围是1-9999999，1688无需关注此字段
        /// </summary>
        [JsonProperty(PropertyName = "volume")]
        public int Volume { get; set; }
        /// <summary>
        /// 备货期，单位是天，范围是1-60。1688无需处理此字段
        /// </summary>
        [JsonProperty(PropertyName = "handlingTime")]
        public int HandlingTime { get; set; }
        /// <summary>
        /// 发货地址ID，国际站无需处理此字段
        /// </summary>
        [JsonProperty(PropertyName = "sendGoodsAddressId")]
        public long SendGoodsAddressId { get; set; }
    }
}
