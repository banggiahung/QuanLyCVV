using QuanLyCv1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyCv1.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: DanhMuc
        private QuanLyCVEntities db = new QuanLyCVEntities();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChiTiet(int? loaiCv)
        {

            mapLoaiCongViec map = new mapLoaiCongViec();
            var data = map.spTimKiem(loaiCv ?? 0);
            ViewBag.TimKiem = loaiCv;
            return View(data);
        }


    }
}