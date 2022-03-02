using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using B_E.Tropin.lab1.Models;

namespace B_E.Tropin.lab1.Controllers
{
    public class CalculationsController : Controller
    {
        Random rand = new Random();
        private readonly ILogger<CalculationsController> _logger;

        public CalculationsController(ILogger<CalculationsController> logger)
        {
            _logger = logger;
        }

        public IActionResult PassUsingModel()
        {
            CalculModel Temp = new CalculModel();

            Temp.val1 = rand.Next(0, 10);
            Temp.val2 = rand.Next(0, 10);

            Temp.add = Temp.val1 + Temp.val2;
            Temp.sub = Temp.val1 - Temp.val2;
            Temp.mult = Temp.val1 * Temp.val2;

            if (Temp.val2 != 0) Temp.div = "" + Math.Round(Temp.val1/Temp.val2);
            else Temp.div = "Error: Division by zero";
            return View(Temp);
        }

        public IActionResult PassUsingViewData()
        {
            Random rand = new Random();

            double val1 = rand.Next(0, 10);
            double val2 = rand.Next(0, 10);

            ViewData["val1"] = val1;
            ViewData["val2"] = val2;
            ViewData["add"] = val1 + val2;
            ViewData["sub"] = val1 - val2;
            ViewData["mult"] = val1 * val2;

            if (val2 != 0) ViewData["div"] = "" + Math.Round(val1/val2);
            else ViewData["div"] = "Error: Division by zero";

            return View();
        }

        public IActionResult PassUsingViewBag()
        {
            Random rand = new Random();

            double val1 = rand.Next(0, 10);
            double val2 = rand.Next(0, 10);

            ViewBag.val1 = val1;
            ViewBag.val2 = val2;
            ViewBag.add = val1 + val2;
            ViewBag.sub = val1 - val2;
            ViewBag.mult = val1 * val2;

            if (val2 != 0) ViewBag.div = "" + Math.Round(val1/val2);
            else ViewBag.div = "Error: Division by zero";

            return View();
        }

        public IActionResult AcessServiceDirectly()
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
