using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using VigProject_Api.Utility;

namespace vigstudent.Model
{
    public class CommonData_Parameter
    {
        public int @OrgId { get; set; }
        public int @BranchId { get; set; }
        public int @UserLogInId { get; set; }
    }
    public class CommonClassData
    {
        public string Status { get; set; }
        public List<commoncode_masterlist> commoncode_masterlist { get; set; }
    }

    public class commoncode_masterlist
    {
        public int CommonCode { get; set; }
        public string CommonCodeName { get; set; }
        public List<commonId_Master> commonId_Master { get; set; }


    }
    public class commonId_Master
    {
        public int CommonId { get; set; }
        public string CommonDesc { get; set; }
        public List<commonId_Master1> commonId_Master1 { get; set; }
    }

    public class commonId_Master1
    {
        public int Commonid1 { get; set; }
        public string CommonDesc1 { get; set; }
        public List<commonId_Master2> commonId_Master2 { get; set; }
    }

    public class commonId_Master2
    {
        public int Commonid2 { get; set; }
        public string CommonDesc2 { get; set; }
    }

    public class FunctionAll
    {

        public async Task<CommonClassData> checkdata(CommonData_Parameter _parameter)        
        {
            CommonClassData _classdata = new CommonClassData();
            try
            {
                //string strcon = "Data Source=162.215.230.14;Initial Catalog=Dbadmin_techonstudy;User Id = Dbuser_techonstudy; Password = 62E6ecz@8;Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0;";
                string connString = SqlHelper.GetConnectionString("TechOnStudy");
                DataSet ds = SelectDs_d("exec USP_Get_CommonIdData "+ _parameter.OrgId + ","+ _parameter.BranchId + "," + _parameter.UserLogInId + "", connString);

                
                List<commoncode_masterlist> _commoncode_Masterlist_All = new List<commoncode_masterlist>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    commoncode_masterlist _commoncode_Masterlist = new commoncode_masterlist
                    {
                        CommonCode = Convert.ToInt32(ds.Tables[0].Rows[i]["CommonCode"]),
                        CommonCodeName = Convert.ToString(ds.Tables[0].Rows[i]["CommonName"]),
                        commonId_Master = GetcommonId_Master(Convert.ToInt32(ds.Tables[0].Rows[i]["CommonCode"]), ds)
                    };
                    _commoncode_Masterlist_All.Add(_commoncode_Masterlist);
                }
                _classdata.commoncode_masterlist = _commoncode_Masterlist_All;
                _classdata.Status = "Success";
            }
            catch (Exception)
            {
                _classdata.Status = "Failed";
            }

            //string serialisedData = Newtonsoft.Json.JsonConvert.SerializeObject(_classdata);
            //string strJson = Newtonsoft.Json.JsonSerializer.Serialize<List<commoncode_masterlist>>(_commoncode_Masterlist_All);
          
            return await Task.FromResult(_classdata);

        }


        private List<commonId_Master> GetcommonId_Master(int CommonCode, DataSet ds)
        {
            DataTable dt = new DataTable();
            try
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    DataRow[] drdate = ds.Tables[1].Select("commoncode='" + CommonCode + "'", "");
                    if (drdate.Length > 0)
                        dt = drdate.CopyToDataTable();
                    else
                        dt = ds.Tables[1].Clone();
                }
                else
                    dt = ds.Tables[1].Clone();
            }
            catch
            { dt = ds.Tables[1].Clone(); }


            List<commonId_Master> commonId_Master = new List<commonId_Master>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                commonId_Master.Add(new commonId_Master
                {
                    CommonId = Convert.ToInt32(dt.Rows[i]["commonid"]),
                    CommonDesc = Convert.ToString(dt.Rows[i]["commonDesc"]),
                    commonId_Master1 = GetcommonId_Master1(CommonCode, Convert.ToInt32(dt.Rows[i]["commonid"]), ds)
                });
            }
            return commonId_Master;
        }

        private List<commonId_Master1> GetcommonId_Master1(int CommonCode, int commnonid, DataSet ds)
        {
            DataTable dt = new DataTable();
            try
            {
                if (ds.Tables[2].Rows.Count > 0)
                {
                    DataRow[] drdate = ds.Tables[2].Select("commoncode='" + CommonCode + "' and commonid=" + commnonid, "");
                    if (drdate.Length > 0)
                        dt = drdate.CopyToDataTable();
                    else
                        dt = ds.Tables[2].Clone();
                }
                else
                    dt = ds.Tables[2].Clone();
            }
            catch
            { dt = ds.Tables[2].Clone(); }


            List<commonId_Master1> commonId_Master1 = new List<commonId_Master1>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                commonId_Master1.Add(new commonId_Master1
                {
                    Commonid1 = Convert.ToInt32(dt.Rows[i]["commonid1"]),
                    CommonDesc1 = Convert.ToString(dt.Rows[i]["commonDesc1"]),
                    commonId_Master2 = GetcommonId_Master2(CommonCode, commnonid, Convert.ToInt32(dt.Rows[i]["commonid1"]), ds)
                });
            }
            return commonId_Master1;
        }

        private List<commonId_Master2> GetcommonId_Master2(int commonCode, int commnonid, int commonid1, DataSet ds)
        {
            DataTable dt = new DataTable();
            try
            {
                if (ds.Tables[3].Rows.Count > 0)
                {
                    DataRow[] drdate = ds.Tables[3].Select("commonid='" + commnonid + "' and commonid1=" + commonid1, "");
                    if (drdate.Length > 0)
                        dt = drdate.CopyToDataTable();
                    else
                        dt = ds.Tables[2].Clone();
                }
                else
                    dt = ds.Tables[2].Clone();
            }
            catch
            { dt = ds.Tables[2].Clone(); }


            List<commonId_Master2> _commonId_Master2 = new List<commonId_Master2>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                _commonId_Master2.Add(new commonId_Master2
                {
                    Commonid2 = Convert.ToInt32(dt.Rows[i]["commonId2"]),
                    CommonDesc2 = Convert.ToString(dt.Rows[i]["commonDesc2"])
                });
            }
            return _commonId_Master2;
        }

        public DataSet SelectDs_d(string str, string connection)
        {

            DataSet ds = new DataSet();
            try
            {
                SqlConnection con = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter adpt = new SqlDataAdapter();
                ds.Clear();
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.ConnectionString = connection;
                con.Open();
                cmd.CommandText = str;
                cmd.CommandTimeout = 300;
                cmd.Connection = con;
                adpt.SelectCommand = cmd;
                adpt.Fill(ds);
                con.Close();
                con.Dispose();
                cmd.Dispose();
            }
            catch
            { }
            return ds;
        }

    }

}
