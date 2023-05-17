using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VigProject_Api.Model
{
    public class Delete_CommonMaster_Model
    {
        public int Orgid { get; set; }
        public int Branchid { get; set; }
        public int CommonId2 { get; set; }
        public int CommonId1 { get; set; }
        public int CommonId { get; set; }
        public string Status { get; set; }
        public int Status1 { get; set; }
        public int CommonCode { get; set; }
        public string CommonDesc { get; set; }
    }
    public class Delete_CommonMaster_Return_Model
    {
        public String RowEffected { get; set; }

    }
}
