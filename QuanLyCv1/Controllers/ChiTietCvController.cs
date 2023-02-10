using QuanLyCv1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyCv1.Controllers
{
    public class ChiTietCvController : Controller
    {
        // GET: ChiTietSanPham
        public ActionResult ChiTietCv(int? id)
        {
            QuanLyCVEntities db = new QuanLyCVEntities();
            var nhaCC = db.NhaCungCaps.Find(id);
            return View(nhaCC);
        }
    }
}