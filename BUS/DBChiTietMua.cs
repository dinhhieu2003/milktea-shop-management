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
    public class DBChiTietMua
    {
        DAO db = null;
        public DBChiTietMua()
        {
            db = new DAO(DBCurrentLogin_Singleton.GetCurrentLoginInfo().UserName,
                DBCurrentLogin_Singleton.GetCurrentLoginInfo().Password);
        }
        public DataSet LayThongTinChiTietMua()
        {
            return db.ExecuteQueryDataSet("select * from ChiTietMua", CommandType.Text, null);
        }
        public DataSet LayThongTinViewChiTietMua()
        {
            return db.ExecuteQueryDataSet("select * from VW_ChiTietMua", CommandType.Text, null);
        }
        public bool SuaChiTietMua(ref string error, string MaPhieuMua, string MaNVL, int SoLuongNVL)
        {
            return db.MyExecuteNonQuery("USP_SuaChiTietMua", CommandType.StoredProcedure,
                ref error, new SqlParameter("@MaPhieuMua", MaPhieuMua),
                new SqlParameter("@MaNVL", MaNVL),
                new SqlParameter("@SoLuongNVL", SoLuongNVL));
        }
        public bool ThemChiTietMua(ref string err, string MaPhieuMua, string MaNVl, int SoLuongNVL)
        {
            return db.MyExecuteNonQuery("USP_ThemChitietMua", CommandType.StoredProcedure,
                ref err, new SqlParameter("@MaPhieuMua", MaPhieuMua),
                    new SqlParameter("@MaNVL", MaNVl),
                    new SqlParameter("@SoLuongNVL", SoLuongNVL));
        }
        public bool XoaChiTietMua(ref string err, string MaPhieuMua, string MaNVL)
        {
            return db.MyExecuteNonQuery("USP_XoaChiTietMua", CommandType.StoredProcedure,
                ref err, new SqlParameter("@MaPhieuMua", MaPhieuMua),
                new SqlParameter("@MaNVL", MaNVL));
        }
        public float TinhTongDanhSachPhieuMua(string MaPhieuMua, string TenNVL, DateTime NgayGioMua)
        {
            string maphieumua = "NULL", tennvl = "NULL", ngaygiomua = "NULL";
            if (MaPhieuMua != null)
            {
                maphieumua = "'" + MaPhieuMua + "'";
            }
            if (TenNVL != null)
            {
                tennvl = "N'" + TenNVL + "'";
            }
            if (NgayGioMua != new DateTime(1, 1, 1))
            {
              ngaygiomua = "'" + NgayGioMua.Date.ToString("yyyy-MM-dd") + "'";
            }

            return db.MyExecuteScalar<float>
                ("select dbo.Scalar_FN_TinhTongTienPhieuMua(" + maphieumua + ", " +
                tennvl + ", " + ngaygiomua + ")", CommandType.Text);
        }
        public DataSet TimKiemChiTietPhieuMua(string MaPhieuMua, string TenNVL, DateTime NgayGioMua)
        {
            string maphieumua = "NULL", tennvl = "NULL", ngaygiomua = "NULL";
            if (MaPhieuMua != null)
            {
                maphieumua = "'" + MaPhieuMua + "'";
            }
            if (TenNVL != null)
            {
                tennvl = "N'" + TenNVL + "'";
            }
            if (NgayGioMua != new DateTime(1,1,1))
            {
                ngaygiomua = "'" + NgayGioMua.Date.ToString("yyyy-MM-dd") + "'";
            }

            return db.ExecuteQueryDataSet
                ("select * from dbo.Table_FN_LocChiTietMua(" + maphieumua + ", " +
                tennvl + ", " + ngaygiomua + ")", CommandType.Text, null);
        }
    }
}
