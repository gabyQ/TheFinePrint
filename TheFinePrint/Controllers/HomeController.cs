using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheFinePrint.Models;

namespace TheFinePrint.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Category(string categoryName)
        {
            ViewData["Message"] = categoryName;
            ViewData["Category"] = categoryName;

            return View("~/Views/Blog/Category.cshtml");
        }

        public IActionResult Content(string id)
        {
            ViewData["Message"] = "Content";
            ViewData["ContentId"] = id;

            return View("~/Views/Blog/Content.cshtml");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
