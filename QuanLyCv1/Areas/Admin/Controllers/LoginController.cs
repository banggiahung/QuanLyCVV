using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyCv1.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string user, string pass)
        {
            //

            //
            if(user.ToLower() =="admin" && pass == "123456")
            {
                Session["user"] = "admin";
                return RedirectToAction("Trangchu");
            }
            else
            {
                return View();

            }
        }
    }
}