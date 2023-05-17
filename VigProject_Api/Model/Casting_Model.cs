using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VigProject_Api.Model_casting
{
    public class Casting_Model
    {
    }
    public class Enc_Inputs
    {
        public string value1 { get; set; }
        public string value2 { get; set; }
    }
    #region Citizen
    public class Casting_Inputs
    {
        public string username { get; set; }
        public string password { get; set; }
        public string conn { get; set; }
    }
       
    public class SuperAdminLogin_Model
    {
        public string status { get; set; }
        public string status_msg { get; set; }
        public List<SuperAdminLoginList_Model> Userloginlist { get; set; }
    }
    public class SuperAdminLoginList_Model
    {
       
        public string UserId { get; set; }
        public string org_id { get; set; }
        public string MakeName { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string Cash { get; set; }
        public string status { get; set; }
        public string user_login_id { get; set; }
        public string ContactNo1 { get; set; }
        public string IsServerUpdated { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string castinguserid { get; set; }
        public string caminguserid { get; set; }
    }
     
    #endregion
}
