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
    
    public partial class tblTemplateSectionItem
    {
        public int TemplateSectionItemID { get; set; }
        public string TemplateSectionItemCode { get; set; }
        public string TemplateSectionItemName { get; set; }
        public string TemplateSectionItemLink { get; set; }
        public int TemplateSectionID { get; set; }
        public int TemplateSectionItemSortOrder { get; set; }
        public bool TemplateSectionItemActive { get; set; }
    
        public virtual tblTemplateSection tblTemplateSection { get; set; }
    }
}
