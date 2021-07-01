using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructability_Review_Test_Models
{
  public class CheckListReviewItemModel
    {
        public int ChecklistReviewItemID { get; set; }
        public Nullable<int> ChecklistReviewID { get; set; }
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
        public Nullable<System.DateTime> ChecklistReviewItemCreatedDate { get; set; }
        public string ChecklistReviewItemCreatedUser { get; set; }
        public Nullable<System.DateTime> ChecklistReviewItemModifiedDate { get; set; }
        public string ChecklistReviewItemModifiedUser { get; set; }
        public  List<ChecklistReviewModel> ChecklistReviewList { get; set; }
        public List<CheckListReviewItemComments> ChecklistReviewItemCommentsDtls { get; set; }
        public bool ChecklistReviewItemActive { get; set; }
    }
}
