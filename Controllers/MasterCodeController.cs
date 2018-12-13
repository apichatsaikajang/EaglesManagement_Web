using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EaglesManagement_Web.Models;
using System.Dynamic;


namespace EaglesManagement_Web.Controllers
{
    public class MasterCodeController : Controller
    {
        // GET: MasterCode
        public ActionResult Index()
        {

            using (ITmanagementEntities db = new ITmanagementEntities())
            {

                TempData.Keep("username");

                string user_by = TempData["username"].ToString();

                dynamic model = new ExpandoObject();
               // model.mastercode = db.tblMasterCodes.Where(x => x.UserName == user_by).OrderByDescending(y => y.UserName).ToList();

                model.mastercode = db.tblMasterCodes
                    .ToList();
                return View(model);
            }
        }


        public ActionResult mastercodeInsertForm()
        
            {
                TempData.Keep("username");

                return View();
            }



        [HttpPost]
        public ActionResult insertMasterCode(tblMasterCode mastercode_obj)
        {
            TempData.Keep("username");

            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    string user_by = TempData["username"].ToString();

                    tblMasterCode mastercode = new tblMasterCode();

                    int LisenceSum = int.Parse(Request["LisenceSum"]);


                    mastercode.Type = mastercode_obj.Type;
                    mastercode.Code = mastercode_obj.Code;
                    mastercode.Description = mastercode_obj.Description;
                    mastercode.Note = mastercode_obj.Note;
                    mastercode.FilterInd = mastercode_obj.FilterInd;
                    mastercode.TypeCode = mastercode_obj.TypeCode;


                    mastercode.CreateBy = user_by;
                    mastercode.CreateDate = DateTime.Now;
                    mastercode.UpdateBy = user_by;
                    mastercode.UpdateDate = DateTime.Now;



                    try
                    {
                        db.tblMasterCodes.Add(mastercode);
                        db.SaveChanges();

                        transaction.Commit();

                        TempData["alert_msg"] = "Saved";
                        return RedirectToAction("Index", "MasterCode");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                        TempData["alert_msg"] = "System Error";
                        return RedirectToAction("Index", "MasterCode");
                    }
                }
            }

        }


        public ActionResult mastercodeEditForm(string type, string code)
        {
            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                TempData.Keep("UserName");

                string user_by = TempData["username"].ToString();

                dynamic model = new ExpandoObject();

                model.editmastercode = db.tblMasterCodes
                    .Where(x => x.Type == type && x.Code == code)
                    .FirstOrDefault();

                return View(model);
            }
        }


        [HttpPost]
        public ActionResult editMasterCode(tblMasterCode editmastercode)
        {
            TempData.Keep("username");

            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    string user_by = TempData["username"].ToString();

                    tblMasterCode mc = db.tblMasterCodes
                    .Where(x => x.Type == editmastercode.Type && x.Code == editmastercode.Code)
                    .FirstOrDefault();

                    int LisenceSum = int.Parse(Request["LisenceSum"]);


                    mc.Type = editmastercode.Type;
                    mc.Code = editmastercode.Code;
                    mc.Description = editmastercode.Description;
                    mc.Note = editmastercode.Note;
                    mc.FilterInd = editmastercode.FilterInd;
                    mc.TypeCode = editmastercode.TypeCode;


                    mc.CreateBy = user_by;
                    mc.CreateDate = DateTime.Now;
                    mc.UpdateBy = user_by;
                    mc.UpdateDate = DateTime.Now;


                    try
                    {
                        db.SaveChanges();

                        transaction.Commit();

                        TempData["alert_msg"] = "Updated";
                        return RedirectToAction("Index", "MasterCode");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                        TempData["alert_msg"] = "System Error";
                        return RedirectToAction("Index", "MasterCode");
                    }
                }
            }
        }




        [HttpPost]
        public ActionResult deletemastercode(tblMasterCode mastercode_obj)
        {
            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    TempData.Keep("username");

                    string user_by = TempData["username"].ToString();


                    tblMasterCode del_mastercode = db.tblMasterCodes
                        .Where(x => x.Type == mastercode_obj.Type && x.Code == mastercode_obj.Code)
                        .FirstOrDefault();
                    try
                    {
                        db.tblMasterCodes.Remove(del_mastercode);
                        db.SaveChanges();

                        transaction.Commit();

                        TempData["alert_msg"] = "Delete";
                        return RedirectToAction("Index", "MasterCode");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                        TempData["alert_msg"] = "System Error";
                        return RedirectToAction("Index", "MasterCode");

                    }
                }
            }
        }



    }
}