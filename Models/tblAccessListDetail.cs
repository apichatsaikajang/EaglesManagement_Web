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
    
    public partial class tblAccessListDetail
    {
        public string AccessNo { get; set; }
        public string ItemNo { get; set; }
        public string TypeOfDevice { get; set; }
        public string NameOfDevice { get; set; }
        public Nullable<double> Price { get; set; }
        public string OrderNo { get; set; }
        public Nullable<double> WarrantyValue { get; set; }
        public string WarrantyUnit { get; set; }
        public Nullable<System.DateTime> StartWarranty { get; set; }
        public Nullable<System.DateTime> EndWarranty { get; set; }
        public string PlaceOfWarranty { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
        public string ModifyName { get; set; }
    }
}
