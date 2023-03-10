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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class QuanLyCVEntities : DbContext
    {
        public QuanLyCVEntities()
            : base("name=QuanLyCVEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Loai_C_V> Loai_C_V { get; set; }
        public virtual DbSet<SLIDE> SLIDEs { get; set; }
        public virtual DbSet<STT_TT> STT_TT { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
    
        public virtual int detailts_hd(Nullable<System.DateTime> start, Nullable<System.DateTime> end)
        {
            var startParameter = start.HasValue ?
                new ObjectParameter("start", start) :
                new ObjectParameter("start", typeof(System.DateTime));
    
            var endParameter = end.HasValue ?
                new ObjectParameter("end", end) :
                new ObjectParameter("end", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("detailts_hd", startParameter, endParameter);
        }
    
        public virtual ObjectResult<search_by_id_Result> search_by_id(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<search_by_id_Result>("search_by_id", idParameter);
        }
    
        public virtual ObjectResult<spDanhSach_Result> spDanhSach(Nullable<int> idCv)
        {
            var idCvParameter = idCv.HasValue ?
                new ObjectParameter("idCv", idCv) :
                new ObjectParameter("idCv", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spDanhSach_Result>("spDanhSach", idCvParameter);
        }
    
        public virtual ObjectResult<spDanhSachCv_Result> spDanhSachCv(Nullable<int> idLoaiCv)
        {
            var idLoaiCvParameter = idLoaiCv.HasValue ?
                new ObjectParameter("idLoaiCv", idLoaiCv) :
                new ObjectParameter("idLoaiCv", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spDanhSachCv_Result>("spDanhSachCv", idLoaiCvParameter);
        }
    }
}
