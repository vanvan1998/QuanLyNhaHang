﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelManagementApp.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLKHACHSANEntities : DbContext
    {
        public QLKHACHSANEntities()
            : base("name=QLKHACHSANEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DanhSachBangGia> DanhSachBangGias { get; set; }
        public virtual DbSet<DanhSachLoaiNhanVien> DanhSachLoaiNhanViens { get; set; }
        public virtual DbSet<DanhSachLoaiPhong> DanhSachLoaiPhongs { get; set; }
        public virtual DbSet<DanhSachMaKhuyenMai> DanhSachMaKhuyenMais { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }
    }
}
