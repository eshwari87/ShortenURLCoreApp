using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShortenURLCoreApp.Models;

namespace ShortenURLCoreApp.Controllers
{
    public class UrlController : Controller
    {
        private readonly UrlDbContext _dbcontext;
        public UrlController(UrlDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ViewResult> AllShortenURL()
        {

            var list = await _dbcontext.Url.ToListAsync();
            return View(list);
        }



    }
} 
