using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class DBKhachHang
    {
        DAO db = null;
        public DBKhachHang()
        {
            db = new DAO(DBCurrentLogin_Singleton.GetCurrentLoginInfo().UserName,
                DBCurrentLogin_Singleton.GetCurrentLoginInfo().Password);
        }

        public DataSet LayThongTinKhachHang()
        {
            return db.ExecuteQueryDataSet("select * from KhachHang", CommandType.Text, null);
        }

        public DataSet LayThongTinViewKhachHang()
        {
            return db.ExecuteQueryDataSet("select * from VW_ThongTinKhachHang", CommandType.Text, null);
        }

        public bool ThemKhachHang(ref string error, string MaLoaiKH,
            string TenKH, string DiaChi, string SDT, float DiemTichLuyHienTai,
            float TongDiemTichLuy)
        {
            return db.MyExecuteNonQuery("USP_ThemKhachHang", CommandType.StoredProcedure,
                ref error, new SqlParameter("@maloaikh", MaLoaiKH),
                new SqlParameter("@tenkh", TenKH),
                new SqlParameter("@diachi", DiaChi),
                new SqlParameter("@sdt", SDT),
                new SqlParameter("@currentpoint", DiemTichLuyHienTai),
                new SqlParameter("@totalpoint", TongDiemTichLuy));
        }

        public bool CapNhatKhachHang(ref string error, string MaKH, string TenKH,
            string MaLoaiKH, string DiaChi, string SDT, float DiemTichLuyHienTai,
            float TongDiemTichLuy)
        {
            return db.MyExecuteNonQuery("USP_SuaKhachHang", CommandType.StoredProcedure,
                ref error, new SqlParameter("@makh", MaKH),
                new SqlParameter("@tenkh", TenKH),
                new SqlParameter("@maloaikh", MaLoaiKH),
                new SqlParameter("@diachi", DiaChi),
                new SqlParameter("@sdt", SDT),
                new SqlParameter("@currentpoint", DiemTichLuyHienTai),
                new SqlParameter("@totalpoint", TongDiemTichLuy));
        }

        public DataSet TimKiemThongTinKhachHang(string MaKH, string TenKH, string TenLoaiKH)
        {
            string maKH = "NULL", tenKH = "NULL", tenLoaiKH = "NULL";
            if (MaKH != null)
            {
                maKH = "'" + MaKH + "'";
            }
            if (TenKH != null)
            {
                tenKH = "N'" + TenKH + "'";
            }
            if (TenLoaiKH != null)
            {
                tenLoaiKH = "N'" + TenLoaiKH + "'";
            }
            return db.ExecuteQueryDataSet
                ("select * from dbo.Table_FN_LocThongTinKhachHang(" + maKH + ", " +
                tenKH + ", " + tenLoaiKH + ")",
                CommandType.Text, null);
        }
    }
}