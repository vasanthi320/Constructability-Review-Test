using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Constructability_Review_Test_Models
{
    
        public class AddCheckListCommentsmodel
        {
            public string designLvlCode { get; set; }
            public string riwerrole { get; set; }
            public string ReviewerName { get; set; }
            public string cmts { get; set; }        
            public string chkSecNam { get; set; }
            public int chkId { get; set; }
            public int chkItmId { get; set; }
            public int chkSecId { get; set; }
          public string AttachmentName { get; set; }
          public string Attachment { get; set; }
          public HttpPostedFileBase FAttachment { get; set; }
    }
 }
