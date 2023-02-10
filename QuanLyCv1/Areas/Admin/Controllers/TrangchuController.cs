using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using QuanLyCv1.Models;
using ShopQuanAo.Areas.admin.Data;

namespace QuanLyCv1.Areas.Admin.Controllers
{
    public class TrangchuController : Controller
    {
        //GET: Admin/Home

        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult Index()
       {

           QuanLyCVEntities db = new QuanLyCVEntities();

           var danhsachNCC = db.NhaCungCaps.ToList();
           if (Session["user"] == null)
           {
               return RedirectToAction("Login");

           }
           else
           {
               return View(danhsachNCC);

           }
       }
      
       public ActionResult Login()
       {
           return View();
       }
       [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult Login(string email,string pass)
       {
           QuanLyCVEntities db = new QuanLyCVEntities();
          
           if (ModelState.IsValid)
           {
               var f_password = GetMD5(pass);
               var data = db.Users.Where(s => s.Username.Equals(email) && s.Password.Equals(f_password)).ToList();
               if (data.Count() > 0)
               {
                  //add session
                  Session["user"] = "admin";
                  //Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                  //Session["Email"] = data.FirstOrDefault().Email;
                  //Session["idUser"] = data.FirstOrDefault().idUser;
                   return RedirectToAction("Index");
               }
               else
               {
                   TempData["error"] = "Sai tài khoản hoặc mật khẩu";
                   return RedirectToAction("Index");

               }
           }
           return View();
            
       }
       public ActionResult LogOut()
       {

           Session.Remove("user") ;
           FormsAuthentication.SignOut();
           return RedirectToAction("Login");
       }
        // {admin - hung }
       public static string GetMD5(string str)
       {
           MD5 md5 = new MD5CryptoServiceProvider();
           byte[] fromData = Encoding.UTF8.GetBytes(str);
           byte[] targetData = md5.ComputeHash(fromData);
           string byte2String = null;

           for (int i = 0; i < targetData.Length; i++)
          {
              byte2String += targetData[i].ToString("x2");

          }
          return byte2String;
       }
    }
}