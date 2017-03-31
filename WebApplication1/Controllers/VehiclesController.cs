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
    public class VehiclesController : ApiController
    {
        private CarFleetEntities db = new CarFleetEntities();

        private int qry = 0;
        public class modelVehicle
        {
            public int id { get; set; }
            public int id_company { get; set; }
            public int id_fleet { get; set; }
            public int id_vehicletype { get; set; }
            public int id_driver { get; set; }
            public string name { get; set; }
            public string make { get; set; }
            public string model { get; set; }
            public int year { get; set; }
            public string plate { get; set; }
            public float odometer { get; set; }
            public string color { get; set; }
            public string chassis_number { get; set; }
            public string factory_color { get; set; }
            public DateTime installation_date_time { get; set; }
        }

        public class ModelVehicleWeekDay {
            public int id_vehicle { get; set; }
            public int id_weekday { get; set; }
            public bool allowed { get; set; }      
        }

        public class ModelVehicleDevice {
            public int id_vehicle { get; set; }
            public int id_company { get; set; }
            public string system_id { get; set; }
            public string phone_number { get; set; }
        }

        public class ModelVehiclePoi {
            public int id_vehicle { get; set; }
            public int id_poi { get; set; }
        }

        public class ModelVehicleSec
        {
            public int id { get; set; }   
            public int id_securityroute { get; set; }
            public int id_vehicle { get; set; }
            public bool time_control { get; set; }
            public DateTime start_time { get; set; }
            public DateTime end_time { get; set; }
            public bool stop_control { get; set; }
        }

        [HttpGet]
        [Route("api/Vehicles")]
        public IQueryable<Vehicle> GetVehicles()
        {
            return db.Vehicles;
        }

        [HttpGet]
        [Route("api/Vehicles_WeekDay")]
        public IQueryable<Vehicle_WeekDay> GetVehicles_WeekDay()
        {
            return db.Vehicle_WeekDay;
        }

        [HttpGet]
        [Route("api/Vehicles/Poi")]
        public IEnumerable<sp_VehiclePoiSelect_Result> GetPoi(int id)
        {

            return db.sp_VehiclePoiSelect(id).AsEnumerable();
        }

        [HttpGet]
        [Route("api/Vehicles/SecurityRoute")]
        public IEnumerable<sp_VehicleSecRouteAsign_Result> GetSecRoute(int id)
        {

            return db.sp_VehicleSecRouteAsign(id).AsEnumerable();
        }

        [HttpGet]
        [Route("api/Vehicles/SecurityRouteData")]
        public IEnumerable<sp_VehicleSecRoutePermitida_Result> GetSecRouteData(int id)
        {

            return db.sp_VehicleSecRoutePermitida(id).AsEnumerable();
        }

        // GET: api/Vehicles/5
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult GetVehicle(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        [HttpPut]
        [Route("api/Vehicles/Update")]
        public HttpResponseMessage updateVehicle(modelVehicle data)
        {
            if (data.id_driver == 0) { data.id_driver = 99999; }

            db.sp_VehicleUpdate(data.id, data.id_company, data.id_fleet, data.id_vehicletype, data.id_driver, data.name, data.make, data.model, data.year, data.plate, data.odometer, data.color,
                data.chassis_number, data.factory_color, data.installation_date_time);
            db.SaveChanges();

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        [HttpPut]
        [Route("api/Vehicles/WeekDay/Update")]
        public HttpResponseMessage updateVehicleWeekDay(ModelVehicleWeekDay data)
        {
            db.sp_VehicleWeekDayUpdate(data.id_vehicle, data.id_weekday, Convert.ToByte(data.allowed));
            db.SaveChanges();

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        [HttpPut]
        [Route("api/Vehicles/Device/Update")]
        public HttpResponseMessage updateVehiclesDevice(ModelVehicleDevice data)
        {

            db.sp_DeviceUpdate(data.id_vehicle, data.id_company, data.system_id, data.phone_number);
            db.SaveChanges();

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        [HttpPut]
        [Route("api/Vehicles/Poi/Update")]
        public HttpResponseMessage updateVehiclePoi(List<ModelVehiclePoi> data)
        {
            foreach (var item in data)
            {
                db.sp_VehiclePoiDelete(item.id_vehicle);
                db.SaveChanges();
            }

            foreach (var item in data)
            {
                db.sp_VehiclePoiInsert(item.id_vehicle, item.id_poi);
                db.SaveChanges();
            }
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        [HttpPut]
        [Route("api/Vehicles/Sec/Update")]
        public HttpResponseMessage updateVehicleSec(List<ModelVehicleSec> data)
        {
            qry = obtenerID();

            foreach (var item in data)
            {
                if (db.SecurityRoute_Vehicle.Any(x => x.id_securityroute == item.id_securityroute && x.id_vehicle == item.id_vehicle)) 
                {
                    db.sp_VehicleSecRouteUpdate(item.id, item.id_securityroute, item.id_vehicle, item.time_control, item.start_time, item.end_time, item.stop_control);
                    db.SaveChanges();
                }
                else
                {
                    db.sp_VehicleSecRouteInsert(item.id, item.id_securityroute, qry, item.time_control, item.start_time, item.end_time, item.stop_control);
                    db.SaveChanges();
                }
            }
           
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        [HttpPost]
        [Route("api/Vehicles/Insert")]
        public HttpResponseMessage insertVehicle(modelVehicle data)
        {

            db.sp_VehicleInsert(data.id_company, data.id_fleet, data.id_vehicletype, data.id_driver, data.name, data.make, data.model, data.year, data.plate, data.odometer, data.color,
                 data.chassis_number, data.factory_color, data.installation_date_time);
            db.SaveChanges();

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        [HttpPost]
        [Route("api/Vehicles/WeekDay/Insert")]
        public HttpResponseMessage insertVehicleWeekDay(ModelVehicleWeekDay data)
        {
            qry = obtenerID();

            db.sp_VehicleWeekDayInsert(qry, data.id_weekday, Convert.ToByte(data.allowed));
            db.SaveChanges();

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        [HttpPost]
        [Route("api/Vehicles/Device/Insert")]
        public HttpResponseMessage insertVehiclesDevice(ModelVehicleDevice data)
        {
            qry = obtenerID();

    

            db.sp_DeviceInsert(qry, data.id_company, data.system_id, data.phone_number);
            db.SaveChanges();

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        [HttpPost]
        [Route("api/Vehicles/Poi/Insert")]
        public HttpResponseMessage InsertVehiclePoi(List<ModelVehiclePoi> data)
        {
            qry = obtenerID();

            foreach (var item in data)
            {
                db.sp_VehiclePoiInsert(qry, item.id_poi);
                db.SaveChanges(); 
            }
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

        [HttpDelete]
        [Route("api/Vehicles/{id}")]
        public HttpResponseMessage DeleteVehicle(int id)
        {
            db.sp_DeviceDelete(id);
            db.SaveChanges();

            db.sp_VehicleWeekDayDelete(id);
            db.SaveChanges();

            db.sp_VehicleDelete(id);
            db.SaveChanges();

            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleExists(int id)
        {
            return db.Vehicles.Count(e => e.id == id) > 0;
        }

        private int obtenerID() {
            return  db.Vehicles
                    .OrderByDescending(m => m.id)
                    .FirstOrDefault()
                    .id;

        }
    }
}