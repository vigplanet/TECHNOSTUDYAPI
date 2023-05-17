using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.UI.WebControls;
using System.IO;
//using System.Web.UI;
using System.Data;
using System.Net;
using System.Data.SqlClient;
using System.Collections;
using System.Globalization;
using Microsoft.AspNetCore.Http;

namespace DentVideo
{
    public class BusinessLogicLayer : DataAccessLayer
    {
        
        public enum Method
        {
            GET,
            POST
        }
        
        public string GenerateCode(int len)
        {

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, len)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result.ToUpper();
        }

        public string[] GetDistinctValues(string[] array)
        {
            System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
            for (int i = 0; i <= array.Length - 1; i++)
            {
                if (list.Contains(array[i]))
                {
                    continue;
                }
                list.Add(array[i]);
            }
            return list.ToArray();
        }


        //public string CreateMenu()
        //{
        //    string menu = string.Empty;
        //    DataTable dt = null;
        //    string a = ctx.Session["menustr"].ToString();
        //    string mstr = ctx.Session["menustr"].ToString().Substring(0, ctx.Session["menustr"].ToString().Length - 1);
        //    menu = "<table cellspacing='0' cellpadding='0' border='0'><tr> <td><div class='topmainmenu' id='ddtopmenubar'><ul id='main_menu'>";
        //    string str = "select Row_number() over(order by sno) rno,Sno,MenuName,isnull(Url,'') Url,ParentMenuid from DynamicMenu where Active=1 and sno in (" + mstr + ")";
        //    dt = ExecDataTable(str);
        //    string Childstr = "";
        //    DataRow[] drow = dt.Select("ParentMenuid=0");
        //    int K = 1;
        //    for (int i = 0; i <= drow.Length - 1; i++)
        //    {
        //        DataRow[] childrow = dt.Select("Parentmenuid=" + drow[i]["Sno"]);
        //        if (childrow.Length > 0)
        //        {
        //            menu = menu + string.Format("<li><a href='{0}' rel='ddsubmenu{1}'>{2}</a></li>", drow[i]["Url"], K, drow[i]["MenuName"]);
        //        }
        //        else
        //        {
        //            menu = menu + string.Format("<li><a href='{0}' >{1}</a></li>", drow[i]["Url"], drow[i]["MenuName"]);
        //        }
        //        for (int j = 0; j <= childrow.Length - 1; j++)
        //        {
        //            if (j == 0)
        //            {
        //                Childstr = Childstr + "<ul visible='false' class='ddsubmenustyle' id='ddsubmenu" + (K).ToString() + "'><li><a href='" + childrow[j]["Url"] + "'>" + childrow[j]["MenuName"] + "</a>" + GetStr(dt.Select("Parentmenuid=" + childrow[j]["Sno"])) + "</li>";
        //                K = K + 1;
        //            }
        //            else
        //            {
        //                Childstr = Childstr + "<li><a href='" + childrow[j]["Url"] + "'>" + childrow[j]["MenuName"] + "</a>" + GetStr(dt.Select("Parentmenuid=" + childrow[j]["Sno"])) + "</li>";
        //            }
        //            if (j == childrow.Length - 1)
        //            {
        //                Childstr = Childstr + "</ul>";
        //            }
        //        }
        //    }
        //    menu = menu + "</ul></div><script type='text/javascript'>ddlevelsmenu.setup('ddtopmenubar', 'topbar') //ddlevelsmenu.setup('mainmenuid', 'topbar|sidebar')</script>";
        //    Childstr = Childstr + "</td></tr></table>";

        //    return menu + Childstr;

        //}

        public string GetStr(DataRow[] mrow)
        {
            string str = "<ul>";
            for (int i = 0; i <= mrow.Length - 1; i++)
            {
                str = str + "<li><a href='" + mrow[i]["url"] + "'>" + mrow[i]["menuName"] + "</a></li>";
            }
            if (str == "<ul>")
            {
                str = "";
            }
            else
            {
                str = str + "</ul>";
            }
            return str;
        }

        //public bool IsValidForPage()
        //{
        //    string pagename = GetCurrentPageName();
        //    string pageid = ExecScalar("Select sno from  DynamicMenu where pagename=@PageName", "@PageName", pagename).ToString();
        //    pageid = "," + pageid + ",";
        //    string mstr = "," + ctx.Session["menustr"].ToString();
        //    if (mstr.Contains(pageid))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        protected bool CheckDate(string date)
        {
            bool chechdate = true;
            try
            {
                DateTime dt = DateTime.Parse(date);
                //return true;
            }
            catch
            {
                chechdate = false;
            }
            return chechdate;
        }



        protected bool CheckDate1(String date)
        {
            DateTime Temp;
            if (DateTime.TryParse(date, out Temp) == true)
                return true;
            else
                return false;
        }

        //bool IsDate(string input)
        //{
        //    DateTime temp;
        //   // return DateTime.TryParse(input, CultureInfo.CurrentCulture, DateTimeStyles.NotCurrentDateDefault, out temp) &&
        //           temp.Hour == 0 &&
        //           temp.Minute == 0 &&
        //           temp.Second == 0 &&
        //           temp.Millisecond == 0 &&
        //           temp > DateTime.MinValue;
        //}


        //public string GetCurrentPageName()
        //{
        //    string sPath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        //    System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
        //    string sRet = oInfo.Name;
        //    return sRet;
        //}


        //public void CreatePaging(int intTotalRecords, int intTotalPages, int RecordsPerPage, int CurrentPage, Label TotalMessages, Label PagingLabel, Label RecordsCount)
        //{
        //    if (intTotalRecords % RecordsPerPage == 0)
        //    {
        //        intTotalPages = Convert.ToInt32(intTotalRecords / RecordsPerPage);
        //    }
        //    else
        //    {
        //        intTotalPages = Convert.ToInt32(intTotalRecords / RecordsPerPage + 1);
        //    }
        //    TotalMessages.Text = "Page <b>" + CurrentPage + "</b> of <b>" + intTotalPages + "</b>";
        //    RecordsCount.Text = "<b>" + intTotalRecords + "</b> Records";
        //    int i = 0;
        //    string NavigationText = "";
        //    if (CurrentPage > 1)
        //    {
        //        NavigationText += "<a href=" + HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"] + "?Page=" + (CurrentPage - 1) + "><<</a> ";
        //    }
        //    for (i = 1; i <= intTotalPages; i++)
        //    {
        //        if (CurrentPage == i)
        //        {
        //            NavigationText += "<b>" + i + "</b>    ";
        //        }
        //        else
        //        {
        //            NavigationText += "<a href=" + HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"] + "?Page=" + i + ">" + i + "</a> ";
        //        }
        //    }
        //    if (CurrentPage < intTotalPages)
        //    {
        //        NavigationText += "<a href=" + HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"] + "?Page=" + CurrentPage + 1 + ">>></a> ";
        //    }
        //    PagingLabel.Text = NavigationText;
        //}

        //public void ShowNoResultFound(DataTable source, GridView gv)
        //{
        //    DataTable dt = source.Clone();
        //    foreach (DataColumn c in dt.Columns)
        //    {
        //        c.AllowDBNull = true;
        //    }
        //    dt.Rows.Add(dt.NewRow());
        //    // // create a new blank row to the DataTable
        //    //// Bind the DataTable which contain a blank row to the GridView
        //    gv.DataSource = dt;
        //    gv.DataBind();
        //    //// Get the total number of columns in the GridView to know what the Column Span should be
        //    int columnsCount = 0;
        //    if (gv.Columns.Count == 0)
        //    {
        //        columnsCount = source.Columns.Count;
        //    }
        //    else
        //    {
        //        columnsCount = gv.Columns.Count;
        //    }

