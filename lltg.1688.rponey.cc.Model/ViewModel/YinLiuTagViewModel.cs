using System;

namespace lltg._1688.rponey.cc.Model.ViewModel
{
    public class YinLiuTagViewModel
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

        /// <summary>
        /// 产品用户名
        /// </summary>
        public string ProductUserName { get; set; }
    }
}
