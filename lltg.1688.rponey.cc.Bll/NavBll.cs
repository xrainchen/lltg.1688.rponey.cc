using System.Collections.Generic;
using lltg._1688.rponey.cc.Model.Entity;

namespace lltg._1688.rponey.cc.Bll
{
    public class NavBll
    {
        public  List<NavEntity> GetNavList(long productUserId)
        {
            return new List<NavEntity>()
            {
                new NavEntity
                {
                    Title = "首页",
                    Url="/Home/Index",
                    IconClass = "icon-shouye-shouye",
                    Sort = 1,Area = "",Controller = "Home",Action = "Index",
                },
                new NavEntity
                {
                    Title = "推广中心",
                    Url="/Spread/Index",
                    IconClass = "icon-chanpin",
                    Sort = 1,Area = "",Controller = "Spread",Action = "Index",
                },
                new NavEntity
                {
                    Title = "效果分析",
                    Url="/EffectAnalysis/Index",
                    IconClass = "icon-weibiaoti1",
                    Sort = 1,Area = "",Controller = "EffectAnalysis",Action = "Index",
                },
                new NavEntity
                {
                    Title = "资源中心",
                    Url="/Resource/Index",
                    IconClass = "icon-iconfont89",
                    Sort = 1,Area = "",Controller = "Resource",Action = "Index",
                }
            };
        }
    }
}
