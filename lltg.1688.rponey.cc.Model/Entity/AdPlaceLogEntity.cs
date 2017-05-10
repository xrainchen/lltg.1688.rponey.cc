using System;

namespace lltg._1688.rponey.cc.Model.Entity
{
    /// <summary>
    /// 广告位日志
    /// </summary>
    public class AdPlaceLogEntity : IIdentityEntity
    {

        public long Id { get; set; }

        public string Description { get; set; }

        public PublicEnum.AdPlaceLogTypeEnum AdPlaceLogType { get; set; }

        public DateTime Created { get; set; }
    }
}
