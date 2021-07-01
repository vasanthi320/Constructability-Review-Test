using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructability_Review_Test_Models
{
   public class TemplateSectionModel
    {
        public int TemplateSectionID { get; set; }
        public string TemplateSectionName { get; set; }
        public int TemplateMajorSectionID { get; set; }
        public int TemplateDivisionID { get; set; }
        public int TemplateSectionSortOrder { get; set; }
        public bool TemplateSectionActive { get; set; }
    }
}
