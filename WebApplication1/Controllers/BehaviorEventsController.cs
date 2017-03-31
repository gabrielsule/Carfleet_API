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
    public class BehaviorEventsController : ApiController
    {
        private CarFleetEntities db = new CarFleetEntities();

        public class modelBehavior
        {
            public int id { get; set; }
        }

        [HttpGet]
        [Route("api/Behavior/Speed")]
        public IEnumerable<sp_behaviorSpeed_Result> getSpeed(int id)
        {
            return db.sp_behaviorSpeed(id).AsEnumerable();
        }

        [HttpGet]
        [Route("api/Behavior/Odometer")]
        public IEnumerable<sp_behaviorOdometer_Result> getOdometer(int id)
        {
            return db.sp_behaviorOdometer(id).AsEnumerable();
        }

        [HttpGet]
        [Route("api/Behavior/Events")]
        public IEnumerable<sp_behaviorEvents_Result> getEvents(int id)
        {
            return db.sp_behaviorEvents(id).AsEnumerable();
        }
    }
}