        //    gv.Rows[0].Cells.Clear();
        //    //// clear all the cells in the row
        //    gv.Rows[0].Cells.Add(new TableCell());
        //    // //add a new blank cell
        //    gv.Rows[0].Cells[0].ColumnSpan = columnsCount;
        //    // //set the column span to the new added cell

        //    // //You can set the styles here
        //    gv.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        //    //;
        //    gv.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        //    //
        //    gv.Rows[0].Cells[0].Font.Bold = true;
        //    //
        //    // //set No Results found to the new added cell
        //    gv.Rows[0].Cells[0].Text = "NO RESULT FOUND!";
        //    //
        //}


        public string GeneratePassword(int length, int numberOfNonAlphanumericCharacters)
        {
            //Make sure length and numberOfNonAlphanumericCharacters are valid....
            if (((length < 1) || (length > 128)))
            {
                throw new ArgumentException("Membership_password_length_incorrect");
            }

            if (((numberOfNonAlphanumericCharacters > length) || (numberOfNonAlphanumericCharacters < 0)))
            {
                throw new ArgumentException("Membership_min_required_non_alphanumeric_characters_incorrect");
            }

            while (true)
            {
                int i = 0;
                int nonANcount = 0;
                byte[] buffer1 = new byte[length];

                //chPassword contains the password's characters as it's built up
                char[] chPassword = new char[length];

                //chPunctionations contains the list of legal non-alphanumeric characters
                char[] chPunctuations = "!@@$%^^*()_-+=[{]};:>|./?".ToCharArray();

                //Get a cryptographically strong series of bytes
                System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
                rng.GetBytes(buffer1);

                for (i = 0; i <= length - 1; i++)
                {
                    //Convert each byte into its representative character
                    int rndChr = (buffer1[i] % 87);
                    if ((rndChr < 10))
                    {
                        chPassword[i] = Convert.ToChar(Convert.ToUInt16(48 + rndChr));
                    }
                    else
                    {
                        if ((rndChr < 36))
                        {
                            chPassword[i] = Convert.ToChar(Convert.ToUInt16((65 + rndChr) - 10));
                        }
                        else
                        {
                            if ((rndChr < 62))
                            {
                                chPassword[i] = Convert.ToChar(Convert.ToUInt16((97 + rndChr) - 36));
                            }
                            else
                            {
                                chPassword[i] = chPunctuations[rndChr - 62];
                                nonANcount += 1;
                            }
                        }
                    }
                }

                if (nonANcount < numberOfNonAlphanumericCharacters)
                {
                    Random rndNumber = new Random();
                    for (i = 0; i <= (numberOfNonAlphanumericCharacters - nonANcount) - 1; i++)
                    {
                        int passwordPos = 0;
                        do
                        {
                            passwordPos = rndNumber.Next(0, length);
                        } while (!char.IsLetterOrDigit(chPassword[passwordPos]));
                        chPassword[passwordPos] = chPunctuations[rndNumber.Next(0, chPunctuations.Length)];
                    }
                }

                return new string(chPassword);
            }
        }

        private SqlParameter PrepareCommand(string ParamName, object ParamValue, SqlDbType ParamType, Int16 ParamSize, ParameterDirection ParamDir)
        {
            SqlParameter Param = new SqlParameter();
            Param.ParameterName = ParamName;
            if (ParamValue == null)
            {
                Param.Value = DBNull.Value;
            }
            else
            {
                Param.Value = ParamValue;
            }
            Param.SqlDbType = ParamType;
            Param.Size = ParamSize;
            Param.Direction = ParamDir;
            return Param;
        }

        public string WebRequest(Method MType, string url, string postData)
        {
            string functionReturnValue = null;
            Uri objURI = new Uri(url);
            HttpWebRequest webReq = null;
            StreamWriter requestWriter = null;
            string responseData = "";
            webReq = (HttpWebRequest)System.Net.WebRequest.Create(objURI);
            //TryCast(System.Net.WebRequest.Create(url), HttpWebRequest)
            webReq.Method = MType.ToString();
            //webReq.ServicePoint.Expect100Continue = False
            //webReq.UserAgent = "[You user agent]"
            webReq.Timeout = 20000;
            if (MType == Method.POST)
            {
                webReq.ContentType = "application/x-www-form-urlencoded";
                webReq.ContentLength = postData.Length;
                //POST the data.
                requestWriter = new StreamWriter(webReq.GetRequestStream(), System.Text.Encoding.ASCII);
                try
                {
                    requestWriter.Write(postData);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    requestWriter.Close();
                    requestWriter = null;
                }
            }
            responseData = WebResponseGet(webReq);
            functionReturnValue = null;
            return responseData;
            //return functionReturnValue;
        }
        /// <summary>
        /// Process the web response.
        /// </summary>
        /// <param name="webRequest">The request object.</param>
        /// <returns>The response data.</returns>
        /// 
        public string WebResponseGet(HttpWebRequest webRequest)
        {
            StreamReader responseReader = null;
            string responseData = "";
            try
            {
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                responseData = responseReader.ReadToEnd();
            }
            catch
            {
                throw;
            }
            finally
            {
                webRequest.GetResponse().GetResponseStream().Close();
                responseReader.Close();
                responseReader = null;
            }
            return responseData;
        }

        //public SqlDataReader CheckAdminLogin(string UserId, string Password)
        //{
        //    ArrayList arrList = new ArrayList();
        //    arrList.Add(PrepareCommand("@UserId", UserId, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //    arrList.Add(PrepareCommand("@Password", Password, SqlDbType.VarChar, 500, ParameterDirection.Input));

        //    SqlDataReader dr = ExecDataReaderProc("bannag_soft_Prc_CheckAdminLogin", arrList.ToArray());
        //    return dr;
        //}

        //public SqlDataReader CheckSuperAdminLogin(string UserId, string Password)
        //{
        //    ArrayList arrList = new ArrayList();
        //    arrList.Add(PrepareCommand("@UserId", UserId, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //    arrList.Add(PrepareCommand("@Password", Password, SqlDbType.VarChar, 500, ParameterDirection.Input));

        //    SqlDataReader dr = ExecDataReaderProc("bannag_soft_Prc_CheckSuperAdminLogin", arrList.ToArray());
        //    return dr;
        //}

        //public string GetMemberName(string Memberid)
        //{
        //    string MemberName = null;
        //    try
        //    {
        //        ArrayList arrList = new ArrayList();
        //        arrList.Add(PrepareCommand("@MemberId", Memberid, SqlDbType.VarChar, 20, ParameterDirection.Input));
        //        arrList.Add(PrepareCommand("@MemberName", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //        MemberName = ExecScalarProc("bannag_soft_Prc_getMemberName", arrList.ToArray());
        //        if (string.IsNullOrEmpty(MemberName))
        //        {
        //            MemberName = "!";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MemberName = "!";
        //    }
        //    return MemberName;
        //}

        //public int isUserExists(string MemberId)
        //{
        //    int isExists = 0;
        //    try
        //    {
        //        isExists = Convert.ToInt32((new BusinessLogicLayer()).ExecScalar("if Exists(select Msrno from Membermaster where MemberId=@MemberId) select 1 else select 0", "@MemberId", MemberId));
        //    }
        //    catch (Exception ex)
        //    {
        //        isExists = 1;

