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
    public class Employee_Repository
    {
        public async Task<List<orgEmpLoginList_Model>> repo_getOrgEmpLoginStatus(string UserName, string Password, string Conn)
        {
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();

            List<orgEmpLoginList_Model> lst = new List<orgEmpLoginList_Model>();
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("getOrgLogin", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", UserName);
                        cmd.Parameters.AddWithValue("@password", Password);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }




                lst = dt_result.AsEnumerable()
                                .Select(dataRow => new orgEmpLoginList_Model
                                {
                                    loginId = Convert.ToInt32(dataRow.Field<Int32>("LoginId")),
                                    username = Convert.ToString(dataRow.Field<string>("Username")),
                                    status = "1"
                                }).ToList();
            }
            catch (Exception ex)
            {
                lst.Add(new orgEmpLoginList_Model
                {
                    status = "0"
                });
                // string msg = ex.Message;
            }
            return await Task.FromResult(lst);
        }

        public async Task<List<orgEmpList_Model>> repo_getOrgEmpList(string Conn)
        {
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();

            List<orgEmpList_Model> lst = new List<orgEmpList_Model>();
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("getOrgEmpList", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@username", UserName);
                        //cmd.Parameters.AddWithValue("@password", Password);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        //dt_result = new DataTable();
                        //dt_result.Load(sdr);

                        while (sdr.Read())
                        {
                            lst.Add(new orgEmpList_Model
                            {
                                empid = Convert.ToInt32(sdr["empid"].ToString()),
                                EmpRegNo = Convert.ToString(sdr["EmpRegNo"].ToString()),
                                EmpName = Convert.ToString(sdr["EmpName"].ToString()),
                                MobileNo = Convert.ToString(sdr["MobileNo"].ToString()),
                                photo = Convert.ToString(sdr["photo"])
                            });
                        }
                        sdr.Close();
                        con.Close();

                    }
                }




                //lst = dt_result.AsEnumerable()
                //        .Select(dataRow => new orgEmpList_Model
                //        {
                //            empid = Convert.ToInt32(dataRow.Field<Int32>("empid")),
                //            EmpRegNo = Convert.ToString(dataRow.Field<string>("EmpRegNo")),
                //            EmpName = Convert.ToString(dataRow.Field<string>("EmpName")),
                //            MobileNo = Convert.ToString(dataRow.Field<string>("MobileNo"))
                //        }).ToList();
            }
            catch (Exception ex)
            {
                lst.Add(new orgEmpList_Model
                {
                    EmpName = ex.ToString()
                }); ;
                // string msg = ex.Message;
            }
            return await Task.FromResult(lst);
        }

        public async Task<string> repo_setEmployeePhoto(string Conn, int empid, string photo)
        {
            string result = "";

            //byte[] picArray = Convert.FromBase64String(photo);

            try
            {

                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("SaveEmp_Photos", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@empid", empid);
                        cmd.Parameters.AddWithValue("@filename", photo);
                        con.Open();
                        cmd.ExecuteNonQuery();

                        con.Close();
                        result = "Success";
                    }
                }
            }
            catch (Exception ex) { result = ex.ToString(); }


            return await Task.FromResult(result);
        }
        //public async Task<string> repo_setEmployeePhoto(string Conn, int empid, string photo)
        //{
        //    string result = "";

        //    byte[] picArray = Convert.FromBase64String(photo);

        //    try
        //    {

        //        string conString = SqlHelper.GetConnectionString(Conn);
        //        using (SqlConnection con = new SqlConnection(conString))
        //        {
        //            using (SqlCommand cmd = new SqlCommand("SaveEmp_Photos", con))
        //            {
        //                cmd.Connection = con;
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@empid", empid);
        //                cmd.Parameters.AddWithValue("@photo", picArray);
        //                con.Open();
        //                cmd.ExecuteNonQuery();

        //                con.Close();
        //                result = "Success";
        //            }
        //        }
        //    }
        //    catch (Exception ex) { result = ex.ToString(); }


        //    return await Task.FromResult(result);
        //}

        //public async Task<string> repo_getEmployeePhoto(string Conn, int empid)
        //{
        //    string result = "";

        //    //byte[] picArray = Convert.FromBase64String(photo);

        //    try
        //    {

        //        string conString = SqlHelper.GetConnectionString(Conn);


        //        byte[] bytes;


        //        using (SqlConnection con = new SqlConnection(conString))
        //        {
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.CommandText = "SELECT photo FROM [EmpMaster] where empid = @empid";
        //                cmd.Parameters.AddWithValue("@empid", empid);
        //                cmd.Connection = con;
        //                con.Open();
        //                using (SqlDataReader sdr = cmd.ExecuteReader())
        //                {
        //                    sdr.Read();
        //                    bytes = (byte[])sdr["photo"];
        //                }
        //                con.Close();
        //            }
        //        }
        //        result = Convert.ToBase64String(bytes);


        //    }
        //    catch (Exception ex) { result = ex.ToString(); }


        //    return await Task.FromResult(result);
        //}

        public async Task<string> repo_getEmployeePhoto(string Conn, int empid)
        {
            string result = "";

            //byte[] picArray = Convert.FromBase64String(photo);

            try
            {

                string conString = SqlHelper.GetConnectionString(Conn);


                // byte[] bytes;
                string str = "";

                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "SELECT filename FROM [EmpMaster] where empid = @empid";
                        cmd.Parameters.AddWithValue("@empid", empid);
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            sdr.Read();
                            str = Convert.ToString(sdr["filename"]);
                        }
                        con.Close();
                    }
                }
                result = str;


            }
            catch (Exception ex) { result = ex.ToString(); }


            return await Task.FromResult(result);
        }

        public async Task<string> repo_setEmployeeCheckIn(string Conn, int empid)
        {
            string result = "";



            try
            {

                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("setAppAttendanceDaily_punchinc", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@empid", empid);
                        cmd.Parameters.AddWithValue("@status", 1);
                        con.Open();
                        string str = cmd.ExecuteScalar().ToString();
                        con.Close();
                        if (str == "1")
                            result = "Success";
                        else result = "Already Exist";

                    }
                }
            }
            catch (Exception ex) { result = ex.ToString(); }


            return await Task.FromResult(result);
        }

        public async Task<string> repo_setEmployeeCheckOut(string Conn, int empid)
        {
            string result = "";



            try
            {

                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("setAppAttendanceDaily_punchout", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@empid", empid);
                        cmd.Parameters.AddWithValue("@status", 1);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        result = "Success";
                    }
                }
            }
            catch (Exception ex) { result = ex.ToString(); }


            return await Task.FromResult(result);
        }



        public async Task<List<kamLoginList_Model>> repo_setKAMMemberRegistration(string LoginId, string Fullname, string EmailID, string mobileno, string username, string password, string deviceid, string Conn)
        {
            SqlDataReader sdr;
            string conString = SqlHelper.GetConnectionString(Conn);
            string _Result = "";
            List<kamLoginList_Model> lst = new List<kamLoginList_Model>();

            DataTable dt_result = new DataTable();
            try
            {

                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("SetUserRegistrationDetails", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@LoginId", LoginId);
                        cmd.Parameters.AddWithValue("@Fullname", Fullname);
                        cmd.Parameters.AddWithValue("@EmailID", EmailID);
                        cmd.Parameters.AddWithValue("@mobileno", mobileno);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@deviceid", deviceid);
                        cmd.Parameters.AddWithValue("@result1", SqlDbType.Int);
                        cmd.Parameters["@result1"].Direction = ParameterDirection.Output;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        LoginId = Convert.ToString(cmd.Parameters["@result1"].Value.ToString());
                        if (LoginId == "-3")
                        {
                            _Result = "Email id already Register";
                            lst.Add(new kamLoginList_Model
                            {
                                loginId = 0,
                                status = _Result
                            });
                        }
                        else if (LoginId == "-2")
                        {
                            _Result = "MobileNo already Register";
                            lst.Add(new kamLoginList_Model
                            {
                                loginId = 0,
                                status = _Result
                            });
                        }
                        else
                        {
                            _Result = "You Saved Successfully";

                        }
                    }
                }


                if (_Result == "You Saved Successfully")
                {
                    try
                    {
                        // string conString = SqlHelper.GetConnectionString(Conn);
                        using (SqlConnection con = new SqlConnection(conString))
                        {
                            using (SqlCommand cmd = new SqlCommand("GetUserRegistrationDetailsId", con))
                            {
                                cmd.Connection = con;
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@LoginId", LoginId);
                                con.Open();
                                sdr = cmd.ExecuteReader();
                                dt_result = new DataTable();
                                dt_result.Load(sdr);
                                con.Close();
                            }
                        }




                        lst = dt_result.AsEnumerable()
                                        .Select(dataRow => new kamLoginList_Model
                                        {
                                            loginId = Convert.ToInt32(dataRow.Field<Int32>("Id")),
                                            fullname = Convert.ToString(dataRow.Field<string>("Fullname")),
                                            emailid = Convert.ToString(dataRow.Field<string>("EmailID")),
                                            mobileno = Convert.ToString(dataRow.Field<string>("mobileno")),
                                            status = _Result
                                        }).ToList();
                    }
                    catch (Exception ex)
                    {
                        lst.Add(new kamLoginList_Model
                        {
                            loginId = 0,
                            status = "Failed"
                        });
                        // string msg = ex.Message;
                    }
                }

            }
            catch (Exception ex)
            {
                lst.Add(new kamLoginList_Model
                {
                    loginId = 0,
                    status = "Failed"
                });
                // _Result = Convert.ToString(ex.Message);


            }
            return await Task.FromResult(lst);
        }


        public async Task<List<kamLoginList_Model>> repo_setKAMMemberlogin(string UserName, string Password, string Conn)
        {
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();

            List<kamLoginList_Model> lst = new List<kamLoginList_Model>();
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetUserRegistrationDetails", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", UserName);
                        cmd.Parameters.AddWithValue("@password", Password);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }




                lst = dt_result.AsEnumerable()
                                .Select(dataRow => new kamLoginList_Model
                                {
                                    loginId = Convert.ToInt32(dataRow.Field<Int32>("Id")),
                                    fullname = Convert.ToString(dataRow.Field<string>("Fullname")),
                                    emailid = Convert.ToString(dataRow.Field<string>("EmailID")),
                                    mobileno = Convert.ToString(dataRow.Field<string>("mobileno"))
                                }).ToList();
            }
            catch (Exception ex)
            {
                lst.Add(new kamLoginList_Model
                {
                    loginId = 0
                });
                // string msg = ex.Message;
            }
            return await Task.FromResult(lst);
        }

    }
}
