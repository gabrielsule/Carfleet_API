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
    
    public partial class SecurityRoute_Vehicle
    {
        public int id { get; set; }
        public Nullable<int> id_securityroute { get; set; }
        public Nullable<int> id_vehicle { get; set; }
        public Nullable<bool> time_control { get; set; }
        public Nullable<System.DateTime> start_time { get; set; }
        public Nullable<System.DateTime> end_time { get; set; }
        public Nullable<bool> stop_control { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> id_securityroute_point { get; set; }
        public Nullable<bool> start_delay_event_raised { get; set; }
        public Nullable<bool> end_delay_event_raised { get; set; }
        public Nullable<int> id_securityroute_point_next_stop { get; set; }
    
        public virtual SecurityRoute SecurityRoute { get; set; }
        public virtual SecurityRoute_Point SecurityRoute_Point { get; set; }
        public virtual SecurityRoute_Point SecurityRoute_Point1 { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}