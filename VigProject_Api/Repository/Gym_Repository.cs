using VigProject_Api.Model_Gym;
using VigProject_Api.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace VigProject_Api.Repository
{
    public class Gym_Repository
    {
        public async Task<List<orgLoginList_Model>> repo_getOrgLoginStatus(string UserName, string Password, string orgcode, string orgtype, string Conn)
        {
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();

            List<orgLoginList_Model> lst = new List<orgLoginList_Model>();
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("checkuserlogin", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", UserName);
                        cmd.Parameters.AddWithValue("@Password", Password);
                        cmd.Parameters.AddWithValue("@usercode", orgcode);
                        cmd.Parameters.AddWithValue("@orgtype", orgtype);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }




                lst = dt_result.AsEnumerable()
                                .Select(dataRow => new orgLoginList_Model
                                {
                                    org_id = Convert.ToInt32(dataRow.Field<Int32>("org_id")),
                                    loginId = Convert.ToInt32(dataRow.Field<Int32>("loginId")),
                                    username = Convert.ToString(dataRow.Field<string>("username")),
                                    approve = Convert.ToInt32(dataRow.Field<Int32>("approve")),
                                    org_code = Convert.ToString(dataRow.Field<string>("org_code")),
                                    org_name = Convert.ToString(dataRow.Field<string>("org_name")),
                                    contactno = Convert.ToString(dataRow.Field<string>("contactno")),
                                    emailId = Convert.ToString(dataRow.Field<string>("emailId")),
                                    website = Convert.ToString(dataRow.Field<string>("website")),
                                    ownername = Convert.ToString(dataRow.Field<string>("ownername")),
                                    ownerno = Convert.ToString(dataRow.Field<string>("ownerno")),
                                    address = Convert.ToString(dataRow.Field<string>("address")),
                                    status = Convert.ToInt32(dataRow.Field<Int32>("status")),
                                    adminapprove = Convert.ToInt32(dataRow.Field<Int32>("adminapprove")),
                                    error_msg = "",
                                }).ToList();
            }
            catch (Exception ex)
            {
                lst.Add(new orgLoginList_Model
                {
                    error_msg = Convert.ToString(ex.Message)
                });
                // string msg = ex.Message;
            }
            return await Task.FromResult(lst);
        }

        public async Task<string> repo_setOrgSignUp(int org_id,
         string org_name,
         string contactno,
         string emailId,
         string website,
         string ownername,
         string ownerno,
         string address,
         int status,
         string createip,
         string username,
         string password, string Conn)
        {
            SqlDataReader sdr;

            string _Result = "";
            int _orgId = 0;// Convert.ToInt32(sdr[0].ToString());
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("Set_org_signup", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@org_id", org_id);
                        cmd.Parameters.AddWithValue("@org_code", "");
                        cmd.Parameters.AddWithValue("@org_name", org_name);
                        cmd.Parameters.AddWithValue("@contactno", contactno);
                        cmd.Parameters.AddWithValue("@emailId", emailId);
                        cmd.Parameters.AddWithValue("@website", website);
                        cmd.Parameters.AddWithValue("@ownername", ownername);
                        cmd.Parameters.AddWithValue("@ownerno", ownerno);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@createip", createip);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@result", SqlDbType.Int);
                        cmd.Parameters["@result"].Direction = ParameterDirection.Output;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        org_id = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());
                        if (org_id == 0)
                        {
                            _Result = "Duplicate Username";
                        }
                        if (org_id == -1)
                        {
                            _Result = "Duplicate Contact No or EmailId";
                        }
                        else
                            _Result = "You Saved Successfully";


                    }
                }
                if (org_id > 0)
                {
                    using (SqlConnection con = new SqlConnection(conString))
                    {
                        using (SqlCommand cmd = new SqlCommand("Set_userlogin", con))
                        {
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@org_id", _orgId);
                            cmd.Parameters.AddWithValue("@loginId", 0);
                            cmd.Parameters.AddWithValue("@username", username);
                            cmd.Parameters.AddWithValue("@password", password);
                            cmd.Parameters.AddWithValue("@createip", createip);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                _Result = Convert.ToString(ex.Message);


            }
            return await Task.FromResult(_Result);
        }

        public async Task<string> repo_setMemberRegistration(int org_id, int memberid, string membername, string contactno, string emailId, string address, int age, 
            string dob, string createip,
            string Conn)
        {
            SqlDataReader sdr;

            string _Result = "";
            int _orgId = 0;// Convert.ToInt32(sdr[0].ToString());
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("[Set_member_registration]", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@org_id", org_id);
                        cmd.Parameters.AddWithValue("@memberid", memberid);
                        cmd.Parameters.AddWithValue("@membercode", "");
                        cmd.Parameters.AddWithValue("@membername", membername);
                        cmd.Parameters.AddWithValue("@contactno", contactno);
                        cmd.Parameters.AddWithValue("@emailid", emailId);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@dob", dob);
                        cmd.Parameters.AddWithValue("@status", 1);                                           
                        cmd.Parameters.AddWithValue("@createip", createip);
                        cmd.Parameters.AddWithValue("@result", SqlDbType.Int);
                        cmd.Parameters["@result"].Direction = ParameterDirection.Output;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        org_id = Convert.ToInt32(cmd.Parameters["@result"].Value.ToString());                        
                        if (org_id == -1)
                        {
                            _Result = "Duplicate Contact No or EmailId";
                        }
                        else
                            _Result = "You Saved Successfully";


                    }
                }
            }
            catch (Exception ex)
            {

                _Result = Convert.ToString(ex.Message);


            }
            return await Task.FromResult(_Result);
        }
    }
}
