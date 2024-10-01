using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RE_Tool.Areas.Admin.Models
{
    public class PCBResponseModel
    {
        public List<PCBInfo> AddedPCBs { get; set; } = new List<PCBInfo>();
        public List<string> DuplicateSerialNumbers { get; set; } = new List<string>();
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    public class PCBInfo
    {
        public string SerialNumber { get; set; }
        public DateTime EntryDate { get; set; }
        public string Repository { get; set; }
        public string Sheft { get; set; }
        public string Tray { get; set; }
        public string Approver { get; set; }
        public DateTime BorrowDate { get; set; }
        public string Borrower { get; set; }
        public DateTime ExitDate { get; set; }
        public string ApproverOut {  get; set; }
    }
}