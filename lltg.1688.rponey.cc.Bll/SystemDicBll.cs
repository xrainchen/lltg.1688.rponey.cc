using System;
using System.Collections.Generic;
using lltg._1688.rponey.cc.Dal;
using lltg._1688.rponey.cc.Model.Entity;
using lltg._1688.rponey.cc.Model.Search;

namespace lltg._1688.rponey.cc.Bll
{
    public class SystemDicBll
    {
        private readonly Lazy<SystemDicDal> _systemDicDal = new Lazy<SystemDicDal>();
        public SystemDicEntity Get(string key)
        {
            return _systemDicDal.Value.Get(key);
        }

        public SystemDicEntity Get(long id)
        {
            return _systemDicDal.Value.Get(id);
        }
        public IList<SystemDicEntity> GetList(SearchParameter search)
        {
            return _systemDicDal.Value.GetList(search);
        }

        public bool Update(SystemDicEntity entity)
        {
            return _systemDicDal.Value.Update(entity);
        }
    }
}
