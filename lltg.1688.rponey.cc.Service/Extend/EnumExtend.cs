using System;
using lltg._1688.rponey.cc.Service.Model;
using RPoney.Utilty.Extend;

namespace lltg._1688.rponey.cc.Service.Extend
{
    public static class EnumExtend
    {
        public static ResultModel GetResultModel(this Enum em)
        {
            return new ResultModel()
            {
                Code =(int)(ResultCode.ResultCode)em,
                Message = em.GetRemark()
            };
        }
    }
}
