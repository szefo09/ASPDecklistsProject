using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DecklistProjectASP.Models;
using Microsoft.AspNetCore.Authorization;
using DecklistProjectASP.Data;
using DecklistProjectASP.ViewModel;

namespace DecklistProjectASP.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            DecksUsersAmount dua = new DecksUsersAmount()
            {
                DecksAmount = _context.Decklists.Count(),
                UsersAmount = _context.Users.Count()
            };

            return View(dua);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "YGOPro Deck Archiver";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact";

            return View();
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
