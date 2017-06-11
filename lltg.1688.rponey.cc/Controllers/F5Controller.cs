using System;
using System.Web;
using System.Web.Mvc;
using RPoney;

namespace lltg._1688.rponey.cc.Controllers
{
    public class F5Controller : Controller
    {
        // GET: F5
        public ActionResult Index()
        {
            RPoney.Log.LoggerManager.Debug(GetType().Name, "Debug Test");
            RPoney.Log.LoggerManager.Error(GetType().Name, "Error Test");
            return Content("OK");
        }

        [HttpPost]
        public ActionResult JsonText(TestModel model)
        {
            return Json(model);
        }
        [HttpPost]
        public string Upload(TestModel model)
        {
            try
            {
                var files = Request.Files;
                var str = string.Empty;
                if (files.Count > 0)
                {
                    for (var i = 0; i < files.Count; i++)
                    {
                        var fileName = Server.MapPath($@"~\Upload\{Guid.NewGuid().ToString("N")}.jpg");
                        files[i].SaveAs(fileName);
                        str += fileName;
                    }
                }

                return str + model.SerializeToJSON();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }

    public class TestModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}