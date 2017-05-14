using Newtonsoft.Json;

namespace Rponey.AlbbSDK.Model.ApiProduct
{
    /// <summary>
    /// 商品价格区间
    /// </summary>
    public class ProductPriceRangeModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "startQuantity")]
        public int StartQuantity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public double Price { get; set; }
    }
}
