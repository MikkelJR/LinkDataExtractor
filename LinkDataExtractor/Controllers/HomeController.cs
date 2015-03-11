using System.Web;
using System.Web.Mvc;
using LinkDataExtractor.Library;
using LinkDataExtractor.Models;
using Newtonsoft.Json;

namespace LinkDataExtractor.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TestModel model)
        {
            if (ModelState.IsValid)
            {
                var handler = new ModelHandler
                {
                    Url = HttpUtility.UrlDecode(model.Url),
                    UserAgent = "Link data extractor V1.0",
                    FacebookTags = model.Facebook,
                    TwitterTags = model.Twitter,
                    ManualTags = model.Manual
                };

                TempData["ShowResult"] = "true";
                TempData["Json"] = JsonConvert.SerializeObject(handler.ExtractData()).Replace("],", "], <br /> &nbsp;&nbsp;&nbsp;&nbsp;").Replace("{", "{ <br />&nbsp;&nbsp;&nbsp;&nbsp;").Replace("}", "<br /> }");
            }

            return View(model);
        }


    }
}