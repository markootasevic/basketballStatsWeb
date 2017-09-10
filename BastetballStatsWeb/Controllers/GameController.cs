using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BastetballStatsWeb.Services;
using Models;

namespace BastetballStatsWeb.Controllers
{
    public class GameController : Controller
    {
        private IGameService _gameService;
        private ITeamService _teamService;

        public GameController(IGameService gameService, ITeamService teamService)
        {
            _gameService = gameService;
            _teamService = teamService;

        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Teams = _teamService.getAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Game game)
        {
            _gameService.Insert(game);
            _gameService.Commit();
            return View("Index", _gameService.getAll());
        }

        public IActionResult Index()
        {
            return View(_gameService.getAll());
        }

        public IActionResult Stats(int id)
        {
            var stat = _gameService.getStatsForGame(id);
            return View(stat);
        }
    }
}