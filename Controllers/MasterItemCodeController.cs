using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EaglesManagement_Web.Models;
using System.Dynamic;
using System.Text;


namespace EaglesManagement_Web.Controllers
{
    public class MasterItemCodeController : Controller
    {
        // GET: MasterItemCode
        public ActionResult Index()
        {

            using (ITmanagementEntities db = new ITmanagementEntities())
            {

                TempData.Keep("username");
                string user_by = TempData["username"].ToString();

                dynamic model = new ExpandoObject();
                model.masteritemcode = db.tblInventoryItems
                    .ToList();

                return View(model);
            }
        }

        public ActionResult masteritemcodeInsertForm()
        {
                TempData.Keep("username");

                return View();
        }


        [HttpPost]
        public ActionResult insertMasterItemCode(tblInventoryItem masteritemcode_obj)
        {
            TempData.Keep("username");

            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    string user_by = TempData["username"].ToString();

                    tblInventoryItem masteritemcode = new tblInventoryItem();


                    //double Price = double.Parse(Request["Price"]);

                    masteritemcode.Price = masteritemcode_obj.Price;

                    masteritemcode.Itemcode = masteritemcode_obj.Itemcode;
                    masteritemcode.Itemname = masteritemcode_obj.Itemname;
                    masteritemcode.TypeUse = masteritemcode_obj.TypeUse;
                    masteritemcode.TypeEquipment = masteritemcode_obj.TypeEquipment;
                    masteritemcode.Vendor = masteritemcode_obj.Vendor;

                    masteritemcode.Userby = user_by;
                    masteritemcode.Lastupdate = DateTime.Now;




                    try
                    {
                        db.tblInventoryItems.Add(masteritemcode);
                        db.SaveChanges();

                        transaction.Commit();

                        TempData["alert_msg"] = "Saved";
                        return RedirectToAction("Index", "MasterItemCode");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                        TempData["alert_msg"] = "System Error";
                        return RedirectToAction("Index", "MasterItemCode");
                    }
                }
            }

        }



        public ActionResult masteritemcodeEditForm(string itemcode)
        {
            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                TempData.Keep("UserName");

                string user_by = TempData["username"].ToString();

                dynamic model = new ExpandoObject();

                model.editmasteritemcode = db.tblInventoryItems
                    .Where(x => x.Itemcode == itemcode)
                    .FirstOrDefault();

                return View(model);
            }
        }


        [HttpPost]
        public ActionResult editMasterItemcode(tblInventoryItem edititemcode)
        {
            TempData.Keep("username");

            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    string user_by = TempData["username"].ToString();

                    tblInventoryItem masteritemcode = db.tblInventoryItems
                    .Where(x => x.Itemcode == edititemcode.Itemcode)
                    .FirstOrDefault();

                    //double Price = double.Parse(Request["Price"]);
                   // masteritemcode.Price = '0';
                    masteritemcode.Price = edititemcode.Price;
                    masteritemcode.Itemcode = edititemcode.Itemcode;
                    masteritemcode.Itemname = edititemcode.Itemname;
                    masteritemcode.TypeUse = edititemcode.TypeUse;
                    masteritemcode.TypeEquipment = edititemcode.TypeEquipment;
                    masteritemcode.Vendor = edititemcode.Vendor;

                    
 
                    masteritemcode.Userby = user_by;
                    masteritemcode.Lastupdate = DateTime.Now;

                    try
                    {
                        db.SaveChanges();

                        transaction.Commit();

                        TempData["alert_msg"] = "Updated";
                        return RedirectToAction("Index", "MasterItemCode");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                        TempData["alert_msg"] = "System Error";
                        return RedirectToAction("Index", "MasterItemCode");
                    }
                }
            }
        }




        [HttpPost]
        public ActionResult deletemasteritemcode(tblInventoryItem masteritemcode_obj)
        {
            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    TempData.Keep("username");

                    string user_by = TempData["username"].ToString();


                    tblInventoryItem del_masteritemcode = db.tblInventoryItems
                    .Where(x => x.Itemcode == masteritemcode_obj.Itemcode)
                        .FirstOrDefault();
                    try
                    {
                        db.tblInventoryItems.Remove(del_masteritemcode);
                        db.SaveChanges();

                        transaction.Commit();

                        TempData["alert_msg"] = "Delete";
                        return RedirectToAction("Index", "MasterItemCode");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                        TempData["alert_msg"] = "System Error";
                        return RedirectToAction("Index", "MasterItemCode");

                    }
                }
            }
        }


    }
}