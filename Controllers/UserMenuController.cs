using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EaglesManagement_Web.Models;
using System.Dynamic;

namespace EaglesManagement_Web.Controllers
{
    public class UserMenuController : Controller
    {
        // GET: UserMenu
        public ActionResult Index()
        {
                return View();
            
        }


        public ActionResult user()
        {
            using (ITmanagementEntities db = new ITmanagementEntities())
            {

                TempData.Keep("username");

                string user_by = TempData["username"].ToString();

                dynamic model = new ExpandoObject();
                model.user = db.tblUserMenus
                    .ToList();

                return View(model);
            }

        }




        public ActionResult userInsertForm()
          {
                TempData.Keep ("username");

                 return View();
           }
        


        [HttpPost]
        public ActionResult insertUser(tblUserMenu user_obj)
        {
            TempData.Keep("username");

            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    string user_by = TempData["username"].ToString();

                    tblUserMenu user = new tblUserMenu();

                    user.UserName = user_obj.UserName;
                    user.Program = user_obj.Program;
                    user.status = user_obj.status;

                    user.UserBy = user_by;
                    user.LastUpdate= DateTime.Now;

                    try
                    {
                        db.tblUserMenus.Add(user);
                        db.SaveChanges();

                        transaction.Commit();

                        TempData["alert_msg"] = "Saved";
                        return RedirectToAction("user", "UserMenu");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                        TempData["alert_msg"] = "System Error";
                        return RedirectToAction("user", "UserMenu");
                    }
                }
            }

        }


        public ActionResult userEditForm(string username)
        {
            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                TempData.Keep("UserName");

                string user_by = TempData["username"].ToString();

                dynamic model = new ExpandoObject();
                model.user = db.tblUserMenus
                    .Where(w => w.UserName == username && w.Program == w.Program)
                    .FirstOrDefault();

                return View(model);
            }
        }


        [HttpPost]
        public ActionResult deleteUser(tblUserMenu user_obj)
        {
            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    TempData.Keep("username");

                    string user_by = TempData["username"].ToString();

                    tblUserMenu del_user = db.tblUserMenus.Where(x => x.UserName == user_obj.UserName && x.Program == user_obj.Program).FirstOrDefault();
                    try
                    {
                        db.tblUserMenus.Remove(del_user);
                        db.SaveChanges();

                        transaction.Commit();

                        TempData["alert_msg"] = "Delete";
                        return RedirectToAction("Index", "User");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                        TempData["alert_msg"] = "System Error";
                        return RedirectToAction("Index", "User");

                    }
                }
            }
        }




        public ActionResult Menu()
        {
            using (ITmanagementEntities db = new ITmanagementEntities())
            {

                TempData.Keep("username");


                dynamic model = new ExpandoObject();
                model.menu = db.tblMenus
                    .ToList();

                return View(model);
            }

        }


        public ActionResult menuInsertForm()
        {
            TempData.Keep("username");

            return View();
        }



        [HttpPost]
        public ActionResult insertMenu(tblMenu menu_obj)
        {
            TempData.Keep("username");

            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    string user_by = TempData["username"].ToString();

                    tblMenu menu = new tblMenu();

                    menu.Program = menu_obj.Program;
                    menu.Description = menu_obj.Description;

                    menu.UserBy = user_by;
                    menu.LastUpdate = DateTime.Now;

                    try
                    {
                        db.tblMenus.Add(menu);
                        db.SaveChanges();

                        transaction.Commit();

                        TempData["alert_msg"] = "Saved";
                        return RedirectToAction("Menu", "UserMenu");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                        TempData["alert_msg"] = "System Error";
                        return RedirectToAction("Menu", "UserMenu");
                    }
                }
            }

        }


        public ActionResult menuEditForm(string Program)
        {
            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                TempData.Keep("UserName");

                string user_by = TempData["username"].ToString();

                dynamic model = new ExpandoObject();
                model.menu = db.tblMenus
                    .Where(w => w.Program == w.Program)
                    .FirstOrDefault();

                return View(model);
            }
        }


        [HttpPost]
        public ActionResult deleteMenu(tblMenu menu_obj)
        {
            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    TempData.Keep("username");

                    string user_by = TempData["username"].ToString();

                    tblMenu del_menu = db.tblMenus.Where(x => x.Program == menu_obj.Program).FirstOrDefault();
                    try
                    {
                        db.tblMenus.Remove(del_menu);
                        db.SaveChanges();

                        transaction.Commit();

                        TempData["alert_msg"] = "Delete";
                        return RedirectToAction("menu", "UserMenu");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();

                        TempData["alert_msg"] = "System Error";
                        return RedirectToAction("menu", "UserMenu");

                    }
                }
            }
        }




    }
}