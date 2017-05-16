using System.Collections.Generic;
using Newtonsoft.Json;

namespace Rponey.AlbbSDK.Model.Category
{
    /// <summary>
    /// 类目信息
    /// </summary>
    public class CategoryInfoModel
    {
        /// <summary>
        /// 类目ID
        /// </summary>
        [JsonProperty(PropertyName = "categoryID")]
        public long CategoryId { get; set; }
        /// <summary>
        /// 类目名称
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        /// <summary>
        /// 类目英文名称，1688无此内容
        /// </summary>
        [JsonProperty(PropertyName = "enName")]
        public string EnName { get; set; }
        /// <summary>
        /// 类目层级，1688无此内容
        /// </summary>
        [JsonProperty(PropertyName = "level")]
        public int Level { get; set; }
        /// <summary>
        /// 是否叶子类目（只有叶子类目才能发布商品）
        /// </summary>
        [JsonProperty(PropertyName = "isLeaf")]
        public bool IsLeaf { get; set; }
        /// <summary>
        /// 父类目ID数组,1688只返回一个父id
        /// </summary>
        [JsonProperty(PropertyName = "parentIDs")]
        public IList<long> ParentIds { get; set; }
        /// <summary>
        /// 子类目ID数组，1688无此内容
        /// </summary>
        [JsonProperty(PropertyName = "childIDs")]
        public IList<long> ChildIds { get; set; }
    }
}
