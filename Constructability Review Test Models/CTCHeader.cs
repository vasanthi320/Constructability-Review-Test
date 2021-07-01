using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructability_Review_Test_Models
{
    public class CTCHeader
    {
        public List<JobModel> JobDtls { get; set; }
        public string Job { get; set; }
        public Nullable<int> JobNum { get; set; }       
        public decimal percentage { get; set; }      
    }
}
