using System.Collections.Generic;
using System.Linq;

namespace dao.Entity
{
    public class MapSerialNumber
    {
        //Ham lay du lieu
        //Ham them moi
        //Ham update
        //Ham xoa

        testDbEntities db = new testDbEntities();
        public List<Detail> LoadDetail()
        {


            //Lay danh sach tu bangr
            var danhsachSN = db.Details.ToList();

            //var danhsachSearchSN = db.Details.Where(m=>m.SerialNumber == "4342342234").ToList();

            ////Lay 1 doi tuong
            //var doituong = db.Details.Find("46456456");//Search theo khoa chinh
            //var doituong2 = db.Details.SingleOrDefault(m=>m.SerialNumber == "435346546");//Search 
            //var doituong3 = db.Details.FirstOrDefault(m=>m.SerialNumber == "435346546");//Search 
            return danhsachSN;

        }
        public List<Detail> LoadPage(int page, int size)
        {
            var danhsach = db.Details.ToList().Skip((page - 1) * size).Take(size).ToList();
            return danhsach;
        }
        public Detail GetChiTiet(string serialNumber)
        {
            var doituong = db.Details.Find(serialNumber);
            return doituong;

        }

    }
}
