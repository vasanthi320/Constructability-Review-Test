//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Constructability_Review_Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblChecklistReview
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblChecklistReview()
        {
            this.tblChecklistReviewItems = new HashSet<tblChecklistReviewItem>();
        }
    
        public int ChecklistReviewID { get; set; }
        public Nullable<byte> ChecklistReviewJCCo { get; set; }
        public string ChecklistReviewJob { get; set; }
        public string ChecklistReviewJobName { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
    
        public virtual tblJob tblJob { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblChecklistReviewItem> tblChecklistReviewItems { get; set; }
    }
}
