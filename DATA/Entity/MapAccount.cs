using System.Linq;

namespace dao.Entity
{
    public class MapAccount
    {
        testDbEntities db = new testDbEntities();
        public Account searchAccount(string username, string password)
        {
            var user = db.Accounts.Where(m => m.IDEmployee == username & m.Password == password).ToList();
            if (user.Count > 0)
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
