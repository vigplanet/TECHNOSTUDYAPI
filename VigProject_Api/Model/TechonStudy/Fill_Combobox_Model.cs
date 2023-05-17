using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VigProject_Api.Model
{
    public class Fill_Combobox_Model
    {
        public int OrgId { get; set; }
        public int BranchId { get; set; }
        public int CommonCode { get; set; }
        public int CommonId { get; set; }
    }

    public class Fill_Combobox_Return_Model
    {
        public int CommonId{ get; set; }
        public string CommonDesc { get; set; }
    }
}
