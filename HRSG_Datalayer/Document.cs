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
    
    public partial class Document
    {
        public int ID { get; set; }
        public System.DateTime Modified { get; set; }
        public System.DateTime Created { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public string Filename { get; set; }
        public int ClientID { get; set; }
    
        public virtual Client Client { get; set; }
    }
}
