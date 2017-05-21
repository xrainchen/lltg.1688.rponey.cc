using System;
using lltg._1688.rponey.cc.Dal;
using lltg._1688.rponey.cc.Model.Entity;

namespace lltg._1688.rponey.cc.Bll
{
    public class YinLiuTagBll
    {
        private readonly Lazy<YinLiuTagDal> _yinLiuTagDal = new Lazy<YinLiuTagDal>();

        public long Add(YinLiuTagEntity model)
        {
            return _yinLiuTagDal.Value.Add(model);
        }
    }
}
