using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BastetballStatsWeb.Services;

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

        public IActionResult Create()
        {
            return View();
        }
    }
}