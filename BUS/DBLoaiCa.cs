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
    public class DBLoaiCa
    {
        DAO db = null;
        public DBLoaiCa()
        {
            db = new DAO(DBCurrentLogin_Singleton.GetCurrentLoginInfo().UserName,
                DBCurrentLogin_Singleton.GetCurrentLoginInfo().Password);
        }
        public DataSet LayThongTinLoaiCa()
        {
            return db.ExecuteQueryDataSet("select * from LoaiCa", CommandType.Text, null);
        }

        public DataSet LayThongTinViewLoaiCa()
        {
            return db.ExecuteQueryDataSet("select * from VW_LoaiCaLam", CommandType.Text, null);
        }

        public bool ThemLoaiCa(ref string error, string MaLoaiCa, string TenLoaiCa,
            TimeSpan GioBatDau, TimeSpan GioKetThuc, float TienThuongCa)
        {
            return db.MyExecuteNonQuery("usp_ThemLoaiCa", CommandType.StoredProcedure,
                ref error, new SqlParameter("@MaLoaiCa", MaLoaiCa),
                new SqlParameter("@TenLoaiCa", TenLoaiCa),
                new SqlParameter("@GioBatDau", GioBatDau),
                new SqlParameter("@GioKetThuc", GioKetThuc),
                new SqlParameter("@TienThuongCa", TienThuongCa));
        }

        public bool XoaCaLam(ref string error, string MaCa)
        {
            return db.MyExecuteNonQuery("USP_XoaCaLam", CommandType.StoredProcedure,
                ref error, new SqlParameter("@MaCa", MaCa));
        }

        public bool CapNhatLoaiCa(ref string error, string MaLoaiCa, string TenLoaiCa,
            TimeSpan GioBatDau, TimeSpan GioKetThuc, float TienThuongCa)
        {
            return db.MyExecuteNonQuery("usp_SuaLoaiCa", CommandType.StoredProcedure,
                ref error, new SqlParameter("@MaLoaiCa", MaLoaiCa),
                new SqlParameter("@TenLoaiCa", TenLoaiCa),
                new SqlParameter("@GioBatDau", GioBatDau),
                new SqlParameter("@GioKetThuc", GioKetThuc),
                new SqlParameter("@TienThuongCa", TienThuongCa));
        }
    }
}
