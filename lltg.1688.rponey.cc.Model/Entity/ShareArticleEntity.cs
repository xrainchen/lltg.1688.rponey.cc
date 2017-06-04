
using System;

namespace lltg._1688.rponey.cc.Model.Entity
{
    [Serializable]
    public class ShareArticleEntity
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string ArticleUrl { get; set; }

        public PublicEnum.ShareArticleTypeEnum ArticleType { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime UpdatedTime { get; set; }

        public string Cover { get; set; }
    }
}
