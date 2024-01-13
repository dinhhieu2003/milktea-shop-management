using DAL;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BUS
{
    public class DBLoaiMatHang
    {
        DAO db = null;
        public DBLoaiMatHang()
        {
            db = new DAO(DBCurrentLogin_Singleton.GetCurrentLoginInfo().UserName,
                DBCurrentLogin_Singleton.GetCurrentLoginInfo().Password);
        }

        public DataSet LayThongTinLoaiMatHang()
        {
            return db.ExecuteQueryDataSet
                ("select * from LoaiMatHang", CommandType.Text,
                null);
        }

        
    }
}
