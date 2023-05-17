using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using VigProject_Api.Utility;

namespace DentVideo
{
    public class DataAccessLayer
    {
       // Microsoft.AspNetCore.Http.HttpContext ctx = Microsoft.AspNetCore.Http.HttpContext.Current;
        private SqlCommand CreateCommand(string Query, CommandType CmdType, params object[] obj)
        {
            SqlCommand cmd = new SqlCommand(Query);
            try
            {
                cmd.CommandType = CmdType;
                for (int i = 0; i <= obj.Length - 1; i++)
                {
                    if (obj[i] is string & i < obj.Length - 1)
                    {
                        SqlParameter Parm = new SqlParameter();
                        Parm.ParameterName = obj[i].ToString();
                        i = i + 1;
                        Parm.Value = obj[i];
                        cmd.Parameters.Add(Parm);
                    }
                    else if (obj[i] is SqlParameter)
                    {
                        cmd.Parameters.Add(obj[i]);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid number or type of arguments supplied");
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return cmd;
        }

        public int ExecNonQuery(string Query, string strconn, params object[] obj)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(SqlHelper.GetConnectionString(strconn)))
            {
                using (SqlCommand cmd = CreateCommand(Query, CommandType.Text, obj))
                {
                    try
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        result = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        result = 0;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return result;
        }

        public string ExecNonQueryProc(string Proc, string strconn, params object[] obj)
        {
            string result = "!";
            using (SqlConnection conn = new SqlConnection(SqlHelper.GetConnectionString(strconn)))
            {
                using (SqlCommand cmd = CreateCommand(Proc, CommandType.StoredProcedure, obj))
                {
                    try
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        result = cmd.ExecuteNonQuery().ToString();
                        if (obj.Length > 0 && cmd.Parameters[cmd.Parameters.Count - 1].Direction == ParameterDirection.Output)
                        {
                            result = cmd.Parameters[cmd.Parameters.Count - 1].Value.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        result = null;
                        Email_onError(ex, "Function ExecNonQueryProc");
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return result;
        }

        public object ExecScalar(string Query, string strconn, params object[] obj)
        {
            object result = null;
            using (SqlConnection conn = new SqlConnection(SqlHelper.GetConnectionString(strconn)))
            {
                using (SqlCommand cmd = CreateCommand(Query, CommandType.Text, obj))
                {
                    try
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        result = cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        result = null;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return result;
        }

        public string ExecScalarProc(string Proc, string strconn, params object[] obj)
        {
            object result = null;
            using (SqlConnection conn = new SqlConnection(SqlHelper.GetConnectionString(strconn)))
            {
                using (SqlCommand cmd = CreateCommand(Proc, CommandType.StoredProcedure, obj))
                {
                    try
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        result = cmd.ExecuteScalar();
                        if (obj.Length > 0 && cmd.Parameters[cmd.Parameters.Count - 1].Direction == ParameterDirection.Output)
                        {
                            result = cmd.Parameters[cmd.Parameters.Count - 1].Value;
                        }
                    }
                    catch (Exception ex)
                    {
                        result = null;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            if (result == null)
                result = 0;
            return result.ToString();
        }
        public SqlDataReader ExecDataReader(string Query, string strconn, params object[] obj)
        {
            SqlDataReader result = default(SqlDataReader);
            SqlConnection conn = new SqlConnection(SqlHelper.GetConnectionString(strconn));
            using (SqlCommand cmd = CreateCommand(Query, CommandType.Text, obj))
            {
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    result = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (Exception ex)
                {
                    result = null;

                }
                finally
                {

                }
            }
            return result;
        }

        public SqlDataReader ExecDataReaderProc(string Proc, string strconn, params object[] obj)
        {
            SqlDataReader result = default(SqlDataReader);
            SqlConnection conn = new SqlConnection(SqlHelper.GetConnectionString(strconn));
            using (SqlCommand cmd = CreateCommand(Proc, CommandType.StoredProcedure, obj))
            {
                try
                {
                    cmd.Connection = conn;
                    conn.Open();
                    result = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (Exception ex)
                {
                    result = null;
                }
                finally
                {
                }
            }
            return result;
        }
        public DataTable ExecDataTable(string Query, string strconn, params object[] obj)
        {
            DataTable Dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(SqlHelper.GetConnectionString(strconn)))
            {
                using (SqlCommand cmd = CreateCommand(Query, CommandType.Text, obj))
                {
                    try
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        Dt.Load(cmd.ExecuteReader());
                    }
                    catch (Exception ex)
                    {
                        Dt = null;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return Dt;
        }
        public DataTable ExecDataTableProc(string Proc, string strconn, params object[] obj)
        {
            DataTable result = new DataTable();
            using (SqlConnection conn = new SqlConnection(SqlHelper.GetConnectionString(strconn)))
            {
                using (SqlCommand cmd = CreateCommand(Proc, CommandType.StoredProcedure, obj))
                {
                    try
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        result.Load(cmd.ExecuteReader());
                    }
                    catch (Exception ex)
                    {
                        result = null;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            return result;
        }

        public DataSet GetDataSet(string Query,string strconn, params object[] obj)
        {
            DataSet ds = new DataSet();
            using (SqlConnection Conn = new SqlConnection(SqlHelper.GetConnectionString(strconn)))
            {
                using (SqlCommand cmd = CreateCommand(Query, CommandType.Text, obj))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        try
                        {
                            cmd.Connection = Conn;
                            sda.SelectCommand = cmd;
                            Conn.Open();
                            sda.Fill(ds);
                        }
                        catch (Exception ex)
                        {
                            ds = null;
                        }
                        finally
                        {
                            Conn.Close();
                        }
                    }
                }
            }
            return ds;
        }

        public void Email_onError(Exception ex, string MailSub)
        {
            //Hashtable templateVars = new Hashtable();
            //templateVars.Add("ErrorIn", ctx.Request.Url);
            //templateVars.Add("ErrorMsg", ex.Message);
            //templateVars.Add("StackTrace", ex.StackTrace);
           // Email.SendEmail("error.htm", templateVars, System.Configuration.ConfigurationManager.AppSettings["email"], System.Configuration.ConfigurationManager.AppSettings["errormail"], MailSub);
        }
    }
}