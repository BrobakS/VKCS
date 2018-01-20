using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
 
namespace KartingCupStandings.Controllers
{
    public class TeamDriverController : ApiController
    {
        DatabaseEntities _db;
        public TeamDriverController()
        {
            _db = new DatabaseEntities();
        }

        // POST api/values 
        public int Post([FromBody]TeamDriver d)
        {
            _db.TeamDrivers.Add(d);
            _db.SaveChanges();
            var res = _db.TeamDrivers.FirstOrDefault(x => x.DriverId == d.DriverId && x.TeamId == d.TeamId);
            return res.Id;
        }

    }
}
