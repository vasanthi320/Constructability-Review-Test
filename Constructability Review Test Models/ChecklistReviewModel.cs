using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructability_Review_Test_Models
{
    public class ChecklistReviewModel
    { 
        public int ChecklistReviewID { get; set; }
        public Nullable<byte> ChecklistReviewJCCo { get; set; }
        public string ChecklistReviewJob { get; set; }
        public string ChecklistReviewJobName { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }

             
        //public virtual ICollection<ChecklistReviewItem> ChecklistReviewItems { get; set; }
       
      
      

    }
}
