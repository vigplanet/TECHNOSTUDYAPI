using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using VigProject_Api.Model;

namespace vigstudent2.Model
{
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

        public string checkdata()
        {
            CommonClassData _classdata = new CommonClassData();

            try
            {
                string strcon = "Data Source=162.215.230.14;Initial Catalog=Dbadmin_techonstudy;User Id = Dbuser_techonstudy; Password = 62E6ecz@8;Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0;";
                DataSet ds = SelectDs_d("exec USP_Get_CommonIdData 1,1,1", strcon);

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

            string serialisedData = Newtonsoft.Json.JsonConvert.SerializeObject(_classdata);
            //string strJson = Newtonsoft.Json.JsonSerializer.Serialize<List<commoncode_masterlist>>(_commoncode_Masterlist_All);
            return serialisedData;
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


        public ItemUtility ItemUtilityFill(string connectionstring)
        {
            ItemUtility _classdata = new ItemUtility();

            try
            {
                DataSet ds = SelectDs_d("exec [USP_APP_GetItemList_Utility] ", connectionstring);

                List<CategoryList> _commoncode_Masterlist_All = new List<CategoryList>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    CategoryList _commoncode_Masterlist = new CategoryList
                    {
                        categoryid = Convert.ToInt32(ds.Tables[0].Rows[i]["categoryid"]),
                        categoryname = Convert.ToString(ds.Tables[0].Rows[i]["categoryname"]),
                        SubCategoryList = GetSubcategory_Master(Convert.ToInt32(ds.Tables[0].Rows[i]["categoryid"]), ds)
                    };
                    _commoncode_Masterlist_All.Add(_commoncode_Masterlist);
                }
                _classdata.CategoryList = _commoncode_Masterlist_All;
                _classdata.status = "Success";
            }
            catch (Exception ex)
            {
                _classdata.status = ex.ToString();
            }

            // string serialisedData = Newtonsoft.Json.JsonConvert.SerializeObject(_classdata);
            // //string strJson = Newtonsoft.Json.JsonSerializer.Serialize<List<commoncode_masterlist>>(_commoncode_Masterlist_All);
            return _classdata;
        }

        private List<SubCategoryList> GetSubcategory_Master(int categoryid, DataSet ds)
        {
            DataTable dt = new DataTable();
            try
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    DataRow[] drdate = ds.Tables[1].Select("categoryid='" + categoryid + "'", "");
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


            List<SubCategoryList> commonId_Master = new List<SubCategoryList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                commonId_Master.Add(new SubCategoryList
                {
                    subcategoryid = Convert.ToInt32(dt.Rows[i]["subcategoryid"]),
                    SubCategoryName = Convert.ToString(dt.Rows[i]["SubCategoryName"]),
                    item_model_list = getItemListData(categoryid, Convert.ToInt32(dt.Rows[i]["subcategoryid"]), ds)
                });
            }
            return commonId_Master;
        }

        private List<item_model_list> getItemListData(int category, int subcategory, DataSet ds)
        {
            DataTable dt = new DataTable();
            try
            {
                if (ds.Tables[2].Rows.Count > 0)
                {
                    DataRow[] drdate = ds.Tables[2].Select("categoryid=" + category + " and subcategoryid=" + subcategory, "");
                    if (drdate.Length > 0)
                        dt = drdate.CopyToDataTable();
                    else
                        dt = ds.Tables[2].Clone();
                }
                else
                    dt = ds.Tables[2].Clone();
            }
            catch (Exception ex)
            { dt = ds.Tables[2].Clone(); }


            List<item_model_list> commonId_Master1 = new List<item_model_list>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                commonId_Master1.Add(new item_model_list
                {
                    productid = Convert.ToInt32(dt.Rows[i]["productid"]),
                    productname = Convert.ToString(dt.Rows[i]["productname"])
                    //,commonId_Master2 = GetcommonId_Master2(CommonCode, commnonid, Convert.ToInt32(dt.Rows[i]["commonid1"]), ds)
                });
            }
            return commonId_Master1;
        }


        public LedgerUtility LedgerUtilityFill(string connectionstring)
        {
            LedgerUtility _classdata = new LedgerUtility();

            try
            {
                DataSet ds = SelectDs_d("exec [USP_APP_GetLedgerList_Utility] ", connectionstring);

                List<HeadList> _commoncode_Masterlist_All = new List<HeadList>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    HeadList _commoncode_Masterlist = new HeadList
                    {
                        HeadId = Convert.ToInt32(ds.Tables[0].Rows[i]["HeadId"]),
                        HeadName = Convert.ToString(ds.Tables[0].Rows[i]["HeadName"]),
                        GroupType = Convert.ToString(ds.Tables[0].Rows[i]["GroupType"]),
                        LedgerList = GetLedger_Master(Convert.ToInt32(ds.Tables[0].Rows[i]["HeadId"]), ds)
                    };
                    _commoncode_Masterlist_All.Add(_commoncode_Masterlist);
                }
                _classdata.HeadList = _commoncode_Masterlist_All;
                _classdata.status = "Success";
            }
            catch (Exception ex)
            {
                _classdata.status = ex.ToString();
            }

            // string serialisedData = Newtonsoft.Json.JsonConvert.SerializeObject(_classdata);
            // //string strJson = Newtonsoft.Json.JsonSerializer.Serialize<List<commoncode_masterlist>>(_commoncode_Masterlist_All);
            return _classdata;
        }

        private List<LedgerList> GetLedger_Master(int HeadId, DataSet ds)
        {
            DataTable dt = new DataTable();
            try
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    DataRow[] drdate = ds.Tables[1].Select("HeadId='" + HeadId + "'", "");
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


            List<LedgerList> commonId_Master = new List<LedgerList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                commonId_Master.Add(new LedgerList
                {
                    Ledgerid = Convert.ToInt32(dt.Rows[i]["Ledgerid"]),
                    LedgerName = Convert.ToString(dt.Rows[i]["LedgerName"])
                });
            }
            return commonId_Master;
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
