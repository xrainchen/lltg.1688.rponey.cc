using System;
using System.Collections.Generic;
using System.Linq;
using lltg._1688.rponey.cc.Bll;
using lltg._1688.rponey.cc.Model;
using lltg._1688.rponey.cc.Model.Entity;
using lltg._1688.rponey.cc.Service.Extend;
using lltg._1688.rponey.cc.Service.Model;
using RPoney.Log;

namespace lltg._1688.rponey.cc.Service
{
    public class YinLiuTagService : BaseService
    {
        private readonly Lazy<YinLiuTagBll> _yinLiuTagBll = new Lazy<YinLiuTagBll>();

        /// <summary>
        /// 保存自定义引流标签
        /// </summary>
        /// <param name="productUserId"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        public ResultModel Save(long productUserId, IList<string> tags)
        {
            if (tags == null || tags.Count > 2)
            {
                return ResultCode.Error.GetResultModel();
            }
            if (!_yinLiuTagBll.Value.Delete(productUserId))
            {
                return ResultCode.Error.GetResultModel();
            }
            if (tags.Any())//为空,则代表删除
            {
                var sort = 0;
                foreach (var tag in tags)
                {
                    sort++;
                    try
                    {
                        _yinLiuTagBll.Value.Add(new YinLiuTagEntity()
                        {
                            CreatedTime = DateTime.Now,
                            Name = tag,
                            Type = PublicEnum.YinLiuTagTypeEnum.Custom,
                            ProductUserId = productUserId,
                            Sort = sort
                        });
                    }
                    catch (Exception ex)
                    {
                        LoggerManager.Error(GetType().Name, "添加引流标签异常", ex);
                    }
                }
            }
            return ResultCode.Success.GetResultModel();
        }
    }
}
