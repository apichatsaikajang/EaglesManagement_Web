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
    public class UserProfileController : Controller
    {
        // GET: User
        public ActionResult Index()
        {

            using (ITmanagementEntities db = new ITmanagementEntities())
            {

                TempData.Keep("username");
                TempData.Keep("dept");

                string user_by = TempData["username"].ToString();

                dynamic model = new ExpandoObject();
                model.userprofiles = db.tblUsers
                    .ToList();

                return View(model);
            }
        }

        public ActionResult userprofileInsertForm()
        {
            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                TempData.Keep("username");
                string user_by = TempData["username"].ToString();

                dynamic model = new ExpandoObject();
                model.userprofiles = db.tblUsers
                     .Where(x => x.UserName == user_by)
                     .ToList();

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult insertUserProfile(tblUser user_obj)
        {
            TempData.Keep("username");

            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    string user_by = TempData["username"].ToString();


                    tblUser user = new tblUser();


                    user.UserName = user_obj.UserName;
                    user.Name = user_obj.Name;
                    user.Dept = user_obj.Dept;
                    user.Branch = user_obj.Branch;
                    user.Party = user_obj.Party;
                    user.Password = user_obj.Password;
                    user.Mail = user_obj.Mail;

                    try
                    {
                        db.tblUsers.Add(user);
                        db.SaveChanges();

                        transaction.Commit();

                        TempData["alert_msg"] = "Saved";
                        return RedirectToAction("Index", "UserProfile");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                        TempData["alert_msg"] = "System Error";
                        return RedirectToAction("Index", "UserProfile");
                    }
                }

            }
        }

        public ActionResult userprofileEditForm(string username)
        {
            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                TempData.Keep("UserName");

                string user_by = TempData["username"].ToString();

                dynamic model = new ExpandoObject();
                model.userprofiles = db.tblUsers
                    .Where(w => w.UserName == username)
                    .FirstOrDefault();

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult deleteUser(tblUser user_obj)
        {
            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    TempData.Keep("username");

                    string user_by = TempData["username"].ToString();

                    tblUser del_as = db.tblUsers.Where(x => x.UserName == user_obj.UserName).FirstOrDefault();
                    try
                    {
                        db.tblUsers.Remove(del_as);
                        db.SaveChanges();

                        transaction.Commit();

                        TempData["alert_msg"] = "Delete";
                        return RedirectToAction("Index", "UserProfile");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                        TempData["alert_msg"] = "System Error";
                        return RedirectToAction("Index", "UserProfile");

                    }
                }
            }
        }

    }
}

