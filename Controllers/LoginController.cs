using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using EaglesManagement_Web.Models;
using System.Web.Security;
using System.IO;
using System.Security.Cryptography;

namespace EaglesManagement_Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        //[AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(tblUser userModel)
        {
            string usernameToUpper = (userModel.UserName).ToUpper();
            Byte[] CurrentIV = { 51, 52, 53, 54, 55, 56, 57, 58 };
            Byte[] CurrentKey = { };

            if ((userModel.UserName).Length == 8)
            {
                CurrentKey = Encoding.ASCII.GetBytes(usernameToUpper);
            }
            else if ((userModel.UserName).Length > 8)
            {
                CurrentKey = Encoding.ASCII.GetBytes(usernameToUpper.Substring(0, 8));
            }
            else
            {
                int i = 0;
                string AddString = usernameToUpper.Substring(0, 1);
                int TotalLoop = 8 - usernameToUpper.Length;
                string tmpKey = usernameToUpper;

                for (i = 1; i <= TotalLoop; i++)
                {
                    tmpKey = tmpKey + AddString;
                }

                CurrentKey = Encoding.ASCII.GetBytes(tmpKey);
            }

            DESCryptoServiceProvider desCrypt = new DESCryptoServiceProvider();
            desCrypt.IV = CurrentIV;
            desCrypt.Key = CurrentKey;

            MemoryStream ms = new MemoryStream();
            ms.Position = 0;

            CryptoStream cs = new CryptoStream(ms, desCrypt.CreateEncryptor(), CryptoStreamMode.Write);
            Byte[] arrByte = Encoding.ASCII.GetBytes((userModel.Password));
            cs.Write(arrByte, 0, arrByte.Length);
            cs.FlushFinalBlock();
            cs.Close();

            string PwdwithEncrypt = Convert.ToBase64String(ms.ToArray());

            using (ITmanagementEntities db = new ITmanagementEntities())
            {
                var userDetails = db.tblUsers.Where(x => x.UserName == usernameToUpper && x.Password == PwdwithEncrypt).FirstOrDefault();
                if (userDetails != null)
                {
                    FormsAuthentication.SetAuthCookie(userModel.UserName, false);
                    TempData["username"] = userModel.UserName;
                    //TempData["name_th"] = userDetails.Name_thai;
                    //TempData["position"] = userDetails.Position;
                    //TempData["dept"] = userDetails.Dept;
                    return RedirectToAction("Index", "UserProfile");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }

            //return RedirectToAction("Index", "Approve");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            TempData.Clear();
            return RedirectToAction("Index", "Login");
        }

        


    }
}