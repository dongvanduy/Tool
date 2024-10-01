using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dao.Entity
{
    public class MapAdd
    {
        dataBaseTestEntities db = new dataBaseTestEntities();
        public string AddSN(addPCB product)
        {
            db.addPCBs.Add(product);
            db.SaveChanges();
            return product.SerialNumber;
        }
    }
}
