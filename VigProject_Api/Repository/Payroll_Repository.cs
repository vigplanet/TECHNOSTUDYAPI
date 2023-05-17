using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using VigProject_Api.Model;
using VigProject_Api.Utility;

namespace VigProject_Api.Repository
{
    public class Payroll_Repository
    {
        public async Task<List<EmployeeListModel>> repo_GetEmployeeList(string Conn, string empname, string mobileno)
        {
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();

            List<EmployeeListModel> lst = new List<EmployeeListModel>();
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_getEmployeeList", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@empname", empname);
                        cmd.Parameters.AddWithValue("@MobileNo", mobileno);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }
                lst = dt_result.DataTableToList<EmployeeListModel>();
            }
            catch (Exception ex)
            {
                lst.Add(new EmployeeListModel { });
            }
            return await Task.FromResult(lst);
        }



        public async Task<string> repo_SetNewEmployee(string conn, SetEmployeeReq _setEmployeeReq)
        {
            try
            {
                string conString = SqlHelper.GetConnectionString(conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("EMPSet_EmpMaster", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmpId", _setEmployeeReq.EmpId);
                        cmd.Parameters.AddWithValue("@EmpRegNo", _setEmployeeReq.EmpRegNo);
                        cmd.Parameters.AddWithValue("@EmpName", _setEmployeeReq.EmpName);
                        cmd.Parameters.AddWithValue("@MobileNo", _setEmployeeReq.MobileNo);
                        cmd.Parameters.AddWithValue("@MobileNo2", _setEmployeeReq.MobileNo2);
                        cmd.Parameters.AddWithValue("@EmailID", _setEmployeeReq.EmailID);
                        cmd.Parameters.AddWithValue("@Status", _setEmployeeReq.Status);
                        cmd.Parameters.AddWithValue("@Address", _setEmployeeReq.Address);
                        cmd.Parameters.AddWithValue("@UID", _setEmployeeReq.UID);
                        cmd.Parameters.AddWithValue("@fathername", _setEmployeeReq.fathername);
                        cmd.Parameters.AddWithValue("@acno", _setEmployeeReq.acno);
                        cmd.Parameters.AddWithValue("@m_code", _setEmployeeReq.MachineCode);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return await Task.FromResult("1");
        }

        public async Task<string> repo_EMPSet_BankMasterSetting(string conn, SetBankSetting _SetBankSetting)
        {
            try
            {
                string conString = SqlHelper.GetConnectionString(conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("EMPSet_BankMasterSetting", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@BankID", _SetBankSetting.BankID);
                        cmd.Parameters.AddWithValue("@BankName", _SetBankSetting.BankName);
                        cmd.Parameters.AddWithValue("@BranchName", _SetBankSetting.BranchName);
                        cmd.Parameters.AddWithValue("@Esivalue", _SetBankSetting.Esivalue);
                        cmd.Parameters.AddWithValue("@EsiPer", _SetBankSetting.EsiPer);
                        cmd.Parameters.AddWithValue("@Status", _SetBankSetting.Status);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return await Task.FromResult("1");
        }

        public async Task<List<SetBankSetting>> repo_gettBankMasterSetting(string Conn)
        {
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();

            List<SetBankSetting> lst = new List<SetBankSetting>();
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("EMPGet_BankMasterSetting", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }
                lst = dt_result.DataTableToList<SetBankSetting>();
            }
            catch (Exception ex)
            {
                lst.Add(new SetBankSetting { });
            }
            return await Task.FromResult(lst);
        }

        public async Task<string> repo_setmployeeSalarySetting(string conn, EmployeeSalarySettingList_in _EmployeeSalarySettingList)
        {
            try
            {
                string conString = SqlHelper.GetConnectionString(conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("EMPSet_EmpSalaryMaster", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmpID", _EmployeeSalarySettingList.EmpID);
                        cmd.Parameters.AddWithValue("@OfficetimeStart", _EmployeeSalarySettingList.OfficetimeStart);
                        cmd.Parameters.AddWithValue("@OfficetimeEnd", _EmployeeSalarySettingList.OfficetimeEnd);
                        cmd.Parameters.AddWithValue("@TotalWorkingHours", _EmployeeSalarySettingList.TotalWorkingHours);
                        cmd.Parameters.AddWithValue("@TotalMonthlySalary", _EmployeeSalarySettingList.TotalMonthlySalary);
                        cmd.Parameters.AddWithValue("@PerHoursSalary", _EmployeeSalarySettingList.PerHoursSalary);
                        cmd.Parameters.AddWithValue("@LateDeductionHours", _EmployeeSalarySettingList.LateDeductionHours);
                        cmd.Parameters.AddWithValue("@LunchtimeStart", _EmployeeSalarySettingList.LunchtimeStart);
                        cmd.Parameters.AddWithValue("@LunchtimeEnd", _EmployeeSalarySettingList.LunchtimeEnd);
                        cmd.Parameters.AddWithValue("@TotalLunchHours", _EmployeeSalarySettingList.TotalLunchHours);
                        cmd.Parameters.AddWithValue("@SundayFilldayHours", _EmployeeSalarySettingList.SundayFilldayHours);
                        cmd.Parameters.AddWithValue("@SundayFilldaySalary", _EmployeeSalarySettingList.SundayFilldaySalary);
                        cmd.Parameters.AddWithValue("@ExtraAmountBefore_after_time", _EmployeeSalarySettingList.ExtraAmountBefore_after_time);
                        cmd.Parameters.AddWithValue("@Status", 1);
                        cmd.Parameters.AddWithValue("@banksalary", _EmployeeSalarySettingList.banksalary);
                        cmd.Parameters.AddWithValue("@officelatetime", _EmployeeSalarySettingList.officelatetime);
                        cmd.Parameters.AddWithValue("@BonusMonth", _EmployeeSalarySettingList.BonusMonth);
                        cmd.Parameters.AddWithValue("@ded_BonusLV", _EmployeeSalarySettingList.ded_BonusLV);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return await Task.FromResult("200");
        }

        public async Task<List<EmployeeSalarySettingList>> repo_getEmployeeSalarySettingList(string Conn, int Empid)
        {
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();

            List<EmployeeSalarySettingList> lst = new List<EmployeeSalarySettingList>();
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_GetEmpSalarySetting", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@empid", Empid);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }
                lst = dt_result.DataTableToList<EmployeeSalarySettingList>();
            }
            catch (Exception ex)
            {
                lst.Add(new EmployeeSalarySettingList { });
            }
            return await Task.FromResult(lst);
        }

        public async Task<string> repo_setLoandMaster(string conn, EmpLoanMasterInput _EmpLoanMasterInput)
        {
            try
            {
                string conString = SqlHelper.GetConnectionString(conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("EMPSet_EmpSalaryMaster", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LoanId", _EmpLoanMasterInput.LoanId);
                        cmd.Parameters.AddWithValue("@EmpID", _EmpLoanMasterInput.EmpID);
                        cmd.Parameters.AddWithValue("@LoanDate", _EmpLoanMasterInput.LoanDate);
                        cmd.Parameters.AddWithValue("@LoanAmt", _EmpLoanMasterInput.LoanAmt);
                        cmd.Parameters.AddWithValue("@EmiAmt", _EmpLoanMasterInput.EmiAmt);
                        cmd.Parameters.AddWithValue("@LoanStatus", _EmpLoanMasterInput.LoanStatus);
                        cmd.Parameters.AddWithValue("@Status", _EmpLoanMasterInput.Status);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return await Task.FromResult("200");
        }

        public async Task<List<EmpLoanMasterInput>> repo_getLoanMaster(string Conn, int Empid, int Loanid)
        {
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();

            List<EmpLoanMasterInput> lst = new List<EmpLoanMasterInput>();
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_GetEmpLoanMaster", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@empid", Empid);
                        cmd.Parameters.AddWithValue("@loanid", Loanid);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }
                lst = dt_result.DataTableToList<EmpLoanMasterInput>();
            }
            catch (Exception ex)
            {
                lst.Add(new EmpLoanMasterInput { });
            }
            return await Task.FromResult(lst);
        }

        public async Task<string> repo_setEmployeeSalaryIncrement(string conn, EmpSalaryIncrementInput _EmpSalaryIncrementInput)
        {
            try
            {
                string conString = SqlHelper.GetConnectionString(conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("EMPSet_SalaryIncrement", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IncID", _EmpSalaryIncrementInput.IncID);
                        cmd.Parameters.AddWithValue("@EmpID", _EmpSalaryIncrementInput.EmpID);
                        cmd.Parameters.AddWithValue("@Date", _EmpSalaryIncrementInput.Date);
                        cmd.Parameters.AddWithValue("@IncrementSalary", _EmpSalaryIncrementInput.IncrementSalary);
                        cmd.Parameters.AddWithValue("@BankSalary", _EmpSalaryIncrementInput.BankSalary);
                        cmd.Parameters.AddWithValue("@Status", _EmpSalaryIncrementInput.Status);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return await Task.FromResult("200");
        }

        public async Task<List<EmpSalaryIncrementOutPut>> repo_getEmployeeSalaryIncrement(string Conn)
        {
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();

            List<EmpSalaryIncrementOutPut> lst = new List<EmpSalaryIncrementOutPut>();
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetEmpSalaryIncrement", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;                       
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }
                lst = dt_result.DataTableToList<EmpSalaryIncrementOutPut>();
            }
            catch (Exception ex)
            {
                lst.Add(new EmpSalaryIncrementOutPut { });
            }
            return await Task.FromResult(lst);
        }
    }
}
