using lltg._1688.rponey.cc.Model.Entity;

namespace lltg._1688.rponey.cc.Bll
{
    public class AppConfigBll
    {
        public static AppConfigEntity AppConfig => new AppConfigEntity()
        {
            Id = 1,
            AppHost = "lltg.1688.vvzs168.com",
            AppKey = "3518486",
            AppSecrect = "0K024PEUxUI",
            AppName = "站外精准流量推广",
            AppRediretUrl = "http://lltg.1688.rponey.cc/F5/Index"
        };
    }

}
