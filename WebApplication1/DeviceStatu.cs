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
    
    public partial class DeviceStatu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeviceStatu()
        {
            this.Events = new HashSet<Event>();
            this.Routes = new HashSet<Route>();
            this.Routes1 = new HashSet<Route>();
        }
    
        public int id { get; set; }
        public Nullable<int> id_device { get; set; }
        public string ip_address { get; set; }
        public Nullable<int> ip_port { get; set; }
        public Nullable<System.DateTime> reception_date_time { get; set; }
        public Nullable<System.DateTime> gps_date_time { get; set; }
        public string location_string { get; set; }
        public Nullable<double> latitude { get; set; }
        public Nullable<double> longitude { get; set; }
        public Nullable<int> fix_quality { get; set; }
        public Nullable<int> satellites_in_use { get; set; }
        public Nullable<int> satellites_in_view { get; set; }
        public Nullable<double> hdop { get; set; }
        public Nullable<double> vdop { get; set; }
        public Nullable<double> pdop { get; set; }
        public Nullable<double> altitude { get; set; }
        public Nullable<double> course { get; set; }
        public Nullable<double> speed { get; set; }
        public Nullable<int> activity { get; set; }
        public Nullable<double> total_gps_odometer { get; set; }
        public Nullable<double> partial_gps_odometer { get; set; }
        public Nullable<bool> engine_state { get; set; }
        public Nullable<bool> gpdi_1 { get; set; }
        public Nullable<bool> gpdi_2 { get; set; }
        public Nullable<bool> gpdi_3 { get; set; }
        public Nullable<bool> gpdi_4 { get; set; }
        public Nullable<int> gpai_1 { get; set; }
        public Nullable<int> gpai_2 { get; set; }
        public Nullable<int> location_source { get; set; }
        public Nullable<int> battery_level { get; set; }
        public Nullable<int> activity_time { get; set; }
        public Nullable<int> road_max_speed { get; set; }
        public string vehicle_vin { get; set; }
        public Nullable<int> engine_rpm { get; set; }
        public Nullable<System.DateTime> utc_gps_date_time { get; set; }
    
        public virtual Device Device { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Events { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Route> Routes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Route> Routes1 { get; set; }
    }
}
