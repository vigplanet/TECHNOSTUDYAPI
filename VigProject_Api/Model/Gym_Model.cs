using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VigProject_Api.Model_Gym
{
    public class Gym_Model
    {
    }

    public class gym_Enc_Inputs
    {
        public string value1 { get; set; }
        public string value2 { get; set; }
    }

    public class gym_Inputs
    {
        public string username { get; set; }
        public string password { get; set; }
        public string orgcode { get; set; }
        public string orgtype { get; set; }
    }

    public class gym_signupInputs
    {
        public int org_id { get; set; }
        public string org_code { get; set; }
        public string org_name { get; set; }
        public string contactno { get; set; }
        public string emailId { get; set; }
        public string website { get; set; }
        public string ownername { get; set; }
        public string ownerno { get; set; }
        public string address { get; set; }
        public int status { get; set; }
        public string createip { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string orgcode { get; set; }
        public string orgtype { get; set; }
    }

    public class gym_membersignup
    {
        public int org_id { get; set; }
        public int memberid { get; set; }
        public string membercode { get; set; }
        public string membername { get; set; }
        public string contactno { get; set; }
        public string emailId { get; set; }
        public string address { get; set; }
        public int age { get; set; }
        public string dob { get; set; }       
        public int status { get; set; }
        public string createip { get; set; }         
    }

    public class orgLogin_Model
    {
        public string status { get; set; }
        public string status_msg { get; set; }
        public List<orgLoginList_Model> Userloginlist { get; set; }
    }
    public class orgLoginList_Model
    {
        public int org_id { get; set; }
        public int loginId { get; set; }
        public string username { get; set; }
        public int approve { get; set; }
        public DateTime createdate { get; set; }
        public string org_code { get; set; }
        public string org_name { get; set; }
        public string contactno { get; set; }
        public string emailId { get; set; }
        public string website { get; set; }
        public string ownername { get; set; }
        public string ownerno { get; set; }
        public string address { get; set; }
        public int status { get; set; }
        public int adminapprove { get; set; }
        public string error_msg { get; set; }
    }
}
