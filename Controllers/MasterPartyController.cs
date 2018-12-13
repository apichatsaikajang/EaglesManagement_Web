using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EaglesManagement_Web.Models;
using System.Dynamic;


namespace EaglesManagement_Web.Controllers
{
    public class MasterPartyController : Controller
    {
        // GET: MasterParty
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Information()
        {
            using (ITmanagementEntities db = new ITmanagementEntities())
            {

                TempData.Keep("username");

                string user_by = TempData["username"].ToString();

                dynamic model = new ExpandoObject();
                model.information = db.tblParties
                    .ToList();

                return View(model);
            }

        }


        public ActionResult informationInsertForm()
        {
            TempData.Keep("username");

            return View();
        }



        [HttpPost]
        public ActionResult insertInformation(tblParty information_obj)
        {
            TempData.Keep("username");

            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    string user_by = TempData["username"].ToString();

                    tblParty information = new tblParty();

                    information.PartyCode = information_obj.PartyCode;
                    information.PartyFullName = information_obj.PartyFullName;
                    information.PartyLocalCode = information_obj.PartyLocalCode;
                    information.PartyLocalName = information_obj.PartyLocalName;
                    information.PartyLocation = information_obj.PartyLocation;
                    information.PartyCountry = information_obj.PartyCountry;
                    information.RegistrationNo = information_obj.RegistrationNo;
                    information.PartyTypeCode = information_obj.PartyTypeCode;
                    information.PartyTypeName = information_obj.PartyTypeName;
                    information.CommissionToSales = information_obj.CommissionToSales;
                    information.IATACode = information_obj.IATACode;
                    information.Remarks = information_obj.Remarks;
                    information.PartyStatus = information_obj.PartyStatus;
                    information.MessageHubID = information_obj.MessageHubID;
                    information.OtherSystemPartyID = information_obj.OtherSystemPartyID;
                    information.FormID = information_obj.FormID;
                    information.Shipper = information_obj.Shipper;
                    information.Consignee = information_obj.Consignee;
                    information.Branch_Agent = information_obj.Branch_Agent;
                    information.Co_Loader = information_obj.Co_Loader;
                    information.Trucking = information_obj.Trucking;
                    information.ShippingLine = information_obj.ShippingLine;
                    information.Vendor = information_obj.Vendor;
                    information.ContainerYard = information_obj.ContainerYard;
                    information.Warehouse = information_obj.Warehouse;
                    information.Bank = information_obj.Bank;
                    information.Factory = information_obj.Factory;
                    information.Customer = information_obj.Customer;
                    information.Broker = information_obj.Broker;
                    information.AirLine = information_obj.AirLine;
                    information.EndCustomer = information_obj.EndCustomer;

                    information.CreateBy = user_by;
                    information.CreateDate = DateTime.Now;
                    information.UpdateBy = user_by;
                    information.UpdateDate = DateTime.Now;
                    


                    try
                    {
                        db.tblParties.Add(information);
                        db.SaveChanges();

                        transaction.Commit();

                        TempData["alert_msg"] = "Saved";
                        return RedirectToAction("Information", "MasterParty");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                        TempData["alert_msg"] = "System Error";
                        return RedirectToAction("Information", "MasterParty");
                    }
                }
            }

        }



        public ActionResult informationEditForm(string PartyCode)
        {
            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                TempData.Keep("UserName");

                string user_by = TempData["username"].ToString();

                dynamic model = new ExpandoObject();
                model.information = db.tblParties
                    .Where(w => w.PartyCode == PartyCode)
                    .FirstOrDefault();

                return View(model);
            }
        }


        [HttpPost]
        public ActionResult deleteinformation(tblParty party_obj)
        {
            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    TempData.Keep("username");

                    string user_by = TempData["username"].ToString();

                    tblParty del_information = db.tblParties
                        .Where(x => x.PartyCode == party_obj.PartyCode).FirstOrDefault();
                    try
                    {
                        db.tblParties.Remove(del_information);
                        db.SaveChanges();

                        transaction.Commit();

                        TempData["alert_msg"] = "Delete";
                        return RedirectToAction("Information", "MasterParty");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                        TempData["alert_msg"] = "System Error";
                        return RedirectToAction("Information", "MasterParty");

                    }
                }
            }
        }



        public ActionResult Address()
        {
            using (ITmanagementEntities db = new ITmanagementEntities())
            {

                TempData.Keep("username");

                string user_by = TempData["username"].ToString();

                dynamic model = new ExpandoObject();
                model.address = db.tblPartyAddresses
                    .ToList();

                return View(model);
            }

        }


        public ActionResult addressInsertForm()
        {
            TempData.Keep("username");

            return View();
        }



        [HttpPost]
        public ActionResult insertAddress(tblPartyAddress address_obj)
        {
            TempData.Keep("username");

            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    string user_by = TempData["username"].ToString();

                    tblPartyAddress address = new tblPartyAddress();

                    address.PartyCode = address_obj.PartyCode;
                    address.AddressType = address_obj.AddressType;
                    address.Address1 = address_obj.Address1;
                    address.Address2 = address_obj.Address2;
                    address.Address3 = address_obj.Address3;
                    address.Address4 = address_obj.Address4;
                    address.AreaCode = address_obj.AreaCode;
                    address.Attn = address_obj.Attn;
                    address.email = address_obj.email;
                    address.Fax = address_obj.Fax;
                    address.Tel = address_obj.Tel;
                    address.Web = address_obj.Web;
                    address.ZipCode = address_obj.ZipCode;

                    address.CreateBy = user_by;
                    address.UpdateDate = DateTime.Now;
                    address.CreateDate = DateTime.Now;
                    address.UpdateBy = user_by;

                    try
                    {
                        db.tblPartyAddresses.Add(address);
                        db.SaveChanges();

                        transaction.Commit();

                        TempData["alert_msg"] = "Saved";
                        return RedirectToAction("Address", "MasterParty");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                        TempData["alert_msg"] = "System Error";
                        return RedirectToAction("Address", "MasterParty");
                    }
                }
            }

        }


        public ActionResult addressEditForm(string PartyAddressCode, string PartyCode)
        {
            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                TempData.Keep("UserName");

                string user_by = TempData["username"].ToString();

                dynamic model = new ExpandoObject();
                model.address = db.tblPartyAddresses
                    .Where(w => w.PartyAddressCode == w.PartyAddressCode && w.PartyCode == w.PartyCode)
                    .FirstOrDefault();

                return View(model);
            }
        }


        [HttpPost]
        public ActionResult deleteAddress(tblPartyAddress address_obj)
        {
            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    TempData.Keep("username");

                    string user_by = TempData["username"].ToString();

                    tblPartyAddress del_address = db.tblPartyAddresses.Where(x => x.PartyAddressCode == address_obj.PartyAddressCode && x.PartyCode == address_obj.PartyCode).FirstOrDefault();
                    try
                    {
                        db.tblPartyAddresses.Remove(del_address);
                        db.SaveChanges();

                        transaction.Commit();

                        TempData["alert_msg"] = "Delete";
                        return RedirectToAction("Address", "MasterParty");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                        TempData["alert_msg"] = "System Error";
                        return RedirectToAction("Address", "MasterParty");

                    }
                }
            }
        }



    }
}