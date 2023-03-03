using Microsoft.AspNetCore.Mvc;
using ShortenURLCoreApp.Models;
using System.Diagnostics;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Specialized;
using System.Net;
using System.Web;
using System.Security.Policy;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace ShortenURLCoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UrlDbContext _context;
        public HomeController(ILogger<HomeController> logger, UrlDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //URLViewModel urldt = new ()
            //{ urlID=1,UrlName="ABC"};


            return View();
        }

        [HttpPost]
        public IActionResult Index(UrlModel urlview)
        {
            if (ModelState.IsValid)
            {
                //var task = IsURLValid();
                //if ((bool)IsURLValid(urlview.UrlName))

                //{

                    var existingShortUrl = _context.Url
                             .Where(x => x.UrlName.Contains(urlview.UrlName))
                             .FirstOrDefault();

                    if (existingShortUrl != null)
                    {
                        ViewData["Message"] = "Shorten URL already Exists";
                        ViewBag.shorten = existingShortUrl.ShortenUrl;
                        ViewData["originalurl"] = existingShortUrl.UrlName;
                        return View("ShortenUrl");
                    }
                    else
                    {
                        UrlModel urlTbltDdb = new UrlModel();
                        string shortenUrl = string.Empty;
                        Uri uri = new Uri(urlview.UrlName.Trim());
                        var url = urlview;
                        string key = token();
                        shortenUrl = uri.GetLeftPart(System.UriPartial.Authority);
                        shortenUrl = shortenUrl + "/" + key;
                        while (_context.Url.ToList().Where(x => x.Token == key).Any())
                        {
                            key = token();
                        }
                        urlTbltDdb.ShortenUrl = shortenUrl;
                        urlTbltDdb.UrlName = uri.AbsoluteUri;
                        urlTbltDdb.DomainName = uri.Host;
                        urlTbltDdb.Token = key;
                    //Add new url to Database
                        _context.Add(urlTbltDdb);
                        _context.SaveChanges();

                        ViewBag.Name = urlTbltDdb.UrlName;
                        ViewBag.Domain = uri.Host;
                        ViewBag.absoluteuri = uri.AbsoluteUri;
                        ViewBag.shorten = shortenUrl;
                        ViewBag.Token = key;
                        ViewData["originalurl"] = uri.AbsoluteUri;
                        return View("ShortenUrl");
                    }
                //}
            }

            return View("Index");
        }


        public static async Task<bool> IsURLValid(string source)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, source));
                    if (response.IsSuccessStatusCode)
                    { return true; }
                    return false;
                    
                }
            }
            catch
            {
                return false;
            }

            //Uri? uriResult;

            //return Uri.TryCreate(source, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;

        }

        public string token()
        {
            string key = string.Empty;
            while (key.Length < 7)
            {
                key += Guid.NewGuid().ToString().GetHashCode().ToString("X");
            }
            return key.Substring(0, 7).ToLower();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}