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
    public class DevicesController : ApiController
    {
        private CarFleetEntities db = new CarFleetEntities();

        public class DeviceModelGral {
            public int id { get; set; }
            public string name { get; set; }
        }

        public class DeviceSimsGral
        {
            public int id { get; set; }
            public int id_devicemodel { get; set; }
            public int id_sim { get; set; }
            public string system_id { get; set; }
            public string imei { get; set; }
            public string phone_number { get; set; }
        }

        [HttpGet]
        [Route("api/Devices")]
        public IQueryable<Device> GetDevices()
        {
            return db.Devices;
        }

        [HttpGet]
        [Route("api/Devices/{id}")]
        [ResponseType(typeof(Device))]
        public IHttpActionResult GetDevice(int id)
        {
            Device device = db.Devices.Find(id);
            if (device == null)
            {
                return NotFound();
            }

            return Ok(device);
        }

        [HttpGet]
        [Route("api/Devices/Models")]
        [ResponseType(typeof(Sim))]
        public List<DeviceModelGral> getModels()
        {
            var temp = db.DeviceModels
                .Select(d => new DeviceModelGral
                {
                    id = d.id,
                    name = d.name
                })
                .ToList();
            return temp;
        }



        [HttpPut]
        [Route("api/Devices/Update")]
        public HttpResponseMessage DeviceGralUpdate(DeviceSimsGral data)
        {

            db.sp_DeviceGralUpdate(data.id, data.id_devicemodel, data.id_sim, data.system_id, data.imei, data.phone_number);
            db.SaveChanges();

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        [HttpPost]
        [Route("api/Devices/Insert")]
        public HttpResponseMessage DeviceGralInsert(DeviceSimsGral data)
        {

            db.sp_DeviceGralInsert(data.id_devicemodel, data.id_sim, data.system_id, data.imei, data.phone_number);
            db.SaveChanges();

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        //DELETE: api/Devices/5
        [ResponseType(typeof(Device))]
        public IHttpActionResult DeleteDevice(int id)
        {
            Device device = db.Devices.Find(id);
            if (device == null)
            {
                return NotFound();
            }

            db.Devices.Remove(device);
            db.SaveChanges();

            return Ok(device);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DeviceExists(int id)
        {
            return db.Devices.Count(e => e.id == id) > 0;
        }
    }
}