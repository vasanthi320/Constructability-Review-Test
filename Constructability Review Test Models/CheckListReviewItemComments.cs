using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Constructability_Review_Test_Models
{
    public class CheckListReviewItemComments
    {
        public int ChecklistReviewItemCommentID { get; set; }
        public Nullable<int> ChecklistReviewItemID { get; set; }
        public Nullable<int> ChecklistReviewDesignLevelID { get; set; }
        public string ChecklistReviewDesignLevelCode { get; set; }
        public string ChecklistReviewDesignLevelName { get; set; }
        public string ChecklistReviewItemReviewerRole { get; set; }
        public string ChecklistReviewItemReviewerResultName { get; set; }
        public string ChecklistReviewItemReviewerResultComments { get; set; }
        public string Attachment { get; set; }
        public string AttachmentName { get; set; }  
        public HttpPostedFileBase FAttachment { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string ModifiedUser { get; set; }
        public List<CheckListReviewItemModel> tblChecklistReviewItem { get; set; }
        public int CheckListReviewID { get; set; }
        public int ChecklistReviewItemMajorSectionID { get; set; }
        public string ChecklistReviewItemMajorSectionName { get; set; }
    }
}
