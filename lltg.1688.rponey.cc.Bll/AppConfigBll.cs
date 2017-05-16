using lltg._1688.rponey.cc.Model.Entity;

namespace lltg._1688.rponey.cc.Bll
{
    public class AppConfigBll
    {
        private static AppConfigEntity Test=> new AppConfigEntity()
        {
            Id = 1,
            AppHost = "lltg.1688.vvzs168.com",
            AppKey = "3578988",
            AppSecrect = "MvK1H6xuWbhI",
            AppName = "应用app name",
            AppRediretUrl = "http://lltg.1688.vvzs168.com/Home/Index",
            Company = "福州一七互动网络科技有限公司"
        };

        private static AppConfigEntity Application => new AppConfigEntity()
        {
            Id = 1,
            AppHost = "lltg.1688.vvzs168.com",
            AppKey = "3518486",
            AppSecrect = "0K024PEUxUI",
            AppName = "站外精准流量推广",
            AppRediretUrl = "http://lltg.1688.vvzs168.com/Home/Index",
            Company = "福州一七互动网络科技有限公司"
        };
        public static AppConfigEntity AppConfig => Application;
    }

}
