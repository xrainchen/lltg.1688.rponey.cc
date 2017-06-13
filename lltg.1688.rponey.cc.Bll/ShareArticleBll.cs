using System;
using System.Collections.Generic;
using lltg._1688.rponey.cc.Dal;
using lltg._1688.rponey.cc.Model.Entity;
using lltg._1688.rponey.cc.Model.Search;

namespace lltg._1688.rponey.cc.Bll
{
    public class ShareArticleBll
    {
        private readonly Lazy<ShareArticleDal> _shareArticleDal = new Lazy<ShareArticleDal>();

        public long Add(ShareArticleEntity model)
        {
            return _shareArticleDal.Value.Add(model);
        }

        public IList<ShareArticleEntity> GetList(SearchParameter search)
        {
            return _shareArticleDal.Value.GetList(search);
        }

        public IList<ShareArticleEntity> GetRecommendShareArticle(SearchParameter search)
        {
            return _shareArticleDal.Value.GetRecommendShareArticle(search);
        }

        public ShareArticleEntity Get(long id)
        {
            return _shareArticleDal.Value.Get(id);
        }

        public bool Update(ShareArticleEntity entity)
        {
            return _shareArticleDal.Value.Update(entity);
        }

        public bool Save(ShareArticleEntity entity)
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
    }
}
