using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace KartingCupStandings.Controllers
{
    public class StandInController : ApiController
    {
        DatabaseEntities _db;

        public StandInController()
        {
            _db = new DatabaseEntities();
        }

        // POST api/values 
        public int Post([FromBody]Standin s)
        {
            _db.Standins.Add(s);
            _db.SaveChanges();
            var res = _db.Standins.FirstOrDefault(x => x.TeamId == s.TeamId && x.DriverId == s.DriverId);
            return res.Id;
        }
    }
}
