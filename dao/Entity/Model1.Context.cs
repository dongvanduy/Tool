﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class dataBaseTestEntities : DbContext
    {
        public dataBaseTestEntities()
            : base("name=dataBaseTestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<addPCB> addPCBs { get; set; }
        public virtual DbSet<ExportedPCB> ExportedPCBs { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<sp_Search_Product_Result> sp_SearchProduct(string repository, string errorCode, Nullable<int> status)
        {
            var repositoryParameter = repository != null ?
                new ObjectParameter("Repository", repository) :
                new ObjectParameter("Repository", typeof(string));
    
            var errorCodeParameter = errorCode != null ?
                new ObjectParameter("ErrorCode", errorCode) :
                new ObjectParameter("ErrorCode", typeof(string));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Search_Product_Result>("sp_SearchProduct", repositoryParameter, errorCodeParameter, statusParameter);
        }
    
        public virtual ObjectResult<sp_SearchProductBySerialNumber_Result> sp_SearchProductBySerialNumber(string serialNumber)
        {
            var serialNumberParameter = serialNumber != null ?
                new ObjectParameter("SerialNumber", serialNumber) :
                new ObjectParameter("SerialNumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SearchProductBySerialNumber_Result>("sp_SearchProductBySerialNumber", serialNumberParameter);
        }
    
        public virtual ObjectResult<sp_Search_Product_Result> sp_Search_Product(string repository, string errorCode, string errorDesc, Nullable<int> status)
        {
            var repositoryParameter = repository != null ?
                new ObjectParameter("Repository", repository) :
                new ObjectParameter("Repository", typeof(string));
    
            var errorCodeParameter = errorCode != null ?
                new ObjectParameter("ErrorCode", errorCode) :
                new ObjectParameter("ErrorCode", typeof(string));
    
            var errorDescParameter = errorDesc != null ?
                new ObjectParameter("ErrorDesc", errorDesc) :
                new ObjectParameter("ErrorDesc", typeof(string));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Search_Product_Result>("sp_Search_Product", repositoryParameter, errorCodeParameter, errorDescParameter, statusParameter);
        }
    
        public virtual ObjectResult<sp_SearchBySerialNumber_Result> sp_SearchBySerialNumber(string serialNumber)
        {
            var serialNumberParameter = serialNumber != null ?
                new ObjectParameter("SerialNumber", serialNumber) :
                new ObjectParameter("SerialNumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SearchBySerialNumber_Result>("sp_SearchBySerialNumber", serialNumberParameter);
        }
    
        public virtual int UpdatePCBForBorrow(string serialNumbers, string borrower, string approver_Br, Nullable<System.DateTime> br_date, ObjectParameter alreadyBorrowedSerialNumbers)
        {
            var serialNumbersParameter = serialNumbers != null ?
                new ObjectParameter("SerialNumbers", serialNumbers) :
                new ObjectParameter("SerialNumbers", typeof(string));
    
            var borrowerParameter = borrower != null ?
                new ObjectParameter("Borrower", borrower) :
                new ObjectParameter("Borrower", typeof(string));
    
            var approver_BrParameter = approver_Br != null ?
                new ObjectParameter("Approver_Br", approver_Br) :
                new ObjectParameter("Approver_Br", typeof(string));
    
            var br_dateParameter = br_date.HasValue ?
                new ObjectParameter("Br_date", br_date) :
                new ObjectParameter("Br_date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdatePCBForBorrow", serialNumbersParameter, borrowerParameter, approver_BrParameter, br_dateParameter, alreadyBorrowedSerialNumbers);
        }
    
        public virtual ObjectResult<sp_SearchBySN_Result> sp_SearchBySN(string serialNumber)
        {
            var serialNumberParameter = serialNumber != null ?
                new ObjectParameter("SerialNumber", serialNumber) :
                new ObjectParameter("SerialNumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SearchBySN_Result>("sp_SearchBySN", serialNumberParameter);
        }
    
        public virtual int UpdateBorrow(string serialNumbers, string borrower, string approver_Br, Nullable<System.DateTime> br_date, ObjectParameter alreadyBorrowedSerialNumbers)
        {
            var serialNumbersParameter = serialNumbers != null ?
                new ObjectParameter("SerialNumbers", serialNumbers) :
                new ObjectParameter("SerialNumbers", typeof(string));
    
            var borrowerParameter = borrower != null ?
                new ObjectParameter("Borrower", borrower) :
                new ObjectParameter("Borrower", typeof(string));
    
            var approver_BrParameter = approver_Br != null ?
                new ObjectParameter("Approver_Br", approver_Br) :
                new ObjectParameter("Approver_Br", typeof(string));
    
            var br_dateParameter = br_date.HasValue ?
                new ObjectParameter("Br_date", br_date) :
                new ObjectParameter("Br_date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateBorrow", serialNumbersParameter, borrowerParameter, approver_BrParameter, br_dateParameter, alreadyBorrowedSerialNumbers);
        }
    
        public virtual int UpdatePCBForBorrow1(string serialNumbers, string borrower, string approver_Br, Nullable<System.DateTime> br_date, ObjectParameter alreadyBorrowedSerialNumbers)
        {
            var serialNumbersParameter = serialNumbers != null ?
                new ObjectParameter("SerialNumbers", serialNumbers) :
                new ObjectParameter("SerialNumbers", typeof(string));
    
            var borrowerParameter = borrower != null ?
                new ObjectParameter("Borrower", borrower) :
                new ObjectParameter("Borrower", typeof(string));
    
            var approver_BrParameter = approver_Br != null ?
                new ObjectParameter("Approver_Br", approver_Br) :
                new ObjectParameter("Approver_Br", typeof(string));
    
            var br_dateParameter = br_date.HasValue ?
                new ObjectParameter("Br_date", br_date) :
                new ObjectParameter("Br_date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdatePCBForBorrow1", serialNumbersParameter, borrowerParameter, approver_BrParameter, br_dateParameter, alreadyBorrowedSerialNumbers);
        }
    
        public virtual int UpdateBorrowNe(string serialNumbers, string borrower, string approver_Br, Nullable<System.DateTime> br_date, ObjectParameter alreadyBorrowedSerialNumbers)
        {
            var serialNumbersParameter = serialNumbers != null ?
                new ObjectParameter("SerialNumbers", serialNumbers) :
                new ObjectParameter("SerialNumbers", typeof(string));
    
            var borrowerParameter = borrower != null ?
                new ObjectParameter("Borrower", borrower) :
                new ObjectParameter("Borrower", typeof(string));
    
            var approver_BrParameter = approver_Br != null ?
                new ObjectParameter("Approver_Br", approver_Br) :
                new ObjectParameter("Approver_Br", typeof(string));
    
            var br_dateParameter = br_date.HasValue ?
                new ObjectParameter("Br_date", br_date) :
                new ObjectParameter("Br_date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateBorrowNe", serialNumbersParameter, borrowerParameter, approver_BrParameter, br_dateParameter, alreadyBorrowedSerialNumbers);
        }
    
        public virtual int ReturnPCBToWarehouse(string serialNumbers, string repo, string sheft, string tray, Nullable<System.DateTime> returnDate)
        {
            var serialNumbersParameter = serialNumbers != null ?
                new ObjectParameter("SerialNumbers", serialNumbers) :
                new ObjectParameter("SerialNumbers", typeof(string));
    
            var repoParameter = repo != null ?
                new ObjectParameter("Repo", repo) :
                new ObjectParameter("Repo", typeof(string));
    
            var sheftParameter = sheft != null ?
                new ObjectParameter("Sheft", sheft) :
                new ObjectParameter("Sheft", typeof(string));
    
            var trayParameter = tray != null ?
                new ObjectParameter("Tray", tray) :
                new ObjectParameter("Tray", typeof(string));
    
            var returnDateParameter = returnDate.HasValue ?
                new ObjectParameter("ReturnDate", returnDate) :
                new ObjectParameter("ReturnDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ReturnPCBToWarehouse", serialNumbersParameter, repoParameter, sheftParameter, trayParameter, returnDateParameter);
        }
    }
}