        //    }
        //    finally
        //    {
        //    }
        //    return isExists;
        //}

        //public string InsertUpdateCategory(int id, string Category)
        //{
        //    ArrayList arrList = new ArrayList();
        //    arrList.Add(PrepareCommand("@Category_Id", id, SqlDbType.Int, 0, ParameterDirection.Input));
        //    arrList.Add(PrepareCommand("@CategoryName", Category, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //    arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //    string result = ExecNonQueryProc("bannag_soft_Prc_CategoryAddUpdate", arrList.ToArray());
        //    return result;
        //}

        // public string InsertUpdateSubCategory1(int id, int CategoryID, string SubCategory)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@ID", id, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@CategoryId", CategoryID, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@SubcategoryName", SubCategory, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("bannag_soft_Prc_CategorySub1AddUpdate", arrList.ToArray());
        //     return result;
        // }

        // public string InsertUpdateSubCategory2(int id, int CategoryID, int SubCategoryID1, string SubCategory)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@ID", id, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@CategoryId", CategoryID, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@SubCat1id", SubCategoryID1, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@SubcategoryName", SubCategory, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("bannag_soft_Prc_CategorySub2AddUpdate", arrList.ToArray());
        //     return result;
        // }

        // public string InsertUpdateExamDetails(int msrno, int quesid, string answer, int sid, int ishindi, int ansid, int clientid)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@Msrno", msrno, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@QuestionId", quesid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Answer", answer, SqlDbType.VarChar, 1000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@SurveyId", sid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@ishindi", ishindi, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@ansid", ansid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Clientid", clientid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("Prc_SaveExamDetails", arrList.ToArray());
        //     return result;
        // }


        // public string AddImage(int id, string path)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@ID", id, SqlDbType.Int, 0, ParameterDirection.Input));

        //     arrList.Add(PrepareCommand("@path", path, SqlDbType.VarChar, 1000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("Prc_AdImage", arrList.ToArray());
        //     return result;
        // }

        // public string Add_Ad(int PubId, int msrno, string Name, string Mobile, string Email, string Password, string AdName,
        //          string AdType, string AdDetail, int Time, decimal Budget, int TotalClick, decimal Distributionfund, decimal PayPerClick,
        //          int PerDayClick, string Startdate, string Enddate, string Questr, string AdBy, string updateby, string Catstr, string SubCat1str,
        //          string SubCat2str, string Statestr, string Citystr, string Pinstr, string Question, DataTable dt)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@PubId", PubId, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Msrno", msrno, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Name", Name, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Mobile", Mobile, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Email", Email, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Password", Password, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@AdName", AdName, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@AdType", AdType, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@AdDetail", AdDetail, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Time", Time, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Budget", Budget, SqlDbType.Decimal, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@TotalClick", TotalClick, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Distributionfund", Distributionfund, SqlDbType.Decimal, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@PayPerClick", PayPerClick, SqlDbType.Decimal, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@PerDayClick", PerDayClick, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Startdate", Startdate, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Enddate", Enddate, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Questr", Questr, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@AdBy", AdBy, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@updateby", updateby, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Catstr", Catstr, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@SubCat1str", SubCat1str, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@SubCat2str", SubCat2str, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Statestr", Statestr, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Citystr", Citystr, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Pinstr", Pinstr, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Question", Question, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Table", dt, SqlDbType.Structured, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("bannag_soft_Prc_Ad_Adding", arrList.ToArray());
        //     return result;
        // }

        // public string SaveUser(string username, string password, string email, string hashcode, string membertype)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@Username", username, SqlDbType.VarChar, 20, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Password", password, SqlDbType.VarChar, 20, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Email", email, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@hashcode", hashcode, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Membertype", membertype, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("Prc_Registration", arrList.ToArray());
        //     return result;
        // }

        // public string EditUser(string Membername, int stateid, int cityid, string interest, string abtme, string img, string Username, string gender, string membertype)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@Username", Username, SqlDbType.VarChar, 30, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Membername", Membername, SqlDbType.VarChar, 30, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@AboutMe", abtme, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Interest", interest, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Gender", gender, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Membertype", membertype, SqlDbType.VarChar, 20, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Photo", img, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@State", stateid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@city", cityid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("Prc_UpdateUser", arrList.ToArray());
        //     return result;
        // }

        // public SqlDataReader CheckMemberLogin(string username, string password)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@UserName", username, SqlDbType.VarChar, 30, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Password", password, SqlDbType.VarChar, 30, ParameterDirection.Input));
        //     SqlDataReader result = ExecDataReaderProc("CheckMemberLogin", arrList.ToArray());
        //     return result;
        // }

        // public string Save_Survey(DataTable dt)
        // {
        //     ArrayList arrlist = new ArrayList();
        //     arrlist.Add(PrepareCommand("@Table", dt, SqlDbType.Structured, 0, ParameterDirection.Input));
        //     arrlist.Add(PrepareCommand("@result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("bannag_soft_Prc_SaveUserSurvey", arrlist.ToArray());
        //     return result;
        // }




        // //public string InsertSurveyQuestion(int SurveyID, DataSet Question)
        // //{
        // //    ArrayList arrList = new ArrayList();
        // //    arrList.Add(PrepareCommand("@SurveyID", SurveyID, SqlDbType.Int, 0, ParameterDirection.Input));
        // //    arrList.Add(PrepareCommand("@QuestionAnswer", Question.Tables[0], SqlDbType.Structured, 0, ParameterDirection.Input));
        // //    arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        // //    string result = ExecNonQueryProc("Prc_SurveyQuestion", arrList.ToArray());
        // //    return result;
        // //}
        // public string InsertSurveyQuestion(int SurveyID, DataTable Question)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@SurveyID", SurveyID, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@QuestionAnswer", Question, SqlDbType.Structured, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("Prc_SurveyQuestion", arrList.ToArray());
        //     return result;
        // }

        // public string SaveMember(string membername, string refid, string memberid, string password, int state, int city, string pincode, int category, int subcat1, int subcat2, string email, string mobile, string ip, int clientid, int UserRoleID
        //     , string UserType, string UserName, string gender, string CompanyName, string Skills)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@Membername", membername, SqlDbType.VarChar, 20, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Memberid", memberid, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Password", password, SqlDbType.VarChar, 20, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Email", email, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Mobile", mobile, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@State", state, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@City", city, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@IntroId", refid, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Pincode", pincode, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Category", category, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Subcat1", subcat1, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Subcat2", subcat2, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Ip", ip, SqlDbType.VarChar, 20, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@clientid", clientid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@UserRole", UserRoleID, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@UserType", UserType, SqlDbType.VarChar, 50, ParameterDirection.Input));


        //     arrList.Add(PrepareCommand("@UserName", UserName, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Gender", gender, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@CompanyName", CompanyName, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Skils", Skills, SqlDbType.VarChar, 50, ParameterDirection.Input));

        //     arrList.Add(PrepareCommand("@result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("bannag_soft_Prc_MemberRegistration", arrList.ToArray());
        //     return result;
        // }

