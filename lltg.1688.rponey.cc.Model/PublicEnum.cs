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

        /// <summary>
        /// 系统字典配置
        /// </summary>
        public enum SystemDicEnum
        {
            /// <summary>
            /// 初始广告位配置数量
            /// </summary>
            [GlobalSetting("InitAdPlaceCount")]
            [Remark("初始广告位配置数量")]
            InitAdPlaceCount,
            /// <summary>
            /// 好评或者邀请好友赠送广告位数量
            /// </summary>
            [GlobalSetting("PositiveCommentOrIviteFriendPresentAdPlaceCount")]
            [Remark("好评或者邀请好友赠送广告位数量")]
            PositiveCommentOrIviteFriendPresentAdPlaceCount,

            /// <summary>
            /// 订购一年赠送广告位数量
            /// </summary>
            [GlobalSetting("OrderOneYearPresentAdPlaceCount")]
            [Remark("订购一年赠送广告位数量")]
            OrderOneYearPresentAdPlaceCount,
        }
    }
}
