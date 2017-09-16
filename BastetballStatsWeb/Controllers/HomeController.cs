using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BastetballStatsWeb.Models;
using Models;
using Microsoft.EntityFrameworkCore;
using BastetballStatsWeb.Services;

namespace BastetballStatsWeb.Controllers
{
    public class HomeController : Controller
    {
        private IGameService _gameService;

        public HomeController(IGameService gameService)
        {
            _gameService = gameService;
        }

        public IActionResult Index()
        {
            return View(_gameService.getLatestGames());
        }
        

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
