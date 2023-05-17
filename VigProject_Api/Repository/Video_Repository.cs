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
    public class Video_Repository
    {
        public async Task<List<Student_video_login_model_list>> repo_Student_login(string UserName, string Password, string Conn)
        {
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();

            List<Student_video_login_model_list> lst = new List<Student_video_login_model_list>();
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("bannag_soft_prc_CheckMemberLogin2", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MemberId", UserName);
                        cmd.Parameters.AddWithValue("@Password", Password);
                        cmd.Parameters.AddWithValue("@Macaddress", UserName);
                        cmd.Parameters.AddWithValue("@ipaddress", Password);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }


                lst = dt_result.AsEnumerable()
                                .Select(dataRow => new Student_video_login_model_list
                                {
                                    Msrno = dataRow.Field<Int64>("Msrno"),
                                    MemberName = dataRow.Field<string>("MemberName"),
                                    MemberId = dataRow.Field<string>("MemberId"),
                                }).ToList();
            }
            catch (Exception ex)
            {
                lst.Add(new Student_video_login_model_list
                {
                    error_msg = Convert.ToString(ex.Message)
                });
                // string msg = ex.Message;
            }
            return await Task.FromResult(lst);
        }

        public async Task<List<Student_video_category_model_list>> repo_Student_category(Int64 msrno, string Conn)
        {
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();

            List<Student_video_category_model_list> lst = new List<Student_video_category_model_list>();
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_Set_videocategory", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@msrno", msrno);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }


                //lst = new List<Student_video_category_model_list>(ff.ReadAsync<Student_video_category_model_list>());

                lst = dt_result.DataTableToList<Student_video_category_model_list>();

                //lst = dt_result.AsEnumerable()
                //                        .Select(dataRow => new Student_video_category_model_list
                //                        {
                //                            categoryid = dataRow.Field<Int32>("categoryid"),
                //                            categoryname = dataRow.Field<string>("categoryname"),
                //                            Description = dataRow.Field<string>("Description"),
                //                            dateon = dataRow.Field<DateTime>("dateon"),
                //                        }).ToList();
            }
            catch (Exception ex)
            {
                lst.Add(new Student_video_category_model_list
                {
                    error_msg = Convert.ToString(ex.Message)
                });
                // string msg = ex.Message;
            }
            return await Task.FromResult(lst);
        }

        public async Task<List<Student_video_model_list>> repo_Student_videolist(Int64 msrno,int categoryid, string Conn)
        {
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();

            List<Student_video_model_list> lst = new List<Student_video_model_list>();
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_Set_videolist", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@msrno", msrno);
                        cmd.Parameters.AddWithValue("@categoryid", categoryid);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }
                lst = dt_result.DataTableToList<Student_video_model_list>();
                //lst = dt_result.AsEnumerable()
                //                        .Select(dataRow => new Student_video_model_list
                //                        {
                //                            videoid = dataRow.Field<Int64>("cnt"),
                //                            title = dataRow.Field<string>("Name"),
                //                            Description = dataRow.Field<string>("Description"),
                //                            DateOn = dataRow.Field<DateTime>("DateOn"),
                //                            imagepath = dataRow.Field<string>("imagepath"),
                //                            //FilePath = dataRow.Field<string>("FilePath"),
                //                            //PDF_filePath = dataRow.Field<string>("PDF_filePath"),
                //                            //PDF_filePath1 = dataRow.Field<string>("PDF_filePath1"),
                //                            //PDF_filePath2 = dataRow.Field<string>("PDF_filePath2"),
                //                            //PDF_filePath3 = dataRow.Field<string>("PDF_filePath3"),
                //                            //PDF_filePath4 = dataRow.Field<string>("PDF_filePath4"),
                //                            //yotubecode = dataRow.Field<string>("yotubecode"),
                //                            //kalturacode = dataRow.Field<string>("kalturacode"),
                //                            //vidyardcode = dataRow.Field<string>("vidyardcode"),
                //                            //vimeo = dataRow.Field<string>("vimeo"),
                //                            videotype = dataRow.Field<string>("videotype")
                //                        }).ToList();
            }
            catch (Exception ex)
            {
                lst.Add(new Student_video_model_list
                {
                    error_msg = Convert.ToString(ex.Message)
                });
                // string msg = ex.Message;
            }
            return await Task.FromResult(lst);
        }

        public async Task<List<Student_video_model_playlist>> repo_Student_videoStart(Int64 msrno, int videoid, string Conn)
        {
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();

            List<Student_video_model_playlist> lst = new List<Student_video_model_playlist>();
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_Set_videostart", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@msrno", msrno);
                        cmd.Parameters.AddWithValue("@videoid", videoid);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }

                lst = dt_result.AsEnumerable()
                                        .Select(dataRow => new Student_video_model_playlist
                                        {
                                            videoid = dataRow.Field<Int64>("cnt"),
                                            title = dataRow.Field<string>("Name"),
                                            Description = dataRow.Field<string>("Description"),
                                            DateOn = dataRow.Field<DateTime>("DateOn"),
                                            imagepath = dataRow.Field<string>("imagepath"),
                                            FilePath = dataRow.Field<string>("FilePath"),
                                            PDF_filePath = dataRow.Field<string>("PDF_filePath"),
                                            PDF_filePath1 = dataRow.Field<string>("PDF_filePath1"),
                                            PDF_filePath2 = dataRow.Field<string>("PDF_filePath2"),
                                            PDF_filePath3 = dataRow.Field<string>("PDF_filePath3"),
                                            PDF_filePath4 = dataRow.Field<string>("PDF_filePath4"),
                                            yotubecode = dataRow.Field<string>("yotubecode"),
                                            kalturacode = dataRow.Field<string>("kalturacode"),
                                            vidyardcode = dataRow.Field<string>("vidyardcode"),
                                            vimeo = dataRow.Field<string>("vimeo"),
                                            videotype = dataRow.Field<string>("videotype")
                                        }).ToList();
            }
            catch (Exception ex)
            {
                lst.Add(new Student_video_model_playlist
                {
                    error_msg = Convert.ToString(ex.Message)
                });
                // string msg = ex.Message;
            }
            return await Task.FromResult(lst);
        }
    }
}
