using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructability_Review_Test_Models
{
   public class TemplateListModel
    {
        public int TemplateSectionID { get; set; }
        public string TemplateSectionName { get; set; }
        public int TemplateMajorSectionID { get; set; }
        public int TemplateDivisionID { get; set; }       
        public string TemplateMajorSectionName { get; set; }
        public int TemplateSectionSortOrder { get; set; }
        public bool TemplateSectionActive { get; set; }
        public int TemplateMajorSectionSortOrder { get; set; }
        public bool TemplateMajorSectionActive { get; set; }
        public List<TemplateSectionModel> TemplatesectionDetails { get; set; }
        public int TemplateSectionItemID { get; set; }
        public string TemplateSectionItemCode { get; set; }
        public string TemplateSectionItemName { get; set; }
        public string TemplateSectionItemLink { get; set; }       
        public int TemplateSectionItemSortOrder { get; set; }
        public bool TemplateSectionItemActive { get; set; }        
        public List<TemplateSectionItemModel> TemplatesectionItemDetails { get; set; }      
        public string TemplateDivisionNumber { get; set; }
        public string TemplateDivisionName { get; set; }
        public string TemplateDivisionPublic { get; set; }        
        public int TemplateDivisionSortOrder { get; set; }
        public bool TemplateDivisionActive { get; set; }
        public List<TemplateDivisionModel> TemplateDivisionDtls { get; set; }
        public string SectionName { get; set; }
    }
}
