using MatomoDeviceDetectorNET;
using MatomoDeviceDetectorNET.Services.Parser;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestProject.MatomoDeviceDetector.NET.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var userAgent = Request.Headers["User-Agent"];

            userAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 10_2_1 like Mac OS X) AppleWebKit/602.4.6 (KHTML, like Gecko) Mobile/14D27 LightSpeed [FBAN/MessengerLiteForiOS;FBAV/310.0.0.38.116;FBBV/287543612;FBDV/iPhone7,2;FBMD/iPhone;FBSN/iOS;FBSV/10.2.1;FBSS/2;FBCR/;FBID/phone;FBLC/en-GB;FBOP/0]";


            userAgent = "facebookexternalhit/1.1 (+http://www.facebook.com/externalhit_uatext.php)";

           var info= DeviceDetector.GetInfoFromUserAgent(userAgent);

            var d = new DeviceDetector();
            //d.

            var matches = info.Match;

            BotParser b = new BotParser();
            //b.SetUserAgent( userAgent);
            var x = b.RegexList;

          var disticnt=  x.GroupBy(g=>g.Category).Select(c => new { type = c.FirstOrDefault().Category }).ToList();


            var data = JsonConvert.SerializeObject(disticnt.OrderBy(c=>c.type).ToList());


            b.Parse();



            //JsonConvert.SerializeObject

            return View(matches);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}