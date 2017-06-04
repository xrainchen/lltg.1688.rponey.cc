using System;

namespace lltg._1688.rponey.cc.Model.Entity
{
    [Serializable]
    public class GoodsEntity : IIdentityEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// 单位：分
        /// </summary>
        public int Price { get; set; }

        public string Picture { get; set; }
    }
}
