using System.Collections.Generic;
using Rponey.AlbbSDK.Model;

namespace Rponey.AlbbSDK
{
    public class ApiCategory
    {
        public static GetCategoryListResultModel GetList(string accesstoken, string appKey, string appSecret, long categoryId, string webSite = "1688")
        {
            var dic = new Dictionary<string, string> {{ "categoryID", categoryId.ToString() }, {"webSite", webSite}};
            return ApiFacade.GetPostResult<GetCategoryListResultModel>(accesstoken, appKey, appSecret, dic, "com.alibaba.product", "alibaba.category.get");
        }
    }
}
