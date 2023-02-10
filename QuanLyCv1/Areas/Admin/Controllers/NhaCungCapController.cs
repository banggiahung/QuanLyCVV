using PagedList;
using QuanLyCv1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Data.Entity;

using System.Web.Mvc;
using System.Web.UI;
using System.Drawing.Printing;
using System.Web.UI.WebControls;

namespace QuanLyCv1.Areas.Admin.Controllers
{
    public class NhaCungCapController : Controller
    {
        private QuanLyCVEntities db = new QuanLyCVEntities();

        // GET: Admin/NhaCungCap

        
        public ActionResult DanhSach(string name, int? page, int categoryID = 0)
        {
            ViewBag.key = name;
            ViewBag.Subject = categoryID;
            var sp = db.NhaCungCaps.Include(b => b.Loai_C_V);
            if (categoryID != 0)
            {
                sp = sp.Where(c => c.LoaiIdCv == categoryID);
                page = 1;
            }
            if (!string.IsNullOrEmpty(name))
            {
                sp = sp.Where(b => b.TenCongViec.Contains(name));
                page = 1;
            }
            ViewBag.CategoryID = new SelectList(db.Loai_C_V, "ID", "LoaiCV");
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(sp.OrderBy(p=>p.ID).ToPagedList(pageNumber, pageSize));
           
        }
   

        [HttpPost]
        public JsonResult AutoSearch(string autoName)
        {
            var ps = db.NhaCungCaps.Where(b => b.TenCongViec.Contains(autoName)).Select(b => new { label = b.TenCongViec });
            return Json(ps, JsonRequestBehavior.AllowGet);  
        }



