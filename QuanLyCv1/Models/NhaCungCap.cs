//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyCv1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NhaCungCap
    {
        public int ID { get; set; }
        public string TenNhaCungCap { get; set; }
        public string LoaiCongViec { get; set; }
        public string TenCongViec { get; set; }
        public Nullable<System.DateTime> NgayDang { get; set; }
        public Nullable<double> LuongBatDau { get; set; }
        public string HinhAnh { get; set; }
        public Nullable<int> LoaiIdCv { get; set; }
        public string DiaChi { get; set; }
        public string MoTa { get; set; }
        public Nullable<int> ID_TrangThai { get; set; }
    
        public virtual Loai_C_V Loai_C_V { get; set; }
        public virtual STT_TT STT_TT { get; set; }
    }
}
