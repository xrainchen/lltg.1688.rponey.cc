using System;

namespace lltg._1688.rponey.cc.Model.Entity
{
    public class ProductOrderEntity
    {
        public long Id { get; set; }

        public long ProductUserId { get; set; }

        public DateTime BuyDateTime { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public string Unit { get; set; }

        public string GP { get; set; }

        public DateTime CreatedTime { get; set; }

        public PublicEnum.ProductOrderTypeEnum OrderType { get; set; }
    }
}
