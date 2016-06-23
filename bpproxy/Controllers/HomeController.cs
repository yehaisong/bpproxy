using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace bpproxy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public async Task<string> GetUserId(string email)
        {
            string responseString;
            using (var client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                   { "email", email }
                };

                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync("https://backpack.openbadges.org/displayer/convert/email", content);

                responseString = await response.Content.ReadAsStringAsync();
            }
            return responseString;
        }
    }
}
