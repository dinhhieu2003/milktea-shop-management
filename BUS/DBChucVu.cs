using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DBChucVu
    {
        DAO db = null;
        public DBChucVu()
        {
            db = new DAO(DBCurrentLogin_Singleton.GetCurrentLoginInfo().UserName,
                DBCurrentLogin_Singleton.GetCurrentLoginInfo().Password);
        }

        public DataSet LayThongTinChucVu()
        {
            return db.ExecuteQueryDataSet("select * from ChucVu", CommandType.Text, null);
        }

        public DataSet LayThongTinViewChucVu()
        {
            return db.ExecuteQueryDataSet("select * from VW_ThongTinChucVu", CommandType.Text, null);
        }

        public DataSet TimKiemThongTinChucVu(string TenChucVu)
        {
            return db.ExecuteQueryDataSet
                ("select * from dbo.Table_FN_LocChucVu(" + "'" + TenChucVu + "'" + ")",
                CommandType.Text, null);
        }

        public bool ThemChucVu(ref string error, string MaChucVu, string TenChucVu,
            float LuongMotGioLam)
        {
            return db.MyExecuteNonQuery("usp_ThemChucVu", CommandType.StoredProcedure,
                ref error, new SqlParameter("@MaChucVu", MaChucVu),
                new SqlParameter("@TenChucVu", TenChucVu),
                new SqlParameter("@LuongMotGioLam", LuongMotGioLam));
        }

        public bool CapNhatChucVu(ref string error, string MaChucVu, string TenChucVu,
            float LuongMotGioLam)
        {
            return db.MyExecuteNonQuery("usp_SuaChucVu", CommandType.StoredProcedure,
                ref error, new SqlParameter("@MaChucVu", MaChucVu),
                new SqlParameter("@TenChucVu",TenChucVu),
                new SqlParameter("@LuongMotGioLam", LuongMotGioLam));
        }

    }
}
