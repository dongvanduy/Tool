using System;

namespace RE_Tool.Models
{
    public class PCBModel
    {
        public string SerialNumber { get; set; }
        public string ModelName { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
        public string ErrorDesc2 { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? ExitDate { get; set; }
        public string Repo { get; set; }
        public string Sheft { get; set; }
        public string Tray { get; set; }
        public string Approver { get; set; }
        public string Borrower { get; set; }
        public DateTime? BorrowDate { get; set; }
    }
}