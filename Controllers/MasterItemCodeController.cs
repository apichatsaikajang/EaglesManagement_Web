using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EaglesManagement_Web.Models;
using System.Dynamic;


namespace EaglesManagement_Web.Controllers
{
    public class MasterItemCodeController : Controller
    {
        // GET: MasterItemCode
        public ActionResult Index()
        {

            using (DB_EaglesInternalEntities db = new DB_EaglesInternalEntities())
            {

                TempData.Keep("username");
                TempData.Keep("name_th");
                TempData.Keep("position");
                TempData.Keep("dept");

                string user_by = TempData["username"].ToString();

                dynamic model = new ExpandoObject();
                model.Working = db.tblUsers.Where(x => x.UserBy == user_by).OrderByDescending(y => y.UserId).ToList();

                return View(model);
            }
        }

        public ActionResult masteritemcodeInsertForm()
        {
            using (DB_EaglesInternalEntities db = new DB_EaglesInternalEntities())
            {
                TempData.Keep("username");
                TempData.Keep("name_th");
                TempData.Keep("position");
                TempData.Keep("dept");

                string user_by = TempData["username"].ToString();

                dynamic model = new ExpandoObject();
                model.Customer = db.tblUsers.Where(x => x.UserBy == user_by).ToList();

                return View(model);
            }
        }

    }
}