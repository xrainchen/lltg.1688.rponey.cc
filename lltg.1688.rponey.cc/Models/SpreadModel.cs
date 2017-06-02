using System;
using System.Collections.Generic;
using lltg._1688.rponey.cc.Model.Entity;
using lltg._1688.rponey.cc.Model.ViewModel;

namespace lltg._1688.rponey.cc.Models
{
    public class SpreadModel
    {
        public IList<YinLiuTagViewModel> YinLiuTagList { get; set; }
        public AdPlaceConfigEntity AdPlaceConfig { get; set; }
    }
}