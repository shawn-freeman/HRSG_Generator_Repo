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
    
    public partial class WizardAnswer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WizardAnswer()
        {
            this.WizardBranches = new HashSet<WizardBranch>();
            this.WizardQuestions2Answers = new HashSet<WizardQuestions2Answers>();
        }
    
        public int ID { get; set; }
        public System.DateTime Modified { get; set; }
        public System.DateTime Created { get; set; }
        public bool Active { get; set; }
        public string Descriptions { get; set; }
        public int Rank { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WizardBranch> WizardBranches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WizardQuestions2Answers> WizardQuestions2Answers { get; set; }
    }
}