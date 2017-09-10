using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BastetballStatsWeb.Models;

namespace BastetballStatsWeb.Services
{
    public interface IPlayerService
    {
        List<Country> GetAllCountries();
        void Insert(PlayerViewModel p);
        int Commit();
        IEnumerable<Player> getAll();
        Player GetById(int id);
        void Update(PlayerViewModel p);
        List<Player> getAllPlayerForTeam(int teamId);
    }
}
