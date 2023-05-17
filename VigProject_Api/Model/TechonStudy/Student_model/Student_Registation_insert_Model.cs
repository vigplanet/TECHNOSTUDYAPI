using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VigProject_Api.Model.Student
{
    public class Student_Registation_insert_Model
    {
        public int Orgid { get; set; }
        public int Branchid { get; set; }
        public int RegId { get; set; }
        public int RefId { get; set; }
        public int MFeesId { get; set; }
        public int TfeesId { get; set; }
        public int TransId { get; set; }
        public string UserId { get; set; }
        public decimal Amount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal AdjustmentAmount { get; set; }
        public decimal NetRemainingAmount { get; set; }
        public DateTime Date { get; set; }
        public DateTime TransDate { get; set; }
        public int PaymentMode { get; set; }
        public int Ispayment { get; set; }
        public int TranGroup { get; set; }
        public int TranFor { get; set; }
        public int UserLoginId { get; set; }
        public int SubBranchId { get; set; }
        public string StRegNo { get; set; }
        public string Narration { get; set; }
        public int StClass { get; set; }
        public string RegFormNo { get; set; }
        public int RegSession { get; set; }
        public DateTime StRegDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public DateTime DOB { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public int Country { get; set; }
        public int State { get; set; }
        public int City { get; set; }
        public string Pincode { get; set; }
        public string EmailId { get; set; }
        public string UniqueIdAutoGenerate { get; set; }
        public string SlipNo { get; set; }
        public DateTime SlipDate { get; set; }
        public string Status { get; set; }
        public int Year { get; set; }
        public int FeeHeadId { get; set; }
        public decimal Discount { get; set; }
        public decimal Receive { get; set; }
        public decimal Remaining { get; set; }
        public string Remark { get; set; }
        public string ChequeDDNo { get; set; }
        public string BankName { get; set; }
        public int IsCleared { get; set; }
        public DateTime ClearDate { get; set; }
    }
    public class Student_Registation_insert_Return_Model
    {
        public int RegId { get; set; }
        public int RefId { get; set; }
        public int MFeesId { get; set; }
        public int TfeesId { get; set; }


    }
}
