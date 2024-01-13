using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class DBCaLam
    {
        DAO db = null;
        public DBCaLam()
        {
            db = new DAO(DBCurrentLogin_Singleton.GetCurrentLoginInfo().UserName,
                DBCurrentLogin_Singleton.GetCurrentLoginInfo().Password);
        }
        public DataSet LayThongTinCaLam()
        {
            return db.ExecuteQueryDataSet("select * from CaLam", CommandType.Text, null);
        }

        public DataSet LayThongTinViewCaLam()
        {
            return db.ExecuteQueryDataSet("select * from VW_CaLam", CommandType.Text, null);
        }

        public DataSet TimKiemThongTinCaLam(string MaLoaiCa, DateTime NgayLam)
        {
            string maLoaiCa = "NULL", ngayLam = "NULL";
            if (MaLoaiCa != null)
            {
                maLoaiCa = "'" + MaLoaiCa + "'";
            }
            if (NgayLam != new DateTime(1,1,1))
            {
                ngayLam = "'" + NgayLam.ToString("yyyy-MM-dd") + "'" ;
            }
            
            return db.ExecuteQueryDataSet
                ("select * from dbo.Table_FN_LocCaLam(" + maLoaiCa + ", " + ngayLam + ")",
                CommandType.Text, null);
        }

        public bool ThemCaLam(ref string error, string MaLoaiCa, DateTime NgayLam)
        {
            return db.MyExecuteNonQuery("USP_ThemCaLam", CommandType.StoredProcedure,
                ref error, new SqlParameter("@MaLoaiCa", MaLoaiCa),
                new SqlParameter("@NgayLam", NgayLam.Date));
        }

    }
}
