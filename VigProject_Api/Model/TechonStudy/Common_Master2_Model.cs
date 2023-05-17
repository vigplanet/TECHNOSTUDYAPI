using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VigProject_Api.Model
{
    public class Common_Master2_Model
    {
        public int OrgId { get; set; }
        public int BranchId { get; set; }
        public int CommonID { get; set; }
        public int CommonID1 { get; set; }
    }
    public class Common_Master2_Return_Model
    {
        public int SrNo { get; set; }
        public int CommonID { get; set; }
        public int CommonID1 { get; set; }
        public int CommonID2 { get; set; }
        public string CommonDesc { get; set; }
        public string ShortName { get; set; }
        public string Status { get; set; }
    }
}
