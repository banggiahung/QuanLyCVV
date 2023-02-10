using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using QuanLyCv1.Models;


namespace QuanLyCv1.Areas.Admin.Controllers
{
    public class LoaiCongViecController : Controller
    {
        // GET: Admin/LoaiCongViec
        private QuanLyCVEntities db = new QuanLyCVEntities();

        public ActionResult DanhSach(int? loaiCv)
        {
            mapLoaiCongViec map = new mapLoaiCongViec();
            var data = map.spTimKiem(loaiCv??0);
            ViewBag.loaiCv = loaiCv;
            return View(data);
        }
        public ActionResult ChiTiet(int id)
        {

            var nhaCC = db.NhaCungCaps.Find(id);
            return View(nhaCC);
        }
        public ActionResult TimKiem(int? loaiCv, int? page)
        {
            mapLoaiCongViec map = new mapLoaiCongViec();
            var data = map.spTimKiem(loaiCv?? 0);
            ViewBag.TimKiem = loaiCv;
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(data.ToPagedList(pageNumber, pageSize));
        }
    }
}