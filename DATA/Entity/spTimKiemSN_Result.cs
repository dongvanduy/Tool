//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dao.Entity
{
    using System;
    
    public partial class spTimKiemSN_Result
    {
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
        public string Repo { get; set; }
        public string Location { get; set; }
        public string Approver { get; set; }
        public string Borrower { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<System.DateTime> ExitDate { get; set; }
        public Nullable<System.DateTime> BorrowDate { get; set; }
        public string BorrowApprover { get; set; }
    }
}
