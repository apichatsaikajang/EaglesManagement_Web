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
    
    public partial class tblRentDeviceDetail
    {
        public string RentNo { get; set; }
        public string ItemNo { get; set; }
        public string TypeDevice { get; set; }
        public string AccessCode { get; set; }
        public string AccessName { get; set; }
        public Nullable<int> Qty { get; set; }
        public string AccessoryOfDevice { get; set; }
        public string Remarks { get; set; }
        public string StatusOfRent { get; set; }
        public string CreatBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> FirstRent { get; set; }
    }
}
