 
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace VigProject_Api.Utility
{
    public class DBClass : IDisposable
    {

        SqlConnection _con;
        SqlCommand _cmd;
        SqlTransaction _transaction = null;
        
        public DBClass(string commandText, CommandType _commandType, string _dbname)
        {
            //strConnection = Startup.ConnectionString;
            _con = new SqlConnection(_dbname);

            if (_con.State == ConnectionState.Closed)
            {
                _con.Open();
                _transaction = _con.BeginTransaction();
            }

            _cmd = new SqlCommand((commandText));
            _cmd.CommandTimeout = 10 * 60;
            _cmd.CommandType = _commandType;
            _cmd.Connection = _con;
        }

        public SqlConnection ReturnConnection()
        {
            return _con;
        }

        public DataTable ReturnDataTable()
        {
            using (DataTable dt = new DataTable())
            {
                dt.Load(_cmd.ExecuteReader());
                return dt;
            }
        }
        public DataSet ReturnDataSet()
        {
            using (DataSet ds = new DataSet())
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(_cmd))
                {
                    adapter.Fill(ds);
                }
                return ds;
            }
        }
        public string ReturnString()
        {
            return Convert.ToString(_cmd.ExecuteScalar());
        }
        public void AddParameters(string pname, byte[] pvalue)
        {
            _cmd.Parameters.Add(pname, SqlDbType.Binary).Value = pvalue;
        }

        public void ExecuteNonQuery()
        {
            _cmd.ExecuteNonQuery();
        }
        public Int64 ReturnNumber()
        {
            return (Int64)_cmd.ExecuteScalar();
        }
        public Int64 ReturnValueExecuteNonQuery(string pname)
        {
            _cmd.ExecuteNonQuery();
            return (Int64)_cmd.Parameters[pname].Value;
        }

        public void AddOutParameters(string pname)
        {
            _cmd.Parameters.Add(pname, SqlDbType.BigInt).Direction = ParameterDirection.Output;
        }

        public void AddParameters(string pname, string pvalue)
        {
            _cmd.Parameters.Add(pname, SqlDbType.Text).Value = pvalue;
        }

        public void AddParameters(string pname, int pvalue)
        {
            _cmd.Parameters.Add(pname, SqlDbType.Int).Value = pvalue;
        }

        public void AddParameters(string pname, Int16 pvalue)
        {
            _cmd.Parameters.Add(pname, SqlDbType.SmallInt).Value = pvalue;
        }

        public void AddParameters(string pname, Int64 pvalue)
        {
            _cmd.Parameters.Add(pname, SqlDbType.BigInt).Value = pvalue;
        }

        public void AddParameters(string pname, bool pvalue)
        {
            _cmd.Parameters.Add(pname, SqlDbType.Bit).Value = pvalue;
        }

        public void AddParameters(string pname, double pvalue)
        {
            _cmd.Parameters.Add(pname, SqlDbType.Float).Value = pvalue;
        }

        public void AddParameters(string pname, DateTime pvalue)
        {
            _cmd.Parameters.Add(pname, SqlDbType.Date).Value = pvalue;
        }

        public void AddParameters(string pname, Decimal pvalue)
        {
            _cmd.Parameters.Add(pname, SqlDbType.Decimal).Value = pvalue;
        }

        public int ReturnExecuteNonQuery()
        {
            return (int)_cmd.ExecuteNonQuery();
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                if (_transaction.Connection != null)
                    _transaction.Commit();
            }
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Rollback_Transaction()
        {
            _transaction.Rollback();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // get rid of managed resources
                if (_con != null)
                {
                    if (_con.State == ConnectionState.Open)
                    {
                        _con.Close();
                        _con.Dispose();
                    }
                }
                _cmd.Dispose();
            }
            // get rid of unmanaged resources
        }


    }
}
