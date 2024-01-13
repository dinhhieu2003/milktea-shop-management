using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public sealed class DBCurrentLogin_Singleton
    {
        private static DBCurrentLogin_Singleton LoginInfo = null;
        public static DBCurrentLogin_Singleton GetCurrentLoginInfo()
        {
            if(LoginInfo == null)
            {
                LoginInfo = new DBCurrentLogin_Singleton();
            }
            return LoginInfo;
        }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
