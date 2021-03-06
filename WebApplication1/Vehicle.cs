//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehicle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicle()
        {
            this.Devices = new HashSet<Device>();
            this.MaintenanceOperation_Vehicle = new HashSet<MaintenanceOperation_Vehicle>();
            this.SecurityRoute_Vehicle = new HashSet<SecurityRoute_Vehicle>();
            this.Vehicle_Poi = new HashSet<Vehicle_Poi>();
            this.Vehicle_WeekDay = new HashSet<Vehicle_WeekDay>();
        }
    
        public int id { get; set; }
        public Nullable<int> id_company { get; set; }
        public Nullable<int> id_fleet { get; set; }
        public Nullable<int> id_vehicletype { get; set; }
        public Nullable<int> id_driver { get; set; }
        public string name { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public Nullable<int> year { get; set; }
        public string plate { get; set; }
        public Nullable<double> odometer { get; set; }
        public string image { get; set; }
        public string color { get; set; }
        public string chassis_number { get; set; }
        public string factory_color { get; set; }
        public Nullable<System.DateTime> registry_date_time { get; set; }
        public Nullable<System.DateTime> installation_date_time { get; set; }
    
        public virtual Company Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Device> Devices { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual Fleet Fleet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaintenanceOperation_Vehicle> MaintenanceOperation_Vehicle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SecurityRoute_Vehicle> SecurityRoute_Vehicle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vehicle_Poi> Vehicle_Poi { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vehicle_WeekDay> Vehicle_WeekDay { get; set; }
    }
}
