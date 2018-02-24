using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;
using Newtonsoft.Json;

namespace KartingCupStandings.Controllers
{
    public class SeasonsController : ApiController
    {
        DatabaseEntities _db;

        public SeasonsController()
        {
            _db = new DatabaseEntities();
        }

        // GET api/values 
        public List<Season> Get()
        {
            return _db.Seasons.ToList();
        }

        [Route("api/seasons/{seasonId}/drivers")]
        public List<Driver> GetDriversForSeason(int seasonId)
        {
            var races = _db.Races.Where(x => x.SeasonId == seasonId);
            var results = _db.RaceResults.Where(x => races.Any(r => r.Id == x.RaceId));
            var drivers = _db.Drivers.ToList();
            drivers.ForEach(x => x.RaceResults = results.Where(r => r.DriverId == x.Id).ToList());

            return drivers.Where(x => x.RaceResults.Count > 0).ToList();
        }

        [Route("api/seasons/{seasonId}/teams")]
        public List<Team> GetTeamsForSeason(int seasonId)
        {
            var teams = _db.Teams.Where(x => x.SeasonId == seasonId).ToList();

            teams.ForEach(x => x.TeamDrivers = _db.TeamDrivers.Where(z => x.Id == z.TeamId).ToList());
            teams.ForEach(x => x.Standins = _db.Standins.Where(z => x.Id == z.TeamId).ToList());
            return teams;
        }

        // POST api/values 
        public int Post([FromBody]Season s)
        {
            _db.Seasons.Add(s);
            _db.SaveChanges();
            var res = _db.Seasons.FirstOrDefault(x => x.Name == s.Name);
            return res.Id;
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]Season d)
        {
            var res = _db.Seasons.FirstOrDefault(x => x.Id == id);
            res.Name = d.Name;
            res.Description = d.Description;
            _db.SaveChanges();
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
            var res = _db.Seasons.FirstOrDefault(x => x.Id == id);
            _db.Seasons.Remove(res);
            _db.SaveChanges();
        }

    }
}
