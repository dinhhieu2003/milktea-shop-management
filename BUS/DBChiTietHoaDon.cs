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
    public class DBChiTietHoaDon
    {
        DAO db = null;
        public DBChiTietHoaDon()
        {
            db = new DAO(DBCurrentLogin_Singleton.GetCurrentLoginInfo().UserName,
                DBCurrentLogin_Singleton.GetCurrentLoginInfo().Password);
        }

        public DataSet LayThongTinChiTietHoaDon()
        {
            return db.ExecuteQueryDataSet("select * from ChiTietHoaDon", CommandType.Text, null);
        }

        public DataSet LayViewChiTietHoaDon()
        {
            return db.ExecuteQueryDataSet("select * from VW_ChiTietHoaDon", CommandType.Text, null);
        }
        public DataSet LayCTHDBanDangPhucVu(string MaBan)
        {
            string maBan = "'" + MaBan + "'";
            return db.ExecuteQueryDataSet("select * " +
                "from Table_FN_LayChiTietHoaDonCuaBanDangPhucVu (" + maBan + ")", 
                CommandType.Text, null);
        }
        public DataSet LayCTHDKhachMangDiDangPhucVu()
        {
            return db.ExecuteQueryDataSet("select * " +
                "from Table_FN_LayCTHDCuaKhachMangDiDangPhucVu ()" ,
                CommandType.Text, null);
        }

        public DataSet TimKiemThongTinCTHD(string MaHoaDon)
        {
            return db.ExecuteQueryDataSet("select * from " +
                "Table_FN_TimKiemChiTietHoaDon(" + "'" + MaHoaDon + "'" + ")",
                CommandType.Text, null);
        }

        public float LayTongSoTienCTHD(string MaHoaDon)
        {
            return db.MyExecuteScalar<float>
                ("select dbo.Scalar_FN_LayTongSoTienCTHD(" + 
                "'" + MaHoaDon + "'" + ")", CommandType.Text);
        }

        public bool ThemChiTietHoaDon(ref string error, string MaHoaDon, string MaMH,
            int SoLuongMH)
        {
            return db.MyExecuteNonQuery("USP_ThemChiTietHoaDon", CommandType.StoredProcedure,
                ref error, new SqlParameter("@MaHoaDon", MaHoaDon),
                new SqlParameter("@MaMH", MaMH),
                new SqlParameter("@SoLuongMH", SoLuongMH)
                );
        }

        public bool XoaChiTietHoaDon(ref string error, string MaHoaDon, string MaMH)
        {
            return db.MyExecuteNonQuery("USP_XoaChiTietHoaDon", CommandType.StoredProcedure,
                ref error, new SqlParameter("@MaHoaDon", MaHoaDon),
                new SqlParameter("@MaMH", MaMH));
        }

        public bool CapNhatChiTietHoaDon(ref string error, string MaHoaDon, string MaMH,
            int SoLuongMH)
        {
            return db.MyExecuteNonQuery("USP_SuaChiTietHoaDon", CommandType.StoredProcedure,
                ref error, new SqlParameter("@MaHoaDon", MaHoaDon),
                new SqlParameter("@MaMH", MaMH),
                new SqlParameter("@SoLuongMH", SoLuongMH));
        }
        public DataSet TimKiemSanPhamBanChay(string Thang, string Nam)
        {
            string thang = null, nam = null;
            thang = "'" + Thang + "'";
            nam = "'" + Nam + "'";
            return db.ExecuteQueryDataSet("select * from " +
                "Table_FN_LocSanPhamBanChay(" + thang + ", " + nam + ")", CommandType.Text, null);
        }
        public DataSet LayViewDanhMucSanPhamBanChay()
        {
            return db.ExecuteQueryDataSet("select * from VW_DanhMucSanPhamBanChay", CommandType.Text, null);
        }


    }

}
