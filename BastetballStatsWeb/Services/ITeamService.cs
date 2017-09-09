using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace BastetballStatsWeb.Services
{
    public interface ITeamService
    {
        List<Team> getAll();
        int Commit();
    }

}
