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
    
    public partial class tblRepair
    {
        public string RepairNo { get; set; }
        public Nullable<int> Type { get; set; }
        public string Branch { get; set; }
        public string Depart { get; set; }
        public string Asset { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public string PlaceUse { get; set; }
        public string Ruined { get; set; }
        public string Name { get; set; }
        public Nullable<int> Approve { get; set; }
        public string ApproveName { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreateBy { get; set; }
    }
}
