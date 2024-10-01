using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dao.Entity
{
    public class MapAccount
    {
        dataBaseTestEntities db = new dataBaseTestEntities();
        public Account searchAccount(string username, string password)
        {
            var user = db.Accounts.Where(m => m.IDEmployee == username & m.Password == password).ToList();
            if (user.Count() > 0)
            {
                return user[0];
            }
            else
            {
                return null;
            }
        }
    }
}
