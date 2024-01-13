using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class DBBan
    {
        DAO db = null;
        public DBBan() 
        {
            db = new DAO(DBCurrentLogin_Singleton.GetCurrentLoginInfo().UserName,
                DBCurrentLogin_Singleton.GetCurrentLoginInfo().Password);
        }
        public DataSet LayThongTinBan()
        {
            return db.ExecuteQueryDataSet("select * from Ban", CommandType.Text, null);
        }

        public string LayTrangThaiBan(string MaBan)
        {
            return db.MyExecuteScalar<string>("select TrangThai from Ban " +
                "WHERE MaBan = " + "'" + MaBan + "'", CommandType.Text);
        }
    }
}
