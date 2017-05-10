using System;

namespace lltg._1688.rponey.cc.Model.Entity
{
    /// <summary>
    /// 广告位配置
    /// </summary>
    public class AdPlaceConfigEntity : IIdentityEntity
    {
        public long Id { get; set; }

        public long ProductUserId { get; set; }

        public int Total { get; set; }

        public int Used { get; set; }
    }
}
