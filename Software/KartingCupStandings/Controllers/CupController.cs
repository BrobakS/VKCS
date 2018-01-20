using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;
using System.Net;

namespace KartingCupStandings
{
    public class CupsController : ApiController
    {
        DatabaseEntities _db;

        public CupsController()
        {
            _db = new DatabaseEntities();
        }

        // GET api/values 
        public List<Cup> Get()
        {
             var Cups = _db.Cups
                .Include(x => x.Seasons.Select(s => s.Races))
                .Include(x => x.Seasons.Select(s => s.PointSystem))
                .Include(x => x.Seasons.Select(s => s.PointSystem).Select(p => p.ClassTypes))
                .ToList();
            var seasons = Cups.Select(x => x.Seasons);


            return Cups;
        }

        // GET api/values/5 
        public Cup Get(int id)
        {
            return _db.Cups.FirstOrDefault(x => x.Id == id);
        }

        // POST api/values 
        public int Post([FromBody]Cup c)
        {
            if (c != null)
            {
                _db.Cups.Add(c);
                _db.SaveChanges();
                var res = _db.Cups.FirstOrDefault(x => x.Name == c.Name);
                return res.Id;
            }
            return 0;
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]Cup c)
        {
            var res = _db.Cups.FirstOrDefault(x => x.Id == id);
            res.Name = c.Name;
            res.Description = c.Description;
            _db.SaveChanges();
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
            var res = _db.Cups.FirstOrDefault(x => x.Id == id);
            _db.Cups.Remove(res);
            _db.SaveChanges();
        }
    }
}
