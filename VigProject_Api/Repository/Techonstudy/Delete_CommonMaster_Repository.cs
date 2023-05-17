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
    public class Delete_CommonMaster_Repository
    {
        public async Task<List<Delete_CommonMaster_Return_Model>> DeleteData(Delete_CommonMaster_Model model)
        {
            List<Delete_CommonMaster_Return_Model> objModel = new List<Delete_CommonMaster_Return_Model>();
            try
            {
                SqlDataReader sdr;
                DataTable dt_result = new DataTable();
                string conString = SqlHelper.GetConnectionString("TechOnStudy");
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("Delete_CommonMaster", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Orgid", model.Orgid);
                        cmd.Parameters.AddWithValue("@Branchid", model.Branchid);
                        cmd.Parameters.AddWithValue("@CommonCode", model.CommonCode);
                        cmd.Parameters.AddWithValue("@CommonDesc", model.CommonDesc);
                        cmd.Parameters.AddWithValue("@commonid", model.CommonId);
                        cmd.Parameters.AddWithValue("@Status", model.Status);
                        cmd.Parameters.AddWithValue("@Status1", model.Status1);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }
                objModel = dt_result.DataTableToList<Delete_CommonMaster_Return_Model>();

                //string conString = SqlHelper.GetConnectionString("TechOnStudy");
                //using (SqlConnection con = new SqlConnection(conString))
                //{
                //    string sqlstr = "Delete_CommonMaster";
                //    SqlCommand cmd = new SqlCommand(sqlstr, con);
                //    cmd.Parameters.AddWithValue("@Orgid", model.Orgid);
                //    cmd.Parameters.AddWithValue("@Branchid", model.Branchid);
                //    cmd.Parameters.AddWithValue("@CommonCode", model.CommonCode);
                //    cmd.Parameters.AddWithValue("@CommonDesc", model.CommonDesc);
                //    cmd.Parameters.AddWithValue("@commonid", model.CommonId);
                //    cmd.Parameters.AddWithValue("@Status", model.Status);
                //    cmd.Parameters.AddWithValue("@Status1", model.Status1);
                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //    //SqlDataReader sdr = cmd.ExecuteReader();
                //    cmd.ExecuteNonQuery();

                //    //while (sdr.Read())
                //    //{
                //    //    objModel.Add(new Delete_CommonMaster_Return_Model
                //    //    {
                //    //        RowEffected = sdr["S.No."].ToString()
                //    //    });
                //    //}

                //    //sdr.Close();
                //    con.Close();
                //}
            }
            catch (Exception ex)
            {
                //ErrorHandler.LogError(ex, 0, "API", "AuthRepository/ValidateLogin");
            }
            return await Task.FromResult(objModel);
        }

        public async Task<List<Delete_CommonMaster_Return_Model>> DeleteData1(Delete_CommonMaster_Model model)
        {
            List<Delete_CommonMaster_Return_Model> objModel = new List<Delete_CommonMaster_Return_Model>();
            try
            {
                SqlDataReader sdr;
                DataTable dt_result = new DataTable();
                string conString = SqlHelper.GetConnectionString("TechOnStudy");
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("Delete_CommonMaster1", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Orgid", model.Orgid);
                        cmd.Parameters.AddWithValue("@Branchid", model.Branchid);
                        cmd.Parameters.AddWithValue("@CommonCode", model.CommonCode);
                        cmd.Parameters.AddWithValue("@commonid", model.CommonId);
                        cmd.Parameters.AddWithValue("@commonid1", model.CommonId1);
                        cmd.Parameters.AddWithValue("@Status", model.Status);
                        cmd.Parameters.AddWithValue("@Status1", model.Status1);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }
                objModel = dt_result.DataTableToList<Delete_CommonMaster_Return_Model>();

                //string conString = SqlHelper.GetConnectionString("TechOnStudy");

                //using (SqlConnection con = new SqlConnection(conString))
                //{

                //    string sqlstr = "Delete_CommonMaster1";
                //    SqlCommand cmd = new SqlCommand(sqlstr, con);
                //    cmd.Parameters.AddWithValue("@Orgid", model.Orgid);
                //    cmd.Parameters.AddWithValue("@Branchid", model.Branchid);
                //    cmd.Parameters.AddWithValue("@CommonCode", model.CommonCode);
                //    cmd.Parameters.AddWithValue("@commonid", model.CommonId);
                //    cmd.Parameters.AddWithValue("@commonid1", model.CommonId1);
                //    cmd.Parameters.AddWithValue("@Status", model.Status);
                //    cmd.Parameters.AddWithValue("@Status1", model.Status1);
                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //    //SqlDataReader sdr = cmd.ExecuteReader();
                //    cmd.ExecuteNonQuery();

                //    //while (sdr.Read())
                //    //{
                //    //    objModel.Add(new Delete_CommonMaster_Return_Model
                //    //    {
                //    //        RowEffected = sdr["S.No."].ToString()
                //    //    });
                //    //}

                //    //sdr.Close();
                //    con.Close();
                //}

                //string conString = SqlHelper.GetConnectionString("TechOnStudy");

                //using (SqlConnection con = new SqlConnection(conString))
                //{

                //    string sqlstr = "Delete_CommonMaster1";
                //    SqlCommand cmd = new SqlCommand(sqlstr, con);
                //    cmd.Parameters.AddWithValue("@Orgid", model.Orgid);
                //    cmd.Parameters.AddWithValue("@Branchid", model.Branchid);
                //    cmd.Parameters.AddWithValue("@CommonCode", model.CommonCode);
                //    cmd.Parameters.AddWithValue("@commonid", model.CommonId);
                //    cmd.Parameters.AddWithValue("@commonid1", model.CommonId1);
                //    cmd.Parameters.AddWithValue("@Status", model.Status);
                //    cmd.Parameters.AddWithValue("@Status1", model.Status1);
                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //    //SqlDataReader sdr = cmd.ExecuteReader();
                //    cmd.ExecuteNonQuery();

                //    //while (sdr.Read())
                //    //{
                //    //    objModel.Add(new Delete_CommonMaster_Return_Model
                //    //    {
                //    //        RowEffected = sdr["S.No."].ToString()
                //    //    });
                //    //}

                //    //sdr.Close();
                //    con.Close();
                //}
            }
            catch (Exception ex)
            {
                //ErrorHandler.LogError(ex, 0, "API", "AuthRepository/ValidateLogin");
            }
            return await Task.FromResult(objModel);
        }
        public async Task<List<Delete_CommonMaster_Return_Model>> DeleteData2(Delete_CommonMaster_Model model)
        {
            List<Delete_CommonMaster_Return_Model> objModel = new List<Delete_CommonMaster_Return_Model>();
            try
            {
                SqlDataReader sdr;
                DataTable dt_result = new DataTable();
                string conString = SqlHelper.GetConnectionString("TechOnStudy");
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("Delete_CommonMaster2", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Orgid", model.Orgid);
                        cmd.Parameters.AddWithValue("@Branchid", model.Branchid);
                        cmd.Parameters.AddWithValue("@CommonCode", model.CommonCode);
                        cmd.Parameters.AddWithValue("@commonid", model.CommonId);
                        cmd.Parameters.AddWithValue("@commonid1", model.CommonId1);
                        cmd.Parameters.AddWithValue("@commonid2", model.CommonId2);
                        cmd.Parameters.AddWithValue("@Status", model.Status);
                        cmd.Parameters.AddWithValue("@Status1", model.Status1);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }
                objModel = dt_result.DataTableToList<Delete_CommonMaster_Return_Model>();

                //string conString = SqlHelper.GetConnectionString("TechOnStudy");

                //using (SqlConnection con = new SqlConnection(conString))
                //{

                //    string sqlstr = "Delete_CommonMaster2";
                //    SqlCommand cmd = new SqlCommand(sqlstr, con);
                //    cmd.Parameters.AddWithValue("@Orgid", model.Orgid);
                //    cmd.Parameters.AddWithValue("@Branchid", model.Branchid);
                //    cmd.Parameters.AddWithValue("@CommonCode", model.CommonCode);
                //    cmd.Parameters.AddWithValue("@commonid", model.CommonId);
                //    cmd.Parameters.AddWithValue("@commonid1", model.CommonId1);
                //    cmd.Parameters.AddWithValue("@commonid2", model.CommonId2);
                //    cmd.Parameters.AddWithValue("@Status", model.Status);
                //    cmd.Parameters.AddWithValue("@Status1", model.Status1);
                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //    SqlDataReader sdr = cmd.ExecuteReader();

                //    while (sdr.Read())
                //    {
                //        objModel.Add(new Delete_CommonMaster_Return_Model
                //        {
                //            RowEffected = sdr["S.No."].ToString()
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
