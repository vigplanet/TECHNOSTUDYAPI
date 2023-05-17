using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VigProject_Api.Model
{
    public class Payroll_Model
    {

    }

    public class SetBankSetting
    {
        public int BankID { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public decimal Esivalue { get; set; }
        public decimal EsiPer { get; set; }
        public int Status { get; set; }
    }
    public class SetEmployeeReq
    {
        public int EmpId { get; set; }
        public string EmpRegNo { get; set; }
        public string EmpName { get; set; }
        public string MobileNo { get; set; }
        public string MobileNo2 { get; set; }
        public string EmailID { get; set; }
        public int Status { get; set; }
        public string Address { get; set; }
        public string UID { get; set; }
        public string fathername { get; set; }
        public string acno { get; set; }
        public string MachineCode { get; set; }
    }
    public class EmployeeModel
    {
        public string status { get; set; }
        public List<EmployeeListModel> EmployeeListModel { get; set; }
    }
    public class EmployeeListModel
    {
        public int EmpId { get; set; }
        public string EmpRegNo { get; set; }
        public string fathername { get; set; }
        public string EmpName { get; set; }
        public string MobileNo { get; set; }
        public string MobileNo2 { get; set; }
        public string EmailID { get; set; }
        public string Address { get; set; }
        public string UID { get; set; }
        public string acno { get; set; }
        public string M_code { get; set; }
        public string photo { get; set; }
    }

    public class BankSettingModel
    {
        public string status { get; set; }
        public List<SetBankSetting> _SetBankSetting { get; set; }
    }

    public class EmployeeSalarySettingmodel
    {
        public string status { get; set; }
        public List<EmployeeSalarySettingList> EmployeeSalarySettingList { get; set; }
    }
    public class EmployeeSalarySettingList
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpRegNo { get; set; }
        public string MobileNo { get; set; }
        public string OfficetimeStart { get; set; }
        public string OfficetimeEnd { get; set; }
        public decimal TotalWorkingHours { get; set; }
        public decimal TotalMonthlySalary { get; set; }
        public decimal PerHoursSalary { get; set; }
        public decimal LateDeductionHours { get; set; }
        public string LunchtimeStart { get; set; }
        public string LunchtimeEnd { get; set; }
        public decimal TotalLunchHours { get; set; }
        public decimal SundayFilldayHours { get; set; }
        public decimal SundayFilldaySalary { get; set; }
        public decimal ExtraAmountBefore_after_time { get; set; }
        public int Status { get; set; }
        public decimal banksalary { get; set; }
        public string officelatetime { get; set; }
        public decimal BonusMonth { get; set; }
        public decimal ded_BonusLV { get; set; }
    }


    public class EmployeeSalarySettingList_in
    {
        public int EmpID { get; set; }
        public string OfficetimeStart { get; set; }
        public string OfficetimeEnd { get; set; }
        public decimal TotalWorkingHours { get; set; }
        public decimal TotalMonthlySalary { get; set; }
        public decimal PerHoursSalary { get; set; }
        public decimal LateDeductionHours { get; set; }
        public string LunchtimeStart { get; set; }
        public string LunchtimeEnd { get; set; }
        public decimal TotalLunchHours { get; set; }
        public decimal SundayFilldayHours { get; set; }
        public decimal SundayFilldaySalary { get; set; }
        public decimal ExtraAmountBefore_after_time { get; set; }
        public int Status { get; set; }
        public decimal banksalary { get; set; }
        public string officelatetime { get; set; }
        public decimal BonusMonth { get; set; }
        public decimal ded_BonusLV { get; set; }
    }

    public class EmpLoanMasterModel
    {
        public string status { get; set; }
        public List<EmpLoanMasterInput> EmpLoanMasterInput { get; set; }
    }

    public class EmpLoanMasterInput
    {
        public string EmpRegNo { get; set; }
        public string EmpName { get; set; }
        public string acno { get; set; }
        public int LoanId { get; set; }
        public int EmpID { get; set; }
        public DateTime LoanDate { get; set; }
        public decimal LoanAmt { get; set; }
        public decimal EmiAmt { get; set; }
        public string LoanStatus { get; set; }
        public int Status { get; set; }
    }


    public class EmpSalaryIncrementModel
    {
        public string status { get; set; }
        public List<EmpSalaryIncrementOutPut> _EmpSalaryIncrementOutPut { get; set; }
    }

    public class EmpSalaryIncrementInput
    {
        public int IncID { get; set; }
        public int EmpID { get; set; }
        public DateTime Date { get; set; }
        public decimal IncrementSalary { get; set; }
        public decimal BankSalary { get; set; }
        public int Status { get; set; }
    }

    public class EmpSalaryIncrementOutPut
    {
        public int IncID { get; set; }
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public DateTime Date { get; set; }
        public decimal IncrementSalary { get; set; }
        public decimal BankSalary { get; set; }
        public int Status { get; set; }
    }
}
