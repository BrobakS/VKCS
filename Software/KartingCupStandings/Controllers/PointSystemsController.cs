using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;

namespace KartingCupStandings.Controllers
{
    public class PointSystemsController : ApiController
    {
        DatabaseEntities _db;

        public PointSystemsController()
        {
            _db = new DatabaseEntities();
        }

        // GET api/values 
        public List<PointSystem> Get()
        {
            return _db.PointSystems
                .Include(x => x.ClassTypes.Select(s => s.ClassPointSystems))
                .ToList();
        }

        // GET api/values 
        public List<PointSystem> Get(int id)
        {
            return _db.PointSystems.Where(z => z.Id == id)
                .Include(x => x.ClassTypes.Select(s => s.ClassPointSystems))
                .ToList();
        }

    }
}
