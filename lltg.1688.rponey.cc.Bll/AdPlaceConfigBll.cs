using System;
using lltg._1688.rponey.cc.Dal;
using lltg._1688.rponey.cc.Model.Entity;
using RPoney;
using RPoney.Utilty.Extend;

namespace lltg._1688.rponey.cc.Bll
{
    public class AdPlaceConfigBll
    {
        private readonly Lazy<AdPlaceConfigDal> _adPlaceConfigDal = new Lazy<AdPlaceConfigDal>();
        private readonly Lazy<SystemDicBll> _systemDicBll = new Lazy<SystemDicBll>();
        public long Add(AdPlaceConfigEntity model)
        {
            return _adPlaceConfigDal.Value.Add(model);
        }

        public AdPlaceConfigEntity Get(long productUserId)
        {
            return _adPlaceConfigDal.Value.Get(productUserId);
        }

        public AdPlaceConfigEntity GetOrInsert(long productUserId)
        {
            var adPlaceConfig = Get(productUserId);
            if (null != adPlaceConfig) return adPlaceConfig;
            var initAdPlaceCoung = _systemDicBll.Value.Get(Model.PublicEnum.SystemDicEnum.InitAdPlaceCount.GetSettingKey())?
                .Value.CInt(0, false);
            adPlaceConfig = new AdPlaceConfigEntity()
            {
                ProductUserId = productUserId,
                Total = initAdPlaceCoung.GetValueOrDefault(),
                Remain = initAdPlaceCoung.GetValueOrDefault()
            };
            adPlaceConfig.Id = Add(adPlaceConfig);
            if (adPlaceConfig.Id > 0) return adPlaceConfig;
            return null;
        }
    }
}
