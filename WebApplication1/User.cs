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
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.EventPolicies = new HashSet<EventPolicy>();
            this.User_Fleet = new HashSet<User_Fleet>();
            this.UserLogins = new HashSet<UserLogin>();
        }
    
        public int id { get; set; }
        public Nullable<int> id_usertype { get; set; }
        public Nullable<int> id_company { get; set; }
        public Nullable<int> id_language { get; set; }
        public string name { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public Nullable<System.DateTime> sign_in_date { get; set; }
        public Nullable<System.DateTime> expiration_date { get; set; }
        public string events_email_address { get; set; }
        public string gcm_registration_id { get; set; }
        public string gcm_registration_device { get; set; }
        public string surname { get; set; }
        public string validation_code { get; set; }
        public Nullable<bool> user_validated { get; set; }
    
        public virtual Company Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventPolicy> EventPolicies { get; set; }
        public virtual Language Language { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Fleet> User_Fleet { get; set; }
        public virtual UserType UserType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserLogin> UserLogins { get; set; }
    }
}
