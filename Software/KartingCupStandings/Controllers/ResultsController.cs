using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;

namespace KartingCupStandings.Controllers
{
    public class ResultsController : ApiController
    {
        DatabaseEntities _db;

        public ResultsController()
        {
            _db = new DatabaseEntities();
        }

        // GET api/values 
        public List<RaceResult> Get(int id)
        {
            var races = _db.RaceResults.Where(x => x.RaceId == id).ToList();
            
            return races;
        }

        // POST api/values 
        public int Post([FromBody]RaceResult r)
        {
            _db.RaceResults.Add(r);
            _db.SaveChanges();
            var res = _db.RaceResults.FirstOrDefault(x => x.RaceId == r.RaceId && x.Position == r.Position);
            return res.Id;
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]RaceResult r)
        {
            var res = _db.RaceResults.FirstOrDefault(x => x.Id == id);
            res.DriverId = r.DriverId;
            _db.SaveChanges();
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
            var res = _db.RaceResults.FirstOrDefault(x => x.Id == id);
            _db.RaceResults.Remove(res);
            _db.SaveChanges();
        }

    }
}
