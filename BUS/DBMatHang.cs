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
    public class DBMatHang
    {
        DAO db = null;
        public DBMatHang()
        {
            db = new DAO(DBCurrentLogin_Singleton.GetCurrentLoginInfo().UserName,
                DBCurrentLogin_Singleton.GetCurrentLoginInfo().Password);
        }

        public DataSet LayThongTinMatHang()
        {
            return db.ExecuteQueryDataSet("select * from MatHang", CommandType.Text, null);
        }

        public DataSet LayThongTinViewMatHang()
        {
            return db.ExecuteQueryDataSet("select * from VW_Menu", CommandType.Text, null);
        }

        public bool ThemMatHang(ref string err, string MaMH, string MaLoaiMH,
            string TenHang, float GiaTien)
        {
            return db.MyExecuteNonQuery
                ("USP_ThemMatHang", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaMH", MaMH),
                new SqlParameter("@MaLoaiMH", MaLoaiMH),
                new SqlParameter("@TenHang", TenHang),
                new SqlParameter("@GiaTien", GiaTien));
        }

        public bool SuaMatHang(ref string err, string MaMH, string MaLoaiMH,
            string TenHang, float GiaTien)
        {
            return db.MyExecuteNonQuery
                ("USP_SuaMatHang", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaMH", MaMH),
                new SqlParameter("@MaLoaiMH", MaLoaiMH),
                new SqlParameter("@TenHang", TenHang),
                new SqlParameter("@GiaTien", GiaTien));
        }
    }
}
