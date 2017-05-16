using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Rponey.AlbbSDK.Utilty
{
    public static class SignHelper
    {
        /// <summary>
        /// 前面算法
        /// </summary>
        /// <param name="paramDic">请求参数，即queryString + request body 中的所有参数</param>
        /// <param name="appSecret">app密钥，与请求参数中client_id表示的appKey对应</param>
        /// <returns></returns>
        public static string Sign(Dictionary<string, string> paramDic, string appSecret)
        {
            var signatureKey = Encoding.UTF8.GetBytes(appSecret);
            //第一步：拼装key+value
            var list = paramDic.Select(kv => kv.Key + kv.Value).ToList();
            //第二步：排序
            list.Sort();
            //第三步：拼装排序后的各个字符串
            var tmp = list.Aggregate("", (current, kvstr) => current + kvstr);
            //第四步：将拼装后的字符串和app密钥一起计算签名
            //HMAC-SHA1
            var hmacsha1 = new HMACSHA1(signatureKey);
            hmacsha1.ComputeHash(Encoding.UTF8.GetBytes(tmp));
            var hash = hmacsha1.Hash;
            //TO HEX
            return BitConverter.ToString(hash).Replace("-", string.Empty).ToUpper();
        }

        public static string Sign(string urlPath,Dictionary<string, object> paramDic, string appSecret)
        {
            var signatureKey = Encoding.UTF8.GetBytes(appSecret);
            //第一步：拼装key+value
            var list = paramDic.Select(kv => kv.Key + kv.Value).ToList();
            //第二步：排序
            list.Sort();
            //第三步：拼装排序后的各个字符串
            var tmp = list.Aggregate(urlPath, (current, kvstr) => current + kvstr);
            //第四步：将拼装后的字符串和app密钥一起计算签名
            //HMAC-SHA1
            var hmacsha1 = new HMACSHA1(signatureKey);
            hmacsha1.ComputeHash(Encoding.UTF8.GetBytes(tmp));
            var hash = hmacsha1.Hash;
            //TO HEX
            return BitConverter.ToString(hash).Replace("-", string.Empty).ToUpper();
        }
    }
}
