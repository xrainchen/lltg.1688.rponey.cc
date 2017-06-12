using RPoney.Utilty.Extend;

namespace lltg._1688.rponey.cc.Service
{
    public enum ResultCode
    {
        [Remark("对象不存在")]
        ObjectIsNull = -2,
        [Remark("执行异常")]
        Error = -1,
        [Remark("执行成功")]
        Success = 0,



        [Remark("产品订单")]
        ProductOrder = 100,


        [Remark("产品用户")]
        ProductUser = 200,


        [Remark("引流标签")]
        YinLiuTag = 300,
        [Remark("超过引流标签最大限制数")]
        YinLiuTagOverLimitAddCount = 301,
    }
}