        // public string EditMember(string memberid, string email, string mobile, string address, string bankname, string branchname, string acno,
        //     string acholdername, string ifscode, string panno, int clientid)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@MemberId", memberid, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Email", email, SqlDbType.VarChar, 100, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Mobile", mobile, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@address", address, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@BankName", bankname, SqlDbType.VarChar, 100, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@BranchName", branchname, SqlDbType.VarChar, 100, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@AcHolderName", acholdername, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Acno", acno, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Ifscode", ifscode, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Panno", panno, SqlDbType.VarChar, 20, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@clientid", clientid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("bannag_soft_Prc_EditMember", arrList.ToArray());
        //     return result;
        // }

        // public string DisabledButtonCode(string validationGroup = "")
        // {
        //     System.Text.StringBuilder sbValid = new System.Text.StringBuilder();
        //     sbValid.Append("if (typeof(Page_ClientValidate) == 'function') { ");
        //     sbValid.Append("if (Page_ClientValidate('" + validationGroup + "') == false) { return false; }} ");
        //     sbValid.Append("this.value = 'Please wait...';");
        //     sbValid.Append("this.disabled = true;");
        //     return sbValid.ToString();
        // }

        //public SqlDataReader Soft_CheckMemberLogin(string Mid, string password)
        //{
        //    ArrayList arrList = new ArrayList();
        //    arrList.Add(PrepareCommand("@MemberId", Mid, SqlDbType.VarChar, 30, ParameterDirection.Input));
        //    arrList.Add(PrepareCommand("@Password", password, SqlDbType.VarChar, 30, ParameterDirection.Input));
        //    SqlDataReader result = ExecDataReaderProc("bannag_soft_prc_CheckMemberLogin", arrList.ToArray());
        //    return result;
        //}

        // public string ChangePassword(string memberid, string oldpassword, string newpassword, string action)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@MemberId", memberid, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@OldPwd", oldpassword, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@NewPwd", newpassword, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Action", action, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("bannag_soft_Prc_ChangePwd", arrList.ToArray());
        //     return result;
        // }

        // public SqlDataReader GetMemberDetails(string memberid, int msrno, int clientid)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@MemberId", memberid, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Msrno", msrno, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Clientid", clientid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     SqlDataReader result = ExecDataReaderProc("dbo.bannag_soft_Prc_MemberDetails", arrList.ToArray());
        //     return result;
        // }

        // public DataTable GetReferral(string FromDate, string ToDate, string MemberId, int DownLine, int Export)
        // {
        //     ArrayList arrList = new ArrayList();
        //     if (CheckDate(FromDate))
        //     {
        //         FromDate = null;
        //     }
        //     if (CheckDate(ToDate))
        //     {
        //         ToDate = null;
        //     }
        //     arrList.Add(PrepareCommand("@FromDate", FromDate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Todate", ToDate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@MemberId", MemberId, SqlDbType.VarChar, 20, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@DownLine", DownLine, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Export", Export, SqlDbType.Bit, 0, ParameterDirection.Input));
        //     DataTable Dt = ExecDataTableProc("bannag_soft_Prc_DownlineReport", arrList.ToArray());
        //     return Dt;
        // }


        // public DataTable GetMemberDetailsByIp(string FromDate, string ToDate, string MemberId, string ip, int Export)
        // {
        //     ArrayList arrList = new ArrayList();
        //     if (CheckDate(FromDate))
        //     {
        //         FromDate = null;
        //     }
        //     if (CheckDate(ToDate))
        //     {
        //         ToDate = null;
        //     }
        //     arrList.Add(PrepareCommand("@fromdate", FromDate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Todate", ToDate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@MemberId", MemberId, SqlDbType.VarChar, 20, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Ip", ip, SqlDbType.VarChar, 20, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Export", Export, SqlDbType.Bit, 0, ParameterDirection.Input));
        //     DataTable Dt = ExecDataTableProc("bannag_soft_Prc_MemberDetailsByIp", arrList.ToArray());
        //     return Dt;
        // }


        // public DataTable GetLevelDetails(string Memberid)
        // {
        //     DataTable dt = new DataTable();
        //     dt = ExecDataTableProc("bannag_soft_Prc_GetLevelDetail", "@MemberId", Memberid);
        //     return dt;
        // }

        // public DataTable GetLevelWiseMember(string memberid, int levelno)
        // {
        //     DataTable dt = new DataTable();
        //     dt = ExecDataTableProc("bannag_soft_Prc_GetLevelWiseMember", "@MemberId", memberid, "@LevelNo", levelno);
        //     return dt;
        // }

        // public DataTable GetClosingData(string FromDate, string ToDate, string MemberId, int ClosingType, int Export)
        // {
        //     ArrayList arrList = new ArrayList();
        //     if (CheckDate1(FromDate))
        //     {
        //         FromDate = null;
        //     }
        //     if (CheckDate1(ToDate))
        //     {
        //         ToDate = null;
        //     }
        //     arrList.Add(PrepareCommand("@FromDate", FromDate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Todate", ToDate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@MemberId", MemberId, SqlDbType.VarChar, 20, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@ClosingType", ClosingType, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Export", Export, SqlDbType.Bit, 0, ParameterDirection.Input));
        //     DataTable Dt = ExecDataTableProc("Prc_PaidData", arrList.ToArray());
        //     return Dt;
        // }

        // public string InsertUpdateSurvey(int id, int cateID, string Survey, string Description, int duration, int totalsurvey, string StartDate, string EndDate, string Statestr, string citystr, string pinstr, string catstr, string subcat1str, string subcat2str, int Amount, int clientid)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@ID", id, SqlDbType.Int, 0, ParameterDirection.Input));
        //     //arrList.Add(PrepareCommand("@Totalsurvey", totalsurvey, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@cateID", cateID, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Survey", Survey, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Description", Description, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@duration", duration, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@StartDate", StartDate, SqlDbType.VarChar, 100, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@EndDate", EndDate, SqlDbType.VarChar, 100, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Statestr", Statestr, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@citystr", citystr, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@pinstr", pinstr, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@catstr", catstr, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@subcat1str", subcat1str, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@subcat2str", subcat2str, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Amount", Amount, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@clientid", clientid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("Prc_SurveyAddUpdate", arrList.ToArray());
        //     return result;
        // }

        // public string InsertUpdateVideo(int id, int cateID, string Video, string Description,string FilePath,string ImagePath)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@ID", id, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@cateID", cateID, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Video", Video, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Description", Description, SqlDbType.VarChar, 8000, ParameterDirection.Input)); 
        //     arrList.Add(PrepareCommand("@FilePath", FilePath, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@ImagePath", ImagePath, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("Prc_VideoAddUpdate", arrList.ToArray());
        //     return result;
        // }

        // public string VideoCategoryAddUpdate(int cateID, string CategoryName, string Description, int clientid)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@cateID", cateID, SqlDbType.Int, 0, ParameterDirection.Input));
        //     //arrList.Add(PrepareCommand("@Totalsurvey", totalsurvey, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@categoryName", CategoryName, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Description", Description, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("Prc_VideoCategoryAddUpdate", arrList.ToArray());
        //     return result;
        // }

