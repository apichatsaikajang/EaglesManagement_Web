using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EaglesManagement_Web.Models;
using System.Dynamic;

namespace EaglesManagement_Web.Controllers
{
    public class AccessProductController : Controller
    {
        // GET: AccessProduct
        public ActionResult Index()
        {
            using (ITmanagementEntities db = new ITmanagementEntities())
            {

                TempData.Keep("username");

                string user_by = TempData["username"].ToString();

                dynamic model = new ExpandoObject();
                model.Working = db.tblUsers.Where(x => x.UserName == user_by).OrderByDescending(y => y.UserName).ToList();

                return View();
            }
        }

        public ActionResult Access()
        {
            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                TempData.Keep("username");


                string user_by = TempData["username"].ToString();

                dynamic model = new ExpandoObject();
                model.Customer = db.tblUsers.Where(x => x.UserName == user_by).ToList();

                return View();
            }
        }

        public ActionResult Maintenance()
        {
            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                TempData.Keep("username");


                string user_by = TempData["username"].ToString();

                dynamic model = new ExpandoObject();
                model.Customer = db.tblUsers.Where(x => x.UserName == user_by).ToList();

                return View();
            }
        }

        public ActionResult SoftWare()
        {
            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                TempData.Keep("username");


                string user_by = TempData["username"].ToString();

                dynamic model = new ExpandoObject();
                model.Customer = db.tblUsers.Where(x => x.UserName == user_by).ToList();

                return View();
            }
        }


    }
}