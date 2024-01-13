using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BUS
{
    public class DBNguyenVatLieu
    {
        DAO db = null;
        public DBNguyenVatLieu()
        {
            db = new DAO(DBCurrentLogin_Singleton.GetCurrentLoginInfo().UserName,
                DBCurrentLogin_Singleton.GetCurrentLoginInfo().Password);
        }    
        public DataSet LayThongTinNguyenVatLieu()
        {
            return db.ExecuteQueryDataSet("select * from NguyenVatLieu", CommandType.Text, null);
        }
    }
}
