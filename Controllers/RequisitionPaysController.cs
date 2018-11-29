using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using EaglesManagement_Web.Models;

namespace EaglesManagement_Web.Controllers
{
    public class RequisitionPaysController : Controller
    {
        // GET: RequisitionPays
        public ActionResult Index()
        {
            return View();
        }

                public ActionResult requisitionpaysInsertForm()
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
    

