using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VigProject_Api
{
    public class AppSettings
    {
        public ConnectionStrings connectionStrings { get; set; }
        public string Secret { get; set; }
    }
    public class ConnectionStrings
    {
        public string DbConn_CastingAPI { get; set; }
        public string DbConn_gymAPI { get; set; }
        public string DbConn_empAPI { get; set; }
        public string DbConn_ExamAPI { get; set; }
        public string DbConn_VideoAPI { get; set; }
    }
}
