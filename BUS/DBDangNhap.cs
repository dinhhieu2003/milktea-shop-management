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
    public class DBDangNhap
    {
        DAO db = null;
        public DBDangNhap() 
        {
            db = new DAO(DBCurrentLogin_Singleton.GetCurrentLoginInfo().UserName,
                DBCurrentLogin_Singleton.GetCurrentLoginInfo().Password);
        }

        public DataSet LayThongTinDangNhap()
        {
            return db.ExecuteQueryDataSet("select MaNV, TenNguoiDung, MatKhau " +
                "from DangNhap", CommandType.Text, null);
        }    

        public DataSet LayThongTinViewDangNhap()
        {
            return db.ExecuteQueryDataSet("select * from VW_ThongTinDangNhap", CommandType.Text, null);
        }

        public string LayMaNVDangNhap(string userName)
        {
            return db.MyExecuteScalar<string>
                ("select dbo.Scalar_FN_LayMaNVDangNhap('" + userName + "'" + ")",
                CommandType.Text);
        }

        public DataSet LayThongTinNhanVienDangNhap(string userName)
        {
            return db.ExecuteQueryDataSet
                ("select * from Table_FN_LayThongTinNhanVienDangNhap('" + userName + "'" + ")",
                CommandType.Text, null);
        }

        public bool ThemTaiKhoan(ref string err, string MaNV, string TenNguoiDung,
            string MatKhau, string MaNhomNguoiDung)
        {
            return db.MyExecuteNonQuery("USP_ThemTaiKhoan",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaNV", MaNV),
                new SqlParameter("@TenNguoiDung", TenNguoiDung),
                new SqlParameter("@MatKhau", MatKhau),
                new SqlParameter("@MaNhomNguoiDung", MaNhomNguoiDung));
        }

        public bool GanQuyenTaiKhoan(ref string err, string TenNguoiDung,
            string MaNhomNguoiDung)
        {
            return db.MyExecuteNonQuery("USP_GanQuyenTaiKhoan",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@TenNguoiDung", TenNguoiDung),
                new SqlParameter("@MaNhomNguoiDung", MaNhomNguoiDung));
        }

        public bool DoiMatKhau(ref string err, string TenNguoiDung,
            string MatKhau)
        {
            return db.MyExecuteNonQuery("USP_DoiMatKhau",
                CommandType.StoredProcedure, ref err,
                new SqlParameter("@TenNguoiDung", TenNguoiDung),
                new SqlParameter("@MatKhau", MatKhau));
        }
    }
}
