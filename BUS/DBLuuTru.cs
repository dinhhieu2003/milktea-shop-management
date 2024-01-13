using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DBLuuTru
    {
        DAO db = null;
        public DBLuuTru() 
        {
            db = new DAO(DBCurrentLogin_Singleton.GetCurrentLoginInfo().UserName,
                DBCurrentLogin_Singleton.GetCurrentLoginInfo().Password);
        }
        public DataSet LayThongTinLuuTru()
        {
            return db.ExecuteQueryDataSet("select * from LuuTru",
                CommandType.Text, null);
        }    

        public DataSet LayThongTinViewLuuTru()
        {
            return db.ExecuteQueryDataSet("select * from VW_LuuTruKho",
                CommandType.Text, null);
        }

        public DataSet TimKiemThongTinKhoLuuTru(DateTime NgayThang, string TenNVL)
        {
            string ngayThang = "NULL", tenNVL = "NULL";
            if (NgayThang != new DateTime(1, 1, 1))
            {
                ngayThang = "'" + NgayThang.Date.ToString("yyyy-MM-dd") + "'";
            }
            if (TenNVL != null)
            {
                tenNVL = "N'" + TenNVL + "'";
            }
            return db.ExecuteQueryDataSet
                ("select * from Table_FN_LocKhoLuuTru(" + ngayThang + ", " +
                 tenNVL + ")",
                CommandType.Text, null);
        }
    }
}
