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
    public class DBXuatKho
    {
        DAO db = null;
        public DBXuatKho()
        {
            db = new DAO(DBCurrentLogin_Singleton.GetCurrentLoginInfo().UserName,
                DBCurrentLogin_Singleton.GetCurrentLoginInfo().Password);
        }

        public DataSet LayThongTinViewXuatKho()
        {
            return db.ExecuteQueryDataSet("select * from VW_ThongTinXuatKho",
                CommandType.Text, null);
        }    
        public bool ThaoTacXuatKho(ref string err, string MaNVL, string MaKho, 
            int SoLuongXuat, DateTime NgayGioXuat)
        {
            string ngayGioXuat = NgayGioXuat.ToString("yyyy-MM-dd HH:mm:ss");
            return db.MyExecuteNonQuery("USP_ThaoTacXuatKho",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaNVL", MaNVL),
                new SqlParameter("@MaKho", MaKho),
                new SqlParameter("@SoLuongXuat", SoLuongXuat),
                new SqlParameter("@NgayGioXuat", ngayGioXuat));
        }

        public DataSet TimKiemThongTinXuatKho(DateTime NgayXuat, string TenNVL)
        {
            string ngayXuat = "NULL", tenNVL = "NULL";
            if (NgayXuat != new DateTime(1, 1, 1))
            {
                ngayXuat = "'" + NgayXuat.Date.ToString("yyyy-MM-dd") + "'";
            }
            if (TenNVL != null)
            {
                tenNVL = "N'" + TenNVL + "'";
            }
            return db.ExecuteQueryDataSet
                ("select * from Table_FN_LocXuatKho(" + ngayXuat + ", " +
                 tenNVL + ")", CommandType.Text, null);
        }
    }
}
