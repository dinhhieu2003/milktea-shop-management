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
    public class DBHoaDon
    {
        DAO db = null;
        public DBHoaDon()
        {
            db = new DAO(DBCurrentLogin_Singleton.GetCurrentLoginInfo().UserName,
                DBCurrentLogin_Singleton.GetCurrentLoginInfo().Password);
        }
        public DataSet LayThongTinHoaDon()
        {
            return db.ExecuteQueryDataSet("select * from HoaDon", CommandType.Text, null);
        }
        public DataSet LayThongTinViewHoaDon()
        {
            return db.ExecuteQueryDataSet("select * from VW_ThongTinHoaDon", CommandType.Text, null);
        }

        public DataSet TimKiemThongTinHoaDon(string MaNV, string MaKH,
            DateTime NgayHoaDon)
        {
            string maNV = "NULL", maKH = "NULL", ngayHoaDon = "NULL";
            if (MaNV != null)
            {
                maNV = "'" + MaNV + "'";
            }
            if (MaKH != null)
            {
                maKH = "'" + MaKH + "'";
            }
            if (NgayHoaDon != new DateTime(1,1,1))
            {
                ngayHoaDon = "'" + NgayHoaDon.Date.ToString("yyyy-MM-dd") + "'";
            }
            return db.ExecuteQueryDataSet
                ("select * from dbo.Table_FN_LocHoaDon(" + maNV + ", " +
                maKH + ", " + ngayHoaDon + ")",
                CommandType.Text, null);
        }

        public string LayMaHoaDonCuaBanDangPhucVu(string MaBan)
        {
            string maBan = "'" + MaBan + "'";
            return db.MyExecuteScalar<string>
                ("select dbo.Scalar_FN_LayMaHoaDonCuaBanDangPhucVu(" +
                maBan + ")", CommandType.Text);
        }
        public string LayMaHoaDonCuaKhachMangDiDangPhucVu()
        {
            return db.MyExecuteScalar<string>
                ("select dbo.Scalar_FN_LayMaHoaDonCuaKhachMangDiDangPhucVu()",
               CommandType.Text);
        }

        public string LayMaKHTuHoaDon(string maHoaDon)
        {
            return db.MyExecuteScalar<string>
                ("select MaKH from HoaDon where MaHoaDon = " + "'" +  maHoaDon + "'" ,
                CommandType.Text);
        }
        public float TinhTongDanhSachHoaDon(string MaNV, string MaKH,
            DateTime NgayHoaDon)
        {
            string maNV = "NULL", maKH = "NULL", ngayHoaDon = "NULL";
            if (MaNV != null)
            {
                maNV = "'" + MaNV + "'";
            }
            if (MaKH != null)
            {
                maKH = "'" + MaKH + "'";
            }
            if (NgayHoaDon != new DateTime(1, 1, 1))
            {
                ngayHoaDon = "'" + NgayHoaDon.Date.ToString("yyyy-MM-dd") + "'";
            }
            return db.MyExecuteScalar<float>(
                "SELECT dbo.Scalar_FN_TinhTongTienHoaDon(" + maNV + ", " +
                maKH + ", " + ngayHoaDon + ")", CommandType.Text);
        }

        public bool ThemHoaDon(ref string error, string MaNV,
            string MaKH, string MaBan)
        {
            object maNV = MaNV, maKH = MaKH, maBan = MaBan;
            if(MaNV == null)
            {
                maNV = DBNull.Value;
            }    
            if(MaKH == null)
            {
                maKH = DBNull.Value;
            }    
            if (MaBan == null)
            {
                maBan = DBNull.Value;
            }    
            return db.MyExecuteNonQuery("USP_ThemHoaDon", CommandType.StoredProcedure,
                ref error, new SqlParameter("@manv", maNV),
                new SqlParameter("@makh", maKH),
                new SqlParameter("@maban", maBan));
        }

        public bool CapNhatHoaDon(ref string error, string MaHoaDon, 
            string MaBan, DateTime NgayGioInHoaDon, float DiemSuDung)
        {
            object maBan = MaBan;
            if (MaBan == null)
            {
                maBan = DBNull.Value;
            }
            return db.MyExecuteNonQuery("USP_CapNhatHoaDon", CommandType.StoredProcedure,
                ref error, new SqlParameter("@mahoadon", MaHoaDon),
                new SqlParameter("@maban", maBan),
                new SqlParameter("@ngaygioinhoadon", NgayGioInHoaDon),
                new SqlParameter("@DiemSuDung", DiemSuDung));
        }

        public float TinhTongDoanhThu(int Year, int Month)
        {
            return db.MyExecuteScalar<float>
                ("SELECT dbo.Scalar_FN_TinhTongTienDoanhThu(" + Year + ", " + Month + ")",
                CommandType.Text);
        }
    }
}
