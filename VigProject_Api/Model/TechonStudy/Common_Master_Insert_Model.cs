using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VigProject_Api.Model
{
    public class Common_Master_Insert_Model
    {
        public int CommonId { get; set; }
        public int CommonId1 { get; set; }
        public int CommonId2 { get; set; }
        public int CommonCode { get; set; }
        public string CommonDesc { get; set; }
        public string ShortName { get; set; }
        public string Status { get; set; }
        public int UserLOginId { get; set; }
        public int OrgId { get; set; }
        public int BranchId { get; set; }
        public string RecordStatus { get; set; }
    }
    public class Common_Master_Insert_Return_Model
    {
        public String RowEffected { get; set; }
        
    }
}
