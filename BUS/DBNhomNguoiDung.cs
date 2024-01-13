using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DBNhomNguoiDung
    {
        DAO db = null;
        public DBNhomNguoiDung()
        {
            db = new DAO(DBCurrentLogin_Singleton.GetCurrentLoginInfo().UserName,
                DBCurrentLogin_Singleton.GetCurrentLoginInfo().Password);
        }

        public DataSet LayThongTinNhomNguoiDung()
        {
            return db.ExecuteQueryDataSet("select * from NhomNguoiDung",
                CommandType.Text, null);
        }
    }
}
