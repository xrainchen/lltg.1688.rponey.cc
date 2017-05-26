using System.Collections.Generic;
using lltg._1688.rponey.cc.Model.Entity;
using lltg._1688.rponey.cc.Model.ViewModel;

namespace lltg._1688.rponey.cc.Models
{
    public class FrameModel
    {
        public IList<NavEntity> Navs { get; set; }

        public SiteInfo Site { get; set; }

        public ProductUserViewModel CurrentUser { get; set; }
    }



    public class SiteInfo
    {
        /// <summary>
        /// 网站名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Logo
        /// </summary>
        public string LogoUrl { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// 备案号
        /// </summary>
        public string ICP { get; set; }
    }
}