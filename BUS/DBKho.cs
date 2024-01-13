using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DBKho
    {
        DAO db = null;
        public DBKho()
        {
            db = new DAO(DBCurrentLogin_Singleton.GetCurrentLoginInfo().UserName,
                DBCurrentLogin_Singleton.GetCurrentLoginInfo().Password);
        }

        public string LayMaKhoTuNgayThang(DateTime NgayThang)
        {
            string ngayThang = NgayThang.ToString("yyyy-MM-dd");
            return db.MyExecuteScalar<string>
                ("select dbo. Scalar_FN_LayMaKhoTuNgayThang('" + ngayThang + "'" + ")",
                CommandType.Text);
        }
    }
}
