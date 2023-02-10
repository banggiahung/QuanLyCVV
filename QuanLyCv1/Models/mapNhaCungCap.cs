using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCv1.Models
{
    public class mapNhaCungCap
    {

        public List<NhaCungCap> DanhSach()
        {
            // get danh sach
            var db = new QuanLyCVEntities();
            var data = db.NhaCungCaps.ToList();
            return data;
        }
        // loc du lieu
        public List<NhaCungCap> DanhSach(string name)
        {
            // get danh sach
            var db = new QuanLyCVEntities();

            var data = db.NhaCungCaps.Where(m=>m.TenCongViec.ToLower().Contains(name.ToLower()) == true || string.IsNullOrEmpty(name)).ToList();

            // sap xep
            return data.OrderBy(m=>m.Loai_C_V.LoaiCV).ToList();
        }
        public NhaCungCap ChiTiet(int id)
        {
            QuanLyCVEntities db = new QuanLyCVEntities();
            return db.NhaCungCaps.Find(id);
        }
        public List<spDanhSach_Result> spChiTiet(int? idCv)
        {
            QuanLyCVEntities db = new QuanLyCVEntities();
            return db.spDanhSach(idCv).ToList();
        }
      
       

        public bool CapNhatAnh(int idNhaCC,string urlAnh)
        {
            try
            {
                QuanLyCVEntities db = new QuanLyCVEntities();
                var nhaCC = db.NhaCungCaps.Find(idNhaCC);
                nhaCC.HinhAnh = urlAnh;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
           
        }
        public bool CapNhatSTT(int id, int status)
        {
            try
            {
                QuanLyCVEntities db = new QuanLyCVEntities();

                var stt = db.NhaCungCaps.Find(id);
                stt.ID_TrangThai = status;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CapNhatTrangThai(int id, int status)
        {


            QuanLyCVEntities db = new QuanLyCVEntities();

            var stt = db.NhaCungCaps.Find(id);

            if(stt.ID_TrangThai == 1)
            {
                if(status == 2)
                {
                    CapNhatSTT(id,status);
                    return true;
                }
            }
            else if(stt.ID_TrangThai == 2)
            {
                if(status == 1) {
                    CapNhatSTT(id, status);
                    return true;
                }
            }
            return false;

        }
    }
}
