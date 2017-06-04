using System;
using System.Runtime.CompilerServices;

namespace lltg._1688.rponey.cc.Model.Entity
{
    /// <summary>
    /// 产品用户消费动态
    /// </summary>
    [Serializable]
    public class ProductUserBuyDetailEntity : IIdentityEntity
    {
        public long Id { get; set; }
        public DateTime BuyTime { get; set; }

        public string BuyUser { get; set; }

        public string BuyProductName { get; set; }

        public double BuyPrice { get; set; }

        public string BuyPriceUnit { get; set; }
    }
}
