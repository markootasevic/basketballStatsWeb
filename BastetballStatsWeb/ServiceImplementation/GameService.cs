using BastetballStatsWeb.Services;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BastetballStatsWeb.ServiceImplementation
{
    public class GameService : IGameService
    {
        private BasketballstatsContext _context;

        public GameService(BasketballstatsContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Insert(Game game)
        {
            _context.Add(game);
        }

        public IEnumerable<Game> getAll()
        {
            return _context.Games.Include("HomeTeam").Include("GuestTeam").ToList();
        }

        public List<Stats> getStatsForGame(int gameId)
        {
            return _context.Stats.Include("StatsItem").Include("Player").Where(s => s.GameId == gameId).ToList();
        }
    }
}
