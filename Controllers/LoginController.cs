using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Security.Cryptography;
using System.Web.Security;
using System.Web.Routing;
using EaglesManagement_Web.Models;
using System.IO;

namespace EaglesManagement_Web.Controllers
{
    public class LoginController : Controller
    {
        private TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
        private MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
        public string EncryptPass = "eagles";

        // GET: Login
        //[AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(tblUser userModel)
        {
            string str_encypt = userModel.Password;
            string password_enc = encrypt(str_encypt, EncryptPass);

            using (DB_EaglesInternalEntities db = new DB_EaglesInternalEntities())
            {
                var userDetails = db.tblUsers.Where(x => x.UserId == userModel.UserId && x.Password == password_enc).FirstOrDefault();
                if (userDetails != null)
                {
                    FormsAuthentication.SetAuthCookie(userModel.UserId, false);
                    TempData["username"] = userModel.UserId;
                    TempData["name_th"] = userDetails.Name_thai;
                    TempData["position"] = userDetails.Position;
                    TempData["dept"] = userDetails.Dept;
                    return RedirectToAction("Index", "UserProfile");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            TempData.Clear();
            return RedirectToAction("Index", "Login");
        }

        public Byte[] MD5Hash(string value)
        {
            return MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(value));
        }

        public string encrypt(string strToEncrypt, string key)
        {
            DES.Key = MD5Hash(key);
            DES.Mode = CipherMode.ECB;
            Byte[] Buffer = ASCIIEncoding.ASCII.GetBytes(strToEncrypt);
            return Convert.ToBase64String(DES.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length));
        }

        public string decrypt(string encryptedString, string key)
        {
            DES.Key = MD5Hash(key);
            DES.Mode = CipherMode.ECB;
            Byte[] Buffer = Convert.FromBase64String(encryptedString);
            return ASCIIEncoding.ASCII.GetString(DES.CreateDecryptor().TransformFinalBlock(Buffer, 0, Buffer.Length));
        }

    }
}