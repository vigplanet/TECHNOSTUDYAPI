using VigProject_Api.Model_casting;
using VigProject_Api.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace VigProject_Api.Repository
{
    public class Casting_Repository
    {
        public async Task<List<SuperAdminLoginList_Model>> CheckSuperAdminLoginAsync(string UserName, string Password,string Conn)
        {
            SqlDataReader sdr;
            DataTable retVal_casting = new DataTable();
            DataTable retVal_caming = new DataTable();
            DataTable retVal = new DataTable();

            List<SuperAdminLoginList_Model> lst = new List<SuperAdminLoginList_Model>();
            try
            {

                string conString = SqlHelper.GetConnectionString(Conn);
                //string fd = date.ToString("dd/MM/yyyy");
                //using (DBClass obj = new DBClass("CheckSuperAdminLogin", CommandType.StoredProcedure, conString))
                //{
                //    obj.AddParameters("UserName", UserName);
                //    obj.AddParameters("Password", Password);
                //    obj.AddParameters("type_n", "M");
                //    dt = obj.ReturnDataTable();
                //}
               
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("CheckSuperAdminLogin", con))
                    {
                        //cmd.CommandText = "SELECT s.*, m.MakeName FROM ServerBillingDetails AS s LEFT JOIN MakeMaster AS m ON s.MakeId = m.UserId";
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserName", UserName);
                        cmd.Parameters.AddWithValue("@Password", Password);
                        cmd.Parameters.AddWithValue("@type_n", "M");
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        retVal_casting = new DataTable();
                        retVal_casting.Load(sdr);
                        con.Close();
                    }
                }

                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("Cam_CheckSuperAdminLogin", con))
                    {
                        //cmd.CommandText = "SELECT s.*, m.MakeName FROM ServerBillingDetails AS s LEFT JOIN MakeMaster AS m ON s.MakeId = m.UserId";
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserName", UserName);
                        cmd.Parameters.AddWithValue("@Password", Password);
                        cmd.Parameters.AddWithValue("@type_n", "M");
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        retVal_caming = new DataTable();
                        retVal_caming.Load(sdr);
                        con.Close();
                    }
                }


                if (retVal_casting.Rows.Count > 0)
                    retVal = retVal_casting;
                else if (retVal_caming.Rows.Count > 0)
                    retVal = retVal_caming;

                retVal.Columns.Add("castinguserid", typeof(string));
                retVal.Columns.Add("caminguserid", typeof(string));

                if (retVal_casting.Rows.Count > 0)
                {
                    retVal.Rows[0]["caminguserid"] = "0";
                    retVal.Rows[0]["castinguserid"] = retVal_casting.Rows[0]["Userid"].ToString();
                }
                else if (retVal_caming.Rows.Count > 0)
                {
                    retVal.Rows[0]["castinguserid"] = "0";
                    retVal.Rows[0]["caminguserid"] = retVal_caming.Rows[0]["Userid"].ToString();
                }

                if (retVal_casting.Rows.Count > 0 && retVal_caming.Rows.Count > 0 && retVal.Rows.Count > 0)
                {
                    retVal.Rows[0]["castinguserid"] = retVal_casting.Rows[0]["Userid"].ToString();
                    retVal.Rows[0]["caminguserid"] = retVal_caming.Rows[0]["Userid"].ToString();
                }


                lst = retVal.AsEnumerable()
                                .Select(dataRow => new SuperAdminLoginList_Model
                                {
                                    UserId = Convert.ToString(dataRow.Field<Int32>("UserId")),
                                    org_id = Convert.ToString(dataRow.Field<Int32>("org_id")),
                                    MakeName = Convert.ToString(dataRow.Field<string>("MakeName")),
                                    ContactPerson = Convert.ToString(dataRow.Field<string>("ContactPerson")),                                  
                                    ContactNo = Convert.ToString(dataRow.Field<string>("ContactNo")),                                   
                                    Email = Convert.ToString(dataRow.Field<string>("Email")),
                                    ContactNo1 = Convert.ToString(dataRow.Field<string>("ContactNo1")),                                   
                                    UserName = Convert.ToString(dataRow.Field<string>("UserName")),
                                    Password = Convert.ToString(dataRow.Field<string>("Password")),
                                    castinguserid = Convert.ToString(dataRow.Field<string>("castinguserid")),
                                    caminguserid = Convert.ToString(dataRow.Field<string>("caminguserid"))                                    
                                }).ToList();
            }
            catch (Exception ex)
            {
                lst.Add(new SuperAdminLoginList_Model
                {
                    MakeName = Convert.ToString(ex.Message) 
                });
                // string msg = ex.Message;
            }
            return await Task.FromResult(lst);
        }
    }
}
