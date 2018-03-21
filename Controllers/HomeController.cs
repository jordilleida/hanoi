using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HanoiGame.Models;


namespace HanoiGame.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Models.Entities.Hanoi hanoi = new Models.Entities.Hanoi(8);

            hanoi.start(); 
            ViewBag.Total = hanoi.total;

            return View();
        }

    }
}
