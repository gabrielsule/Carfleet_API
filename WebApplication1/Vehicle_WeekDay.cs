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
    
    public partial class Vehicle_WeekDay
    {
        public int id { get; set; }
        public Nullable<int> id_vehicle { get; set; }
        public Nullable<int> id_weekday { get; set; }
        public Nullable<byte> allowed { get; set; }
    
        public virtual Vehicle Vehicle { get; set; }
        public virtual WeekDay WeekDay { get; set; }
    }
}
