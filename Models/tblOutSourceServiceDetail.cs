//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EaglesManagement_Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblOutSourceServiceDetail
    {
        public string TicketNo { get; set; }
        public string ServiceNo { get; set; }
        public string ItemNo { get; set; }
        public string Description { get; set; }
        public Nullable<int> QTY { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<int> VAT { get; set; }
        public Nullable<double> Amount { get; set; }
        public string Remarks { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string ModifyBy { get; set; }
        public Nullable<System.DateTime> ModifyDate { get; set; }
    }
}
