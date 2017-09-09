using BastetballStatsWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using BastetballStatsWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BastetballStatsWeb.ServiceImplementation
{
    public class PlayerService : IPlayerService
    {
        private BasketballstatsContext _context;

        public PlayerService(BasketballstatsContext context)
        {
            _context = context;
        }

        public List<Country> GetAllCountries()
        {
            return _context.Countries.ToList();
        }


        public void Insert(PlayerViewModel p)
        {
            
                _context.Players.Add(new Player
                {
                    BirthDate = p.BirthDate,
                    CountyId = p.CountyId,
                    Height = p.Height,
                    Name = p.Name,
                    Weight = p.Weight
                }); 
            
            
        }
         public int Commit()
        {
            return _context.SaveChanges();
        }

        public IEnumerable<Player> getAll()
        {
            var players = _context.Players.Include("Country").Include("PlaysFor").ToList();
            for (int i = 0; i < players.Count; i++)
            {
                int pId = players[i].PlayerId;
                List<PlaysFor> pf = _context.PlaysFor.Include("Team").Where(p => p.PlayerId == pId).ToList();
                players[i].PlaysFor = pf;
            }
            return players;
        }

        public Player GetById(int id)
        {
            var player = _context.Players.Include("Country").Include("PlaysFor").FirstOrDefault(p => p.PlayerId == id);
            var list = _context.PlaysFor.Include("Team").Where(pf => pf.PlayerId == id);
            player.PlaysFor.Last().Team = list.Last().Team;
            return player;
        }

        public void Update(PlayerViewModel p)
        {
            var player = _context.Players.Include("PlaysFor").FirstOrDefault(pl => pl.PlayerId == p.ID);
            if(player != null)
            {
                player.Name = p.Name;
                player.Height = p.Height;
                player.Weight = p.Weight;
                player.BirthDate = p.BirthDate;
                player.CountyId = p.CountyId;
                if(player.PlaysFor.Last().TeamId != p.TeamId)
                {
                    var lastPlaysFor = _context.PlaysFor.Last();
                    lastPlaysFor.DateTo = DateTime.Now;
                    var pf = new PlaysFor
                    {
                        DateFrom = DateTime.Now,
                        PlayerId = p.ID,
                        TeamId = p.TeamId
                    };
                    _context.PlaysFor.Add(pf);
                }
            }
        }
    }
}
