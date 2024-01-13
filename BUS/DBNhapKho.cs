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
    public class DBNhapKho
    {
        DAO db = null;
        public DBNhapKho()
        {
            db = new DAO(DBCurrentLogin_Singleton.GetCurrentLoginInfo().UserName,
                DBCurrentLogin_Singleton.GetCurrentLoginInfo().Password);
        }

        public DataSet LayThongTinViewNhapKho()
        {
            return db.ExecuteQueryDataSet("select * from VW_ThongTinNhapKho",
                CommandType.Text, null);
        }

        public DataSet TimKiemThongTinNhapKho(DateTime NgayThang, string TenNVL)
        {
            string ngayThang = "NULL", tenNVL = "NULL";
            if (NgayThang != new DateTime(1, 1, 1))
            {
                ngayThang = "'" + NgayThang.Date.ToString("yyyy-MM-dd") + "'";
            }
            if (TenNVL != null)
            {
                tenNVL = "N'" + TenNVL + "'";
            }
            return db.ExecuteQueryDataSet
                ("select * from Table_FN_LocNhapKho(" + ngayThang + ", " +
                 tenNVL + ")", CommandType.Text, null);
        }

        public bool ThaoTacNhapKho(ref string error, string MaNVL,
            int SoLuong, DateTime GioNhap, DateTime NgayThang, string HSD)
        {
            string gioNhap = GioNhap.ToString("HH:mm:ss");
            string ngayThang = NgayThang.ToString("yyyy-MM-dd");
            return db.MyExecuteNonQuery("USP_ThaoTacNhapKho", 
                CommandType.StoredProcedure,
                ref error, new SqlParameter("@MaNVL", MaNVL),
                new SqlParameter("@SoLuongNhap", SoLuong),
                new SqlParameter("@GioNhap", gioNhap),
                new SqlParameter("@NgayThang", ngayThang),
                new SqlParameter("@HSD", HSD));
        }
    }
}
