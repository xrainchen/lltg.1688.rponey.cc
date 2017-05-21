using System;

namespace lltg._1688.rponey.cc.Model.Search
{
    /// <summary>
    /// 搜索条件基类
    /// </summary>
    public class SearchParameter
    {
        /// <summary>
        /// 是否全部
        /// </summary>
        public bool IsAll { get; set; }
        #region 分页
        private int _page { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public int Page
        {
            get { return _page > 0 ? _page : 1; }
            set { _page = value; }
        }

        private int _pageSize { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int PageSize
        {
            get { return _pageSize > 0 ? _pageSize : 20; }
            set { _pageSize = value; }
        }
        /// <summary>
        /// 总数
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage
        {
            get
            {
                if (PageSize < 1) return 1;
                return (Count + PageSize - 1) / PageSize;
            }
        }
        #endregion

        /// <summary>
        /// 排序方式
        /// </summary>
        public string OrderBy { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public dynamic ReturnList { get; set; }

        /// <summary>
        /// 标签页
        /// </summary>
        public string NavTab { get; set; }


        #region 通用搜索
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 开始搜索时间
        /// </summary>
        public DateTime? BeginSearchTime { get; set; }
        /// <summary>
        /// 结束搜索时间
        /// </summary>
        public DateTime? EndSearchTime { get; set; }

        /// <summary>
        /// 选中Id
        /// </summary>
        public string SelectedIds { get; set; }
        #endregion
    }
}
