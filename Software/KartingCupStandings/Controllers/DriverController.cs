using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace KartingCupStandings.Controllers
{
    public class DriversController : ApiController
    {
        DatabaseEntities _db;

        public DriversController()
        {
            _db = new DatabaseEntities();
        }

        // GET api/values 
        public List<Driver> Get()
        {
            return _db.Drivers.ToList();
        }


        // GET api/values/5 
        public Driver Get(int id)
        {
            return _db.Drivers.FirstOrDefault(x => x.Id == id);
        }

        // POST api/values 
        public int Post([FromBody]Driver d)
        {
            //Console.WriteLine(d.Name);
            _db.Drivers.Add(d);
            _db.SaveChanges();
            var res = _db.Drivers.FirstOrDefault(x => x.Name == d.Name);
            return res.Id;
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]Driver d)
        {
            var res = _db.Drivers.FirstOrDefault(x => x.Id == id);
            res.Name = d.Name;
            res.DisplayName = d.DisplayName;
            _db.SaveChanges();
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
            var res =_db.Drivers.FirstOrDefault(x => x.Id == id);
            _db.Drivers.Remove(res);
            _db.SaveChanges();
        }
    }
}
