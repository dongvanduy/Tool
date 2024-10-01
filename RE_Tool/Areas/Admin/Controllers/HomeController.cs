using dao.Entity;
using RE_Tool.App_Start;
using RE_Tool.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Management;
using System.Web.Mvc;

namespace RE_Tool.Areas.Admin.Controllers
{
    [RoleUser]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            var model = new PCBModel();
            return View(model);

        }
        [HttpPost]
        public JsonResult AddPCB(PCBModel pcb)
        {
            var result = new PCBResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    using (var db = new dataBaseTestEntities())
                    {
                        foreach (var serialNumber in pcb.SerialNumber.Split('\n'))
                        {
                            var trimmedSerialNumber = serialNumber.Trim();
                            if (!string.IsNullOrWhiteSpace(trimmedSerialNumber))
                            {
                                //Kiểm tra xem serialnumber đã tồn tại chưa
                                var existingPCB = db.addPCBs.FirstOrDefault(p => p.SerialNumber == trimmedSerialNumber);
                                if (existingPCB != null)
                                {
                                    //Them loi, neu serialnumber da ton tai
                                    result.DuplicateSerialNumbers.Add(trimmedSerialNumber);
                                }
                                else
                                {
                                    var newPCB = new addPCB
                                    {
                                        SerialNumber = trimmedSerialNumber,
                                        EntryDate = pcb.EntryDate,
                                        Repo = pcb.Repository,
                                        sheft = pcb.Sheft,
                                        tray = pcb.Tray,
                                        Approver = pcb.Approver
                                    };

                                    db.addPCBs.Add(newPCB);
                                    //result.AddedSerialNumbers.Add(trimmedSerialNumber);//Them vao ds thanh cong
                                    result.AddedPCBs.Add(new PCBInfo
                                    {
                                        SerialNumber = trimmedSerialNumber,
                                        EntryDate = pcb.EntryDate,
                                        Repository = pcb.Repository,
                                        Sheft = pcb.Sheft,
                                        Tray = pcb.Tray,
                                        Approver = pcb.Approver
                                    });
                                }
                            }
                        }
                        db.SaveChanges();
                    }
                    if (result.DuplicateSerialNumbers.Count > 0)
                    {
                        result.Success = false; // Nếu có serial number bị trùng, không thông báo thành công
                        result.Message = "Một số serial number đã tồn tại trong cơ sở dữ liệu.";
                    }
                    else
                    {
                        result.Success = true;
                        result.Message = "Thêm thành công!";
                    }
                }
                catch (DbEntityValidationException e)
                {
                    result.Success = false;
                    result.Message = "Đã xảy ra lỗi trong quá trình xác  thực";
                }

            }
            else
            {
                result.Success = false;
                result.Message = "Form nhập liệu không hợp lệ.";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult BorrowPCB(PCBModel model)
        {
            var result = new PCBResponseModel();
            List<string> successfulSerials = new List<string>(); // Danh sách serial thành công
            List<string> duplicateSerials = new List<string>();  // Danh sách serial bị trùng
            if (ModelState.IsValid)
            {
                try
                {
                    MapBorrow borrowService = new MapBorrow();
                    borrowService.BorrowPCBs(model.SerialNumber, model.Borrower, model.Approver, model.BorrowDate);

                    //Giả sử service sẽ trả về nhưng serial đã được mượn trước đó
                    if (!string.IsNullOrEmpty(borrowService.alreadyBorrowedSerials))
                    {
                        duplicateSerials = borrowService.alreadyBorrowedSerials.Split('\n').ToList();
                    }

                    //Phân biệt serial nào đã mượn thành công( giả sử PCB nào k có trong danh sách trùng thì thành công)
                    successfulSerials = model.SerialNumber.Split('\n').Select(s => s.Trim()).Where(s => !duplicateSerials.Contains(s)).ToList();
                    result.Success = true;
                    result.Message = "Cho mượn thành công";

                    //Nếu có serial bị trung lặp
                    if (duplicateSerials.Any())
                    {
                        result.Success = false;
                        result.Message = "Một số serial đã được mượn trước đó";
                        result.DuplicateSerialNumbers = duplicateSerials;
                    }
                    //Trả về danh sách các PCB đa được mượn thành công với thông tin chi tiết
                    result.AddedPCBs = successfulSerials.Select(sn => new PCBInfo
                    {
                        SerialNumber = sn,
                        BorrowDate = model.BorrowDate,
                        Borrower = model.Borrower,
                        Approver = model.Approver
                    }).ToList();
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = "Đã xảy ra lỗi trong quá trình xử lý: " + ex.Message;
                }
            }
            else
            {
                result.Success = false;
                result.Message = "Dữ liệu không hợp lệ.";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ExportPCB(PCBModel model)
        {
            var result = new PCBResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    using (var db = new dataBaseTestEntities())
                    {
                        foreach (var serialNumber in model.SerialNumber.Split('\n'))
                        {
                            var trimmedSerialNumber = serialNumber.Trim();
                            if (!string.IsNullOrWhiteSpace(trimmedSerialNumber))
                            {
                                var existingPCB = db.addPCBs.FirstOrDefault(p => p.SerialNumber == trimmedSerialNumber);
                                if (existingPCB != null)
                                {
                                    if (existingPCB.Status == true)
                                    {
                                        //Nếu pcb đang được mượn, thêm vào danh sách lỗi và tiếp tục 
                                        result.DuplicateSerialNumbers.Add(trimmedSerialNumber);
                                        continue;
                                    }
                                    //Tạo đối tượng mới lưu vào bảng ExportedPCBs
                                    var exportedPCB = new ExportedPCB
                                    {
                                        SerialNumber = existingPCB.SerialNumber,
                                        EntryDate = existingPCB.EntryDate,
                                        ExitDate = model.ExitDate,
                                        UserIn = existingPCB.Approver, // Người nhập kho từ addPCB
                                        UserOut = model.ApproverOut     // Người xuất kho từ form
                                    };
                                    //Lưu vào bảng ExportedPCBs
                                    db.ExportedPCBs.Add(exportedPCB);

                                    //Xóa khỏi bảng addPCBs
                                    db.addPCBs.Remove(existingPCB);

                                    //Thêm vào danh sách  thành công
                                    result.AddedPCBs.Add(new PCBInfo
                                    {
                                        SerialNumber = trimmedSerialNumber,
                                        ExitDate = model.ExitDate,
                                        ApproverOut = model.ApproverOut
                                    });

                                }
                                else
                                {
                                    result.DuplicateSerialNumbers.Add(trimmedSerialNumber);//Nếu pcb không tồn tại
                                }
                            }
                        }
                        db.SaveChanges();
                    }
                    if (result.DuplicateSerialNumbers.Count > 0)
                    {
                        result.Success = false;
                        result.Message = "Có Serial number không tồn tại hoặc đang được mượn";
                    }
                    else
                    {
                        result.Success = true;
                        result.Message = "Xuất kho thành công!";
                    }
                }

                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = "Đã xảy ra lỗi trong quá trình xử lý" + ex.Message;
                }
            }
            else
            {
                result.Success = false;
                result.Message = "Dữ liệu không hợp lệ";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult ReturnPCB(PCBModel model)
        {
            var result = new PCBResponseModel();
            if (ModelState.IsValid)
            {
                try
                {
                    MapBorrow borrowService = new MapBorrow();

                    // Gọi phương thức để trả PCB về kho
                    borrowService.ReturnPCBRepo(
                        model.SerialNumber,  // Danh sách serial numbers
                        model.Repository,    // Kho
                        model.Sheft,         // Vị trí kệ
                        model.Tray,          // Khay
                        model.ReturnDate,
                        model.Approver
                    );

                    result.Success = true;
                    result.Message = "Trả PCB về kho thành công!";
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = "Đã xảy ra lỗi trong quá trình xử lý: " + ex.Message;
                }
            }
            else
            {
                result.Success = false;
                result.Message = "Dữ liệu không hợp lệ.";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}