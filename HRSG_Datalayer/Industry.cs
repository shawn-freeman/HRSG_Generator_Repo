//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRSG_Datalayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Industry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Industry()
        {
            this.Clients = new HashSet<Client>();
            this.IndustrySections = new HashSet<IndustrySection>();
        }
    
        public int ID { get; set; }
        public System.DateTime Modified { get; set; }
        public System.DateTime Created { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Client> Clients { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IndustrySection> IndustrySections { get; set; }
    }
}