using System;
using System.Collections.Generic;

namespace RE_Tool.Areas.Admin.Models
{
    public class PCBModel
    {
        public string SerialNumber { get; set; }
        public DateTime EntryDate { get; set; }
        public string Repository { get; set; }
        public string Sheft { get; set; }
        public string Tray { get; set; }
        public string Approver { get; set; }

        public List<string> AddedSerialNumber { get; set; } = new List<string>();
        public List<string> DuplicateSerialNumbers { get; set; } = new List<string>();

        public string Borrower { get; set; }// Người mượn
        public string ApproverBorrow { get; set; }// Người phê duyệt mượn
        public DateTime BorrowDate { get; set; }// Ngày cho mượn
        public DateTime ExitDate { get; set; }//Ngày xuất kho
        public string ApproverOut { get; set; }//Người xuất kho
        public DateTime ReturnDate { get; set; }//Ngày trả
    }
}