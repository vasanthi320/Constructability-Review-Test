using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructability_Review_Test_Models
{
   public class JobModel
    {
        public byte JCCo { get; set; }
        public string Job { get; set; }
        public Nullable<int> JobNum { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}
