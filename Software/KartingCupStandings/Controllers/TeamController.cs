using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace KartingCupStandings.Controllers
{
    public class TeamController : ApiController
    {
        DatabaseEntities _db;

        public TeamController()
        {
            _db = new DatabaseEntities();
        }


        // POST api/values 
        public int Post([FromBody]Team s)
        {
            _db.Teams.Add(s);
            _db.SaveChanges();
            var res = _db.Teams.FirstOrDefault(x => x.Name == s.Name);
            foreach (var driver in s.TeamDrivers)
            {
                _db.TeamDrivers.Add(driver);
            }
            return res.Id;
        }


    }
}
