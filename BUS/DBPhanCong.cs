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
    public class DBPhanCong
    {
        DAO db = null;
        public DBPhanCong()
        {
            db = new DAO(DBCurrentLogin_Singleton.GetCurrentLoginInfo().UserName,
                DBCurrentLogin_Singleton.GetCurrentLoginInfo().Password);
        }
        public DataSet LayThongTinPhanCong()
        {
            return db.ExecuteQueryDataSet("select * from PhanCong", CommandType.Text, null);
        }

        public DataSet LayThongTinViewPhanCong()
        {
            return db.ExecuteQueryDataSet("select * from VW_PhanCong", CommandType.Text, null);
        }

        public DataSet TimKiemThongTinPhanCong(string MaNV, string TenLoaiCa,
            DateTime NgayLam)
        {
            string maNV = "NULL", tenLoaiCa = "NULL", ngayLam = "NULL";
            if (MaNV != null)
            {
                maNV = "'" + MaNV + "'";
            }
            if (TenLoaiCa != null)
            {
                tenLoaiCa = "N'" + TenLoaiCa + "'";
            }
            if (NgayLam != new DateTime(1, 1, 1))
            {
                ngayLam = "'" + NgayLam.ToString("yyyy-MM-dd") + "'";
            }
            return db.ExecuteQueryDataSet("select * from Table_FN_LocPhanCong(" +
                maNV + "," + tenLoaiCa + "," + ngayLam + ")", CommandType.Text,
                null);
        }

        public bool ThemPhanCong(ref string error, string MaNV, string MaCa)
        {
            return db.MyExecuteNonQuery("USP_ThemPhanCong", CommandType.StoredProcedure,
                ref error, new SqlParameter("@MaNV", MaNV),
                new SqlParameter("@MaCa", MaCa));
        }

        public bool XoaPhanCong(ref string error, string MaNV, string MaCa)
        {
            return db.MyExecuteNonQuery("USP_XoaPhanCong", CommandType.StoredProcedure,
                ref error, new SqlParameter("@MaNV", MaNV),
                new SqlParameter("@MaCa", MaCa));
        }

        public bool DiemDanhPhanCong(ref string error, string MaNV, string MaLoaiCa,
            DateTime NgayLam, int DiemDanh)
        {
            return db.MyExecuteNonQuery("USP_DiemDanhPhanCong", CommandType.StoredProcedure,
                ref error, new SqlParameter("@MaNV", MaNV),
                new SqlParameter("@MaLoaiCa", MaLoaiCa),
                new SqlParameter("@NgayLam", NgayLam),
                new SqlParameter("@DiemDanh", DiemDanh));
        }
    }
}
