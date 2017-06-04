using System;

namespace lltg._1688.rponey.cc.Model.Entity
{
    /// <summary>
    /// 广告位配置
    /// </summary>
    [Serializable]
    public class AppConfigEntity
    {
        public long Id { get; set; }

        public string AppSecrect { get; set; }

        public string AppKey { get; set; }

        public string AppName { get; set; }

        public string AppHost { get; set; }

        public string AppRediretUrl { get; set; }

        public string Company { get; set; }
    }
}
