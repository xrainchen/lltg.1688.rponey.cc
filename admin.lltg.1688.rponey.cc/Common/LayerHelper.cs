using System.Web.Mvc;

namespace admin.lltg._1688.rponey.cc.Common
{
    /// <summary>
    /// Layer帮助类
    /// </summary>
    public static class LayerHelper
    {
        public static ActionResult SuccessAndClose(string navTab, string msg = "")
        {
            var json = new JsonResult()
            {
                Data = new
                {
                    statusCode = 200,
                    message = msg,
                    navTableId = navTab,
                    callbackType = "closeCurrent",
                    forwardUrl = ""
                }
            };
            return json;
        }
        public static ActionResult Success(string msg = "")
        {
            var json = new JsonResult()
            {
                Data = new
                {
                    statusCode = 200,
                    message = msg,
                    navTableId = "",
                    callbackType = "",
                    forwardUrl = ""
                }
            };
            return json;
        }
        public static ActionResult Warn(string msg = "")
        {
            var json = new JsonResult()
            {
                Data = new
                {
                    statusCode = 300,
                    message = msg,
                    navTableId = "",
                    callbackType = "",
                    forwardUrl = ""
                }
            };
            return json;
        }
    }
}