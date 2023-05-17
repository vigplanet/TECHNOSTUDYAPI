using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VigProject_Api.Model;
using VigProject_Api.Utility;

namespace VigProject_Api.Repository
{
    public class Exam_Repository
    {
        public async Task<List<Student_login_model_list>> repo_Student_login(string UserName, string Password, string Conn)
        {
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();

            List<Student_login_model_list> lst = new List<Student_login_model_list>();
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("api_CheckMemberLogin", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MemberId", UserName);
                        cmd.Parameters.AddWithValue("@Password", Password);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }


                lst = dt_result.AsEnumerable()
                                .Select(dataRow => new Student_login_model_list
                                {
                                    Msrno = dataRow.Field<int>("Msrno"),//First is Int32 video for convert this Int64
                                    MemberName = dataRow.Field<string>("MemberName"),
                                    MemberId = dataRow.Field<string>("MemberId"),
                                    Mobile = dataRow.Field<string>("Mobile"),
                                    Email = dataRow.Field<string>("Email")
                                }).ToList();
            }
            catch (Exception ex)
            {
                lst.Add(new Student_login_model_list
                {
                    error_msg = Convert.ToString(ex.Message),
                    status = "0"
                });
                // string msg = ex.Message;
            }
            return await Task.FromResult(lst);
        }
        public async Task<List<survey_exam_model_list>> repo_Student_survey_list(int msrno, string action, string Conn)
        {
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();

            List<survey_exam_model_list> lst = new List<survey_exam_model_list>();
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("api_getSurveyPaid", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@msrno", msrno);
                        cmd.Parameters.AddWithValue("@action", action);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }


                lst = dt_result.AsEnumerable()
                                .Select(dataRow => new survey_exam_model_list
                                {
                                    cnt = dataRow.Field<Int32>("cnt"),
                                    duration = dataRow.Field<Int32>("duration"),
                                    SurveyName = dataRow.Field<string>("SurveyName"),
                                    Description = dataRow.Field<string>("Description"),
                                    filepath = dataRow.Field<string>("filepath")
                                }).ToList();
            }
            catch (Exception ex)
            {
                lst.Add(new survey_exam_model_list
                {
                    SurveyName = ex.ToString()
                });
                // string msg = ex.Message;
            }
            return await Task.FromResult(lst);
        }
        public async Task<List<survey_exam_model_list>> repo_student_exam_details(int msrno, int surveyid, string action, string Conn)
        {
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();

            List<survey_exam_model_list> lst = new List<survey_exam_model_list>();
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("api_getSurveyPaidid", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@msrno", msrno);
                        cmd.Parameters.AddWithValue("@surveyid", surveyid);
                        cmd.Parameters.AddWithValue("@action", action);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }


                lst = dt_result.AsEnumerable()
                                .Select(dataRow => new survey_exam_model_list
                                {
                                    cnt = dataRow.Field<Int32>("cnt"),
                                    duration = dataRow.Field<Int32>("duration"),
                                    SurveyName = dataRow.Field<string>("SurveyName"),
                                    Description = dataRow.Field<string>("Description"),
                                    filepath = dataRow.Field<string>("filepath")
                                }).ToList();
            }
            catch (Exception ex)
            {
                lst.Add(new survey_exam_model_list
                {
                    SurveyName = ex.ToString()
                });
                // string msg = ex.Message;
            }
            return await Task.FromResult(lst);
        }
        public async Task<List<survey_question_list>> repo_survey_question_list(int surveyid, int msrno, string Conn)
        {
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();
            DataTable Exampaidcheck = new DataTable();
            List<survey_question_list> customers = new List<survey_question_list>();
            //List<survey_question_list> lst = new List<survey_question_list>();
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                //using (SqlConnection con = new SqlConnection(conString))
                //{
                //    using (SqlCommand cmd = new SqlCommand("api_getSurveyPaid", con))
                //    {
                //        cmd.Connection = con;
                //        cmd.CommandType = CommandType.StoredProcedure;
                //        cmd.Parameters.AddWithValue("@msrno", msrno);
                //        cmd.Parameters.AddWithValue("@action", action);
                //        con.Open();
                //        sdr = cmd.ExecuteReader();
                //        dt_result = new DataTable();
                //        dt_result.Load(sdr);
                //        con.Close();
                //    }
                //}


                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("api_getSurveyPaidid", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@msrno", msrno);
                        cmd.Parameters.AddWithValue("@surveyid", surveyid);
                        cmd.Parameters.AddWithValue("@action", "viewid");
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        Exampaidcheck = new DataTable();
                        Exampaidcheck.Load(sdr);
                        con.Close();
                    }
                }

                if (Exampaidcheck.Rows.Count > 0)
                {

                    DataTable dt = GetData("select ROW_NUMBER() over (Order by  cnt) rowid,cnt as questionid,surveyid,question,QuestionType,Answer as realans,ansid as realansid,'http://www.sarvodayajeeneet.com/uploads/ex/'+imagepath imagepath,'http://www.sarvodayajeeneet.com/uploads/ex/enthospitallogo.png' as imagepath2,ISNULL(Question2,'')  as  Question2,ishindi,rno from surveyquestion where surveyid=" + surveyid + " order by cnt");
                    DataTable dtansques = GetData(" select cnt as ansid,SurveyID,QuestionID,Answer,imgpath from surveyanswer where surveyid=" + surveyid + "");
                    DataTable dtansdt = GetData("select surveyid, ansid, questionid, ishindi, anstype from bannag_soft_tbl_SurveyAnswerUser where msrno = " + msrno + " and surveyid = " + surveyid);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        int anstype = 0;
                        int updateansid = 0;
                        try
                        {

                            if (dtansdt.Rows.Count > 0)
                            {
                                DataRow[] drdate = dtansdt.Select("questionid=" + Convert.ToInt32(dt.Rows[i]["questionid"]) + "", "");
                                if (drdate.Length > 0)
                                {
                                    anstype = Convert.ToInt32(drdate[0]["anstype"].ToString());
                                    updateansid = Convert.ToInt32(drdate[0]["ansid"].ToString());
                                }
                                else
                                {
                                    anstype = 0;
                                    updateansid = 0;
                                }
                            }
                            else
                            {
                                anstype = 0;
                                updateansid = 0;
                            }
                        }
                        catch
                        { }
                        DataTable dtansnewdata = new DataTable();
                        try
                        {
                            if (dtansques.Rows.Count > 0)
                            {
                                DataRow[] drdate = dtansques.Select("QuestionID=" + Convert.ToInt32(dt.Rows[i]["questionid"]) + "", "");
                                if (drdate.Length > 0)
                                {
                                    dtansnewdata = drdate.CopyToDataTable();
                                }
                                else
                                {
                                    dtansnewdata = dtansques.Clone();
                                }
                            }
                            else
                                dtansnewdata = dtansques.Clone();
                        }
                        catch
                        { dtansnewdata = dtansques.Clone(); }


                        survey_question_list customer = new survey_question_list
                        {
                            rowid = Convert.ToInt32(dt.Rows[i]["rowid"]),
                            questionid = Convert.ToInt32(dt.Rows[i]["questionid"]),
                            surveyid = Convert.ToInt32(dt.Rows[i]["surveyid"]),
                            question = Convert.ToString(dt.Rows[i]["question"]),
                            QuestionType = Convert.ToString(dt.Rows[i]["QuestionType"]),
                            realans = Convert.ToString(dt.Rows[i]["realans"]),
                            realansid = Convert.ToInt32(dt.Rows[i]["realansid"]),
                            imagepath = Convert.ToString(dt.Rows[i]["imagepath"]),
                            imagepath2 = Convert.ToString(dt.Rows[i]["imagepath2"]),
                            Question2 = Convert.ToString(dt.Rows[i]["Question2"]),
                            ishindi = Convert.ToInt32(dt.Rows[i]["ishindi"]),
                            rno = Convert.ToInt32(dt.Rows[i]["rno"]),
                            anstype = Convert.ToInt32(anstype),
                            updateansid = Convert.ToInt32(updateansid),
                            //survey_question_answer_list = GetOrders(Convert.ToString(dt.Rows[i]["questionid"]), surveyid)
                            survey_question_answer_list = GetOrders(Convert.ToString(dt.Rows[i]["questionid"]), surveyid, dtansnewdata)
                        };
                        customers.Add(customer);
                    }
                }
                else
                {
                    customers.Add(new survey_question_list
                    {
                        //error_msg = Convert.ToString(ex.Message),
                        status = "Selected Exam not Alloted to student"
                    });
                }
                //var json = new JavaScriptSerializer().Serialize(customers);

                //lst = dt_result.AsEnumerable()
                //                .Select(dataRow => new survey_exam_model_list
                //                {
                //                    cnt = dataRow.Field<Int32>("cnt"),
                //                    duration = dataRow.Field<Int32>("duration"),
                //                    SurveyName = dataRow.Field<string>("SurveyName"),
                //                    Description = dataRow.Field<string>("Description"),
                //                    filepath = dataRow.Field<string>("filepath")
                //                }).ToList();
            }
            catch (Exception ex)
            {
                customers.Add(new survey_question_list
                {
                    //error_msg = Convert.ToString(ex.Message),
                    status = "SUCCESS"
                });
                // string msg = ex.Message;
            }
            return await Task.FromResult(customers);
        }
        public List<survey_question_answer_list> GetOrders(string customerId, int surveyid)
        {
            List<survey_question_answer_list> orders = new List<survey_question_answer_list>();
            DataTable dt = GetData(string.Format(" select cnt as ansid,SurveyID,QuestionID,Answer,imgpath from surveyanswer where surveyid=" + surveyid + " and QuestionID ='{0}'", customerId));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                orders.Add(new survey_question_answer_list
                {
                    ansid = Convert.ToInt32(dt.Rows[i]["ansid"]),
                    SurveyID = Convert.ToInt32(dt.Rows[i]["SurveyID"]),
                    QuestionID = Convert.ToInt32(dt.Rows[i]["QuestionID"]),
                    Answer = Convert.ToString(dt.Rows[i]["Answer"]),
                    imgpath = Convert.ToString(dt.Rows[i]["imgpath"])
                });
            }
            return orders;
        }

        public List<survey_question_answer_list> GetOrders(string customerId, int surveyid, DataTable dt)
        {
            List<survey_question_answer_list> orders = new List<survey_question_answer_list>();
            // DataTable dt = GetData(string.Format(" select cnt as ansid,SurveyID,QuestionID,Answer,imgpath from surveyanswer where surveyid=" + surveyid + " and QuestionID ='{0}'", customerId));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                orders.Add(new survey_question_answer_list
                {
                    ansid = Convert.ToInt32(dt.Rows[i]["ansid"]),
                    SurveyID = Convert.ToInt32(dt.Rows[i]["SurveyID"]),
                    QuestionID = Convert.ToInt32(dt.Rows[i]["QuestionID"]),
                    Answer = Convert.ToString(dt.Rows[i]["Answer"]),
                    imgpath = Convert.ToString(dt.Rows[i]["imgpath"])
                });
            }
            return orders;
        }
        private DataTable GetData(string query)
        {
            string conString = SqlHelper.GetConnectionString("exam");
            SqlCommand cmd = new SqlCommand(query);
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;

                    }
                }
            }
        }

        public async Task<string> repo_student_survey_exam_start(int msrno, int surveyid, string action, string Conn)
        {
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();

            string strResult = "";
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("api_Startsurveystudent", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@msrno", msrno);
                        cmd.Parameters.AddWithValue("@surveyid", surveyid);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }


                strResult = dt_result.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {

                strResult = ex.ToString();

                // string msg = ex.Message;
            }
            return await Task.FromResult(strResult);
        }

        public async Task<string> repo_student_survey_exam_submit(int msrno, int surveyid, string action, string Conn)
        {
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();

            string strResult = "";
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("api_SubmitExamFull", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@msrno", msrno);
                        cmd.Parameters.AddWithValue("@surveyid", surveyid);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }


                strResult = dt_result.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {

                strResult = ex.ToString();

                // string msg = ex.Message;
            }
            return await Task.FromResult(strResult);
        }

        //public async Task<List<survey_exam_result_model_list>> repo_student_result_declare(int msrno, int surveyid, string action, string Conn)
        //{

        //    List<survey_exam_result_model_list> lst = new List<survey_exam_result_model_list>();
        //    SqlDataReader sdr;
        //    DataTable dt_result = new DataTable();

        //    string strResult = "";
        //    try
        //    {
        //        string conString = SqlHelper.GetConnectionString(Conn);
        //        using (SqlConnection con = new SqlConnection(conString))
        //        {
        //            using (SqlCommand cmd = new SqlCommand("Get_Result_Ques", con))
        //            {
        //                cmd.Connection = con;
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddWithValue("@Msrno", msrno);
        //                cmd.Parameters.AddWithValue("@surveyid", surveyid);
        //                con.Open();
        //                sdr = cmd.ExecuteReader();
        //                dt_result = new DataTable();
        //                dt_result.Load(sdr);
        //                con.Close();
        //            }
        //        }


        //        lst = dt_result.AsEnumerable()
        //                       .Select(dataRow => new survey_exam_result_model_list
        //                       {
        //                           ExamStatus="Result Declared",
        //                           total_attend = dataRow.Field<string>("TotalAttendQues"),
        //                           total_rightMarks = dataRow.Field<string>("TotalRightMarks"),
        //                           total_right = dataRow.Field<string>("RightQues"),
        //                           total = dataRow.Field<string>("TotalQuestions"),
        //                           totalMarks = dataRow.Field<string>("TotalExamMarks"),
        //                           total_incorectmarks = dataRow.Field<string>("WrongMarks"),
        //                           total_totalObtain = dataRow.Field<string>("ObtainMarks")

        //                       }).ToList();





        //        //  strResult = dt_result.Rows[0][0].ToString();
        //    }
        //    catch (Exception ex)
        //    {

        //        lst.Add(new survey_exam_result_model_list
        //        {
        //            ExamStatus = ex.ToString()
        //        });

        //        // string msg = ex.Message;
        //    }
        //    return await Task.FromResult(lst);
        //}


        public async Task<List<survey_exam_rank_model_list>> repo_student_result_declare(int msrno, int surveyid, string action, string Conn)
        {

            List<survey_exam_rank_model_list> lst = new List<survey_exam_rank_model_list>();
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();

            string strResult = "";
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetRank_single", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Msrno", msrno);
                        cmd.Parameters.AddWithValue("@surveyid", surveyid);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }


                lst = dt_result.AsEnumerable()
                               .Select(dataRow => new survey_exam_rank_model_list
                               {
                                   ExamStatus = "Result Declared",
                                   SrNo = dataRow.Field<Int64>("SrNo"),
                                   ActualRank = dataRow.Field<Int64>("ActualRank"),
                                   OutofRank = dataRow.Field<Int32>("OutofRank"),
                                   TotalMarks = dataRow.Field<decimal>("TotalMarks"),
                                   TotalQuestion = dataRow.Field<decimal>("TotalQuestion"),
                                   TotalAttend = dataRow.Field<decimal>("TotalAttend"),
                                   SurveyName = dataRow.Field<string>("SurveyName"),
                                   MemberName = dataRow.Field<string>("MemberName"),
                                   righans = dataRow.Field<decimal>("righans"),
                                   Wrong = dataRow.Field<decimal>("Wrong")

                               }).ToList();





                //  strResult = dt_result.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {

                lst.Add(new survey_exam_rank_model_list
                {
                    ExamStatus = ex.ToString()
                });

                // string msg = ex.Message;
            }
            return await Task.FromResult(lst);
        }


        public async Task<List<survey_exam_rank_model_list>> repo_student_toppersList(int msrno, int surveyid, string action, string Conn)
        {

            List<survey_exam_rank_model_list> lst = new List<survey_exam_rank_model_list>();
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();

            string strResult = "";
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetRank", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Msrno", msrno);
                        cmd.Parameters.AddWithValue("@surveyid", surveyid);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }


                lst = dt_result.AsEnumerable()
                               .Select(dataRow => new survey_exam_rank_model_list
                               {
                                   ExamStatus = "Ranking",
                                   SrNo = dataRow.Field<Int64>("SrNo"),
                                   ActualRank = dataRow.Field<Int64>("ActualRank"),
                                   OutofRank = dataRow.Field<Int32>("OutofRank"),
                                   TotalMarks = dataRow.Field<decimal>("TotalMarks"),
                                   TotalQuestion = dataRow.Field<decimal>("TotalQuestion"),
                                   TotalAttend = dataRow.Field<decimal>("TotalAttend"),
                                   SurveyName = dataRow.Field<string>("SurveyName"),
                                   MemberName = dataRow.Field<string>("MemberName"),
                                   righans = dataRow.Field<decimal>("righans"),
                                   Wrong = dataRow.Field<decimal>("Wrong")

                               }).ToList();





                //  strResult = dt_result.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {

                lst.Add(new survey_exam_rank_model_list
                {
                    ExamStatus = ex.ToString()
                });

                // string msg = ex.Message;
            }
            return await Task.FromResult(lst);
        }


        public async Task<List<survey_exam_rank_model_list>> repo_getStudentExamList(int msrno,  string Conn)
        {

            List<survey_exam_rank_model_list> lst = new List<survey_exam_rank_model_list>();
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();

            string strResult = "";
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetRank_List", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Msrno", msrno);
                        cmd.Parameters.AddWithValue("@surveyid", 0);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }


                lst = dt_result.AsEnumerable()
                               .Select(dataRow => new survey_exam_rank_model_list
                               {
                                   ExamStatus = "Ranking",
                                   SrNo = dataRow.Field<Int64>("SrNo"),
                                   ActualRank = dataRow.Field<Int64>("ActualRank"),
                                   OutofRank = dataRow.Field<Int32>("OutofRank"),
                                   TotalMarks = dataRow.Field<decimal>("TotalMarks"),
                                   TotalQuestion = dataRow.Field<decimal>("TotalQuestion"),
                                   TotalAttend = dataRow.Field<decimal>("TotalAttend"),
                                   SurveyName = dataRow.Field<string>("SurveyName"),
                                   MemberName = dataRow.Field<string>("MemberName"),
                                   righans = dataRow.Field<decimal>("righans"),
                                   Wrong = dataRow.Field<decimal>("Wrong"),
                                   surveyid = dataRow.Field<int>("Surveyid")
                               }).ToList();





                //  strResult = dt_result.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {

                lst.Add(new survey_exam_rank_model_list
                {
                    ExamStatus = ex.ToString()
                });

                // string msg = ex.Message;
            }
            return await Task.FromResult(lst);
        }

        public async Task<int> repo_setQuesAnsSave(int msrno, int surveyid, int questionid, int ansid, int ishindi, int anstype, string action, string Conn)
        {
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();

            int strResult = 0;
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("api_Set_SaveQueAnsnw", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@msrno", msrno);
                        cmd.Parameters.AddWithValue("@surveyid", surveyid);
                        cmd.Parameters.AddWithValue("@questionid", questionid);
                        cmd.Parameters.AddWithValue("@ansid", ansid);
                        cmd.Parameters.AddWithValue("@ipaddress", "");
                        cmd.Parameters.AddWithValue("@ishindi", ishindi);
                        cmd.Parameters.AddWithValue("@anstype", anstype);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }

                strResult = Convert.ToInt32(dt_result.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {

                strResult = -1;

                // string msg = ex.Message;
            }
            return await Task.FromResult(strResult);
        }

        public async Task<int> repo_setQuesAnsDelete(int msrno, int surveyid, int questionid, string action, string Conn)
        {
            SqlDataReader sdr;
            DataTable dt_result = new DataTable();

            int strResult = 0;
            try
            {
                string conString = SqlHelper.GetConnectionString(Conn);
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("api_Set_DeleteQueAnsnw", con))
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@msrno", msrno);
                        cmd.Parameters.AddWithValue("@surveyid", surveyid);
                        cmd.Parameters.AddWithValue("@questionid", questionid);
                        con.Open();
                        sdr = cmd.ExecuteReader();
                        dt_result = new DataTable();
                        dt_result.Load(sdr);
                        con.Close();
                    }
                }

                strResult = Convert.ToInt32(dt_result.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {

                strResult = -1;

                // string msg = ex.Message;
            }
            return await Task.FromResult(strResult);
        }

        public async Task<string> GenerateStudentToken(Student_login_model identityRequest)
        {

            // Encrypt the ticket
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("VIPINLh5n_qbdlNUQrqdHPgp");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, "Student"),
                    new Claim(ClaimTypes.NameIdentifier, identityRequest.Student_login_model_list.FirstOrDefault().MemberName.ToString()),
                    new Claim("Msrno", identityRequest.Student_login_model_list.FirstOrDefault().Msrno.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
