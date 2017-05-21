using System;

namespace lltg._1688.rponey.cc.Model.Entity
{
    /// <summary>
    /// 引流标签
    /// </summary>
    public class YinLiuTagEntity : IIdentityEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public PublicEnum.YinLiuTagTypeEnum Type { get; set; }

        /// <summary>
        /// 系统标签用户id为空
        /// </summary>
        public long? ProductUserId { get; set; }

        public int Sort { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
