using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VigProject_Api.Model
{
    public class Emploee_Model
    {
    }
    public class emp_Enc_Inputs
    {
        public string value1 { get; set; }
        public string value2 { get; set; }
    }

    public class Emp_Inputs
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    public class Profile_input
    {
        public int empid { get; set; }
        public string photo { get; set; }
    }

    



    public class orgEmpLogin_Model
    {
        public string status { get; set; }      
        public List<orgEmpLoginList_Model> Userloginlist { get; set; }
    }
    public class orgEmpLoginList_Model
    {
        public int loginId { get; set; }
        public string username { get; set; }
        public string status { get; set; }    
    }


    public class orgEmp_Model
    {
        public string status { get; set; }        
        public List<orgEmpList_Model> orgEmpList_Model { get; set; }
    }
    public class emp_status_Model
    {
        public string status { get; set; }
    }
        public class orgEmpList_Model
    { 
        public int empid { get; set; }
        public string EmpRegNo { get; set; }
        public string EmpName { get; set; }
        public string MobileNo { get; set; }
        public string photo { get; set; }
    }


    public class kam_membersignup_input
    {
        public string LoginId { get; set; }
        public string fullname { get; set; }
        public string mobileno { get; set; }
        public string emailid { get; set; }                 
        public string password { get; set; }       
        public string deviceid { get; set; }
    }

    public class kam_membersignin_input
    {     
        public string emailid { get; set; }
        public string password { get; set; }
    }




    public class kamLogin_Model
    {
        public string status { get; set; }
        public List<kamLoginList_Model> kamloginlist { get; set; }
    }
    public class kamLoginList_Model
    {
        public int loginId { get; set; }
        public string fullname { get; set; }
        public string mobileno { get; set; }
        public string emailid { get; set; }
        public string password { get; set; }
        public string status { get; set; }
    }


    public class kam_notification_input
    {
        public string deviceId { get; set; }
        public string message { get; set; }
        public string tickerText { get; set; }
        public string contentTitle { get; set; }
        public string msgtype { get; set; }       
    }


    public class Message_Input
    {
        public string number { get; set; }
        public string message { get; set; }
        public string mediatype { get; set; }
        public string base64Image { get; set; }
    }

}
