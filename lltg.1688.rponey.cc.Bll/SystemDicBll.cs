using System;
using lltg._1688.rponey.cc.Dal;
using lltg._1688.rponey.cc.Model.Entity;

namespace lltg._1688.rponey.cc.Bll
{
    public class SystemDicBll
    {
        private readonly Lazy<SystemDicDal> _systemDicDal = new Lazy<SystemDicDal>();
        public SystemDicEntity Get(string key)
        {
            return _systemDicDal.Value.Get(key);
        }
    }
}
