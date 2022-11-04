
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KanyeQuotes.Controllers
{
    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();
        static string quote = null;
        public async Task<ActionResult> Index()
        {
            await GetProductAsync();
            ViewBag.Quote = quote;
            return View();
        }

        static async Task<string> GetProductAsync()
        {
            quote = null;
            HttpResponseMessage response = await client.GetAsync("https://api.kanye.rest");
            if (response.IsSuccessStatusCode)
            {
                quote = await response.Content.ReadAsStringAsync();
                quote = quote.Substring(10, quote.Length - 12);
            }
            return quote;
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