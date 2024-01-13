using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DBLoaiKhachHang
    {
        DAO db = null;
        public DBLoaiKhachHang()
        {
            db = new DAO(DBCurrentLogin_Singleton.GetCurrentLoginInfo().UserName,
                DBCurrentLogin_Singleton.GetCurrentLoginInfo().Password);
        }

        public DataSet LayThongTinLoaiKhachHang()
        {
            return db.ExecuteQueryDataSet("select * from LoaiKhachHang", CommandType.Text, null);
        }
    }
}
