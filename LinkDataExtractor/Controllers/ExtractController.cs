using System.Web;
using System.Web.Mvc;
using LinkDataExtractor.Library;

namespace LinkDataExtractor.Controllers
{
    public class ExtractController : Controller
    {
        [HttpGet]
        public JsonResult Index(string url, bool facebook = false, bool twitter = false, bool manual = false)
        {
            if (string.IsNullOrEmpty(url)) return Json("Url cannot be empty.", JsonRequestBehavior.AllowGet);

            var handler = new ModelHandler
                            {
                                Url = HttpUtility.UrlDecode(url),
                                UserAgent = "Link data extractor V1.0",
                                FacebookTags = facebook,
                                TwitterTags = twitter,
                                ManualTags = manual
                            };


            return Json(handler.ExtractData(), JsonRequestBehavior.AllowGet);
        }
	}
}