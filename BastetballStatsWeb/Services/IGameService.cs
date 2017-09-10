using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace BastetballStatsWeb.Services
{
    public interface IGameService
    {
        int Commit();
        void Insert(Game game);
        IEnumerable<Game> getAll();
        List<Stats> getStatsForGame(int gameId);
    }
}