        // //public string InsertUpdateSurvey(int id, string Survey, string Description, int duration, int totalsurvey, string StartDate, string EndDate, string Statestr, string citystr, string pinstr, string catstr, string subcat1str, string subcat2str, int Amount, int clientid)
        // //{
        // //    ArrayList arrList = new ArrayList();
        // //    arrList.Add(PrepareCommand("@ID", id, SqlDbType.Int, 0, ParameterDirection.Input));
        // //    arrList.Add(PrepareCommand("@Totalsurvey", totalsurvey, SqlDbType.Int, 0, ParameterDirection.Input));
        // //    arrList.Add(PrepareCommand("@Survey", Survey, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        // //    arrList.Add(PrepareCommand("@Description", Description, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        // //    arrList.Add(PrepareCommand("@duration", duration, SqlDbType.Int, 0, ParameterDirection.Input));
        // //    arrList.Add(PrepareCommand("@StartDate", StartDate, SqlDbType.VarChar, 100, ParameterDirection.Input));
        // //    arrList.Add(PrepareCommand("@EndDate", EndDate, SqlDbType.VarChar, 100, ParameterDirection.Input));
        // //    arrList.Add(PrepareCommand("@Statestr", Statestr, SqlDbType.VarChar, 500, ParameterDirection.Input));
        // //    arrList.Add(PrepareCommand("@citystr", citystr, SqlDbType.VarChar, 500, ParameterDirection.Input));
        // //    arrList.Add(PrepareCommand("@pinstr", pinstr, SqlDbType.VarChar, 500, ParameterDirection.Input));
        // //    arrList.Add(PrepareCommand("@catstr", catstr, SqlDbType.VarChar, 500, ParameterDirection.Input));
        // //    arrList.Add(PrepareCommand("@subcat1str", subcat1str, SqlDbType.VarChar, 500, ParameterDirection.Input));
        // //    arrList.Add(PrepareCommand("@subcat2str", subcat2str, SqlDbType.VarChar, 500, ParameterDirection.Input));
        // //    arrList.Add(PrepareCommand("@Amount", Amount, SqlDbType.Int, 0, ParameterDirection.Input));
        // //    arrList.Add(PrepareCommand("@clientid", clientid, SqlDbType.Int, 0, ParameterDirection.Input));
        // //    arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        // //    string result = ExecNonQueryProc("Prc_SurveyAddUpdate", arrList.ToArray());
        // //    return result;
        // //}




        // public string InsertUpdateExamcategory(int id, string Survey, string Description, int clientid)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@ID", id, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Survey", Survey, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Description", Description, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("Prc_CategoryAddUpdate", arrList.ToArray());
        //     return result;
        // }

        // public string InsertUpdateBatch(int id, string BatchName, string Description, int clientid)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@ID", id, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@BatchName", BatchName, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Description", Description, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //     //arrList.Add(PrepareCommand("@clientID", clientid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("Prc_BatchMaster", arrList.ToArray());
        //     return result;
        // }

        // public string InsertUpdate_VideoGroup(int id, string subcategoryName)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@ID", id, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@subcategoryName", subcategoryName, SqlDbType.VarChar, 8000, ParameterDirection.Input));           
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("Prc_subcategoryMaster", arrList.ToArray());
        //     return result;
        // }

        // public string insertcount(int videoid, int msrno)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@videoid", videoid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@msrnoid", msrno, SqlDbType.VarChar, 8000, ParameterDirection.Input));                     
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("Prc_chkvcount", arrList.ToArray());
        //     return result;
        // }

        // public string InsertBannerImage(string Position, string Image, string StateStr, string CityStr, string PinStr, string CategoryStr, string SubCategoryStr, string SubCategory1Str, string URLPath, string StartDate, string EndDate)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@Position", Position, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Image", Image, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@StateStr", StateStr, SqlDbType.VarChar, 5000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@CityStr", CityStr, SqlDbType.VarChar, 5000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@PinStr", PinStr, SqlDbType.VarChar, 5000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@CategoryStr", CategoryStr, SqlDbType.VarChar, 5000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@SubCategoryStr", SubCategoryStr, SqlDbType.VarChar, 5000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@SubCategory1Str", SubCategoryStr, SqlDbType.VarChar, 5000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@URLPath", URLPath, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@StartDate", StartDate, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@EndDate", EndDate, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("bannag_soft_Prc_InsertBannerImage", arrList.ToArray());
        //     return result;
        // }

        // public string InsertBannerAdAnswer(int msrno, string Answer, int BannerAdID)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@msrno", msrno, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@answer", Answer, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@BannerAdID", BannerAdID, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("bannag_soft_Prc_Ad_BannerAdAnswer", arrList.ToArray());
        //     return result;
        // }

        // public SqlDataReader TotalMembers(string FromDate, string ToDate, string MemberId, int Export, string isactivechk, string BatchID, int clientid)
        // {
        //     ArrayList arrList = new ArrayList();
        //     if (FromDate == "")
        //     {
        //         FromDate = null;
        //     }
        //     if (ToDate == "")
        //     {
        //         ToDate = null;
        //     }
        //     arrList.Add(PrepareCommand("@FromDate", FromDate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Todate", ToDate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@MemberId", MemberId, SqlDbType.VarChar, 100, ParameterDirection.Input));
        //     //arrList.Add(PrepareCommand("@IntroId", IntroId, SqlDbType.VarChar, 20, ParameterDirection.Input));
        //     //arrList.Add(PrepareCommand("@isActive", isActive, SqlDbType.VarChar, 1, ParameterDirection.Input));
        //     //arrList.Add(PrepareCommand("@Mscheme", Itemid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     //arrList.Add(PrepareCommand("@Deactive", Deactive, SqlDbType.Bit, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Export", Export, SqlDbType.Bit, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@isactivechk", isactivechk, SqlDbType.VarChar, 100, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@BatchId", BatchID, SqlDbType.VarChar, 100, ParameterDirection.Input));

        //     SqlDataReader dr = ExecDataReaderProc("bannag_soft_Prc_TotalMembers", arrList.ToArray());
        //     return dr;
        // }

        // public DataTable AdminUser(string FromDate, string ToDate, int adminid, int type, string usertype)
        // {
        //     DataTable dt = new DataTable();
        //     ArrayList arrList = new ArrayList();
        //     //if (FromDate == "")
        //     //{
        //     //    FromDate = null;
        //     //}
        //     //if (ToDate == "")
        //     //{
        //     //    ToDate = null;
        //     //}

        //     arrList.Add(PrepareCommand("@FromDate", FromDate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Todate", ToDate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@adminid", adminid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@type", type, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@usertye", usertype, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     dt = ExecDataTableProc("Get_AdminUser", arrList.ToArray());
        //     return dt;
        // }

        // public void ActiveDeactive(string Memberid, char Type, int AllTeam, string Remark)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@MemberId", Memberid, SqlDbType.VarChar, 20, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Type", Type, SqlDbType.Char, 1, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@AllTeam", AllTeam, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Remark", Remark, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     ExecNonQueryProc("bannag_soft_Prc_ActiveDeactive", arrList.ToArray());

        // }
        // public DataTable AccountStatement(string FromDate, string ToDate, string MemberId, int WalletType, string TranType, int Export)
        // {
        //     ArrayList arrList = new ArrayList();
        //     if (FromDate == "")
        //     {
        //         FromDate = "";
        //     }
        //     if (ToDate == "")
        //     {
        //         ToDate = "";
        //     }
        //     arrList.Add(PrepareCommand("@FromDate", FromDate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Todate", ToDate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@MemberId", MemberId, SqlDbType.VarChar, 20, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@WType", WalletType, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@TranType", TranType, SqlDbType.VarChar, 2, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Export", Export, SqlDbType.Bit, 0, ParameterDirection.Input));
        //     DataTable DT = ExecDataTableProc("bannag_soft_Prc_AllAccountStatement", arrList.ToArray());
        //     return DT;
        // }



