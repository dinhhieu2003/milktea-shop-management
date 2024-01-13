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
    public class DBNhanVien
    {
        DAO db = null;
        public DBNhanVien()
        {
            db = new DAO(DBCurrentLogin_Singleton.GetCurrentLoginInfo().UserName,
                DBCurrentLogin_Singleton.GetCurrentLoginInfo().Password);
        }
        public DataSet LayThongTinNhanVien()
        {
            return db.ExecuteQueryDataSet("select * from NhanVien", CommandType.Text, null);
        }

        public DataSet LayThongTinNhanVienDangLam()
        {
            return db.ExecuteQueryDataSet(
                "select * from NhanVien where TinhTrang LIKE N'Đang làm'", CommandType.Text, null);
        }

        public DataSet LayThongTinViewNhanVien()
        {
            return db.ExecuteQueryDataSet("select * from VW_ThongTinNV", CommandType.Text, null);
        }

        public DataSet TimKiemThongTinNhanVien(string MaNV, string HoTen, string TenChucVu)
        {
            string maNV = "NULL", hoTen = "NULL", tenChucVu = "NULL";
            if(MaNV != null)
            {
                maNV = "'" + MaNV +"'";
            }    
            if(HoTen != null)
            {
                hoTen = "N'" + HoTen +"'";
            }    
            if(TenChucVu != null)
            {
                tenChucVu = "N'" + TenChucVu +"'";
            }    
            return db.ExecuteQueryDataSet
                ("select * from dbo.Table_FN_LocNhanVien(" + maNV + ", " + 
                hoTen + ", " + tenChucVu +")", 
                CommandType.Text, null);
        }

        public bool ThemNhanVien(ref string error, string MaChucVu, 
            string HoTen, DateTime NgaySinh, string GioiTinh, DateTime NgayBatDauLam,
            string SDT, string TinhTrang)
        {
            return db.MyExecuteNonQuery("usp_ThemNhanVien", CommandType.StoredProcedure,
                ref error, new SqlParameter("@MaChucVu", MaChucVu),
                new SqlParameter("@HoTen", HoTen),
                new SqlParameter("@NgaySinh", NgaySinh.Date),
                new SqlParameter("@GioiTinh", GioiTinh),
                new SqlParameter("@NgayBatDauLam", NgayBatDauLam.Date),
                new SqlParameter("@SDT", SDT),
                new SqlParameter("@TinhTrang", TinhTrang));
        }

        public bool XoaNhanVien(ref string error, string MaNV)
        {
            return db.MyExecuteNonQuery("usp_XoaNhanVien", CommandType.StoredProcedure,
                ref error, new SqlParameter("@MaNV", MaNV));
        }

        public bool CapNhatNhanVien(ref string error, string MaNV, string MaChucVu,
            string HoTen, DateTime NgaySinh, string GioiTinh, DateTime NgayBatDauLam,
            string SDT, string TinhTrang)
        {
            return db.MyExecuteNonQuery("usp_SuaNhanVien", CommandType.StoredProcedure,
                ref error, new SqlParameter("@MaNV", MaNV),
                new SqlParameter("@MaChucVu", MaChucVu),
                new SqlParameter("@HoTen", HoTen),
                new SqlParameter("@NgaySinh", NgaySinh.Date),
                new SqlParameter("@GioiTinh", GioiTinh),
                new SqlParameter("@NgayBatDauLam", NgayBatDauLam.Date),
                new SqlParameter("@SDT", SDT),
                new SqlParameter("@TinhTrang", TinhTrang));
        }
    }
}
