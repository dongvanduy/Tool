using dao.Entity;
using RE_Tool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RE_Tool.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new List<PCBModel>();
            return View(model);

        }

        [HttpPost]
        public ActionResult SearchProductSN(string serialNumbers)
        {
            if (string.IsNullOrEmpty(serialNumbers))
            {
                // Trả về view với danh sách rỗng nếu không có serial numbers được nhập
                return View("Index",new List<PCBModel>());
            }

            var serialNumberList = serialNumbers.Split(new[] { "\r\n", "\n", "," }, 
                StringSplitOptions.RemoveEmptyEntries).Select(sn => sn.Trim()).ToList();

            if(serialNumberList.Count == 0)
            {
                return View(new List<PCBModel>());
            }
            
            var resultList = new List<PCBModel>();
            var map = new MapSerialNumber();

            foreach (var serialNumber in serialNumberList) {
                var result = map.SearchSerialNumber(serialNumber);

                resultList.AddRange(result.Select(r => new PCBModel {
                    SerialNumber = r.Serial_Number,
                    ModelName = r.Model,
                    ErrorCode = r.Error_Code,
                    ErrorDesc = r.Error_Description,
                    ErrorDesc2 = r.Error_Description_2,
                    EntryDate = r.Entry_Date,
                    ExitDate = r.Exit_Date,
                    Repo = r.Repository,
                    Sheft = r.Shelf,
                    Tray = r.Tray,
                    Approver = r.Approver,
                    BorrowDate = r.Borrow_Date,
                    Borrower = r.Borrower
                }));
            }
            return PartialView("_SearchResults",resultList);
        }

        [HttpPost]
        public ActionResult SearchProductNe(string repository, string errorCode, string errorDesc, int? status)
        {
            var map = new MapSerialNumber();
            var resultList = map.SearchProduct(repository, errorCode,errorDesc, status);
            var model = resultList.Select(r => new PCBModel
            {
                SerialNumber = r.SerialNumber,
                ModelName = r.Model,
                ErrorCode = r.ErrorCode,
                ErrorDesc = r.ErrorDesc,
                EntryDate = r.EntryDate,
                ExitDate = r.ExitDate,
                Repo = r.Repo,
                Sheft = r.Sheft,
                Tray = r.Tray,
                Approver = r.Approver
            }).ToList();
            return PartialView("_SearchResults", model);
        }
    }
}