using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Finance.Helpers
{
   public class Users
    {
        public PasswordBox pass;
        public string login;
        public Users(PasswordBox p, string log)
        {
            pass = p;
            login = log;
        }
    }
}
