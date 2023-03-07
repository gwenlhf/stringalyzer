using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stringalyzer.Web.Models;

namespace Stringalyzer.Web.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string input)
        {
            var analyzer = new Analyzer(input);
            StringalyzerViewModel vm = new StringalyzerViewModel()
            {
                TotalUniqueWords = analyzer.TotalUniqueWords,
                TotalWords = analyzer.TotalWords,
                UniqueWordCounts = analyzer.UniqueWordCounts,
                UniqueWords = analyzer.UniqueWords
            };
            return View(vm);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
