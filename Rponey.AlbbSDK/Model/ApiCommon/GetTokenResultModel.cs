using Newtonsoft.Json;

namespace Rponey.AlbbSDK.Model.ApiCommon
{
    /// <summary>
    /// 获取Token结果
    /// </summary>
    public class GetTokenResultModel
    {
        /// <summary>
        /// 阿里巴巴集团统一的id
        /// </summary>
        [JsonProperty(PropertyName = "aliId")]
        public string AliId { get; set; }

        /// <summary>
        /// 登录id
        /// </summary>
        [JsonProperty(PropertyName = "resource_owner")]
        public string ResourceOwner { get; set; }

        /// <summary>
        /// 会员接口id
        /// </summary>
        [JsonProperty(PropertyName = "memberId")]
        public string MemberId { get; set; }

        /// <summary>
        /// access_token
        /// </summary>
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 刷新token
        /// </summary>
        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// 有效时间
        /// </summary>
        [JsonProperty(PropertyName = "expires_in")]
        public string ExpiresIn { get; set; }

        /// <summary>
        /// RefreshToken过期时间  20121222222222+0800 yyyyMMddHHmmss+区
        /// </summary>
        [JsonProperty(PropertyName = "refresh_token_timeout")]
        public string RefreshTokenTimeout { get; set; }
    }
}
