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
    
    public partial class sp_VehicleSecRoutePermitida_Result
    {
        public int id { get; set; }
        public Nullable<int> id_securityroute { get; set; }
        public Nullable<int> id_vehicle { get; set; }
        public Nullable<bool> time_control { get; set; }
        public Nullable<System.DateTime> start_time { get; set; }
        public Nullable<System.DateTime> end_time { get; set; }
        public Nullable<bool> stop_control { get; set; }
        public string name { get; set; }
    }
}