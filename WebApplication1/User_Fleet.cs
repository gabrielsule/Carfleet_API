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
    
    public partial class User_Fleet
    {
        public int id { get; set; }
        public int id_user { get; set; }
        public int id_fleet { get; set; }
    
        public virtual Fleet Fleet { get; set; }
        public virtual User User { get; set; }
    }
}
