using System;
using System.Collections.Generic;
using Rponey.AlbbSDK.Http;
using Rponey.AlbbSDK.Utilty;
using RPoney.Utilty.Extend;

namespace Rponey.AlbbSDK
{
    public class ApiFacade
    {
        private const string OpenHost = "gw.open.1688.com";
        private const string Protocol = "param2";

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="accesstoken"></param>
        /// <param name="appKey"></param>
        /// <param name="appSecret"></param>
        /// <param name="param"></param>
        /// <param name="apiNamespace"></param>
        /// <param name="apiName"></param>
        /// <param name="addAopSignature"></param>
        /// <param name="apiVersion"></param>
        /// <param name="addAopTimeStamp"></param>
        /// <param name="addAccessToken"></param>
        /// <returns></returns>
        public static T GetPostResult<T>(string accesstoken, string appKey, string appSecret,
            Dictionary<string, string> param, string apiNamespace, string apiName,
            bool addAopTimeStamp = false,
            bool addAccessToken = false,
            bool addAopSignature = false,
            string apiVersion = "1")
        {
            var urlPath = $"{Protocol}/{apiVersion}/{apiNamespace}/{apiName}/{appKey}";
            var url = $"http://{OpenHost}/openapi/{urlPath}";
            var dic = param ?? new Dictionary<string, string>();
            if (addAopSignature)
            {
                var sign = SignHelper.Sign(urlPath, dic, appSecret);
                dic.Add("_aop_signature", sign);
            }
            if (addAopTimeStamp)
                dic.Add("_aop_timestamp", DateTime.Now.ToLocalMilliTimeStamp().ToString());
            if (addAccessToken)
                dic.Add("access_token", accesstoken);
            RPoney.Log.LoggerManager.Debug(typeof(ApiFacade).Name, $"调用阿里API请求:{dic.SerializeToJson()}");
            return Post.PostGetJson<T>(url, null, dic);
        }
    }
}