        public ActionResult ThemMoi()
        {
            ViewBag.LoaiIdCv = new SelectList(db.Loai_C_V, "ID", "LoaiCV");
          
            return View(new NhaCungCap() { NgayDang = DateTime.Now}) ;
        }
        public ActionResult ThemMoiLoai(int id)
        {
            return View(new Loai_C_V() { ID = id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult ThemMoi([Bind(Include = "ID,TenNhaCungCap,LoaiCongViec,TenCongViec,NgayDang,LuongBatDau,TrangThai,Status,HinhAnh,LoaiIdCv,DiaChi,MoTa")] NhaCungCap model, HttpPostedFileBase HinhAnh, int? id)
        {
            //check data
            model.ID_TrangThai = 1;
            if (string.IsNullOrEmpty(model.TenNhaCungCap) == true)
            {
                ModelState.AddModelError("", "Khong de trong nha cung cap");
                return View(model);

            }
            if (HinhAnh != null && HinhAnh.ContentLength > 0)
            {
               

                //model.Anh = new byte[HinhAnh.ContentLength];
                //HinhAnh.InputStream.Read(model.Anh, 0, HinhAnh.ContentLength);
                //string fileName = System.IO.Path.GetFileName(HinhAnh.FileName);
                //string url = Server.MapPath("~/Data/images/" + fileName);
                //HinhAnh.SaveAs(url);
                //model.HinhAnh = "~/Data/images/" + fileName;
               var tuongDoiUrl = "/Data/images/"; // luu data 
                var tuyetDoiUrl = Server.MapPath(tuongDoiUrl); // luu file server

                HinhAnh.SaveAs(tuyetDoiUrl + HinhAnh.FileName);
                string fullUrl = tuyetDoiUrl + HinhAnh.FileName;
                int i = 0;
                while (System.IO.File.Exists(fullUrl) == true)
                {
                    string ten = Path.GetFileNameWithoutExtension(HinhAnh.FileName);
                    string duoi = Path.GetExtension(HinhAnh.FileName);
                    fullUrl = tuyetDoiUrl + ten + "-" + i + duoi;
                    i++;
                }
                HinhAnh.SaveAs(fullUrl);
                model.HinhAnh = tuongDoiUrl + Path.GetFileName(fullUrl);
            }

            // save
            if (ModelState.IsValid)
            {
                try
                {
                   
                    //var tuongDoiUrl = "/Data/images/"; // luu data 
                    //var tuyetDoiUrl = Server.MapPath(tuongDoiUrl); // luu file server

                    //HinhAnh.SaveAs(tuyetDoiUrl + HinhAnh.FileName);
                    //string fullUrl = tuyetDoiUrl + HinhAnh.FileName;
                    //int i = 0;
                    //while (System.IO.File.Exists(fullUrl) == true)
                    //{
                    //    string ten = Path.GetFileNameWithoutExtension(HinhAnh.FileName);
                    //    string duoi = Path.GetExtension(HinhAnh.FileName);
                    //    fullUrl = tuyetDoiUrl + ten + "-" + i + duoi;
                    //    i++;
                    //}
                    //HinhAnh.SaveAs(fullUrl);

                    //string _FileName = Path.GetFileName(HinhAnh.FileName);
                    //string _path = Path.Combine(Server.MapPath("~/Data/images/"), _FileName);
                    //HinhAnh.SaveAs(_path);

                    db.NhaCungCaps.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("ChiTiet", new {id = model.ID});
                }

                catch
                {
                    ModelState.AddModelError("", "Loi khong the tao");

                }
              
            }
            ViewBag.LoaiIdCv = new SelectList(db.Loai_C_V, "ID", "LoaiCV", model.LoaiIdCv);
            return View(model);

        }

        public ActionResult CapNhat(int id)
        {
            var map = new mapNhaCungCap();
            var cungCap = map.ChiTiet(id);
            ViewBag.LoaiIdCv = new SelectList(db.Loai_C_V, "ID", "LoaiCV");

            return View(cungCap);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult CapNhat([Bind(Include = "ID,TenNhaCungCap,LoaiCongViec,TenCongViec,NgayDang,LuongBatDau,TrangThai,Status,HinhAnh,LoaiIdCv,DiaChi,MoTa")] NhaCungCap model,int? id, HttpPostedFileBase fileAnh)
        {
            

            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ChiTiet", new {id = model.ID});


            }
            ViewBag.LoaiIdCv = new SelectList(db.Loai_C_V, "ID", "LoaiCV", model.LoaiIdCv);
            return View(model);

            //if (string.IsNullOrEmpty(model.TenNhaCungCap) == true)
            //{
            //    ModelState.AddModelError("", "Khong de trong nha cung cap");
            //    return View(model);

            //}

            //// save
            //try
            //{
            //    var upDateCungCap = db.NhaCungCaps.Find(model.ID);

            //    upDateCungCap.TenNhaCungCap = model.TenNhaCungCap;
            //    upDateCungCap.TenCongViec = model.TenCongViec;
            //    upDateCungCap.LoaiIdCv = model.LoaiIdCv;
            //    upDateCungCap.NgayDang = model.NgayDang;
            //    upDateCungCap.LuongBatDau= model.LuongBatDau;

            //    db.SaveChanges();

            //    return RedirectToAction("DanhSach");

            //}
            //catch
            //{
            //    ModelState.AddModelError("", "Loi khong the tao");

            //    return View();
            //}
           

        }
        public ActionResult Xoa(int id)
        {
            var deleteCungCap = db.NhaCungCaps.Find(id);

            db.NhaCungCaps.Remove(deleteCungCap);
            db.SaveChanges();

            return RedirectToAction("DanhSach");

        }
        public ActionResult ChiTiet(int id)
        {

            var nhaCC = db.NhaCungCaps.Find(id);
            return View(nhaCC);
        }

       //public ActionResult ThemPhanLoai(int idLoai) {

       //   return View(new Loai_C_V() { ID == idLoai });
       // }
        public ActionResult CapNhatAnh(int idNhaCC)
        {
            ViewBag.idNhaCC = idNhaCC;
            return View();
        }
        [HttpPost]
        public ActionResult CapNhatAnh(int idNhaCC, HttpPostedFileBase fileAnh)
        {

            if(fileAnh == null)
            {
                ViewBag.error = "Chua chon file";
                ViewBag.idNhaCC = idNhaCC;

                return View();
            }
            if(fileAnh.ContentLength ==0)
            {
                ViewBag.error = "file khong co noi dung";
                ViewBag.idNhaCC = idNhaCC;

                return View();
            }
            var tuongDoiUrl = "/Data/images/"; // luu data 
            var tuyetDoiUrl = Server.MapPath(tuongDoiUrl); // luu file server

            fileAnh.SaveAs(tuyetDoiUrl+fileAnh.FileName);
            string fullUrl = tuyetDoiUrl+ fileAnh.FileName;
            int i = 0;
            while(System.IO.File.Exists(fullUrl)==true)
            {
                string ten = Path.GetFileNameWithoutExtension(fileAnh.FileName);
            string duoi = Path.GetExtension(fileAnh.FileName);
                fullUrl = tuyetDoiUrl+ten +"-" + i+ duoi;
                i++;
            }
            fileAnh.SaveAs(fullUrl);

            // data

            mapNhaCungCap map = new mapNhaCungCap();
            map.CapNhatAnh(idNhaCC, tuongDoiUrl + Path.GetFileName(fullUrl));

            return RedirectToAction("ChiTiet", new {id = idNhaCC});
        }

        public JsonResult CapNhatStt(int id, FormCollection collection)
        {
            var map = new mapNhaCungCap();

            var status = int.Parse(collection["status"]);
            var check = map.CapNhatTrangThai(id, status);
            return Json(new
            {
                status = check
            }, JsonRequestBehavior.AllowGet);
        }
    }
}