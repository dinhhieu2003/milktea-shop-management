using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DBPhieuMua
    {
        DAO db = null;
        public DBPhieuMua()
        {
            db = new DAO(DBCurrentLogin_Singleton.GetCurrentLoginInfo().UserName,
                DBCurrentLogin_Singleton.GetCurrentLoginInfo().Password);
        }
        public DataSet LayThongTinPhieuMua()
        {
            return db.ExecuteQueryDataSet("select * from PhieuMua", CommandType.Text, null);
        }
        public bool ThemPhieuMua(ref string error, DateTime NgayGioMua)
        {
            return db.MyExecuteNonQuery("USP_ThemPhieuMua", CommandType.StoredProcedure,
                ref error, new SqlParameter("@NgayGioMua", NgayGioMua));
        }
    }
}
