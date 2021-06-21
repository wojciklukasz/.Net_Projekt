using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Models;
using System;
using System.Diagnostics;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Autor()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Kalkulator()
        {
            Console.WriteLine("Tworzenie");
            KalkulatorModel k = new KalkulatorModel();
            k.x = 0;
            k.y = 0;
            k.result = "0";
            return View(k);
        }

        [HttpPost]
        public IActionResult Kalkulator(KalkulatorModel k, string c)
        {
            Console.WriteLine("Akcja");
            Console.WriteLine(c);
            switch (c)
            {
                case "+":
                    Console.WriteLine("Dodawanie");
                    k.result = Convert.ToString(Convert.ToDouble(k.x) + Convert.ToDouble(k.y));
                    break;
                case "-":
                    k.result = Convert.ToString(Convert.ToDouble(k.x) - Convert.ToDouble(k.y));
                    break;
                case "*":
                    k.result = Convert.ToString(Convert.ToDouble(k.x) * Convert.ToDouble(k.y));
                    break;
                case "/":
                    if(Convert.ToDouble(k.y) == 0)
                    {
                        Console.WriteLine("Zero");
                        k.result = "Nie można dzielić przez zero!";
                        
                    }
                    else
                    {
                        k.result = Convert.ToString(Convert.ToDouble(k.x) / Convert.ToDouble(k.y));
                    }
                    break;

            }
            return View(k);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
