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
    
    public partial class MaintenanceOperation_Vehicle
    {
        public int id { get; set; }
        public Nullable<int> id_vehicle { get; set; }
        public Nullable<int> id_maintenanceoperation { get; set; }
        public Nullable<int> distance_notification { get; set; }
        public Nullable<int> time_notification { get; set; }
        public Nullable<int> current_distance { get; set; }
        public Nullable<System.DateTime> starting_time { get; set; }
        public Nullable<bool> maintenance_performed { get; set; }
        public Nullable<System.DateTime> performing_time { get; set; }
        public Nullable<bool> notification_sent { get; set; }
    
        public virtual MaintenanceOperation MaintenanceOperation { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
