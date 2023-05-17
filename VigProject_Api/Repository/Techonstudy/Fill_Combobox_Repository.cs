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
    public class Fill_Combobox_Repository
    {
        public async Task<List<Fill_Combobox_Return_Model>> GetData(Fill_Combobox_Model model)
        {
            List<Fill_Combobox_Return_Model> objModel = new List<Fill_Combobox_Return_Model>();
            try
            {
                SqlDataReader sdr;
                DataTable dt_result = new DataTable();
                string conString = SqlHelper.GetConnectionString("TechOnStudy");
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("Usp_Fillcmb_Master", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Orgid", model.OrgId);
                        cmd.Parameters.AddWithValue("@Branchid", model.BranchId);
                        cmd.Parameters.AddWithValue("@commoncode", model.CommonCode);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }
                objModel = dt_result.DataTableToList<Fill_Combobox_Return_Model>();

                //string conString = SqlHelper.GetConnectionString("TechOnStudy");
                //using (SqlConnection con = new SqlConnection(conString))
                //{
                //    string sqlstr = "Usp_Fillcmb_Master";
                //    SqlCommand cmd = new SqlCommand(sqlstr, con);
                //    cmd.Parameters.AddWithValue("@Orgid", model.OrgId);
                //    cmd.Parameters.AddWithValue("@Branchid", model.BranchId);
                //    cmd.Parameters.AddWithValue("@commoncode", model.CommonCode);
                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //    SqlDataReader sdr = cmd.ExecuteReader();

                //    while (sdr.Read())
                //    {
                //        objModel.Add(new Fill_Combobox_Return_Model
                //        {
                //            CommonId = Convert.ToInt32(sdr["commonid"].ToString()),
                //            CommonDesc = Convert.ToString(sdr["commondesc"].ToString())
                //        });
                //    }

                //    sdr.Close();
                //    con.Close();
                //}
            }
            catch (Exception ex)
            {
                //ErrorHandler.LogError(ex, 0, "API", "AuthRepository/ValidateLogin");
            }
            return await Task.FromResult(objModel);
        }

        public async Task<List<Fill_Combobox_Return_Model>> GetData1(Fill_Combobox_Model model)
        {
            List<Fill_Combobox_Return_Model> objModel = new List<Fill_Combobox_Return_Model>();
            try
            {
                SqlDataReader sdr;
                DataTable dt_result = new DataTable();
                string conString = SqlHelper.GetConnectionString("TechOnStudy");
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("Usp_Fillcmb_Master1", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Orgid", model.OrgId);
                        cmd.Parameters.AddWithValue("@Branchid", model.BranchId);
                        cmd.Parameters.AddWithValue("@commoncode", model.CommonCode);
                        cmd.Parameters.AddWithValue("@CommonId", model.CommonId);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }
                objModel = dt_result.DataTableToList<Fill_Combobox_Return_Model>();

                //string conString = SqlHelper.GetConnectionString("TechOnStudy");
                //using (SqlConnection con = new SqlConnection(conString))
                //{
                //    string sqlstr = "Usp_Fillcmb_Master1";
                //    SqlCommand cmd = new SqlCommand(sqlstr, con);
                //    cmd.Parameters.AddWithValue("@Orgid", model.OrgId);
                //    cmd.Parameters.AddWithValue("@Branchid", model.BranchId);
                //    cmd.Parameters.AddWithValue("@commoncode", model.CommonCode);
                //    cmd.Parameters.AddWithValue("@CommonId", model.CommonId);
                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //    SqlDataReader sdr = cmd.ExecuteReader();

                //    while (sdr.Read())
                //    {
                //        objModel.Add(new Fill_Combobox_Return_Model
                //        {
                //            CommonId = Convert.ToInt32(sdr["commonid1"].ToString()),
                //            CommonDesc = Convert.ToString(sdr["commondesc1"].ToString())
                //        });
                //    }

                //    sdr.Close();
                //    con.Close();
                //}
            }
            catch (Exception ex)
            {
                //ErrorHandler.LogError(ex, 0, "API", "AuthRepository/ValidateLogin");
            }
            return await Task.FromResult(objModel);
        }
    }
}
