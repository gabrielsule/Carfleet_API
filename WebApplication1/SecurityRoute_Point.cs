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
    
    public partial class SecurityRoute_Point
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SecurityRoute_Point()
        {
            this.SecurityRoute_Vehicle = new HashSet<SecurityRoute_Vehicle>();
            this.SecurityRoute_Vehicle1 = new HashSet<SecurityRoute_Vehicle>();
        }
    
        public int id { get; set; }
        public Nullable<int> id_securityroute { get; set; }
        public Nullable<int> id_point { get; set; }
        public Nullable<int> route_point_order { get; set; }
        public Nullable<bool> is_stop { get; set; }
        public Nullable<int> stop_time { get; set; }
    
        public virtual Point Point { get; set; }
        public virtual SecurityRoute SecurityRoute { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SecurityRoute_Vehicle> SecurityRoute_Vehicle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SecurityRoute_Vehicle> SecurityRoute_Vehicle1 { get; set; }
    }
}
