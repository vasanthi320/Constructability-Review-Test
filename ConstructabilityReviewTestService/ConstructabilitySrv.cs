using Constructability_Review_Data;
using Constructability_Review_Test_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace ConstructabilityReviewTestService
{
    public class ConstructabilitySrv : IConstructabilityService
    {
        private readonly CRCTestEntities1 _context;
        public ConstructabilitySrv()
        {
            _context = new CRCTestEntities1();
        }
       
        public IList<CheckListModel> GetCheckListReviewDtls()
        {
            var chklst = (from ti in _context.tblChecklistReviews
                          select new CheckListModel
                          {
                              ChecklistReviewID = ti.ChecklistReviewID,
                              ChecklistReviewJCCo = ti.ChecklistReviewJCCo,
                              ChecklistReviewJob = ti.ChecklistReviewJob,
                              ChecklistReviewJobName = ti.ChecklistReviewJobName,
                              //ChecklistReviewDesignLevelID = ti.ChecklistReviewDesignLevelID,
                              //ChecklistReviewDesignLevelCode = ti.ChecklistReviewDesignLevelCode,
                              //ChecklistReviewDesignLevelName = ti.ChecklistReviewDesignLevelName,
                              //ChecklistReviewDrawingDate = ti.ChecklistReviewDrawingDate
                          }).ToList();
            return chklst;
        }
        public int GetGeneratedId(string Job, string User)
        {
            CRCTestEntities1 cnt = new CRCTestEntities1();

            var order = GetCheckListReviewDtls().Where(x => x.ChecklistReviewJob == Job).FirstOrDefault();
            if (order != null) // update
            {
                return order.ChecklistReviewID;
            }
            else
            {
                // new
                var nlst = cnt.spBuild_NewChecklistReviewForEdit(Job, User);
                return nlst.FirstOrDefault().Value;
            }
        }
        public IList<TemplateListModel> GetTemplateListReviewDtls()
        {
            CRCTestEntities1 cnt = new CRCTestEntities1();
            var lst = (from td in _context.tblTemplateDivisions
                       join tm in _context.tblTemplateMajorSections on td.TemplateMajorSectionID equals tm.TemplateMajorSectionID
                       join ts in _context.tblTemplateSections on td.TemplateDivisionID equals ts.TemplateDivisionID
                       join tsi in _context.tblTemplateSectionItems on ts.TemplateSectionID equals tsi.TemplateSectionID
                       where td.TemplateDivisionID == ts.TemplateDivisionID && ts.TemplateSectionID == tsi.TemplateSectionID && tsi.TemplateSectionItemActive == true
                       select new TemplateListModel
                       {
                           TemplateSectionID = ts.TemplateSectionID,
                           TemplateSectionName = ts.TemplateSectionName,
                           TemplateMajorSectionID = ts.TemplateMajorSectionID,
                           TemplateDivisionID = ts.TemplateDivisionID,
                           TemplateMajorSectionName = tm.TemplateMajorSectionName,
                           TemplateSectionSortOrder = ts.TemplateSectionSortOrder,
                           TemplateSectionActive = ts.TemplateSectionActive,
                           TemplateSectionItemID = tsi.TemplateSectionItemID,
                           TemplateSectionItemCode = tsi.TemplateSectionItemCode,
                           TemplateSectionItemName = tsi.TemplateSectionItemName,
                           TemplateSectionItemLink = tsi.TemplateSectionItemLink,
                           TemplateSectionItemSortOrder = tsi.TemplateSectionItemSortOrder,
                           TemplateSectionItemActive = tsi.TemplateSectionItemActive,
                           TemplateDivisionNumber = td.TemplateDivisionNumber,
                           TemplateDivisionName = td.TemplateDivisionName,
                           TemplateDivisionPublic = td.TemplateDivisionPublic,
                           TemplateDivisionSortOrder = td.TemplateDivisionSortOrder,
                           TemplateDivisionActive = td.TemplateDivisionActive
                       }).ToList();
            return lst;
        }
        public List<CheckListReviewItemModel> GetChklstRwItemSectionDetails(int id, int SectionID)
        {
            CRCTestEntities1 cnt = new CRCTestEntities1();
            var itm = _context.tblChecklistReviews.Find(id);
            //var ei = itm.tblChecklistReviewItems.FirstOrDefault(p => p.ChecklistReviewItemSectionID == SectionID);
            var lst = cnt.tblChecklistReviewItems.Where(c => c.ChecklistReviewItemSectionID == SectionID && c.ChecklistReviewID == id).Select(e => new CheckListReviewItemModel
            {
                ChecklistReviewID = id,
                ChecklistReviewItemID = e.ChecklistReviewItemID,
                ChecklistReviewItemMajorSectionID = e.ChecklistReviewItemMajorSectionID,
                ChecklistReviewItemMajorSectionName = e.ChecklistReviewItemMajorSectionName,
                ChecklistReviewItemMajorSectionSortOrder = e.ChecklistReviewItemMajorSectionSortOrder,
                ChecklistReviewItemDivisionID = e.ChecklistReviewItemDivisionID,
                ChecklistReviewItemDivisionNumber = e.ChecklistReviewItemDivisionNumber,
                ChecklistReviewItemDivisionName = e.ChecklistReviewItemDivisionName,
                ChecklistReviewItemDivisionPublic = e.ChecklistReviewItemDivisionPublic,
                ChecklistReviewItemDivisionSortOrder = e.ChecklistReviewItemDivisionSortOrder,
                ChecklistReviewItemSectionID = e.ChecklistReviewItemSectionID,
                ChecklistReviewItemSectionName = e.ChecklistReviewItemSectionName,
                ChecklistReviewItemSectionSortOrder = e.ChecklistReviewItemSectionSortOrder,
                ChecklistReviewItemSectionItemID = e.ChecklistReviewItemSectionItemID,
                ChecklistReviewItemSectionItemCode = e.ChecklistReviewItemSectionItemCode,
                ChecklistReviewItemSectionItemName = e.ChecklistReviewItemSectionItemName,
                ChecklistReviewItemSectionItemLink = e.ChecklistReviewItemSectionItemLink,
                ChecklistReviewItemSectionItemSortOrder = e.ChecklistReviewItemSectionItemSortOrder,
                ChecklistReviewItemVisible = e.ChecklistReviewItemVisible
            }).ToList();
            return lst;
        }
        public List<CheckListReviewItemModel> GetChklstRwItemDetails(int id,int ChReviewItmId)
        {
            CRCTestEntities1 cnt = new CRCTestEntities1();
            var itm = _context.tblChecklistReviews.Find(ChReviewItmId);
            //var ei = itm.tblChecklistReviewItems.FirstOrDefault(p => p.ChecklistReviewItemSectionID == SectionID);
            var lst = cnt.tblChecklistReviewItems.Where(c=>c.ChecklistReviewItemID == ChReviewItmId && c.ChecklistReviewID==id).Select(e => new CheckListReviewItemModel
            {
                ChecklistReviewID = id,
                ChecklistReviewItemID = ChReviewItmId,
                ChecklistReviewItemMajorSectionID = e.ChecklistReviewItemMajorSectionID,
                ChecklistReviewItemMajorSectionName = e.ChecklistReviewItemMajorSectionName,
                ChecklistReviewItemMajorSectionSortOrder = e.ChecklistReviewItemMajorSectionSortOrder,
                ChecklistReviewItemDivisionID = e.ChecklistReviewItemDivisionID,
                ChecklistReviewItemDivisionNumber = e.ChecklistReviewItemDivisionNumber,
                ChecklistReviewItemDivisionName = e.ChecklistReviewItemDivisionName,
                ChecklistReviewItemDivisionPublic = e.ChecklistReviewItemDivisionPublic,
                ChecklistReviewItemDivisionSortOrder = e.ChecklistReviewItemDivisionSortOrder,
                ChecklistReviewItemSectionID = e.ChecklistReviewItemSectionID,
                ChecklistReviewItemSectionName = e.ChecklistReviewItemSectionName,
                ChecklistReviewItemSectionSortOrder = e.ChecklistReviewItemSectionSortOrder,
                ChecklistReviewItemSectionItemID = e.ChecklistReviewItemSectionItemID,
                ChecklistReviewItemSectionItemCode = e.ChecklistReviewItemSectionItemCode,
                ChecklistReviewItemSectionItemName = e.ChecklistReviewItemSectionItemName,
                ChecklistReviewItemSectionItemLink = e.ChecklistReviewItemSectionItemLink,
                ChecklistReviewItemSectionItemSortOrder = e.ChecklistReviewItemSectionItemSortOrder,
                ChecklistReviewItemVisible = e.ChecklistReviewItemVisible
            }).ToList();
            return lst;
        }
        public List<TemplateResultModel> GetChkListNamePreconDetails()
        {
            CRCTestEntities1 cnt = new CRCTestEntities1();
            var lst = cnt.tblTemplateResults.Select(p => new TemplateResultModel
            {
                TemplateResultID = p.TemplateResultID,
                TemplateResultName = p.TemplateResultName,
                TemplateResultSortOrder = p.TemplateResultSortOrder,
                TemplateResultActive = p.TemplateResultActive
            }).ToList();
            return lst;
        }

        //public CheckListModel GetCheckLisDtls(int ID)
        //{
        //    CRCTestEntities1 cnt = new CRCTestEntities1();
        //    var model = _context.tblChecklistReviews.SingleOrDefault(p => p.ChecklistReviewID == ID);
        //    var emodel = _context.tblChecklistReviewItems.Where(r => r.ChecklistReviewID==ID); ;
        //    CheckListModel ep = new CheckListModel();
        //    ep.ChecklistReviewID = ID;
        //    ep.ChecklistReviewJob = model.ChecklistReviewJob;
        //    ep.ChecklistReviewJobName = model.ChecklistReviewJobName;
        //    ep.ChecklistReviewJCCo = model.ChecklistReviewJCCo;
        //    ep.ChecklistReviewCreatedDate = model.CreatedDate;
        //    ep.ChecklistReviewCreatedUser = model.CreatedUser;
        //    ep.ChecklistReviewModifiedDate = model.ModifiedDate;
        //    ep.ChecklistReviewModifiedUser = model.ModifiedUser;
        //    ep.CheckListReviewItemDetails = model.tblChecklistReviewItems
        //        .OrderBy(u => u.ChecklistReviewItemMajorSectionSortOrder).ThenBy(x => x.ChecklistReviewItemDivisionSortOrder).ThenBy(a => a.ChecklistReviewItemSectionSortOrder).ThenBy(c => c.ChecklistReviewItemSectionItemSortOrder)
        //        .Select(p => new CheckListReviewItemModel
        //        {
        //            ChecklistReviewID = p.ChecklistReviewID,
        //            ChecklistReviewItemID = p.ChecklistReviewItemID,
        //            ChecklistReviewItemMajorSectionID = p.ChecklistReviewItemMajorSectionID,
        //            ChecklistReviewItemMajorSectionName = p.ChecklistReviewItemMajorSectionName,
        //            ChecklistReviewItemMajorSectionSortOrder = p.ChecklistReviewItemMajorSectionSortOrder,
        //            ChecklistReviewItemDivisionID = p.ChecklistReviewItemDivisionID,
        //            ChecklistReviewItemDivisionNumber = p.ChecklistReviewItemDivisionNumber,
        //            ChecklistReviewItemDivisionName = p.ChecklistReviewItemDivisionName,
        //            ChecklistReviewItemDivisionPublic = p.ChecklistReviewItemDivisionPublic,
        //            ChecklistReviewItemDivisionSortOrder = p.ChecklistReviewItemDivisionSortOrder,
        //            ChecklistReviewItemSectionID = p.ChecklistReviewItemSectionID,
        //            ChecklistReviewItemSectionName = p.ChecklistReviewItemSectionName,
        //            ChecklistReviewItemSectionSortOrder = p.ChecklistReviewItemSectionSortOrder,
        //            ChecklistReviewItemSectionItemID = p.ChecklistReviewItemSectionItemID,
        //            ChecklistReviewItemSectionItemCode = p.ChecklistReviewItemSectionItemCode,
        //            ChecklistReviewItemSectionItemName = p.ChecklistReviewItemSectionItemName,
        //            ChecklistReviewItemSectionItemLink = p.ChecklistReviewItemSectionItemLink,
        //            ChecklistReviewItemSectionItemSortOrder = p.ChecklistReviewItemSectionItemSortOrder,
        //            ChecklistReviewItemVisible = p.ChecklistReviewItemVisible,
        //            ChecklistReviewItemActive = p.ChecklistReviewItemReviewerActive,
        //            ChecklistReviewItemModifiedDate = p.ModifiedDate,
        //            ChecklistReviewItemModifiedUser = p.ModifiedUser,
        //            ChecklistReviewItemCommentsDtls = emodel.tblChecklistReviewItemComments
        //             .Select(pi => new CheckListReviewItemComments
        //             {
        //                 ChecklistReviewItemCommentID = pi.ChecklistReviewItemCommentID,
        //                 ChecklistReviewDesignLevelID = pi.ChecklistReviewDesignLevelID,
        //                 ChecklistReviewDesignLevelCode = pi.ChecklistReviewDesignLevelCode,
        //                 ChecklistReviewDesignLevelName = pi.ChecklistReviewDesignLevelName,
        //                 ChecklistReviewItemReviewerRole = pi.ChecklistReviewItemReviewerRole,
        //                 ChecklistReviewItemReviewerResultName = pi.ChecklistReviewItemReviewerResultName,
        //                 ChecklistReviewItemReviewerResultComments = pi.ChecklistReviewItemReviewerResultComments,
        //                 CreatedDate = pi.CreatedDate,
        //                 CreatedUser = pi.CreatedUser,
        //                 ModifiedDate = pi.ModifiedDate,
        //                 ModifiedUser = pi.ModifiedUser
        //             }).Where(q => q.ChecklistReviewItemID == emodel.ChecklistReviewItemID).ToList()
        //        }).ToList();

        //    return ep;
        //}
        public IList<CheckListModel> GetCheckLisDtls(int ID)
        {
            CRCTestEntities1 cnt = new CRCTestEntities1();
            var lst = (from cr in _context.tblChecklistReviews
                       join cri in _context.tblChecklistReviewItems on cr.ChecklistReviewID equals cri.ChecklistReviewID
                       join cric in _context.tblChecklistReviewItemComments on cri.ChecklistReviewItemID equals cric.ChecklistReviewItemID
                       into cric1 from cric in cric1.DefaultIfEmpty().GroupBy(c => c.ChecklistReviewItemID)
                       where (cr.ChecklistReviewID == ID && cri.ChecklistReviewID == ID)

                       select new CheckListModel
                       {
                           MajorSectionName = cri.ChecklistReviewItemMajorSectionName,
                           ChecklistReviewID = cr.ChecklistReviewID,
                           ChecklistReviewJCCo = cr.ChecklistReviewJCCo,
                           ChecklistReviewJob = cr.ChecklistReviewJob,
                           ChecklistReviewJobName = cr.ChecklistReviewJobName,
                           ChecklistReviewItemID = cri.ChecklistReviewItemID,
                           ChecklistReviewItemActive = cri.ChecklistReviewItemReviewerActive,
                           ChecklistReviewItemMajorSectionID = cri.ChecklistReviewItemMajorSectionID,
                           ChecklistReviewItemMajorSectionName = cri.ChecklistReviewItemMajorSectionName,
                           ChecklistReviewItemMajorSectionSortOrder = cri.ChecklistReviewItemMajorSectionSortOrder,
                           ChecklistReviewItemDivisionID = cri.ChecklistReviewItemDivisionID,
                           ChecklistReviewItemDivisionNumber = cri.ChecklistReviewItemDivisionNumber,
                           ChecklistReviewItemDivisionName = cri.ChecklistReviewItemDivisionName,
                           ChecklistReviewItemDivisionPublic = cri.ChecklistReviewItemDivisionPublic,
                           ChecklistReviewItemDivisionSortOrder = cri.ChecklistReviewItemDivisionSortOrder,
                           ChecklistReviewItemSectionID = cri.ChecklistReviewItemSectionID,
                           ChecklistReviewItemSectionName = cri.ChecklistReviewItemSectionName,
                           ChecklistReviewItemSectionSortOrder = cri.ChecklistReviewItemSectionSortOrder,
                           ChecklistReviewItemSectionItemID = cri.ChecklistReviewItemSectionItemID,
                           ChecklistReviewItemSectionItemCode = cri.ChecklistReviewItemSectionItemCode,
                           ChecklistReviewItemSectionItemName = cri.ChecklistReviewItemSectionItemName,
                           ChecklistReviewItemSectionItemLink = cri.ChecklistReviewItemSectionItemLink,
                           ChecklistReviewItemSectionItemSortOrder = cri.ChecklistReviewItemSectionItemSortOrder,
                           ChecklistReviewItemVisible = cri.ChecklistReviewItemVisible,
                       }).ToList();
            foreach (var item in lst)
            {
                item.ChecklistReviewItemCommentDetails = GetCheckListCommentIData(item.ChecklistReviewID,item.ChecklistReviewItemID);
            }
            return lst;
        }
        public IList<CheckListReviewItemComments> GetCheckListCommentIData(int Id,int ChecklistReviewItemID)
        {
            var dtlist = _context.tblChecklistReviewItemComments.Where(l => l.ChecklistReviewItemID == ChecklistReviewItemID).
            Select(p => new CheckListReviewItemComments
            {
                CheckListReviewID = Id,
                ChecklistReviewItemID=ChecklistReviewItemID,
                ChecklistReviewItemCommentID=p.ChecklistReviewItemCommentID,
                ChecklistReviewDesignLevelID = p.ChecklistReviewDesignLevelID,
                ChecklistReviewDesignLevelCode = p.ChecklistReviewDesignLevelCode,
                ChecklistReviewDesignLevelName = p.ChecklistReviewDesignLevelName,
                ChecklistReviewItemReviewerRole = p.ChecklistReviewItemReviewerRole,
                ChecklistReviewItemReviewerResultName = p.ChecklistReviewItemReviewerResultName,
                ChecklistReviewItemReviewerResultComments = p.ChecklistReviewItemReviewerResultComments,
                Attachment=p.Attachment,
                AttachmentName=p.AttachmentName,
                CreatedDate = p.CreatedDate,
                CreatedUser = p.CreatedUser,
                ModifiedDate = p.ModifiedDate,
                ModifiedUser = p.ModifiedUser
            }).ToList();
            return dtlist;
        }
               
        public IList<CheckListModel> GetCheckListDatafromCommentTable(int ID)
        {
            var dt = _context.tblChecklistReviewItemComments.Where(c => c.ChecklistReviewItemID == ID).
                             Select(p => new CheckListModel
                             {
                            
                                ChecklistReviewDesignLevelID = p.ChecklistReviewDesignLevelID,
                                ChecklistReviewDesignLevelCode = p.ChecklistReviewDesignLevelCode,
                                ChecklistReviewDesignLevelName = p.ChecklistReviewDesignLevelName,
                                ChecklistReviewItemReviewerRole = p.ChecklistReviewItemReviewerRole,
                                ChecklistReviewItemReviewerResultName = p.ChecklistReviewItemReviewerResultName,
                                ChecklistReviewItemReviewerResultComments = p.ChecklistReviewItemReviewerResultComments,
                                
                                CheckListReviewerCommentsCreatedDate = p.CreatedDate,
                                CheckListReviewerCommentsCreatedUser = p.CreatedUser,
                                CheckListReviewerCommentsModifiedDate = p.ModifiedDate,
                                CheckListReviewerCommentsModifiedUser = p.ModifiedUser
                            }).ToList();
            return dt;
        }
        public CheckListModel GetchkreviewDataById(int ChkReviewID, int chklistReviewItemSectionItemID)
        {
            var itm = _context.tblChecklistReviews.Find(ChkReviewID);
            var it = itm.tblChecklistReviewItems.SingleOrDefault(p => p.ChecklistReviewItemSectionItemID == chklistReviewItemSectionItemID);
            var lst = new CheckListModel
            {
                ChecklistReviewID = ChkReviewID,
                ChecklistReviewItemID = it.ChecklistReviewItemID,
                ChecklistReviewItemMajorSectionID = it.ChecklistReviewItemMajorSectionID,
                ChecklistReviewItemMajorSectionName = it.ChecklistReviewItemMajorSectionName,
                ChecklistReviewItemMajorSectionSortOrder = it.ChecklistReviewItemMajorSectionSortOrder,
                ChecklistReviewItemDivisionID = it.ChecklistReviewItemDivisionID,
                ChecklistReviewItemDivisionNumber = it.ChecklistReviewItemDivisionNumber,
                ChecklistReviewItemDivisionName = it.ChecklistReviewItemDivisionName,
                ChecklistReviewItemDivisionPublic = it.ChecklistReviewItemDivisionPublic,
                ChecklistReviewItemDivisionSortOrder = it.ChecklistReviewItemDivisionSortOrder,
                ChecklistReviewItemSectionID = it.ChecklistReviewItemSectionID,
                ChecklistReviewItemSectionName = it.ChecklistReviewItemSectionName,
                ChecklistReviewItemSectionSortOrder = it.ChecklistReviewItemSectionSortOrder,
                ChecklistReviewItemSectionItemID = it.ChecklistReviewItemSectionItemID,
                ChecklistReviewItemSectionItemCode = it.ChecklistReviewItemSectionItemCode,
                ChecklistReviewItemSectionItemName = it.ChecklistReviewItemSectionItemName,
                ChecklistReviewItemSectionItemLink = it.ChecklistReviewItemSectionItemLink,
                ChecklistReviewItemSectionItemSortOrder = it.ChecklistReviewItemSectionItemSortOrder,
                ChecklistReviewItemVisible = it.ChecklistReviewItemVisible
               
            };
            return lst;
        }

        public int SaveEditDetails(CheckListModel model)
        {
            tblChecklistReviewItem id;

            var invoice = _context.tblChecklistReviews.Find(model.ChecklistReviewID);
            id = _context.tblChecklistReviewItems.Find(model.ChecklistReviewItemID);
            id.ChecklistReviewItemSectionID = model.ChecklistReviewItemSectionID;
            id.ChecklistReviewItemSectionName = model.ChecklistReviewItemSectionName;
            id.ChecklistReviewItemSectionSortOrder = model.ChecklistReviewItemSectionSortOrder;
            id.ChecklistReviewItemSectionItemID = model.ChecklistReviewItemSectionItemID;
            id.ChecklistReviewItemSectionItemCode = model.ChecklistReviewItemSectionItemCode;
            id.ChecklistReviewItemSectionItemName = model.ChecklistReviewItemSectionItemName;
            id.ChecklistReviewItemSectionItemLink = model.ChecklistReviewItemSectionItemLink;
            id.ChecklistReviewItemSectionItemSortOrder = model.ChecklistReviewItemSectionItemSortOrder;
            id.ChecklistReviewItemVisible = model.ChecklistReviewItemVisible;          

            var r = _context.SaveChanges();
            return id.ChecklistReviewItemID;
        }
        public TemplateListModel GetTemplateItemDataById(int SectionId, int Id)
        {
            CRCTestEntities1 cnt = new CRCTestEntities1();
            var model = _context.tblTemplateSectionItems.SingleOrDefault(p => p.TemplateSectionItemID == Id);
            TemplateListModel ep = new TemplateListModel();
            ep.TemplateSectionItemID = model.TemplateSectionItemID;
            ep.TemplateSectionItemCode = model.TemplateSectionItemCode;
            ep.TemplateSectionItemName = model.TemplateSectionItemName;
            ep.TemplateSectionItemLink = model.TemplateSectionItemLink;
            ep.TemplateSectionID = SectionId;
            ep.TemplateSectionItemSortOrder = model.TemplateSectionItemSortOrder;
            ep.TemplateSectionItemActive = model.TemplateSectionItemActive;
            return ep;
        }
        public int SaveEditTemplateDetails(TemplateListModel model)
        {
            tblTemplateSectionItem td;
            var invoice = _context.tblTemplateSections.Find(model.TemplateSectionID);
            td = _context.tblTemplateSectionItems.Find(model.TemplateSectionItemID);
            td.TemplateSectionItemID = model.TemplateSectionItemID;
            td.TemplateSectionItemLink = model.TemplateSectionItemLink;
            td.TemplateSectionItemName = model.TemplateSectionItemName;
            td.TemplateSectionItemSortOrder = model.TemplateSectionItemSortOrder;
            td.TemplateSectionItemActive = model.TemplateSectionItemActive;
            td.TemplateSectionItemCode = String.IsNullOrEmpty(model.TemplateSectionItemCode) ? "" : model.TemplateSectionItemCode;

            var r = _context.SaveChanges();
            return td.TemplateSectionItemID;
        }
        public int GetMajorSectionName(int SectionId)
        {
            var sectionName = _context.tblTemplateSections.FirstOrDefault(x => x.TemplateSectionID == SectionId).TemplateMajorSectionID;
            return sectionName;
        }
        public string GetchekMajorSectionName(int SectionId)
        {
            var sectionName = _context.tblChecklistReviewItems.FirstOrDefault(x => x.ChecklistReviewItemSectionID == SectionId).ChecklistReviewItemMajorSectionName;
            return sectionName;
        }
        public string GetChkDivisionName(int DivisionId)
        {
            var DivisionName = _context.tblChecklistReviewItems.FirstOrDefault(x => x.ChecklistReviewItemDivisionID == DivisionId).ChecklistReviewItemDivisionName;
            return DivisionName;
        }
        public string GetChkDivisionpublic(int DivisionId)
        {
            var Divisionpublic = _context.tblChecklistReviewItems.FirstOrDefault(x => x.ChecklistReviewItemDivisionID == DivisionId).ChecklistReviewItemDivisionPublic;
            return Divisionpublic;
        }
        public string GetChkDivisionNumber(int DivisionId)
        {
            var DivisionNumber = _context.tblChecklistReviewItems.FirstOrDefault(x => x.ChecklistReviewItemDivisionID == DivisionId).ChecklistReviewItemDivisionNumber;
            return DivisionNumber;
        }
        public string GetChkSectionName(int SectionID)
        {
            var ChkSectionName = _context.tblChecklistReviewItems.FirstOrDefault(x => x.ChecklistReviewItemSectionID == SectionID).ChecklistReviewItemSectionName;
            return ChkSectionName;
        }
        public bool AddTemplateSection(TemplateListModel model)
        {
            // Select last TemplateSectionItemSortOrder by ordering desc. 
            int lastSortOrder = _context.tblTemplateSectionItems.OrderByDescending(x => x.TemplateSectionItemSortOrder).FirstOrDefault().TemplateSectionItemSortOrder;
            int i = 0;
            CRCTestEntities1 crm = new CRCTestEntities1();
            tblTemplateSectionItem ts = new tblTemplateSectionItem();
            ts.TemplateSectionItemCode = model.TemplateSectionItemCode;
            ts.TemplateSectionItemLink = model.TemplateSectionItemLink;
            ts.TemplateSectionItemName = model.TemplateSectionItemName;
            ts.TemplateSectionID = model.TemplateSectionID;
            ts.TemplateSectionItemSortOrder = lastSortOrder + 100;
            ts.TemplateSectionItemActive = true;
            crm.tblTemplateSectionItems.Add(ts);
            var r = crm.SaveChanges();
            return r > 0;
        }
        public bool updateTemplateSectionItemStatus(int ID, int SectionID)
        {
            tblTemplateSectionItem emodel;
            bool result = false;
            using (var c = new CRCTestEntities1())
            {
                emodel = c.tblTemplateSectionItems.SingleOrDefault(p => p.TemplateSectionID == ID && p.TemplateSectionItemID == SectionID);
                emodel.TemplateSectionItemActive = false;
                result = c.SaveChanges() > 0;
            }
            return result;
        }
        public bool AddCustomchklistSection(CheckListModel model)
        {
            // Select last TemplateSectionItemSortOrder by ordering desc. 
            int SortOrder = _context.tblChecklistReviewItems.OrderByDescending(x => x.ChecklistReviewItemSectionItemSortOrder).FirstOrDefault().ChecklistReviewItemSectionItemSortOrder.Value;
            int sectionItemID = _context.tblChecklistReviewItems.OrderByDescending(p => p.ChecklistReviewItemSectionItemID).FirstOrDefault().ChecklistReviewItemSectionItemID.Value;
            int i = 0;
            CRCTestEntities1 crm = new CRCTestEntities1();
            tblChecklistReviewItem chk = new tblChecklistReviewItem();
            chk.ChecklistReviewID = model.ChecklistReviewID;
            chk.ChecklistReviewItemID = model.ChecklistReviewItemID;
            chk.ChecklistReviewItemMajorSectionID = model.ChecklistReviewItemMajorSectionID;
            chk.ChecklistReviewItemMajorSectionName = model.ChecklistReviewItemMajorSectionName;
            chk.ChecklistReviewItemMajorSectionSortOrder = model.ChecklistReviewItemMajorSectionSortOrder;
            chk.ChecklistReviewItemSectionID = model.ChecklistReviewItemSectionID;
            chk.ChecklistReviewItemSectionName = model.ChecklistReviewItemSectionName;
            chk.ChecklistReviewItemSectionSortOrder = model.ChecklistReviewItemSectionSortOrder;
            chk.ChecklistReviewItemSectionItemID = sectionItemID + 1;
            chk.ChecklistReviewItemSectionItemCode = model.ChecklistReviewItemSectionItemCode;
            chk.ChecklistReviewItemSectionItemName = model.ChecklistReviewItemSectionItemName;
            chk.ChecklistReviewItemSectionItemLink = model.ChecklistReviewItemSectionItemLink;
            chk.ChecklistReviewItemDivisionID = model.ChecklistReviewItemDivisionID;
            chk.ChecklistReviewItemDivisionNumber = model.ChecklistReviewItemDivisionNumber;
            chk.ChecklistReviewItemDivisionSortOrder = model.ChecklistReviewItemDivisionSortOrder;
            chk.ChecklistReviewItemDivisionName = model.ChecklistReviewItemDivisionName;
            chk.ChecklistReviewItemDivisionPublic = model.ChecklistReviewItemDivisionPublic;
            chk.ChecklistReviewItemVisible = true;
            chk.ChecklistReviewItemSectionItemSortOrder = SortOrder + 100;           
            chk.CreatedDate = DateTime.Now;
            chk.ModifiedDate = DateTime.Now;
            chk.ModifiedUser = model.ModifiedUser;
            chk.CreatedUser = model.CreatedUser;
            crm.tblChecklistReviewItems.Add(chk);
            var r = crm.SaveChanges();
            return r > 0;
        }
        public bool AddCommentschklistSection(string designLvlCode,string riwerrole,string ReviewerName,string cmts,string AttachmentFilename, string Attachment,int chkItmId, string CreatedBy,string ModifiedBy)
        {
        
            int i = 0;
            CRCTestEntities1 crm = new CRCTestEntities1();
            tblChecklistReviewItemComment chk = new tblChecklistReviewItemComment();

            chk.ChecklistReviewItemID = chkItmId;
            chk.ChecklistReviewDesignLevelCode = designLvlCode;
            chk.ChecklistReviewDesignLevelID = designLvlCode == "SD" ? 1 : designLvlCode == "CD" ? 2 : 3;
            chk.ChecklistReviewDesignLevelName = designLvlCode == "SD" ? "Schematic Drawings" : designLvlCode == "CD" ? "Construction Drawings" : "Design Drawings";
            chk.ChecklistReviewItemReviewerRole = riwerrole;
            chk.ChecklistReviewItemReviewerResultName = ReviewerName;
            chk.ChecklistReviewItemReviewerResultComments =cmts;
            chk.AttachmentName = AttachmentFilename;
            chk.Attachment = Attachment;            
            //chk.ChecklistReviewItemSectionItemSortOrder = SortOrder + 100;
            chk.CreatedDate = DateTime.Now;
            chk.ModifiedDate = DateTime.Now;           
            chk.CreatedUser = CreatedBy;
            chk.ModifiedUser = ModifiedBy;
            crm.tblChecklistReviewItemComments.Add(chk);
            var r = crm.SaveChanges();
            return r > 0;
        }
        public CheckListReviewItemModel UpdatechkActiveStatus1(int ChkRevewID, int chklistsectionID)
        {
            tblChecklistReviewItem emodel;
            using (var c = new CRCTestEntities1())
            {
                var records = c.tblChecklistReviewItems.Where(x => x.ChecklistReviewID == ChkRevewID && x.ChecklistReviewItemSectionID == chklistsectionID);
                foreach (var item in records)
                {
                    if (item.ChecklistReviewItemReviewerActive == true)
                    {
                        item.ChecklistReviewItemReviewerActive = false;
                    }
                    else if (item.ChecklistReviewItemReviewerActive == false)
                    {
                        item.ChecklistReviewItemReviewerActive = true;
                    }
                }
                c.SaveChanges();
            }
            return new CheckListReviewItemModel { ChecklistReviewID = ChkRevewID, ChecklistReviewItemSectionID = chklistsectionID };
        }

        public CheckListReviewItemComments GetCRCReceipt(int ChkItemId, int CommentItemId)
        {
            CRCTestEntities1 cnt = new CRCTestEntities1();
            var itm = cnt.tblChecklistReviewItemComments.Find(CommentItemId);
            var crcdetail = new CheckListReviewItemComments
            {
               //CheckListReviewID = ChkItemId,
               ChecklistReviewItemID= ChkItemId,
               ChecklistReviewDesignLevelCode = itm.ChecklistReviewDesignLevelCode,
               ChecklistReviewDesignLevelName = itm.ChecklistReviewDesignLevelName,
               ChecklistReviewDesignLevelID = itm.ChecklistReviewDesignLevelID,
               ChecklistReviewItemCommentID = itm.ChecklistReviewItemCommentID,
               ChecklistReviewItemReviewerResultComments=itm.ChecklistReviewItemReviewerResultComments,
               ChecklistReviewItemReviewerResultName=itm.ChecklistReviewItemReviewerResultName,
               ChecklistReviewItemReviewerRole=itm.ChecklistReviewItemReviewerRole,
               Attachment = itm.Attachment,
               AttachmentName = itm.AttachmentName              
            };
            return crcdetail;
        }
    }

    }