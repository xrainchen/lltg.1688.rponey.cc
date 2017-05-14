using System;
using System.Collections.Generic;

namespace Rponey.AlbbSDK.Model.ApiProduct
{
    public class ProductInfoModel
    {
        public long ProductId { get; set; }

        public string ProductType { get; set; }

        public long CategoryId { get; set; }

        public IList<ProductAttributeModel> Attributes { get; set; }

        public long[] GroupId { get; set; }

        public string Status { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

        public string Language { get; set; }

        public int PeriodOfValidty { get; set; }

        public int BizType { get; set; }

        public bool PictureAuth { get; set; }
        public ProductImageInfoModel Image { get; set; }

        public IList<ProductSkuInfoModel> SkuInfos { get; set; }
        public ProductSaleInfoModel SaleInfo { get; set; }

        public ProductShippingInfoModel ShippingInfo { get; set; }

        public ProductInternationalTradeInfoModel InternationalTradeInfo { get; set; }

        public IList<ProductExtendInfoModel> ExtendInfos { get; set; } 
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public DateTime LastRepostTime { get; set; }
        public DateTime ApprovedTime { get; set; }
        public DateTime ExpireTime { get; set; }
    }
}
