﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ITmanagementEntities : DbContext
    {
        public ITmanagementEntities()
            : base("name=ITmanagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<dtproperty> dtproperties { get; set; }
        public virtual DbSet<RunningNumber> RunningNumbers { get; set; }
        public virtual DbSet<tblAccessList> tblAccessLists { get; set; }
        public virtual DbSet<tblAccessListDetail> tblAccessListDetails { get; set; }
        public virtual DbSet<tblAccessMA> tblAccessMAs { get; set; }
        public virtual DbSet<tblAccessSoftware> tblAccessSoftwares { get; set; }
        public virtual DbSet<tblCheckBackUp> tblCheckBackUps { get; set; }
        public virtual DbSet<tblCheckCCTV> tblCheckCCTVs { get; set; }
        public virtual DbSet<tblCheckFireWall> tblCheckFireWalls { get; set; }
        public virtual DbSet<tblCheckMeterial> tblCheckMeterials { get; set; }
        public virtual DbSet<tblCheckRouter> tblCheckRouters { get; set; }
        public virtual DbSet<tblCheckServer> tblCheckServers { get; set; }
        public virtual DbSet<tblCheckSwitch> tblCheckSwitches { get; set; }
        public virtual DbSet<tblDepartment> tblDepartments { get; set; }
        public virtual DbSet<tblEmployee> tblEmployees { get; set; }
        public virtual DbSet<tblEmployee_out> tblEmployee_out { get; set; }
        public virtual DbSet<tblEmployee_outdtl> tblEmployee_outdtl { get; set; }
        public virtual DbSet<tblGenAutoNo> tblGenAutoNoes { get; set; }
        public virtual DbSet<tblInventoryItem> tblInventoryItems { get; set; }
        public virtual DbSet<tblITServiceSparepart> tblITServiceSpareparts { get; set; }
        public virtual DbSet<tblITServiceTicket> tblITServiceTickets { get; set; }
        public virtual DbSet<tblITServiceTicketDetail> tblITServiceTicketDetails { get; set; }
        public virtual DbSet<tblMasterCode> tblMasterCodes { get; set; }
        public virtual DbSet<tblMenu> tblMenus { get; set; }
        public virtual DbSet<tblOutSiteService> tblOutSiteServices { get; set; }
        public virtual DbSet<tblOutSiteServiceDetail> tblOutSiteServiceDetails { get; set; }
        public virtual DbSet<tblOutSourceService> tblOutSourceServices { get; set; }
        public virtual DbSet<tblOutSourceServiceDetail> tblOutSourceServiceDetails { get; set; }
        public virtual DbSet<tblPurchaseRequistionDtl> tblPurchaseRequistionDtls { get; set; }
        public virtual DbSet<tblPurchaseRequistionHdr> tblPurchaseRequistionHdrs { get; set; }
        public virtual DbSet<tblRecordProduct> tblRecordProducts { get; set; }
        public virtual DbSet<tblRecordProductDtl> tblRecordProductDtls { get; set; }
        public virtual DbSet<tblRentDevice> tblRentDevices { get; set; }
        public virtual DbSet<tblRentDeviceDetail> tblRentDeviceDetails { get; set; }
        public virtual DbSet<tblRepair> tblRepairs { get; set; }
        public virtual DbSet<tblRepairDetail> tblRepairDetails { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
        public virtual DbSet<tblUserMenu> tblUserMenus { get; set; }
        public virtual DbSet<tblParty> tblParties { get; set; }
        public virtual DbSet<tblPartyAddress> tblPartyAddresses { get; set; }
        public virtual DbSet<tblUserGroup> tblUserGroups { get; set; }
    }
}