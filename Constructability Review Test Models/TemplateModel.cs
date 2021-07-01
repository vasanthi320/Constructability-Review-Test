using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructability_Review_Test_Models
{
    public class TemplateModel
    {
        public List<JobModel> JobList { get; set; }
        public byte JCCo { get; set; }
        public string Job { get; set; }
        public Nullable<int> JobNum { get; set; }
        public string JobDescription { get; set; }
        public Nullable<bool> JobActive { get; set; }
        public string JobErrorMessage { get; set; }
        public List<TemplateDesignLevelModel> designList { get; set; }
        public int TemplateDesignLevelID { get; set; }
        public string TemplateDesignLevelCode { get; set; }
        public string TemplateDesignLevelName { get; set; }
        public int TemplateDesignLevelSortOrder { get; set; }
        public bool TemplateDesignLevelActive { get; set; }
        public List<TemplateMajaorSectionModel> TempMajSection { get; set; }
        public List<TemplateSectionModel> TempSections { get; set; }
        public List<TemplateSectionItemModel> TempSectionItems{get;set;}
    }
}
