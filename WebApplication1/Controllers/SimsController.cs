using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1;

namespace WebApplication1.Controllers
{
    public class SimsController : ApiController
    {
        private CarFleetEntities db = new CarFleetEntities();

        public class modelSim{
            public int id { get; set; }
            public string operador { get; set; }
            public string number { get; set; }
            public string icc { get; set; }
        }

        public class modelSimGroup
        {
            public int id { get; set; }
            public string operador { get; set; }
            public string number { get; set; }
            public string icc { get; set; }
            public string system_id { get; set; }
        }

        [HttpGet]
        [Route("api/Sims")]
        public IQueryable<Sim> GetSims()
        {
            return db.Sims;
        }
        [HttpGet]
        [Route("api/Sims/Group")]
        public IEnumerable<modelSimGroup> getSimsGroup()
        {
            var studentercord = db.sp_SimSelect().ToList();
            IEnumerable<modelSimGroup> data = (from item in studentercord
                                               select new modelSimGroup
                                               {
                                                   id = item.id,
                                                   operador = item.@operator,
                                                   number = item.number,
                                                   icc = item.icc,
                                                   system_id = item.system_id
                                               }).ToList();

            return data;
        }

        [HttpGet]
        [Route("api/Sims/{id}")]
        [ResponseType(typeof(Sim))]
        public IHttpActionResult GetSimId(int id)
        {
            Sim sim = db.Sims.Find(id);
            if (sim == null)
            {
                return NotFound();
            }

            return Ok(sim);
        }

        [HttpGet]
        [Route("api/Sims/Operator")]
        [ResponseType(typeof(Sim))]
        public List<String> getOperators()
        {
            var temp = db.Sims
                .Select(d => d.@operator)
                .Distinct()
                .ToList();
                return temp;
        }


        [HttpPut]
        [Route("api/Sims/Update")]
        public HttpResponseMessage updateUsers(modelSim data)
        {

            db.sp_SimUpdate(data.id, data.operador, data.number, data.icc);
            db.SaveChanges();

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        [HttpPost]
        [Route("api/Sims/Insert")]
        public HttpResponseMessage insertUser(modelSim data)
        {

            db.sp_SimInsert(data.operador, data.number, data.icc);
            db.SaveChanges();

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        [HttpDelete]
        [Route("api/Sims/Delete")]
        [ResponseType(typeof(Sim))]
        public IHttpActionResult DeleteSim(int id)
        {
            Sim sim = db.Sims.Find(id);
            if (sim == null)
            {
                return NotFound();
            }

            db.Sims.Remove(sim);
            db.SaveChanges();

            return Ok(sim);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SimExists(int id)
        {
            return db.Sims.Count(e => e.id == id) > 0;
        }
    }
}