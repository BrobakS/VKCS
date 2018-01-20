using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;

namespace KartingCupStandings.Controllers
{
    public class RacesController : ApiController
    {
        DatabaseEntities _db;

        public RacesController()
        {
            _db = new DatabaseEntities();
        }

        public List<Race> Get()
        {
            return _db.Races.ToList();
        }


        // POST api/values 
        public int Post([FromBody]Race r)
        {
            Season season = _db.Seasons.FirstOrDefault(x => x.Id == r.SeasonId);

            var classes = _db.ClassTypes.Where(x => x.PointSystemId == season.PointSystemId);

            var positions = _db.ClassPointSystems.Where(x => classes.Any(c => c.Id == x.ClassId)).ToList();

            _db.Races.Add(r);
            _db.SaveChanges();

            var res = _db.Races.FirstOrDefault(x => x.Name == r.Name && x.SeasonId == r.SeasonId);

            positions.ForEach(x => _db.RaceResults.Add(new RaceResult { RaceId=res.Id, Position = x.Position, ClassTypeId = x.ClassId}));
            _db.SaveChanges();


            return res.Id;
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]Race r)
        {
            var res = _db.Races.FirstOrDefault(x => x.Id == id);
            res.Name = r.Name;
            _db.SaveChanges();
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
            var res = _db.Races.FirstOrDefault(x => x.Id == id);
            if(res != null)
                _db.Races.Remove(res);
            _db.RaceResults.RemoveRange(_db.RaceResults.Where(x => x.RaceId == id));
            _db.SaveChanges();
        }

        [Route("api/race/{raceId}/{teamId}/{standinId}")]
        public void AddStandin(int raceId, int teamId, int standinId)
        {
            _db.Standins.Add(new Standin { DriverId = standinId, TeamId = teamId, RaceId = raceId });
        }
    }
}