        // public string UpdateUserDetails(int Msrno, string Membername, string Address,
        //string Mobile, string Email, string BankName, string BranchName, string AcNo, string PanNo, string IFSC, string Password,
        //     string DtUser, string AcName, string pincode, int clientid)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@Msrno", Msrno, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@MemberName", Membername, SqlDbType.VarChar, 100, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Address", Address, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     //arrList.Add(PrepareCommand("@State", State, SqlDbType.Int , 0, ParameterDirection.Input));
        //     //arrList.Add(PrepareCommand("@City", City, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Mobile", Mobile, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Email", Email, SqlDbType.VarChar, 100, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@BankName", BankName, SqlDbType.VarChar, 100, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@BranchName", BranchName, SqlDbType.VarChar, 100, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@AcNo", AcNo, SqlDbType.VarChar, 30, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@PanNo", PanNo, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@IFSC", IFSC, SqlDbType.VarChar, 20, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Password", Password, SqlDbType.VarChar, 20, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@DtUser", DtUser, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@AcHolderName", AcName, SqlDbType.VarChar, 100, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@PinCode", pincode, SqlDbType.VarChar, 6, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@clientid", clientid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string str = ExecNonQueryProc("bannag_soft_Prc_UpdateMemberDetails", arrList.ToArray());
        //     return str;
        // }

        // public DataTable GetUserSecurityInfo(string FromDate, string ToDate, string MemberId, string IntroId)
        // {
        //     ArrayList arrList = new ArrayList();
        //     if (FromDate == "")
        //     {
        //         FromDate = null;
        //     }
        //     if (ToDate == "")
        //     {
        //         ToDate = null;
        //     }
        //     arrList.Add(PrepareCommand("@FromDate", FromDate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Todate", ToDate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@MemberId", MemberId, SqlDbType.VarChar, 20, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@IntroId", IntroId, SqlDbType.VarChar, 20, ParameterDirection.Input));
        //     DataTable Dt = ExecDataTableProc("bannag_soft_Prc_GetUserSecurityInfo", arrList.ToArray());
        //     return Dt;
        // }

        // public SqlDataReader GetWalletStatus(string MemberId)
        // {
        //     SqlParameter Param = new SqlParameter("@MemberId", SqlDbType.VarChar, 20);
        //     Param.Value = MemberId;
        //     SqlDataReader dr = ExecDataReaderProc("bannag_soft_Prc_WalletStatus", Param);
        //     return dr;
        // }

        // public DataTable GetWithDrawlRequest(string Fromdate, string Todate, string MemberId, int Paid, int Export)
        // {
        //     ArrayList arrList = new ArrayList();
        //     if (Fromdate == "")
        //     {
        //         Fromdate = null;
        //     }
        //     if (Todate == "")
        //     {
        //         Todate = null;
        //     }
        //     arrList.Add(PrepareCommand("@FromDate", Fromdate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Todate", Todate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@MemberId", MemberId, SqlDbType.VarChar, 20, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Paid", Paid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Export", Export, SqlDbType.Bit, 0, ParameterDirection.Input));
        //     DataTable Dt = ExecDataTableProc("bannag_soft_Prc_WalletPaidDetails", arrList.ToArray());
        //     return Dt;
        // }


        // public string AmountSettlement(string MemberId, decimal Amount, string Scode, string Remark)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@MemberId", MemberId, SqlDbType.VarChar, 20, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Amount", Amount, SqlDbType.Int, 0, ParameterDirection.Input));
        //     //arrList.Add(PrepareCommand("@Scode", Scode, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Remark", Remark, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string str = ExecNonQueryProc("bannag_soft_Prc_Payment_Request", arrList.ToArray());
        //     return str;
        // }

        // public DataTable GetUpline(string FromDate, string ToDate, string MemberId, int Export)
        // {
        //     ArrayList arrList = new ArrayList();
        //     if (FromDate == "")
        //     {
        //         FromDate = "";
        //     }
        //     if (ToDate == "")
        //     {
        //         ToDate = "";
        //     }
        //     arrList.Add(PrepareCommand("@FromDate", FromDate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Todate", ToDate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@MemberId", MemberId, SqlDbType.VarChar, 20, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Export", Export, SqlDbType.Bit, 0, ParameterDirection.Input));
        //     DataTable Dt = ExecDataTableProc("bannag_soft_Prc_UplineLine", arrList.ToArray());
        //     return Dt;
        // }


        // public string InsertTempRegistration(int ID, string title, string Surname, string Ftitle, string fathername, string name, string imagepath,
        //   string CourseTYpe, string Gender, string DOB, string landline,
        //   string city, string address, string state, string Mobileno, string Email, string BDSPercentage, string college, string BDSYear, string ip)
        // {
        //     ArrayList arrList = new ArrayList();

        //     arrList.Add(PrepareCommand("@title", title, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@name", name, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Surname", Surname, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Ftitle", Ftitle, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@fathername", fathername, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@imagepath", imagepath, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@city", city, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@CourseTYpe", CourseTYpe, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@address", address, SqlDbType.VarChar, 1000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@state", state, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@mobileno", Mobileno, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@DOB", DOB, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Gender", Gender, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@landline", landline, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@emailid", Email, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@College", college, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@BDSYear", BDSYear, SqlDbType.VarChar, 3000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@BDSPercentage", BDSPercentage, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Regid", ID, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Createdipaddress", ip, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     string result = ExecNonQueryProc("Set_TempRegister", arrList.ToArray());
        //     return result;
        // }


        // public string ExamAlloatment(string action, int tid, string msrno, int surveyid, DateTime dtfrom, DateTime dtto, string status, int BatchID, int Clientid)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@action", action, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@TID", tid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@SurveyID", surveyid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@msrno", msrno, SqlDbType.VarChar, 4000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Dateto", dtto, SqlDbType.DateTime, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@DateFrom", dtfrom, SqlDbType.DateTime, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@CompleteStatus", status, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@BatchID", BatchID, SqlDbType.Int, 0, ParameterDirection.Input));
        //     //arrList.Add(PrepareCommand("@Clientid", Clientid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("Prc_ExamAlloatMent", arrList.ToArray());
        //     return result;
        // }

        // public string BatchAlloatment(string action, int tid, string msrno, int BatchID, DateTime dtfrom, DateTime dtto, string status, int clientid)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@action", action, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@TID", tid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@batchID", BatchID, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@msrno", msrno, SqlDbType.VarChar, 4000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Dateto", dtto, SqlDbType.DateTime, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@DateFrom", dtfrom, SqlDbType.DateTime, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@CompleteStatus", status, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     //arrList.Add(PrepareCommand("@Clientid", clientid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("Prc_batchAlloatMent", arrList.ToArray());
        //     return result;
        // }


        // public string VideoGroupAlloatment(string action, int tid, string videocatid, int subcatid, string status)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@action", action, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@TID", tid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@subcatid", subcatid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@videocatid", videocatid, SqlDbType.VarChar, 4000, ParameterDirection.Input));          
        //     //arrList.Add(PrepareCommand("@CompleteStatus", status, SqlDbType.VarChar, 500, ParameterDirection.Input));           
        //     arrList.Add(PrepareCommand("@result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("Prc_categoryAlloatMent", arrList.ToArray());
        //     return result;
        // }

