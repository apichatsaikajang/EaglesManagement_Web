using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using System.IO;
using EaglesManagement_Web.Models;

namespace EaglesManagement_Web.Controllers
{
    public class MasterDepartmentController : Controller
    {
        // GET: MasterDepartment
        public ActionResult Index()
        {

            using (ITmanagementEntities db = new ITmanagementEntities())
            {

                TempData.Keep("username");
                TempData.Keep("dept");

                string user_by = TempData["username"].ToString();

                dynamic model = new ExpandoObject();
                model.masterdepartment = db.tblDepartments
                    .ToList();

                return View(model);
            }
        }

         public ActionResult masterdepartmentInsertForm()
        {
             TempData.Keep("username");
        
             return View();
         }



         [HttpPost]
         public ActionResult insertMasterDepartment(tblDepartment masterdepartment_obj)
         {
             TempData.Keep("username");

             using (ITmanagementEntities db = new ITmanagementEntities())
             {
                 using (var transaction = db.Database.BeginTransaction())
                 {
                     string user_by = TempData["username"].ToString();

                     tblDepartment masterdepartment = new tblDepartment();

                     masterdepartment.Branch = masterdepartment_obj.Branch;
                     masterdepartment.Party = masterdepartment_obj.Party;
                     masterdepartment.Department = masterdepartment_obj.Department;
                     masterdepartment.Manager = masterdepartment_obj.Manager;
                     masterdepartment.A_Manager = masterdepartment_obj.A_Manager;
                     masterdepartment.Status = masterdepartment_obj.Status;


                     masterdepartment.Userby = user_by;
                     masterdepartment.Lastupdate = DateTime.Now;




                     try
                     {
                         db.tblDepartments.Add(masterdepartment);
                         db.SaveChanges();

                         transaction.Commit();

                         TempData["alert_msg"] = "Saved";
                         return RedirectToAction("Index", "MasterDepartment");
                     }
                     catch (Exception)
                     {
                         transaction.Rollback();

                         TempData["alert_msg"] = "System Error";
                         return RedirectToAction("Index", "MasterDepartment");
                     }
                 }
             }

         }



         public ActionResult masterdepartmentEditForm(string branch, string party, string department)
         {
             using (ITmanagementEntities db = new ITmanagementEntities())
             {
                 TempData.Keep("UserName");

                 string user_by = TempData["username"].ToString();

                 dynamic model = new ExpandoObject();

                 model.editdepartment = db.tblDepartments
                     .Where(x => x.Branch == branch && x.Party == party && x.Department == department )
                     .FirstOrDefault();

                 return View(model);
             }
         }


         [HttpPost]
         public ActionResult editMasterDepartment(tblDepartment editdepartment)
         {
             TempData.Keep("username");

             using (ITmanagementEntities db = new ITmanagementEntities())
             {
                 using (var transaction = db.Database.BeginTransaction())
                 {
                     string user_by = TempData["username"].ToString();

                     tblDepartment mdp = db.tblDepartments
                     .Where(x => x.Branch == editdepartment.Branch && x.Party == editdepartment.Party && x.Department == editdepartment.Department)
                     .FirstOrDefault();

                     int Status = int.Parse(Request["Status"]);


                     mdp.Branch = editdepartment.Branch;
                     mdp.Party = editdepartment.Party;
                     mdp.Department = editdepartment.Department;
                     mdp.Manager = editdepartment.Manager;
                     mdp.A_Manager = editdepartment.A_Manager;


                     mdp.Userby = user_by;
                     mdp.Lastupdate = DateTime.Now;

                     try
                     {
                         db.SaveChanges();

                         transaction.Commit();

                         TempData["alert_msg"] = "Updated";
                         return RedirectToAction("Index", "MasterDepartment");
                     }
                     catch (Exception)
                     {
                         transaction.Rollback();

                         TempData["alert_msg"] = "System Error";
                         return RedirectToAction("Index", "MasterDepartment");
                     }
                 }
             }
         }




         [HttpPost]
         public ActionResult deletemasterdepartment(tblDepartment masterdepartment_obj)
         {
             using (ITmanagementEntities db = new ITmanagementEntities())
             {
                 using (var transaction = db.Database.BeginTransaction())
                 {
                     TempData.Keep("username");

                     string user_by = TempData["username"].ToString();


                     tblDepartment del_masterdepartment = db.tblDepartments
                         .Where(x => x.Branch == masterdepartment_obj.Branch && x.Party == masterdepartment_obj.Party && x.Department == masterdepartment_obj.Department)
                         .FirstOrDefault();
                     try
                     {
                         db.tblDepartments.Remove(del_masterdepartment);
                         db.SaveChanges();

                         transaction.Commit();

                         TempData["alert_msg"] = "Delete";
                         return RedirectToAction("Index", "MasterDepartment");
                     }
                     catch (Exception)
                     {
                         transaction.Rollback();

                         TempData["alert_msg"] = "System Error";
                         return RedirectToAction("Index", "MasterDepartment");

                     }
                 }
             }
         }

    }
}
