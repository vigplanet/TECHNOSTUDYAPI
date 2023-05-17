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
    public class Common_Master2_Repository
    {
        public async Task<List<Common_Master2_Return_Model>> GetData(Common_Master2_Model model)
        {
            List<Common_Master2_Return_Model> objModel = new List<Common_Master2_Return_Model>();
            try
            {
                SqlDataReader sdr;
                DataTable dt_result = new DataTable();
                string conString = SqlHelper.GetConnectionString("TechOnStudy");
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("Usp_Get_Commonid_master2", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Orgid", model.OrgId);
                        cmd.Parameters.AddWithValue("@Branchid", model.BranchId);
                        cmd.Parameters.AddWithValue("@commonid", model.CommonID);
                        cmd.Parameters.AddWithValue("@commonid1", model.CommonID1);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }
                objModel = dt_result.DataTableToList<Common_Master2_Return_Model>();

                //string conString = SqlHelper.GetConnectionString("TechOnStudy");
                //using (SqlConnection con = new SqlConnection(conString))
                //{
                //    string sqlstr = "Usp_Get_Commonid_master2";
                //    SqlCommand cmd = new SqlCommand(sqlstr, con);
                //    cmd.Parameters.AddWithValue("@Orgid", model.OrgId);
                //    cmd.Parameters.AddWithValue("@Branchid", model.BranchId);
                //    cmd.Parameters.AddWithValue("@commonid", model.CommonID);
                //    cmd.Parameters.AddWithValue("@commonid1", model.CommonID1);
                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //    SqlDataReader sdr = cmd.ExecuteReader();

                //    while (sdr.Read())
                //    {
                //        objModel.Add(new Common_Master2_Return_Model
                //        {
                //            SrNo = Convert.ToInt32(sdr["S.No."].ToString()),
                //            CommonID = Convert.ToInt32(sdr["commonid"].ToString()),
                //            CommonID1 = Convert.ToInt32(sdr["commonId1"].ToString()),
                //            CommonID2 = Convert.ToInt32(sdr["commonid2"].ToString()),
                //            CommonDesc = Convert.ToString(sdr["commonDesc2"].ToString()),
                //            ShortName = Convert.ToString(sdr["shortName2"].ToString()),
                //            Status = Convert.ToString(sdr["status"].ToString())
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
