using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VigProject_Api.Model
{
    public class video_Model
    {
    }

    #region Student Login
    public class Student_video_login_model
    {
        public string status { get; set; }
        public List<Student_video_login_model_list> Student_login_model_list { get; set; }
    }
    public class Student_video_login_model_list
    {
        public Int64 Msrno { get; set; }
        public string MemberName { get; set; }
        public string MemberId { get; set; }

        public string error_msg { get; set; }
    }
    #endregion

    #region Video Category
    public class Student_video_category_model
    {
        public string status { get; set; }
        public List<Student_video_category_model_list> Student_category_model_list { get; set; }
    }
    public class Student_video_category_model_list
    {
        public Int64 categoryid { get; set; }
        public string categoryname { get; set; }
        public string Description { get; set; }
        public DateTime dateon { get; set; }
        public string error_msg { get; set; }
    }
    #endregion

    #region Video List
    public class Student_video_model
    {
        public string status { get; set; }
        public List<Student_video_model_list> Student_video_model_list { get; set; }
    }
    public class Student_video_model_list
    {
        public Int64 videoid { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
        public DateTime DateOn { get; set; }
        public string imagepath { get; set; }
        //public string FilePath { get; set; }
        //public string PDF_filePath { get; set; }
        //public string PDF_filePath1 { get; set; }
        //public string PDF_filePath2 { get; set; }
        //public string PDF_filePath3 { get; set; }
        //public string PDF_filePath4 { get; set; }
        //public string yotubecode { get; set; }
        //public string kalturacode { get; set; }
        //public string vidyardcode { get; set; }
        //public string vimeo { get; set; }
        public string videotype { get; set; }
        public string error_msg { get; set; }
    }
    #endregion

    #region Video List
    public class Student_video_model_play
    {
        public string status { get; set; }
        public List<Student_video_model_playlist> Student_video_model_playlist { get; set; }
    }
    public class Student_video_model_playlist
    {
        public Int64 videoid { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
        public DateTime DateOn { get; set; }
        public string imagepath { get; set; }
        public string FilePath { get; set; }
        public string PDF_filePath { get; set; }
        public string PDF_filePath1 { get; set; }
        public string PDF_filePath2 { get; set; }
        public string PDF_filePath3 { get; set; }
        public string PDF_filePath4 { get; set; }
        public string yotubecode { get; set; }
        public string kalturacode { get; set; }
        public string vidyardcode { get; set; }
        public string vimeo { get; set; }
        public string videotype { get; set; }
        public string error_msg { get; set; }
    }
    #endregion
}
