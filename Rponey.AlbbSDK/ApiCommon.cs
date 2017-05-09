using System.Collections.Generic;
using Rponey.AlbbSDK.Http;
using Rponey.AlbbSDK.Model.ApiCommon;

namespace Rponey.AlbbSDK
{
    public class ApiCommon
    {
        /// <summary>
        /// 使用code换取access_token
        /// </summary>
        /// <param name="appkey"></param>
        /// <param name="appsecret"></param>
        /// <param name="redirectUrl"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static GetTokenResultModel GetToken(string appkey, string appsecret, string redirectUrl, string code)
        {
            var url = $@"https://gw.open.1688.com/openapi/http/1/system.oauth2/getToken/{appkey}";
//?grant_type=authorization_code&need_refresh_token=true&client_id={appkey}&client_secret={appsecret}&redirect_uri={redirectUrl}&code={code}";
            var dic = new Dictionary<string, string>
            {
                {"grant_type", "authorization_code"},
                {"need_refresh_token", "true"},
                {"client_id", appkey},
                {"client_secret", appsecret},
                {"redirect_uri", redirectUrl},
                {"code", code}
            };
            return Post.PostGetJson<GetTokenResultModel>(url,null, dic);
        }
        /// <summary>
        /// refreshToken换取accessToken
        /// </summary>
        /// <param name="appkey"></param>
        /// <param name="appsecret"></param>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        public static GetTokenResultModel GetTokenByRefreshToKen(string appkey, string appsecret, string refreshToken)
        {
            var url = $"https://gw.api.alibaba.com/openapi/param2/1/system.oauth2/getToken/{appkey}";
            var dic = new Dictionary<string, string>
            {
                {"grant_type", "refresh_token"},
                {"client_id", appkey},
                {"client_secret", appsecret},
                {"refresh_token", refreshToken}
            };
            return Post.PostGetJson<GetTokenResultModel>(url, null, dic);
        }
        /// <summary>
        /// 换取新的refreshToken:如果当前时间离refreshToken过期时间在30天以内，那么可以调用postponeToken接口换取新的refreshToken；否则会报错。
        /// </summary>
        /// <param name="appkey"></param>
        /// <param name="appsecret"></param>
        /// <param name="refreshToken"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static GetTokenResultModel PostponeToken(string appkey, string appsecret, string refreshToken, string accessToken)
        {
            //client_id=YOUR_APPKEY&client_secret=YOUR_APPSECRET&refresh_token=REFRESH_TOKEN&access_token=ACCESS_TOKEN
            var url = $"https://gw.open.1688.com/openapi/param2/1/system.oauth2/postponeToken/{appkey}";
            var dic = new Dictionary<string, string>
            {
                {"client_id", appkey},
                {"client_secret", appsecret},
                {"refresh_token", refreshToken},
                {"access_token", accessToken}
            };
            return Post.PostGetJson<GetTokenResultModel>(url, null, dic);
        }
    }
}
