using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyCv1.Models;

namespace QuanLyCv1.Areas.Admin.Controllers
{
    public class Loai_C_VController : Controller
    {
        private QuanLyCVEntities db = new QuanLyCVEntities();

        // GET: Admin/Loai_C_V
        public ActionResult Index()
        {
            return View(db.Loai_C_V.ToList());
        }

        // GET: Admin/Loai_C_V/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loai_C_V loai_C_V = db.Loai_C_V.Find(id);
            if (loai_C_V == null)
            {
                return HttpNotFound();
            }
            return View(loai_C_V);
        }

        // GET: Admin/Loai_C_V/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Loai_C_V/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LoaiCV,ID_LOAI")] string categoryName)
        {
            QuanLyCVEntities db = new QuanLyCVEntities();
            var cate = db.Loai_C_V.FirstOrDefault(c => c.LoaiCV == categoryName);
            if (cate == null )
            {
                db.Loai_C_V.Add(new Loai_C_V { LoaiCV = categoryName});
                db.SaveChanges();
                ViewBag.al = "Thêm mới thành công";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.al = "Đã tồn tại tên loại công việc";

            }

            return View();
        }
        public ActionResult Delete(int id)
        {
            var delete = db.Loai_C_V.Find(id);
            if(delete == null)
            {
                ViewBag.sttL = "Không có loại công việc";
            }
            else
            {
                var prd = db.NhaCungCaps.FirstOrDefault(p => p.LoaiIdCv == id);
                if(prd != null)
                {
                    ViewBag.sttL = "Không thể xóa danh mục công việc này vì loại công việc của nhà cung cấp đang có trong danh mục.";

                }
                else
                {
                    db.Loai_C_V.Remove(delete);
                    db.SaveChanges();
                    ViewBag.sttL = "Xóa danh mục thành công.";
                }
            }
            return  View();

        }
        // GET: Admin/Loai_C_V/Edit/5
        public ActionResult Edit(int? id)
        {
            var edit = db.Loai_C_V.Find(id);
            if(edit == null)
            {
                return RedirectToAction("Index");

            }
            return View(edit);
            
        }

        // POST: Admin/Loai_C_V/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eidt(Loai_C_V loai)
        {
            if(ModelState.IsValid)
            {
                var edit = db.Loai_C_V.Find(loai.ID);
                if(edit == null)
                {
                    return RedirectToAction("Index");
                }
                edit.LoaiCV = loai.LoaiCV;
                db.SaveChanges();

                return RedirectToAction("Index");

            }
            return View(loai);
        }
    

        // GET: Admin/Loai_C_V/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loai_C_V loai_C_V = db.Loai_C_V.Find(id);
            if (loai_C_V == null)
            {
                return HttpNotFound();
            }
            return View(loai_C_V);
        }

        // POST: Admin/Loai_C_V/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loai_C_V loai_C_V = db.Loai_C_V.Find(id);
            db.Loai_C_V.Remove(loai_C_V);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
