using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructability_Review_Test_Models
{
   public class TemplateDivisionModel
    {
        public int TemplateDivisionID { get; set; }
        public string TemplateDivisionNumber { get; set; }
        public string TemplateDivisionName { get; set; }
        public string TemplateDivisionPublic { get; set; }
        public int TemplateMajorSectionID { get; set; }
        public int TemplateDivisionSortOrder { get; set; }
        public bool TemplateDivisionActive { get; set; }
    }
}
