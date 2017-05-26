using System;

namespace lltg._1688.rponey.cc.Model.Entity
{
    [Serializable]
    public class NavEntity
    {
        public long Id { get; set; }
        public string Title { get; set; }

        public string Url { get; set; }

        public string IconClass { get; set; }

        public int Sort { get; set; }

        public string Area { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }
    }
}
