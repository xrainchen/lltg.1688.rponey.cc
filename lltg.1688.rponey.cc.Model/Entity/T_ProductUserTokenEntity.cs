using System;

namespace lltg._1688.rponey.cc.Model.Entity
{
    [Serializable]
    public class T_ProductUserTokenEntity : IIdentityEntity
    {
        public long Id { get; set; }

        /// <summary>
        /// 阿里巴巴集团统一的id
        /// </summary>
        public string AliId { get; set; }

        /// <summary>
        /// 登录id--登录用名
        /// </summary>
        public string ResourceOwner { get; set; }

        /// <summary>
        /// 会员接口id
        /// </summary>
        public string MemberId { get; set; }

        /// <summary>
        /// access_token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// 刷新token
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// 有效时间(秒)
        /// </summary>
        public int ExpiresIn { get; set; }

        /// <summary>
        /// RefreshToken过期时间（30天以内 就要更新令牌了）
        /// </summary>
        public DateTime RefreshTokenTimeout { get; set; }

        /// <summary>
        /// 更新时间（用于计算accessToken是否过期）
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
