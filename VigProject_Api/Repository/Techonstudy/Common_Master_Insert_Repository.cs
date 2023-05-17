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
    public class Common_Master_Insert_Repository
    {
        public async Task<List<Common_Master_Insert_Return_Model>> GetData(Common_Master_Insert_Model model)
        {
            List<Common_Master_Insert_Return_Model >objModel = new List<Common_Master_Insert_Return_Model>();
            try
            {
                SqlDataReader sdr;
                DataTable dt_result = new DataTable();
                string conString = SqlHelper.GetConnectionString("TechOnStudy");
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_CommonID_Master", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@commonID", model.CommonId);
                        cmd.Parameters.AddWithValue("@commonCode", model.CommonCode);
                        cmd.Parameters.AddWithValue("@commonDesc", model.CommonDesc);
                        cmd.Parameters.AddWithValue("@shortname", model.ShortName);
                        cmd.Parameters.AddWithValue("@status", model.Status);
                        cmd.Parameters.AddWithValue("@user_login_id", model.UserLOginId);
                        cmd.Parameters.AddWithValue("@org_id", model.OrgId);
                        cmd.Parameters.AddWithValue("@branch_id", model.BranchId);
                        cmd.Parameters.AddWithValue("@RecordStatus", model.RecordStatus);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }
                objModel = dt_result.DataTableToList<Common_Master_Insert_Return_Model>();

                //string conString = SqlHelper.GetConnectionString("TechOnStudy");
                //using (SqlConnection con = new SqlConnection(conString))
                //{
                //    string sqlstr = "sp_CommonID_Master";
                //    SqlCommand cmd = new SqlCommand(sqlstr, con);
                //    cmd.Parameters.AddWithValue("@commonID", model.CommonId);
                //    cmd.Parameters.AddWithValue("@commonCode", model.CommonCode);
                //    cmd.Parameters.AddWithValue("@commonDesc", model.CommonDesc);
                //    cmd.Parameters.AddWithValue("@shortname", model.ShortName);
                //    cmd.Parameters.AddWithValue("@status", model.Status);
                //    cmd.Parameters.AddWithValue("@user_login_id", model.UserLOginId);
                //    cmd.Parameters.AddWithValue("@org_id", model.OrgId);
                //    cmd.Parameters.AddWithValue("@branch_id", model.BranchId);
                //    cmd.Parameters.AddWithValue("@RecordStatus", model.RecordStatus);
                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //    SqlDataReader sdr = cmd.ExecuteReader();

                //    while (sdr.Read())
                //    {
                //        objModel.Add(new Common_Master_Insert_Return_Model
                //        {
                //            RowEffected = (sdr["commonID"].ToString())
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
        public async Task<List<Common_Master_Insert_Return_Model>> GetData1(Common_Master_Insert_Model model)
        {
            List<Common_Master_Insert_Return_Model> objModel = new List<Common_Master_Insert_Return_Model>();
            try
            {
                SqlDataReader sdr;
                DataTable dt_result = new DataTable();
                string conString = SqlHelper.GetConnectionString("TechOnStudy");
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_CommonID_Master1", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@org_id", model.OrgId);
                        cmd.Parameters.AddWithValue("@branch_id", model.BranchId);
                        cmd.Parameters.AddWithValue("@commonId1", model.CommonId1);
                        cmd.Parameters.AddWithValue("@commonId", model.CommonId);
                        cmd.Parameters.AddWithValue("@commonDesc1", model.CommonDesc);
                        cmd.Parameters.AddWithValue("@shortName1", model.ShortName);
                        cmd.Parameters.AddWithValue("@status", model.Status);
                        cmd.Parameters.AddWithValue("@user_login_id", model.UserLOginId);
                        cmd.Parameters.AddWithValue("@commoncode", model.CommonCode);
                        cmd.Parameters.AddWithValue("@RecordStatus", model.RecordStatus);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }
                objModel = dt_result.DataTableToList<Common_Master_Insert_Return_Model>();

                //string conString = SqlHelper.GetConnectionString("TechOnStudy");
                //using (SqlConnection con = new SqlConnection(conString))
                //{
                //    string sqlstr = "sp_CommonID_Master1";
                //    SqlCommand cmd = new SqlCommand(sqlstr, con);
                //    cmd.Parameters.AddWithValue("@org_id", model.OrgId);
                //    cmd.Parameters.AddWithValue("@branch_id", model.BranchId);
                //    cmd.Parameters.AddWithValue("@commonId1", model.CommonId1);
                //    cmd.Parameters.AddWithValue("@commonId", model.CommonId);
                //    cmd.Parameters.AddWithValue("@commonDesc1", model.CommonDesc);
                //    cmd.Parameters.AddWithValue("@shortName1", model.ShortName);
                //    cmd.Parameters.AddWithValue("@status", model.Status);
                //    cmd.Parameters.AddWithValue("@user_login_id", model.UserLOginId);
                //    cmd.Parameters.AddWithValue("@commoncode", model.CommonCode);
                //    cmd.Parameters.AddWithValue("@RecordStatus", model.RecordStatus);
                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //    SqlDataReader sdr = cmd.ExecuteReader();

                //    while (sdr.Read())
                //    {
                //        objModel.Add(new Common_Master_Insert_Return_Model
                //        {
                //            RowEffected = (sdr["commonID1"].ToString())
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

        public async Task<List<Common_Master_Insert_Return_Model>> GetData2(Common_Master_Insert_Model model)
        {
            List<Common_Master_Insert_Return_Model> objModel = new List<Common_Master_Insert_Return_Model>();
            try
            {
                SqlDataReader sdr;
                DataTable dt_result = new DataTable();
                string conString = SqlHelper.GetConnectionString("TechOnStudy");
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_CommonID_Master2", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@org_id", model.OrgId);
                        cmd.Parameters.AddWithValue("@branch_id", model.BranchId);
                        cmd.Parameters.AddWithValue("@commonId2", model.CommonId2);
                        cmd.Parameters.AddWithValue("@commonId1", model.CommonId1);
                        cmd.Parameters.AddWithValue("@commonId", model.CommonId);
                        cmd.Parameters.AddWithValue("@commonDesc2", model.CommonDesc);
                        cmd.Parameters.AddWithValue("@shortName2", model.ShortName);
                        cmd.Parameters.AddWithValue("@status", model.Status);
                        cmd.Parameters.AddWithValue("@user_login_id", model.UserLOginId);
                        cmd.Parameters.AddWithValue("@commoncode", model.CommonCode);
                        cmd.Parameters.AddWithValue("@RecordStatus", model.RecordStatus);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }
                objModel = dt_result.DataTableToList<Common_Master_Insert_Return_Model>();

                //string conString = SqlHelper.GetConnectionString("TechOnStudy");

                //using (SqlConnection con = new SqlConnection(conString))
                //{

                //    string sqlstr = "sp_CommonID_Master2";
                //    SqlCommand cmd = new SqlCommand(sqlstr, con);
                //    cmd.Parameters.AddWithValue("@org_id", model.OrgId);
                //    cmd.Parameters.AddWithValue("@branch_id", model.BranchId);
                //    cmd.Parameters.AddWithValue("@commonId2", model.CommonId2);
                //    cmd.Parameters.AddWithValue("@commonId1", model.CommonId1);
                //    cmd.Parameters.AddWithValue("@commonId", model.CommonId);
                //    cmd.Parameters.AddWithValue("@commonDesc2", model.CommonDesc);
                //    cmd.Parameters.AddWithValue("@shortName2", model.ShortName);
                //    cmd.Parameters.AddWithValue("@status", model.Status);
                //    cmd.Parameters.AddWithValue("@user_login_id", model.UserLOginId);
                //    cmd.Parameters.AddWithValue("@commoncode", model.CommonCode);
                //    cmd.Parameters.AddWithValue("@RecordStatus", model.RecordStatus);
                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //    SqlDataReader sdr = cmd.ExecuteReader();

                //    while (sdr.Read())
                //    {
                //        objModel.Add(new Common_Master_Insert_Return_Model
                //        {
                //            RowEffected = (sdr["commonID2"].ToString())
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
 