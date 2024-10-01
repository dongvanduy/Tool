using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dao.Entity
{
    public class MapSerialNumber
    {
        dataBaseTestEntities db = new dataBaseTestEntities();
        public List<Detail> LoadDetail()
        {
            var danhsachSN = db.Details.ToList();
            return danhsachSN;
        }
        public List<sp_SearchBySN_Result> SearchSerialNumber(string serialNumbers)
        {
            var danhSach = db.sp_SearchBySN(serialNumbers).ToList();
            return danhSach;
        }

        public List<sp_Search_Product_Result> SearchProduct(string repository, string errorCode,string errorDesc, int? status) {
            var listProduct = db.sp_Search_Product(string.IsNullOrEmpty(repository) ? null:repository , string.IsNullOrEmpty(errorCode) ? null : errorCode, string.IsNullOrEmpty(errorDesc) ? null : errorDesc, status).ToList();
            return listProduct;
        }
    }
}
