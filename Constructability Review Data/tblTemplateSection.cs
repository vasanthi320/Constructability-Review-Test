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
    
    public partial class tblTemplateSection
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblTemplateSection()
        {
            this.tblTemplateSectionItems = new HashSet<tblTemplateSectionItem>();
        }
    
        public int TemplateSectionID { get; set; }
        public string TemplateSectionName { get; set; }
        public int TemplateMajorSectionID { get; set; }
        public int TemplateDivisionID { get; set; }
        public int TemplateSectionSortOrder { get; set; }
        public bool TemplateSectionActive { get; set; }
    
        public virtual tblTemplateDivision tblTemplateDivision { get; set; }
        public virtual tblTemplateMajorSection tblTemplateMajorSection { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTemplateSectionItem> tblTemplateSectionItems { get; set; }
    }
}