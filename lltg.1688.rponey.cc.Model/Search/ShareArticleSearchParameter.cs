namespace lltg._1688.rponey.cc.Model.Search
{
    public class ShareArticleSearchParameter : SearchParameter
    {
        public PublicEnum.ShareArticleTypeEnum? ArticleType { get; set; }

        /// <summary>
        /// 文章标题
        /// </summary>
        public string Title { get; set; }
    }
}