        // public SqlDataReader AllFranchiseMembers(string FromDate, string ToDate, string MemberId, string IntroId, string isActive, int Deactive, int Export)
        // {
        //     ArrayList arrList = new ArrayList();
        //     if (FromDate == "")
        //     {
        //         FromDate = null;
        //     }
        //     if (ToDate == "")
        //     {
        //         ToDate = null;
        //     }
        //     arrList.Add(PrepareCommand("@FromDate", FromDate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Todate", ToDate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@MemberId", MemberId, SqlDbType.VarChar, 100, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@IntroId", IntroId, SqlDbType.VarChar, 100, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@isActive", isActive, SqlDbType.VarChar, 1, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Deactive", Deactive, SqlDbType.Bit, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Export", Export, SqlDbType.Bit, 0, ParameterDirection.Input));
        //     SqlDataReader dr = ExecDataReaderProc("bannag_soft_Prc_AllFranchiseMembers", arrList.ToArray());
        //     return dr;
        // }
        // public SqlDataReader GetClickAdDetail(string FromDate, string ToDate, int isActive, int Export)
        // {
        //     ArrayList arrList = new ArrayList();
        //     if (FromDate == "")
        //     {
        //         FromDate = null;
        //     }
        //     if (ToDate == "")
        //     {
        //         ToDate = null;
        //     }
        //     arrList.Add(PrepareCommand("@FromDate", FromDate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Todate", ToDate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@isActive", isActive, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Export", Export, SqlDbType.Bit, 0, ParameterDirection.Input));
        //     SqlDataReader dr = ExecDataReaderProc("bannag_soft_Prc_GetClickAdDetail", arrList.ToArray());
        //     return dr;
        // }

        // public string ChangePublisherPassword(int PubID, string oldpassword, string newpassword)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@PubID", PubID, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@OldPwd", oldpassword, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@NewPwd", newpassword, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("bannag_soft_Prc_ChangePubPwd", arrList.ToArray());
        //     return result;
        // }

        // public SqlDataReader GetPiblisherDetails(string Email, int publisherid)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@Email", Email, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@publisherid", publisherid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     SqlDataReader result = ExecDataReaderProc("dbo.bannag_soft_Prc_PublisherDetails", arrList.ToArray());
        //     return result;
        // }

        // public SqlDataReader Soft_CheckPublisherLogin(string Email, string password)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@Email", Email, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Password", password, SqlDbType.VarChar, 30, ParameterDirection.Input));
        //     SqlDataReader result = ExecDataReaderProc("bannag_soft_prc_CheckPublisherLogin", arrList.ToArray());
        //     return result;
        // }

        // public string InsertUpdateSurveyIncome(int Level, Decimal Amount)
        // {
        //     ArrayList arrList = new ArrayList();

        //     arrList.Add(PrepareCommand("@Level", Level, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Amount", Amount, SqlDbType.Decimal, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("bannag_soft_Prc_UpdateSurveyIncome", arrList.ToArray());
        //     return result;
        // }

        // public string InsertUpdateNews(int cnt, string heading, string description, string path, string type)
        // {
        //     ArrayList arrList = new ArrayList();

        //     arrList.Add(PrepareCommand("@cnt", cnt, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Heading", heading, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Description", description, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Filepath", path, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@type", type, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("Sp_tbl_content", arrList.ToArray());
        //     return result;
        // }

        // public string InsertUpdateVacancy(int cnt, string heading, string description, string url, string file, string clientid)
        // {
        //     ArrayList arrList = new ArrayList();

        //     arrList.Add(PrepareCommand("@cnt", cnt, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Heading", heading, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Description", description, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@url", url, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Filepath", file, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@clientid", clientid, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("Sp_tbl_vacancy", arrList.ToArray());
        //     return result;
        // }

        // public string InsertUpdateGallery(int cnt, string path, string clientid)
        // {
        //     ArrayList arrList = new ArrayList();

        //     arrList.Add(PrepareCommand("@sno", cnt, SqlDbType.Int, 0, ParameterDirection.Input));
        //     //arrList.Add(PrepareCommand("@Heading", heading, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     //arrList.Add(PrepareCommand("@Description", description, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Filepath", path, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@clientid", clientid, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("Sp_tbl_StudentGallery", arrList.ToArray());
        //     return result;
        // }

        // public string InsertEnquiry(string name, string city, string address, string state, string Mobileno, string Email, string Pincode, string Message, string Edate, int ID, string orgname, string websitename)
        // {
        //     ArrayList arrList = new ArrayList();

        //     arrList.Add(PrepareCommand("@name", name, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@city", city, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@address", address, SqlDbType.VarChar, 1000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@state", state, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Mobileno", Mobileno, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Email", Email, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Pincode", Pincode, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Message", Message, SqlDbType.VarChar, 3000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Edate", Edate, SqlDbType.DateTime, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@ID", ID, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@orgname", orgname, SqlDbType.VarChar, 5000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@websitename", websitename, SqlDbType.VarChar, 5000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("sp_Stu_contact_dtl", arrList.ToArray());
        //     return result;
        // }

        // public string InsertEnquiry(string name, string city, string address, string state, string Mobileno, string Email, string Pincode, string Message, string Edate, int ID)
        // {
        //     ArrayList arrList = new ArrayList();

        //     arrList.Add(PrepareCommand("@name", name, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@city", city, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@address", address, SqlDbType.VarChar, 1000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@state", state, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Mobileno", Mobileno, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Email", Email, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Pincode", Pincode, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Message", Message, SqlDbType.VarChar, 3000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Edate", Edate, SqlDbType.DateTime, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@ID", ID, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("sp_Stu_contact_dtl", arrList.ToArray());
        //     return result;
        // }



        // public string InsertUpdateBannerAdIncome(int Level, Decimal Amount)
        // {
        //     ArrayList arrList = new ArrayList();

        //     arrList.Add(PrepareCommand("@Level", Level, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Amount", Amount, SqlDbType.Decimal, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("bannag_soft_Prc_UpdateBannerAdIncome", arrList.ToArray());
        //     return result;
        // }
        // public string InsertUpdateLevelIncome(int Level, Decimal Amount, Decimal refamount)
        // {
        //     ArrayList arrList = new ArrayList();

        //     arrList.Add(PrepareCommand("@Level", Level, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Amount", Amount, SqlDbType.Decimal, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@refamount", refamount, SqlDbType.Decimal, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("bannag_soft_Prc_UpdateLevelIncome", arrList.ToArray());
        //     return result;
        // }
        // public string ApproveClickAd(int Adid, int Time, int TotalClick, Decimal Distributionfund, Decimal GetPerClick, Decimal PerDayClick, string Addetails, decimal budget)
        // {
        //     ArrayList arrList = new ArrayList();

        //     arrList.Add(PrepareCommand("@Adid", Adid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Time", Time, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@TotalClick", TotalClick, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Distributionfund", Distributionfund, SqlDbType.Decimal, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@GetPerClick", GetPerClick, SqlDbType.Decimal, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@PerDayClick", PerDayClick, SqlDbType.Decimal, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@budget", budget, SqlDbType.Decimal, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Addetails", Addetails, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("bannag_sfot_Prc_ApproveClickAd", arrList.ToArray());
        //     return result;
        // }

