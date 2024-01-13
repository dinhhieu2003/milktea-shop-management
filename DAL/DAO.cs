using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAO
    {
        string ConnStr = "";
        SqlConnection conn = null;
        SqlCommand comm = null;
        SqlDataAdapter da = null;
        public DAO(string userName, string password)
        {
            ConnStr = @"Data Source=(local)\SQLEXPRESS
                    ;Initial Catalog=QUANLYQUANTRASUA;
                    User ID=" + userName + ";Password=" + password;
            conn = new SqlConnection(ConnStr);
            comm = conn.CreateCommand();
        }

        public bool checkConnect(ref string err)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Open();
            }
            catch(SqlException q)
            {
                if(q.Number == 18456)
                {
                    err = "Tài khoản hoặc mật khẩu không chính xác";
                    return false;
                }    
            }
            conn.Close();
            return true;
        }
        
        public T MyExecuteScalar<T> (string strSQL, CommandType ct)
        {
            T result = default(T);
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.CommandText= strSQL;
            comm.CommandType = ct;
            if(comm.ExecuteScalar() != DBNull.Value)
            {
                result = (T)Convert.ChangeType(comm.ExecuteScalar(), typeof(T));
            }    
            conn.Close() ;
            return result;
        }    

        public DataSet ExecuteQueryDataSet(string strSQL, CommandType ct, params SqlParameter[] p)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        public bool MyExecuteNonQuery(string strSQL, CommandType ct, ref string error, params SqlParameter[] param)
        {
            bool f = false;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            comm.Parameters.Clear();
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            foreach (SqlParameter p in param)
                comm.Parameters.Add(p);
            try
            {
                comm.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
                if(ex.Number == 229)
                {
                    error = "Bạn không có quyền thao tác";
                }    
                if(ex.Number == 2627)
                {
                    error = "Trùng khóa chính";
                } 
                
            }
            finally
            {
                conn.Close();
            }
            return f;
        }

        public void NgatKetNoi()
        {
            conn.Close();
            conn = null;
        }
    }
}