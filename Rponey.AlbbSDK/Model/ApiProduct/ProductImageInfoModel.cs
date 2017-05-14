using Newtonsoft.Json;

namespace Rponey.AlbbSDK.Model.ApiProduct
{
    /// <summary>
    /// 产品图片信息
    /// </summary>
    public class ProductImageInfoModel
    {
        /// <summary>
        /// 主图列表，需先使用图片上传接口上传图片
        /// </summary>
        [JsonProperty(PropertyName = "images")]
        public string[] Images { get; set; }
        /// <summary>
        /// 是否打水印，是(true)或否(false)，1688无需关注此字段，1688的水印信息在上传图片时处理
        /// </summary>
        [JsonProperty(PropertyName = "isWatermark")]
        public bool IsWaterMask { get; set; }
        /// <summary>
        /// 水印是否有边框，有边框(true)或者无边框(false)，1688无需关注此字段，1688的水印信息在上传图片时处理
        /// </summary>
        [JsonProperty(PropertyName = "isWatermarkFrame")]
        public bool IsWatermarkFrame { get; set; }
        /// <summary>
        /// 水印位置，在中间(center)或者在底部(bottom)，1688无需关注此字段，1688的水印信息在上传图片时处理
        /// </summary>
        [JsonProperty(PropertyName = "watermarkPosition")]
        public string WatermarkPosition { get; set; }
    }
}
