//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModelAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Service()
        {
            this.Communities = new HashSet<Community>();
            this.Languages = new HashSet<Language>();
            this.Locations = new HashSet<Location>();
        }
    
        public int serviceID { get; set; }
        public Nullable<int> programID { get; set; }
        public Nullable<int> departmentID { get; set; }
        public Nullable<int> divisionID { get; set; }
        public string serviceName { get; set; }
        public string serviceDescription { get; set; }
        public string executiveSummary { get; set; }
        public string serviceArea { get; set; }
        public Nullable<int> contactID { get; set; }
        public string employeeConnectMethod { get; set; }
        public string customerConnectMethod { get; set; }
        public Nullable<System.DateTime> expirationDate { get; set; }
    
        public virtual Contact Contact { get; set; }
        public virtual Department Department { get; set; }
        public virtual Division Division { get; set; }
        public virtual Program Program { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Community> Communities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Language> Languages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Location> Locations { get; set; }
    }
}
