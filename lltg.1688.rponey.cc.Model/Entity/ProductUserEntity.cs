using System;

namespace lltg._1688.rponey.cc.Model.Entity
{
    public class ProductUserEntity : IIdentityEntity
    {
        public long Id { get; set; }

        /// <summary>
        /// 登录用户ID
        /// </summary>
        public string ResourceOwner { get; set; }
    }
}
