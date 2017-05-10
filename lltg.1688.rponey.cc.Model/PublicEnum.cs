using RPoney.Utilty.Extend;

namespace lltg._1688.rponey.cc.Model
{
    public class PublicEnum
    {
        /// <summary>
        /// 广告位日志类型
        /// </summary>
        public enum AdPlaceLogTypeEnum
        {
            /// <summary>
            /// 使用
            /// </summary>
            Used = 1,
        }

        /// <summary>
        /// 引流标签类型
        /// </summary>
        public enum YinLiuTagTypeEnum
        {
            /// <summary>
            /// 系统标签
            /// </summary>
            [Remark("系统推荐标签")]
            System = 1,
            /// <summary>
            /// 自定义引流标签
            /// </summary>
            [Remark("自定义引流标签")]
            Custom = 2
        }
    }
}
