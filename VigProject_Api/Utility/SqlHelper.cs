using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VigProject_Api.Utility
{
    public class SqlHelper
    {
        public static string GetConnectionString(string con)
        {
            string strConnection = "";
            if (con == "Casting")
            {
                strConnection = Startup.ConnectionString_CastingAPI;
            }
            else if (con == "gym")
            {
                strConnection = Startup.ConnectionString_gymAPI;
            }
            else if (con == "emp")
            {
                strConnection = Startup.ConnectionString_empAPI;
            }
            else if (con == "exam")
            {
                strConnection = Startup.ConnectionString_ExamAPI;
            }
            else if (con == "video")
            {
                strConnection = Startup.ConnectionString_VideoAPI;
            }
            else if (con == "kamemp")
            {
                strConnection = Startup.ConnectionString_kamemp;
            }
            else if (con == "store")
            {
                strConnection = Startup.ConnectionString_Store;
            }
            else if (con == "payroll")
            {
                strConnection = Startup.ConnectionString_Payroll;
            }
            else if (con == "TechOnStudy")
            {
                strConnection = Startup.ConnectionString_TechOnStudy;
            }
            return strConnection;
        }
    }
}
