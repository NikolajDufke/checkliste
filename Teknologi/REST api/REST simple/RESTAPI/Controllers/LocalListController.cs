using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTAPI.Models;

namespace RESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalListController : ControllerBase
    {
        private static List<Bil> Biler = new List<Bil>() { new Bil("m1", 1), new Bil("m2", 2), new Bil("m3", 3) };

        // GET: api/LocalList
        [HttpGet]
        public IEnumerable<Bil> Get()
        {
            return Biler;
        }

        // GET: api/LocalList/5
        [HttpGet("{id}", Name = "Get")]
        public Bil Get(int id)
        {
            return Biler.FirstOrDefault(x => x.Id == id);
        }

        // POST: api/LocalList
        [HttpPost]
        public void Post([FromBody] Bil value)
        {
            Biler.Add(value);
        }

        // PUT: api/LocalList/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Bil value)
        {
            Biler.Remove(Biler.Find(x => x.Id == id));
            Biler.Add(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Biler.Remove(Biler.Find(x => x.Id == id));
        }
    }
}
