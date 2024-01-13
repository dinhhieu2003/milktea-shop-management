using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DBChiTietLuongNgay
    {
        DAO db = null;
        public DBChiTietLuongNgay()
        {
            db = new DAO(DBCurrentLogin_Singleton.GetCurrentLoginInfo().UserName,
                DBCurrentLogin_Singleton.GetCurrentLoginInfo().Password);
        }
        public DataSet LayThongTinChiTietLuongNgay()
        {
            return db.ExecuteQueryDataSet("select * from ChiTietLuongNgay", CommandType.Text, null);
        }
        public DataSet LayThongTinViewChiTietLuongNgay()
        {
            return db.ExecuteQueryDataSet("select * from VW_ChiTietLuong", CommandType.Text, null);
        }
        public DataSet TimKiemTongLuong(string MaNV)
        {
            string manv = "NULL";
            if (MaNV != null)
                manv = "'" + MaNV + "'";
            return db.ExecuteQueryDataSet
                ("select * from dbo.Table_FN_TimKiemLuongNV(" + manv + ")", CommandType.Text, null);
        }
        public DataSet TimKiemChiTietLuong(string MaNV, string MaCa, string ChucVu)
        {
            string manv = "NULL", maca = "NULL", chucvu = "NULL";
            if (MaNV != null)
            {
                manv = "'" + MaNV + "'";
            }
            if (MaCa != null)
            {
                maca = "'" + MaCa + "'";
            }
            if (ChucVu != null)
            {
                chucvu = "N'" + ChucVu + "'";
            }
            return db.ExecuteQueryDataSet
                ("select * from dbo.Table_FN_LocChiTietLuong(" + manv + ", " +
                maca + ", " + chucvu + ")",
                CommandType.Text, null);
        }
        public bool ThemChiTietLuong(ref string error, string MaNV, string MaCa,
            string MaChucVu, DateTime NgayLuong, float ThanhTien, DateTime KyLuong)
        {
            return db.MyExecuteNonQuery("usp_ThemChiTietLuong", CommandType.StoredProcedure,
                ref error, new SqlParameter("@MaNV", MaNV),
                new SqlParameter("@MaCa", MaCa),
                new SqlParameter("@MaChucVu", MaChucVu),
                new SqlParameter("@NgayLuong", NgayLuong.Date),
                new SqlParameter("@ThanhTien", ThanhTien),
                new SqlParameter("@KyLuong", KyLuong.Date));
        }
        public bool XoaChiTietLuong(ref string error, string MaNV, string MaCa)
        {
            return db.MyExecuteNonQuery("usp_XoaChiTietLuong", CommandType.StoredProcedure,
                ref error, new SqlParameter("@MaNV", MaNV),
                new SqlParameter("@MaCa", MaCa));
        }
        public bool CapNhatChiTietLuong(ref string error, string MaNV, string MaCa,
            string MaChucVu, DateTime NgayLuong, float ThanhTien, DateTime KyLuong)
        {
            return db.MyExecuteNonQuery("usp_SuaChiTietLuong", CommandType.StoredProcedure,
                ref error, new SqlParameter("@MaNV", MaNV),
                new SqlParameter("@MaCa", MaCa),
                new SqlParameter("@MaChucVu", MaChucVu),
                new SqlParameter("@NgayLuong", NgayLuong.Date),
                new SqlParameter("@ThanhTien", ThanhTien),
                new SqlParameter("@KyLuong", KyLuong.Date));
        }
    }
}
