using System;

namespace lltg._1688.rponey.cc.Model.Entity
{
    public class ProductUserEntity : IIdentityEntity
    {
        public long Id { get; set; }

        /// <summary>
        /// 阿里巴巴会员id
        /// </summary>
        public string AlbbMemberId { get; set; }
    }
}
