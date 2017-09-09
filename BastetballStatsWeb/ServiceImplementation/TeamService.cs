using BastetballStatsWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace BastetballStatsWeb.ServiceImplementation
{
    public class TeamService : ITeamService
    {
        private BasketballstatsContext _context;

        public TeamService(BasketballstatsContext context)
        {
            _context = context;
        }

        public List<Team> getAll()
        {
            return _context.Teams.ToList();
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
