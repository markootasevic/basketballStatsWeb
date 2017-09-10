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
        private IPlayerService _playerService;

        public GameController(IGameService gameService, ITeamService teamService, IPlayerService playerService)
        {
            _gameService = gameService;
            _teamService = teamService;
            _playerService = playerService;

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

        [HttpGet]
        public IActionResult AddStats(int id)
        { 
            return View(_gameService.getById(id));
        }

        [HttpPost]
        public IActionResult GetPlayerPartial(int teamId)
        {
            var players = _playerService.getAllPlayerForTeam(teamId);
            return PartialView("_PlayerSelect", players);
        }

        [HttpPost]
        public IActionResult AddStats(Stats stats,string[] Name,string[] Value, int id)
        {
            stats.GameId = id;
            stats.StatsItem = new List<StatsItem>();
            for (int i = 0; i < Name.Length; i++)
            {
                stats.StatsItem.Add(new StatsItem {
                    Name = Name[i],
                    Value = Convert.ToInt32(Value[i])
                });
            }
            _gameService.AddStats(stats);
            _gameService.Commit();
            return View("Index",_gameService.getAll());
        }
    }
}