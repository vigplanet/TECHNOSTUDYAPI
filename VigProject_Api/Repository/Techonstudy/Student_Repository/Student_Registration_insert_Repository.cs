using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using VigProject_Api.Model.Student;
using VigProject_Api.Utility;

namespace VigProject_Api.Repository.Student_Repository
{
    public class Student_Registration_insert_Repository
    {
        public async Task<List<Student_Registation_insert_Return_Model>> InsertStudent(Student_Registation_insert_Model model)
        {
            List<Student_Registation_insert_Return_Model> objModel = new List<Student_Registation_insert_Return_Model>();
            string connString = SqlHelper.GetConnectionString("TechOnStudy");
            SqlTransaction objTrans = null;

            try
            {
                using (SqlConnection objConn = new SqlConnection(connString))
                {
                    objConn.Open();
                    objTrans = objConn.BeginTransaction();
                    SqlCommand cmd = new SqlCommand("insert_registation_before", objConn, objTrans);
                    cmd.Parameters.AddWithValue("@org_id", model.Orgid);
                    cmd.Parameters.AddWithValue("@branch_id", model.Branchid);
                    cmd.Parameters.AddWithValue("@reg_id", model.RegId);
                    cmd.Parameters.AddWithValue("@sub_branch_id", model.SubBranchId);
                    cmd.Parameters.AddWithValue("@st_reg_no", model.StRegNo);
                    cmd.Parameters.AddWithValue("@st_class", model.StClass);
                    cmd.Parameters.AddWithValue("@reg_form_no", model.RegFormNo);
                    cmd.Parameters.AddWithValue("@reg_session", model.RegSession);
                    cmd.Parameters.AddWithValue("@st_reg_date", model.StRegDate);
                    cmd.Parameters.AddWithValue("@st_first_name", model.FirstName);
                    cmd.Parameters.AddWithValue("@st_last_name", model.LastName);
                    cmd.Parameters.AddWithValue("@st_father_name", model.FatherName);
                    cmd.Parameters.AddWithValue("@st_mother_name", model.MotherName);
                    cmd.Parameters.AddWithValue("@st_DOB", model.DOB);
                    cmd.Parameters.AddWithValue("@st_mobile_no", model.MobileNo);
                    cmd.Parameters.AddWithValue("@st_address", model.Address);
                    cmd.Parameters.AddWithValue("@st_country", model.Country);
                    cmd.Parameters.AddWithValue("@st_state", model.State);
                    cmd.Parameters.AddWithValue("@st_city", model.City);
                    cmd.Parameters.AddWithValue("@st_pincode", model.Pincode);
                    cmd.Parameters.AddWithValue("@st_email_id", model.EmailId);
                    cmd.Parameters.AddWithValue("@Amount", model.Amount);
                    cmd.Parameters.AddWithValue("@Payment_mode", model.PaymentMode);
                    cmd.Parameters.AddWithValue("@Ispayment", model.Ispayment);
                    cmd.Parameters.AddWithValue("@ref_id", model.RefId);
                    cmd.Parameters.AddWithValue("@user_login_id", model.UserLoginId);
                    cmd.Parameters.AddWithValue("@Unique_Id_Auto_Generate", model.UniqueIdAutoGenerate);
                    cmd.Parameters.AddWithValue("@slip_no", model.SlipNo);
                    cmd.Parameters.AddWithValue("@slip_date", model.SlipDate);
                    cmd.Parameters.AddWithValue("@status", model.Status);
                    cmd.Parameters.AddWithValue("@st_year", model.Year);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        objModel.Add(new Student_Registation_insert_Return_Model
                        {
                            RegId = Convert.ToInt32(sdr["reg_id"].ToString())
                        });
                    }
                    
                    SqlCommand cmd1 = new SqlCommand("insert_Cheque_Detail", objConn, objTrans);
                    cmd1.Parameters.AddWithValue("@org_id", model.Orgid);
                    cmd1.Parameters.AddWithValue("@branch_id", model.Branchid);
                    cmd1.Parameters.AddWithValue("@reg_id", model.RegId);
                    cmd1.Parameters.AddWithValue("@cheque_dd_No", model.ChequeDDNo);
                    cmd1.Parameters.AddWithValue("@BankName", model.BankName);
                    cmd1.Parameters.AddWithValue("@Date", model.Date);
                    cmd1.Parameters.AddWithValue("@IsCleared", model.IsCleared);
                    cmd1.Parameters.AddWithValue("@ClearDate", model.ClearDate);
                    cmd1.Parameters.AddWithValue("@user_login_id", model.UserLoginId);
                    cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader sdr1 = cmd1.ExecuteReader();

                    while (sdr1.Read())
                    {
                        objModel.Add(new Student_Registation_insert_Return_Model
                        {
                            RefId = Convert.ToInt32(sdr1["ref_id"].ToString())
                        });
                    }

                    SqlCommand cmd2 = new SqlCommand("insert_fee_Submit", objConn, objTrans);
                    cmd2.Parameters.AddWithValue("@org_id", model.Orgid);
                    cmd2.Parameters.AddWithValue("@branch_id", model.Branchid);
                    cmd2.Parameters.AddWithValue("@reg_id", model.RegId);
                    cmd2.Parameters.AddWithValue("@reg_id", model.RefId);
                    cmd2.Parameters.AddWithValue("@MfeesId", model.MFeesId);
                    cmd2.Parameters.AddWithValue("@UserId", model.UserId);
                    cmd2.Parameters.AddWithValue("@Amount", model.Amount);
                    cmd2.Parameters.AddWithValue("@Net_amount", model.NetAmount);
                    cmd2.Parameters.AddWithValue("@Adjustment_amount", model.AdjustmentAmount);
                    cmd2.Parameters.AddWithValue("@Net_remaining_amount", model.NetRemainingAmount);
                    cmd2.Parameters.AddWithValue("@Date", model.Date);
                    cmd2.Parameters.AddWithValue("@Payment_mode", model.PaymentMode);
                    cmd2.Parameters.AddWithValue("@Ispayment", model.Ispayment);
                    cmd2.Parameters.AddWithValue("@ref_id", model.RefId);
                    cmd2.Parameters.AddWithValue("@user_login_id", model.UserLoginId);
                    cmd2.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader sdr2 = cmd2.ExecuteReader();

                    while (sdr2.Read())
                    {
                        objModel.Add(new Student_Registation_insert_Return_Model
                        {
                            MFeesId = Convert.ToInt32(sdr2["MfeesId"].ToString())
                        });
                    }

                    SqlCommand cmd3 = new SqlCommand("Insert_Fee_Submit_transaction", objConn, objTrans);
                    cmd3.Parameters.AddWithValue("@org_id", model.Orgid);
                    cmd3.Parameters.AddWithValue("@branch_id", model.Branchid);
                    cmd3.Parameters.AddWithValue("@reg_id", model.RegId);
                    cmd3.Parameters.AddWithValue("@MfeesId", model.MFeesId);
                    cmd3.Parameters.AddWithValue("@TfeesId", model.TfeesId);
                    cmd3.Parameters.AddWithValue("@UserId", model.UserId);
                    cmd3.Parameters.AddWithValue("@fee_head_id", model.FeeHeadId);
                    cmd3.Parameters.AddWithValue("@Amount", model.Amount);
                    cmd3.Parameters.AddWithValue("@Discount", model.Discount);
                    cmd3.Parameters.AddWithValue("@Receive", model.Receive);
                    cmd3.Parameters.AddWithValue("@Remaining", model.Remaining);
                    cmd3.Parameters.AddWithValue("@Remark", model.Remark);
                    cmd3.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader sdr3 = cmd3.ExecuteReader();

                    while (sdr3.Read())
                    {
                        objModel.Add(new Student_Registation_insert_Return_Model
                        {
                            TfeesId = Convert.ToInt32(sdr3["TfeesId"].ToString())
                        });
                    }

                    SqlCommand cmd4 = new SqlCommand("Insert_Expances_Income", objConn, objTrans);
                    cmd4.Parameters.AddWithValue("@org_id", model.Orgid);
                    cmd4.Parameters.AddWithValue("@branch_id", model.Branchid);
                    cmd4.Parameters.AddWithValue("@entry_Id", model.RegId);
                    cmd4.Parameters.AddWithValue("@Tran_ID", model.TransId);
                    cmd4.Parameters.AddWithValue("@Tran_Date", model.TransDate);
                    cmd4.Parameters.AddWithValue("@Tran_Group", model.TranGroup);
                    cmd4.Parameters.AddWithValue("@Tran_For", model.TranFor);
                    cmd4.Parameters.AddWithValue("@Narration", model.Narration);
                    cmd4.Parameters.AddWithValue("@Amount", model.Amount);
                    cmd4.Parameters.AddWithValue("@user_login_id", model.UserLoginId);
                    cmd4.Parameters.AddWithValue("@status", model.Status);
                    cmd4.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader sdr4 = cmd4.ExecuteReader();

                    while (sdr4.Read())
                    {
                        objModel.Add(new Student_Registation_insert_Return_Model
                        {
                            TfeesId = Convert.ToInt32(sdr4["TfeesId"].ToString())
                        });
                    }

                    objTrans.Commit();
                }
            }
            catch (Exception ex) { objTrans.Rollback(); }
            return await Task.FromResult(objModel);
        }
    }
}
