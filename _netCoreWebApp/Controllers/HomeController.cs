using _netCoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _netCoreWebApp.Controllers
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
            //HomeModel homeModel = new HomeModel
            //{
            //    Users = new List<Tuple<int, string, string, string>>
            //    { new Tuple<int, string, string, string>(1,"" , "" , "") },
            //    Clients = new List<Tuple<int, string, string, string>> 
            //    { new Tuple<int, string, string, string>(1,"" , "" , "") },
            //    Orders = new List<Tuple<int, string, string, string>>
            //    { new Tuple<int, string, string, string>(1,"" , "" , "") },
            //    Invoices = new List<Tuple<int, DateTime , double>>
            //    { new Tuple<int, DateTime , double>(1,DateTime.Now , 2.0) },


            //};
            return View(/*homeModel*/);
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
