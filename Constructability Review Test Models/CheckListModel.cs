using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Constructability_Review_Test_Models
{
   public class CheckListModel
    {
        public string ProjectName {
            get { return string.Format("{0} {1}", ChecklistReviewJob, ChecklistReviewJobName); }
        }
        public string ProjectDescription { get; set; }
        public  List<ChecklistReviewModel> CheckListReviewDetails { get; set; }
        
        public string MajorSectionName { get; set; }
        public int ChecklistReviewID { get; set; }
        public Nullable<byte> ChecklistReviewJCCo { get; set; }
        public string ChecklistReviewJob { get; set; }
        public string ChecklistReviewJobName { get; set; }
       
        
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> ChecklistReviewDrawingDate { get; set; }
        public System.DateTime ChecklistReviewCreatedDate { get; set; }
        public string ChecklistReviewCreatedUser { get; set; }
        public System.DateTime ChecklistReviewModifiedDate { get; set; }
        public string ChecklistReviewModifiedUser { get; set; }
        public List<CheckListReviewItemModel> CheckListReviewItemDetails{ get; set; }
        public int ChecklistReviewItemID { get; set; }        
        public Nullable<int> ChecklistReviewItemMajorSectionID { get; set; }
        public string ChecklistReviewItemMajorSectionName { get; set; }
        public Nullable<int> ChecklistReviewItemMajorSectionSortOrder { get; set; }
        public Nullable<int> ChecklistReviewItemDivisionID { get; set; }
        public string ChecklistReviewItemDivisionNumber { get; set; }
        public string ChecklistReviewItemDivisionName { get; set; }
        public string ChecklistReviewItemDivisionPublic { get; set; }
        public Nullable<int> ChecklistReviewItemDivisionSortOrder { get; set; }
        public Nullable<int> ChecklistReviewItemSectionID { get; set; }
        public string ChecklistReviewItemSectionName { get; set; }
        public Nullable<int> ChecklistReviewItemSectionSortOrder { get; set; }
        public Nullable<int> ChecklistReviewItemSectionItemID { get; set; }
        public string ChecklistReviewItemSectionItemCode { get; set; }
        public string ChecklistReviewItemSectionItemName { get; set; }
        public string ChecklistReviewItemSectionItemLink { get; set; }
        public Nullable<int> ChecklistReviewItemSectionItemSortOrder { get; set; }
        public bool ChecklistReviewItemVisible { get; set; }
       
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public Nullable<System.DateTime> ChecklistReviewItemModifiedDate { get; set; }
        public string ModifiedUser { get; set; }

        public System.DateTime ModifiedDate { get; set; }
     
     
        public System.DateTime ChecklistReviewItemCreatedDate { get; set; }
        public string ChecklistReviewItemCreatedUser { get; set; }       
        public string ChecklistReviewItemModifiedUser { get; set; }
        public string ErrorMessage { get; set; }
        public bool ChecklistReviewItemReviewerActive { get; set; }       
        public List<ChecklistReviewModel> ChecklistReviewList { get; set; }
        public bool ChecklistReviewItemActive { get; set; }
        //----------------
          public int ChecklistReviewItemCommentID { get; set; }
       
        public Nullable<int> ChecklistReviewDesignLevelID { get; set; }
        public string ChecklistReviewDesignLevelCode { get; set; }
        public string ChecklistReviewDesignLevelName { get; set; }
        public string ChecklistReviewItemReviewerRole { get; set; }
        public string ChecklistReviewItemReviewerResultName { get; set; }
        public string ChecklistReviewItemReviewerResultComments { get; set; }
        public System.DateTime CheckListReviewerCommentsCreatedDate { get; set; }
        public string CheckListReviewerCommentsCreatedUser { get; set; }
        public System.DateTime CheckListReviewerCommentsModifiedDate { get; set; }
        public string CheckListReviewerCommentsModifiedUser { get; set; }
        public string Attachment { get; set; }
        public string AttachmentName { get; set; }
        public IList<CheckListReviewItemComments> ChecklistReviewItemCommentDetails { get; set; }
    }
}
