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
    
    public partial class WizardBranch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WizardBranch()
        {
            this.WizardQuestions2WizardBranches = new HashSet<WizardQuestions2WizardBranches>();
        }
    
        public int ID { get; set; }
        public System.DateTime Modified { get; set; }
        public System.DateTime Created { get; set; }
        public bool Active { get; set; }
        public int WizardQuestionID { get; set; }
        public int WizardAnswerID { get; set; }
    
        public virtual WizardAnswer WizardAnswer { get; set; }
        public virtual WizardQuestion WizardQuestion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WizardQuestions2WizardBranches> WizardQuestions2WizardBranches { get; set; }
    }
}