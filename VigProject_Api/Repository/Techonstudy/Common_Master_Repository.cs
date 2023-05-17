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
    public class Common_Master_Repository
    {
        public async Task<List<Common_Master_Return_Model>> GetData(Common_Master_Model model)
        {            
            List<Common_Master_Return_Model> objModel = new List<Common_Master_Return_Model>();
            try
            {
                SqlDataReader sdr;
                DataTable dt_result = new DataTable();
                string conString = SqlHelper.GetConnectionString("TechOnStudy");
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("Usp_Get_CommonMaster_Detail", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Orgid", model.OrgId);
                        cmd.Parameters.AddWithValue("@Branchid", model.BranchId);
                        cmd.Parameters.AddWithValue("@CommonCode", model.CommonCode);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }
                objModel = dt_result.DataTableToList<Common_Master_Return_Model>();
            }
            catch (Exception ex)
            {
                //ErrorHandler.LogError(ex, 0, "API", "AuthRepository/ValidateLogin");
            }
            return await Task.FromResult(objModel);
        }

        public async Task<List<Common_Master_Return_Model>> EditData(Common_Master_Model model)
        {
            List<Common_Master_Return_Model> objModel = new List<Common_Master_Return_Model>();
            try
            {

                SqlDataReader sdr;
                DataTable dt_result = new DataTable();
                string conString = SqlHelper.GetConnectionString("TechOnStudy");
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("Edit_CommonData", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Orgid", model.OrgId);
                        cmd.Parameters.AddWithValue("@Branchid", model.BranchId);
                        cmd.Parameters.AddWithValue("@commonId", model.CommonId);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }
                objModel = dt_result.DataTableToList<Common_Master_Return_Model>();


                //string conString = SqlHelper.GetConnectionString("TechOnStudy");

                //using (SqlConnection con = new SqlConnection(conString))
                //{

                //    string sqlstr = "Edit_CommonData";
                //    SqlCommand cmd = new SqlCommand(sqlstr, con);
                //    cmd.Parameters.AddWithValue("@Orgid", model.OrgId);
                //    cmd.Parameters.AddWithValue("@Branchid", model.BranchId);
                //    cmd.Parameters.AddWithValue("@commonId", model.CommonId);
                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //    SqlDataReader sdr = cmd.ExecuteReader();

                //    while (sdr.Read())
                //    {
                //        objModel.Add(new Common_Master_Return_Model
                //        {
                //            CommonID = Convert.ToInt32(sdr["commonId"].ToString()),
                //            CommonDesc = Convert.ToString(sdr["CommonDesc"].ToString()),
                //            ShortName = Convert.ToString(sdr["ShortName"].ToString())
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
