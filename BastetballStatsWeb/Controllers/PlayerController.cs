using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BastetballStatsWeb.Services;
using Models;
using BastetballStatsWeb.Models;

namespace BastetballStatsWeb.Controllers
{
    public class PlayerController : Controller
    {
        private IPlayerService _playerService;
        private ITeamService _teamService;

        public PlayerController(IPlayerService playerService, ITeamService teamService)
        {
            _playerService = playerService;
            _teamService = teamService;
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Counties = _playerService.GetAllCountries();
            return View();
        }
        [HttpPost]
        public IActionResult Add(PlayerViewModel player)
        {
            _playerService.Insert(player);
            int res = _playerService.Commit();
            if(res > 0)
            {
                ViewBag.InserPlayerSuccess = "You have successfully inserted a player";
            } else
            {
                ViewBag.InserPlayerError = "There was an error, please try again!";
            }
            ViewBag.Counties = _playerService.GetAllCountries();
            return View("Add");
        }

        public IActionResult Search()
        {
            return View(_playerService.getAll());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Teams = _teamService.getAll();
            ViewBag.Counties = _playerService.GetAllCountries();
            var player = _playerService.GetById(id);
            player.Name = player.Name.Trim();
            return View(player);
        }

        [HttpPost]
        public IActionResult Edit(PlayerViewModel player, int id)
        {
            player.ID = id;
            _playerService.Update(player);
            int res = _playerService.Commit();
            return RedirectToAction("Search");
        }
    }
}