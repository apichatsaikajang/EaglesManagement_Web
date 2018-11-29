using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EaglesManagement_Web.Models;
using System.Dynamic;

namespace EaglesManagement_Web.Controllers
{
    public class UserController : Controller
    {
        // GET: UserMenu
        public ActionResult Index()
        {

            using (ITmanagementEntities1 db = new ITmanagementEntities1())
            {

                TempData.Keep("username");

                string user_by = TempData["username"].ToString();

                dynamic model = new ExpandoObject();
                model.Working = db.tblUsers.Where(x => x.UserName == user_by).OrderByDescending(y => y.UserName).ToList();

                return View(model);
            }
        }

        public ActionResult userInsertForm()
        {
            using (ITmanagementEntities1 db = new ITmanagementEntities1())
            {
                TempData.Keep("username");

                string user_by = TempData["username"].ToString();

                dynamic model = new ExpandoObject();
                model.Customer = db.tblUsers.Where(x => x.UserName == user_by).ToList();

                return View(model);
            }
        }

    }
}