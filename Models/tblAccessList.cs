//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EaglesManagement_Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblAccessList
    {
        public string AccessNo { get; set; }
        public string AccessName { get; set; }
        public Nullable<System.DateTime> RecordDate { get; set; }
        public string TypeofAccess { get; set; }
        public string OrderNo { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<double> ValueOfAccess { get; set; }
        public string WarrantyValue { get; set; }
        public string WarrantyUnit { get; set; }
        public Nullable<System.DateTime> StartWarranty { get; set; }
        public Nullable<System.DateTime> EndWarranty { get; set; }
        public string PlaceOfWarranty { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public string StatusOnStock { get; set; }
        public string SN { get; set; }
        public string Branch { get; set; }
        public string Department { get; set; }
        public string Owner { get; set; }
        public string AccessAccount { get; set; }
        public Nullable<System.DateTime> ReceiveDate { get; set; }
    }
}
