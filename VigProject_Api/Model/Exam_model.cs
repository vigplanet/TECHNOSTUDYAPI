using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VigProject_Api.Model
{
    public class Exam_model
    {
    }

    public class Exam_Enc_Inputs
    {
        public string value1 { get; set; }
        public string value2 { get; set; }
    }

    public class Exam_Inputs_login
    {
        public string username { get; set; }
        public string password { get; set; }

        //public int surveyid { get; set; }
        //public int questionid { get; set; }
        //public int answerid { get; set; }
    }
    public class student_input
    {
        public string action { get; set; }
        public int msrno { get; set; }

        public int categoryid { get; set; }
        public int videoid { get; set; }
    }



    public class studentexam_input
    {
        public string action { get; set; }
        public int msrno { get; set; }
        public int surveyid { get; set; }
    }

    public class quesDelete_input
    {
        public string action { get; set; }
        public int msrno { get; set; }
        public int surveyid { get; set; }
        public int questionid { get; set; }
    }
    public class survey_input
    {
        public string action { get; set; }
        public int msrno { get; set; }
        public int surveyid { get; set; }
    }
    public class Student_login_model
    {
        public string status { get; set; }
        public string status_msg { get; set; }
        public string token { get; set; }
        public List<Student_login_model_list> Student_login_model_list { get; set; }
    }
    public class Student_login_model_list
    {
        public int Msrno { get; set; }
        public string MemberName { get; set; }
        public string MemberId { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string status { get; set; }
        public string error_msg { get; set; }
    }


    public class survey_exam_model
    {
        public string status { get; set; }
        public string status_msg { get; set; }
        public List<survey_exam_model_list> survey_exam_model_list { get; set; }
    }
    public class survey_exam_model_list
    {
        public int cnt { get; set; }
        public string SurveyName { get; set; }
        public string Description { get; set; }
        public string filepath { get; set; }
        public int duration { get; set; }
    }


    public class ques_submit_input
    {
        public int msrno { get; set; }
        public int surveyid { get; set; }
        public int questionid { get; set; }
        public int ansid { get; set; }
        public int ishindi { get; set; }
        public int anstype { get; set; }
    }



    public class survey_question_paper
    {
        public string status { get; set; }
        public string status_msg { get; set; }
        public List<survey_list> survey_list { get; set; }


    }

    public class survey_paper
    {
        public string status { get; set; }
        public string status_msg { get; set; }
        public List<survey_question_list> survey_list { get; set; }


    }
    public class survey_list
    {
        public int cnt { get; set; }
        public int surveyid { get; set; }
        public string SurveyName { get; set; }
        public int duration { get; set; }
        public string Description { get; set; }
        public List<survey_question_list> survey_question_list { get; set; }
    }
    public class survey_question_list
    {
        public string status { get; set; }
        public int rowid { get; set; }
        public int questionid { get; set; }
        public int surveyid { get; set; }
        public string question { get; set; }
        public string QuestionType { get; set; }
        public string realans { get; set; }
        public int realansid { get; set; }
        public string imagepath { get; set; }
        public string imagepath2 { get; set; }
        public string Question2 { get; set; }
        public int ishindi { get; set; }
        public int rno { get; set; }

        public int anstype { get; set; }
        public int updateansid { get; set; }
        public List<survey_question_answer_list> survey_question_answer_list { get; set; }
    }
    public class survey_question_answer_list
    {
        public int ansid { get; set; }
        public int SurveyID { get; set; }
        public int QuestionID { get; set; }
        public string Answer { get; set; }
        public string imgpath { get; set; }
    }

    public class survey_exam_result_model
    {
        public string status { get; set; }
        public string status_msg { get; set; }
        public List<survey_exam_result_model_list> survey_exam_result_model_list { get; set; }
    }
    public class survey_exam_result_model_list
    {
        public string ExamStatus { get; set; }
        public string total_attend { get; set; }
        public string total_rightMarks { get; set; }
        public string total_right { get; set; }
        public string total { get; set; }
        public string totalMarks { get; set; }
        public string total_incorectmarks { get; set; }
        public string total_totalObtain { get; set; }

    }

    public class survey_exam_rank_model
    {
        public string status { get; set; }
        public string status_msg { get; set; }
        public List<survey_exam_rank_model_list> survey_exam_rank_model_list { get; set; }
    }
    public class survey_exam_rank_model_list
    {
        public string ExamStatus { get; set; }
        public Int64 SrNo { get; set; }
        public Int64 ActualRank { get; set; }
        public Int32 OutofRank { get; set; }
        public decimal TotalMarks { get; set; }
        public decimal TotalQuestion { get; set; }
        public decimal TotalAttend { get; set; }
        public string SurveyName { get; set; }
        public string MemberName { get; set; }
        public decimal righans { get; set; }
        public decimal Wrong { get; set; }
        public int surveyid { get; set; }

    }


}
