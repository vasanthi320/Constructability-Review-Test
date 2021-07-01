using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructability_Review_Test_Models
{
   public class TemplateSectionItemModel
    {
        public int TemplateSectionItemID { get; set; }
        public string TemplateSectionItemCode { get; set; }
        public string TemplateSectionItemName { get; set; }
        public string TemplateSectionItemLink { get; set; }
        public int TemplateSectionID { get; set; }
        public int TemplateSectionItemSortOrder { get; set; }
        public bool TemplateSectionItemActive { get; set; }
    }
}
