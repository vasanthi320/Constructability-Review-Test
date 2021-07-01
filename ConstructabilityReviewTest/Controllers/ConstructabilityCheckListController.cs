using Constructability_Review_Test_Models;
using ConstructabilityReviewTestService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace ConstructabilityReviewTest.Controllers
{
    public class ConstructabilityCheckListController : Controller
    {

        private readonly IConstructabilityService _service;
        public ConstructabilityCheckListController()
        {

        }
        public ConstructabilityCheckListController(IConstructabilityService service)
        {
            _service = service;
        }
        // GET: ConstructabilityCheckList
        public ActionResult ConstructabilityTemplate(bool popup = false)
        {
            List<CheckListModel> templae = new List<CheckListModel>();
            ViewBag.Popup = popup;
            var service = new ConstructabilitySrv();
            var model = service.GetCheckListReviewDtls();
            foreach (var item in model)
            {
            }
            return View(model);
        }
        public ActionResult TemplateHeader()
        {
            var service = new ConstructabilitySrv();
            var model = new CTCHeader();

            return PartialView("_Header", model);
        }
        public ActionResult GenerateCheckListUsingStoredProcedure(string Job)
        {
            var service = new ConstructabilitySrv();
            string user = User.Identity.Name;
            var string1 = user.Substring(0, 6);
            var string2 = user.Remove(0, 6);
            string user1 = string2;
            string st = Regex.Replace(user1, @"[^0-9a-zA-Z]+", "");
            var ChecklistReviewID = service.GetGeneratedId(Job, st);
            ViewBag.id = ChecklistReviewID;
            List<SelectListItem> NamePrecon = new List<SelectListItem>()
            {
                new SelectListItem{ Text="Select", Value = "",Selected=true },
                new SelectListItem{ Text="YES", Value = "YES" },
                new SelectListItem{ Text="NO", Value = "NO" },
                new SelectListItem{ Text="N/A", Value = "N/A" }
            };
            ViewBag.ChkNamePrecon = NamePrecon;
            return RedirectToAction("EditChecklistReview", "ConstructabilityCheckList", new { Id = ChecklistReviewID });
        }

        public ActionResult EditChecklistReview(int Id, string MajorsectType = "",string DivName="")
        {
            var service = new ConstructabilitySrv();
            var model = service.GetCheckLisDtls(Id);
            ViewBag.MajorSectionName = MajorsectType;
            ViewBag.JumpToDivId = DivName;
            return View("EditChecklistReview", model);
        }
        public ActionResult GetCommentData(int ChkReviewID, int ChklstRwItmId, string MajorSectionName)
        {
            var service = new ConstructabilitySrv();
            var model = service.GetCheckListDatafromCommentTable(ChklstRwItmId);
            model.FirstOrDefault().MajorSectionName = MajorSectionName;
            return View("EditChecklistReview", model);
        }
        public ActionResult EditchkReviewDetaillineItem(int ChkReviewID, int chklistReviewItemSectionItemID)
        {
            var service = new ConstructabilitySrv();
            CheckListModel model;
            model = service.GetchkreviewDataById(ChkReviewID, chklistReviewItemSectionItemID);
            List<SelectListItem> ResultsAndComments = new List<SelectListItem>()
            {
                new SelectListItem{ Text="Select", Value = "",Selected=true },
                new SelectListItem{ Text="YES", Value = "YES" },
                new SelectListItem{ Text="NO", Value = "NO" },
                new SelectListItem{ Text="N/A", Value = "N/A" }
            };
            ViewBag.ChkNameResult = ResultsAndComments;
            ViewBag.MajorSectionName = model.ChecklistReviewItemMajorSectionName;
            return PartialView("_EditchkReviewDetaillineItem", model);
        }
        public ActionResult SaveEditchkListlinedtls(CheckListModel model)
        {
            int id = 0;
            try
            {
                CheckListModel Emodel;
                var service = new ConstructabilitySrv();
                id = service.SaveEditDetails(model);
                ViewBag.MajorSectionName = model.ChecklistReviewItemMajorSectionName;
                return RedirectToAction("EditChecklistReview", "ConstructabilityCheckList", new { Id = model.ChecklistReviewID, MajorsectType = model.ChecklistReviewItemMajorSectionName });

            }
            catch (Exception ex)
            {
                throw new Exception("could not  Save The Details", ex);
            }
        }
        public ActionResult GetChecklistReviewSummary(int Id)
        {
            var service = new ConstructabilitySrv();
            var model = service.GetCheckLisDtls(Id);
            var Designlst = new List<SelectListItem>();
            Designlst.Add(new SelectListItem { Text = "SD", Value = "SD" });
            Designlst.Add(new SelectListItem { Text = "CD", Value = "CD" });
            Designlst.Add(new SelectListItem { Text = "DD", Value = "DD" });
            ViewBag.DesignLevel = Designlst;
            List<SelectListItem> ResultsAndComments = new List<SelectListItem>()
            {
                new SelectListItem{ Text="Select", Value = "",Selected=true },
                new SelectListItem{ Text="YES", Value = "YES" },
                new SelectListItem{ Text="NO", Value = "NO" },
                new SelectListItem{ Text="N/A", Value = "N/A" }
            };
            ViewBag.ChkNameResult = ResultsAndComments;
            return View("GetChecklistReviewSummary", model);
        }
        public ActionResult UpdateCheckListActive(int ChkRevewID, int ChklstRwItmSectionId, string MajorSectionName)
        {
            var service = new ConstructabilitySrv();
            var res = service.UpdatechkActiveStatus1(ChkRevewID, ChklstRwItmSectionId);
            var mj = service.GetchekMajorSectionName(ChklstRwItmSectionId);
            return Redirect(Url.Action("EditChecklistReview", "ConstructabilityCheckList", new { Id = ChkRevewID, MajorsectType = mj }));
        }
        public ActionResult AddChecklistSectionItem(int ChklistrwId, int ChklistreviewItmId, string MajorSectionName, int MjSctiSortOrder, int MajorSectionId, int ItemDivisionId, int DivisionSortOrder, int SectionID, int SectionSortOrder)
        {
            var service = new ConstructabilitySrv();
            CheckListModel model = new CheckListModel();
            List<SelectListItem> ResultsAndComments = new List<SelectListItem>()
            {
                new SelectListItem{ Text="Select", Value = "",Selected=true },
                new SelectListItem{ Text="YES", Value = "YES" },
                new SelectListItem{ Text="NO", Value = "NO" },
                new SelectListItem{ Text="N/A", Value = "N/A" }
            };
            ViewBag.ChkNameResult = ResultsAndComments;
            model.ChecklistReviewID = ChklistrwId;
            model.ChecklistReviewItemID = ChklistreviewItmId;
            model.ChecklistReviewItemSectionItemID = 0;
            model.ChecklistReviewItemMajorSectionID = MajorSectionId;
            model.ChecklistReviewItemMajorSectionName = MajorSectionName;
            model.ChecklistReviewItemDivisionPublic = service.GetChkDivisionpublic(ItemDivisionId);
            model.ChecklistReviewItemMajorSectionSortOrder = MjSctiSortOrder;
            model.ChecklistReviewItemDivisionID = ItemDivisionId;
            model.ChecklistReviewItemDivisionName = service.GetChkDivisionName(ItemDivisionId);
            model.ChecklistReviewItemDivisionNumber = service.GetChkDivisionNumber(ItemDivisionId);
            model.ChecklistReviewItemDivisionSortOrder = DivisionSortOrder;
            model.ChecklistReviewItemSectionID = SectionID;
            model.ChecklistReviewItemSectionName = service.GetChkSectionName(SectionID);
            model.ChecklistReviewItemSectionSortOrder = SectionSortOrder;
            model.CreatedUser = User.Identity.Name;
            model.ModifiedUser = User.Identity.Name;
            return PartialView("AddChecklistSectionItem", model);
        }
        public ActionResult AddChecklistSectionItemComments(int ChklistrwId, int ChklistreviewItmId, string MajorSectionName, int MajorSectionId)
        {
            var service = new ConstructabilitySrv();
            CheckListReviewItemComments model = new CheckListReviewItemComments();
            var Designlst = new List<SelectListItem>();
            Designlst.Add(new SelectListItem { Text = "Select", Value = "", Selected = true });
            Designlst.Add(new SelectListItem { Text = "SD", Value = "SD" });
            Designlst.Add(new SelectListItem { Text = "CD", Value = "CD" });
            Designlst.Add(new SelectListItem { Text = "DD", Value = "DD" });
            ViewBag.DesignLevel = Designlst;
            var Rolelst = new List<SelectListItem>();
            Rolelst.Add(new SelectListItem { Text = "Select", Value = "", Selected = true });
            Rolelst.Add(new SelectListItem { Text = "Precon", Value = "Precon" });
            Rolelst.Add(new SelectListItem { Text = "PM", Value = "PM" });
            Rolelst.Add(new SelectListItem { Text = "Field", Value = "Field" });
            ViewBag.RoleLevel = Rolelst;
            List<SelectListItem> ResultsAndComments = new List<SelectListItem>()
            {
                new SelectListItem{ Text="Select", Value = "",Selected=true },
                new SelectListItem{ Text="YES", Value = "YES" },
                new SelectListItem{ Text="NO", Value = "NO" },
                new SelectListItem{ Text="N/A", Value = "N/A" }
            };
            ViewBag.ChkNameResult = ResultsAndComments;
            model.CheckListReviewID = ChklistrwId;
            model.ChecklistReviewItemID = ChklistreviewItmId;
            model.ChecklistReviewItemMajorSectionID = MajorSectionId;
            model.ChecklistReviewItemMajorSectionName = MajorSectionName;
            model.CreatedUser = User.Identity.Name;
            model.ModifiedUser = User.Identity.Name;
            return PartialView("AddChecklistSectionItemComments", model);
        }
        private string FiletoBase64(HttpPostedFileBase file)
        {
            var strfile = "";
            System.IO.Stream fs = file.InputStream;
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            return base64String;
        }
        [HttpPost]
        public ActionResult SaveCommentsChkListSectionitem(AddCheckListCommentsmodel myObject)
        {

            var service = new ConstructabilitySrv();
            var CreatedBy = User.Identity.Name;
            var ModifiedBy = User.Identity.Name;

            var AttachmentFilename = myObject.FAttachment != null ? myObject.FAttachment.FileName : myObject.Attachment;
            var Attachment = myObject.FAttachment != null ? FiletoBase64(myObject.FAttachment) : myObject.Attachment;
            var model = service.AddCommentschklistSection(myObject.designLvlCode, myObject.riwerrole, myObject.ReviewerName, myObject.cmts, AttachmentFilename, Attachment,myObject.chkItmId,CreatedBy, ModifiedBy);
            var sectionItemName = service.GetChklstRwItemDetails(myObject.chkId, myObject.chkItmId).FirstOrDefault().ChecklistReviewItemSectionName;
            return Json(sectionItemName );
            //return Json(new { sectionItemName }, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        ////[ValidateAntiForgeryToken]
        //public ActionResult SaveCommentsChkListSectionitem(AddCheckListCommentsmodel myObject)
        //{
        //    string result = "";
        //    var service = new ConstructabilitySrv();
        //    var CreatedBy = User.Identity.Name;
        //    var ModifiedBy = User.Identity.Name;
        //    //var AttachmentFilename = System.IO.Path.GetFileName(myObject.FAttachment); //FAttachment is string that holds the path.
        //    //First convert the string to a byte array and then use the Convert.ToBase64String() method to convert the byte array to a Base64 string.
        //    //byte[] bytes = Encoding.ASCII.GetBytes(myObject.FAttachment);
        //    //byte[] byt = System.Text.Encoding.UTF8.GetBytes(strOriginal);
        //    // convert the byte array to a Base64 string
        //    //var Attachment = Convert.ToBase64String(bytes);
        //    //var Receipt = myObject.FReceipt != null ? FiletoBase64(myObject.FReceipt) : myObject.Receipt;
        //    var AttachmentFilename = myObject.FAttachment != null ? myObject.FAttachment.FileName : myObject.Attachment;
        //    var Attachment = myObject.FAttachment != null ? FiletoBase64(myObject.FAttachment) : myObject.Attachment;         
        //    var model = service.AddCommentschklistSection(myObject.designLvlCode, myObject.riwerrole, myObject.ReviewerName, myObject.cmts, AttachmentFilename, Attachment, myObject.chkSecNam, myObject.chkId, myObject.chkItmId, myObject.chkSecId, CreatedBy,ModifiedBy);

        //    return Json(new { msg = "Successfully added ",model });  
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCustomChkListSection(CheckListModel model)
        {
            bool result = false;
            var service = new ConstructabilitySrv();
            try
            {
                model.CreatedUser = User.Identity.Name;
                model.ModifiedUser = User.Identity.Name;
                result = service.AddCustomchklistSection(model);
            }
            catch (Exception ex)
            {
                throw new Exception("couldn't  Save The Custom checkList details", ex);
            }
            return RedirectToAction("EditChecklistReview", "ConstructabilityCheckList", new { Id = model.ChecklistReviewID, MajorsectType = model.ChecklistReviewItemMajorSectionName });
        }

        public ActionResult TemplateAdmin(string MajorsectType = "")
        {
            List<TemplateListModel> templae = new List<TemplateListModel>();
            var service = new ConstructabilitySrv();
            var model = service.GetTemplateListReviewDtls();
            foreach (var item in model)
            {
            }
            model.FirstOrDefault().SectionName = MajorsectType;
            ViewBag.QalitySafety = MajorsectType;
            return View(model);
        }
        public ActionResult EditTemplateAdmin(int SectionId, int Id)
        {
            var service = new ConstructabilitySrv();
            TemplateListModel model;
            model = service.GetTemplateItemDataById(SectionId, Id);
            model.TemplateMajorSectionID = service.GetMajorSectionName(model.TemplateSectionID);
            if (model.TemplateMajorSectionID == 1)
            {
                model.TemplateMajorSectionName = "SAFETY";
            }
            else if (model.TemplateMajorSectionID == 2)
            {
                model.TemplateMajorSectionName = "QUALITY";
            }
            return PartialView("_EditTemplateAdmin", model);
        }
        public ActionResult SaveEditTemplatelinedtls(TemplateListModel model)
        {
            int id = 0;
            try
            {
                TemplateListModel Emodel;
                var service = new ConstructabilitySrv();
                id = service.SaveEditTemplateDetails(model);
                ViewBag.MajorSectionName = model.TemplateMajorSectionName;
                return RedirectToAction("TemplateAdmin", "ConstructabilityCheckList", new { MajorsectType = model.TemplateMajorSectionName });

            }
            catch (Exception ex)
            {
                throw new Exception("could not  Save The Details", ex);
            }
        }
        public ActionResult AddSectionItem(int SectionID,string MajorSectionName)
        {
            var service = new ConstructabilitySrv();
            TemplateListModel model = new TemplateListModel();
            model.TemplateSectionID = SectionID;
            model.TemplateSectionItemActive = true;
            return PartialView("_AddSectionItem", model);
        }       
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveAddTemplateSectionDtls(TemplateListModel model)
        {
            bool result = false;
            var service = new ConstructabilitySrv();
            try
            {
                result = service.AddTemplateSection(model);
            }
            catch (Exception ex)
            {
                throw new Exception(" couldn't  Save The ProjectDetails", ex);
            }
            model.TemplateMajorSectionID = service.GetMajorSectionName(model.TemplateSectionID);
            if (model.TemplateMajorSectionID == 1)
            {
                model.TemplateMajorSectionName = "SAFETY";
            }
            else if (model.TemplateMajorSectionID == 2)
            {
                model.TemplateMajorSectionName = "QUALITY";
            }

            return RedirectToAction("TemplateAdmin", "ConstructabilityCheckList", new { MajorsectType = model.TemplateMajorSectionName });
        }

        public ActionResult SoftDeleteSectionItem(int Id, int SectionId)
        {
            List<TemplateListModel> templae = new List<TemplateListModel>();
            var service = new ConstructabilitySrv();
            var model = service.updateTemplateSectionItemStatus(Id, SectionId);
            var emodel = service.GetTemplateItemDataById(SectionId, Id);
            emodel.TemplateMajorSectionID = service.GetMajorSectionName(Id);
            if (emodel.TemplateMajorSectionID == 1)
            {
                emodel.TemplateMajorSectionName = "SAFETY";
            }
            else if (emodel.TemplateMajorSectionID == 2)
            {
                emodel.TemplateMajorSectionName = "QUALITY";
            }
            return RedirectToAction("TemplateAdmin", "ConstructabilityCheckList", new { MajorsectType = emodel.TemplateMajorSectionName });
        }
        public ActionResult getRFile(int ChkItemId, int CommentItemId)
        {
            CheckListReviewItemComments model;
            var service = new ConstructabilitySrv();
            model = service.GetCRCReceipt(ChkItemId, CommentItemId);
            var bs = model.Attachment.Replace("data:image/png;base64,", "");
            bs = bs.Replace("data:application/pdf;base64,", "");
            byte[] bytes = System.Convert.FromBase64String(bs);
            if (model.AttachmentName.Contains(".pdf"))
                return File(bytes, "application/pdf", model.AttachmentName);
            return File(bytes, "image/png", model.AttachmentName);
        }
    }
}
   
