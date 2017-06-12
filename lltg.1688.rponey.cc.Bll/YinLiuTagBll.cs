using System;
using System.Collections.Generic;
using lltg._1688.rponey.cc.Dal;
using lltg._1688.rponey.cc.Model.Entity;
using lltg._1688.rponey.cc.Model.Search;
using lltg._1688.rponey.cc.Model.ViewModel;

namespace lltg._1688.rponey.cc.Bll
{
    public class YinLiuTagBll
    {
        private readonly Lazy<YinLiuTagDal> _yinLiuTagDal = new Lazy<YinLiuTagDal>();

        public long Add(YinLiuTagEntity model)
        {
            return _yinLiuTagDal.Value.Add(model);
        }

        public IList<YinLiuTagViewModel> GetList(SearchParameter search)
        {
            return _yinLiuTagDal.Value.GetList(search);
        }

        public YinLiuTagEntity Get(long id)
        {
            return _yinLiuTagDal.Value.Get(id);
        }

        public bool Update(YinLiuTagEntity model)
        {
            return _yinLiuTagDal.Value.Update(model);
        }

        public bool Delete(long productUserId)
        {
            return _yinLiuTagDal.Value.Delete(productUserId);
        }
        public bool Save(YinLiuTagEntity entity)
        {
            if (entity.Id > 0)
            {
                return Update(entity);
            }
            else
            {
                return Add(entity) > 0;
            }
        }

        public YinLiuTagViewModel GetView(long id)
        {
            return _yinLiuTagDal.Value.GetView(id);
        }

        public IList<YinLiuTagViewModel> GetTagByProductUserId(long productUserId)
        {
            return _yinLiuTagDal.Value.GetTagByProductUserId(productUserId);
        }

        public IList<YinLiuTagViewModel> GetCustomTagByProductUserId(long productUserId)
        {
            return _yinLiuTagDal.Value.GetCustomTagByProductUserId(productUserId);
        }
    }
}
