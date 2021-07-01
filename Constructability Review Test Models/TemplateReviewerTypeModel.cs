using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructability_Review_Test_Models
{
   public class TemplateReviewerTypeModel
    {
        public int TemplateReviewerTypeID { get; set; }
        public string TemplateReviewerTypeCode { get; set; }
        public string TemplateReviewerTypeName { get; set; }
        public int TemplateReviewerTypeSortOrder { get; set; }
        public bool TemplateReviewerTypeActive { get; set; }
    }
}