        // public string InsertBannerScript(string Position, string Script)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@Position", Position, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Script", Script, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("bannag_soft_Prc_InsertBannerScript", arrList.ToArray());
        //     return result;
        // }
        // public string AddAdvertisement(string StartDate, string EndDate, int capping, int PaymentMode, decimal PaidAmount, string AdFrom, string AdType, int aff_Provider, int OfferId, string Title, string URL, string Note, string BannerUrl, string FlashUrl, int Active, int ActionType)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@capping", capping, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@StartDate", StartDate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@EndDate", EndDate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@PaidAmount", PaidAmount, SqlDbType.Decimal, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@AdFrom", AdFrom, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@AdType", AdType, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@aff_Provider", aff_Provider, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@OfferId", OfferId, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Title", Title, SqlDbType.VarChar, 1000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@URL", URL, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@BannerUrl", BannerUrl, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@FlashUrl", FlashUrl, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Note", Note, SqlDbType.VarChar, 5000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Active", Active, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@ActionType", ActionType, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@PaymentMode", PaymentMode, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("bannag_soft_Prc_AddAdvertisement", arrList.ToArray());
        //     return result;
        // }
        // public string TrackingUrl(int Leadid, int groupid, int GroupLeadid, int Msrno, string IPAddress)
        // {
        //     ArrayList arrList = new ArrayList();

        //     arrList.Add(PrepareCommand("@leadid", Leadid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@groupid", groupid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@GroupLeadid", GroupLeadid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Msrno", Msrno, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@IPAdress", IPAddress, SqlDbType.VarChar, 20, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("TrackingUrl", arrList.ToArray());
        //     return result;
        // }

        // public DataTable GetGroupDetails(int isActive)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@isActive", isActive, SqlDbType.Int, 0, ParameterDirection.Input));

        //     DataTable result = ExecDataTableProc("GetGroupDetails", arrList.ToArray());
        //     return result;
        // }
        // public string InsertGroupWiseLead(int GroupId, int LeadID)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@groupId", GroupId, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@leadid", LeadID, SqlDbType.Int, 0, ParameterDirection.Input));
        //     string result = ExecNonQueryProc("Prc_GroupWiseLead", arrList.ToArray());
        //     return result;
        // }

        // public string AddGroup(string GroupName, string IsFrom, string IsTo, int Active, int ActionType)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@GroupName", GroupName, SqlDbType.VarChar, 1000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@IsFrom", IsFrom, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@IsTo", IsTo, SqlDbType.VarChar, 50, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Active", Active, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@ActionType", ActionType, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("Prc_AddGroupmaster", arrList.ToArray());
        //     return result;
        // }

        // public SqlDataReader GetUnpaidEmail(string FromDate, string ToDate, int isPaid, int Aff, int Export)
        // {
        //     ArrayList arrList = new ArrayList();
        //     if (FromDate == "")
        //     {
        //         FromDate = null;
        //     }
        //     if (ToDate == "")
        //     {
        //         ToDate = null;
        //     }
        //     arrList.Add(PrepareCommand("@FromDate", FromDate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Todate", ToDate, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@isPaid", isPaid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Aff", Aff, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@Export", Export, SqlDbType.Bit, 0, ParameterDirection.Input));
        //     SqlDataReader dr = ExecDataReaderProc("GetUnpaidEmail", arrList.ToArray());
        //     return dr;
        // }


        // //start M.Ksrnews
        // public string GetSateName(int StateID)
        // {
        //     object StateName = ExecScalar("select State from dbo.tbl_State where id=@id", "@id", StateID);
        //     if (StateName == null)
        //     {
        //         return "";
        //     }
        //     else
        //     {
        //         return StateName.ToString();
        //     }

        // }
        // public string GetCityName(int CityID)
        // {
        //     object CityName = ExecScalar("select District from dbo.tbl_StateCity where id=@id", "@id", CityID);
        //     if (CityName == null)
        //     {
        //         return "";
        //     }
        //     else
        //     {
        //         return CityName.ToString();
        //     }

        // }
        // public string GetCategoryName(int CategoryID)
        // {
        //     object CategoryName = ExecScalar("select categoryname from dbo.Category where category_id=@id", "@id", CategoryID);
        //     if (CategoryName == null)
        //     {
        //         return "";
        //     }
        //     else
        //     {
        //         return CategoryName.ToString();
        //     }

        // }
        // public string GetSubCategoryName(int SubCategoryID)
        // {
        //     object SubCategoryName = ExecScalar("select SubcategoryName from dbo.CategorySub where SubCategory_id=@SubCategory_id", "@SubCategory_id", SubCategoryID);
        //     if (SubCategoryName == null)
        //     {
        //         return "";
        //     }
        //     else
        //     {
        //         return SubCategoryName.ToString();
        //     }

        // }

        // public string SaveVideo(int id, int examid, string title, string description, string script, string ip, string clientid)
        // {
        //     ArrayList arrList = new ArrayList();
        //     arrList.Add(PrepareCommand("@Id", id, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@examid", examid, SqlDbType.Int, 0, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@title", title, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@description", description, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@script", script, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@ipaddress", ip, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@clientid", clientid, SqlDbType.VarChar, 10, ParameterDirection.Input));
        //     arrList.Add(PrepareCommand("@result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //     string result = ExecNonQueryProc("Set_Video", arrList.ToArray());
        //     return result;
        // }


        //public string SaveAdminUser(int sno, string username, string orgname, string loginid, string password, string usertype, string email,
        //    string mobile, string address, string ip)
        //{
        //    ArrayList arrList = new ArrayList();
        //    arrList.Add(PrepareCommand("@sno", sno, SqlDbType.Int, 0, ParameterDirection.Input));
        //    arrList.Add(PrepareCommand("@username", username, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //    arrList.Add(PrepareCommand("@orgname", orgname, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //    arrList.Add(PrepareCommand("@loginid", loginid, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //    arrList.Add(PrepareCommand("@password", password, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //    arrList.Add(PrepareCommand("@usertype", usertype, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //    arrList.Add(PrepareCommand("@email", email, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //    arrList.Add(PrepareCommand("@mobile", mobile, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //    arrList.Add(PrepareCommand("@address", address, SqlDbType.VarChar, 8000, ParameterDirection.Input));
        //    arrList.Add(PrepareCommand("@ipaddress", ip, SqlDbType.VarChar, 500, ParameterDirection.Input));
        //    arrList.Add(PrepareCommand("@result", "", SqlDbType.VarChar, 500, ParameterDirection.Output));
        //    string result = ExecNonQueryProc("Set_AdminUser", arrList.ToArray());
        //    return result;
        //}

        //public string Set_org_signup(int org_id,
        // string org_name,
        // string contactno,
        // string emailId,
        // string website,
        // string ownername,
        // string ownerno,
        // string address,
        // int status,
        // string createip,
        // string username,
        // string password, string Conn)
        //{
        //    ArrayList arrList = new ArrayList();
        //    arrList.Add(PrepareCommand("@ID", id, SqlDbType.Int, 0, ParameterDirection.Input));
        //    arrList.Add(PrepareCommand("@CategoryId", CategoryID, SqlDbType.Int, 0, ParameterDirection.Input));
        //    arrList.Add(PrepareCommand("@SubcategoryName", SubCategory, SqlDbType.VarChar, 200, ParameterDirection.Input));
        //    arrList.Add(PrepareCommand("@Result", "", SqlDbType.VarChar, 200, ParameterDirection.Output));
        //    string result = ExecNonQueryProc("Set_org_signup", arrList.ToArray());
        //    return result;
        //}
    }
}