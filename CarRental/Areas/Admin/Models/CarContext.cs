﻿
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarRental.Areas.Admin.Models.ViewModel;

namespace CarRental.Areas.Admin.Models
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options) { }

        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<CTHD> CTHDs { get; set; }
        public DbSet<DonDatXe> DonDatXes { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Hang> Hangs { get; set; }
        public DbSet<InfoUser> InfoUsers { get; set; }
        public DbSet<InfoXe> InfoXes { get; set; }
        public DbSet<Loaixe> Loaixes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<TinhNang> TinhNangs { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<XeTinhNang> XeTinhNangs { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<XeTinhNang>(entity =>
            {
                entity.HasKey(c => new { c.Idtinhnang, c.Idxe });

                entity.HasOne(t => t.TinhNang)
                .WithMany(x => x.XeTinhNang)
                .HasForeignKey(xet => xet.Idtinhnang);

                entity.HasOne(t => t.InfoXe)
               .WithMany(x => x.ListTinhNang)
               .HasForeignKey(xet => xet.Idxe);

            });
            modelBuilder.Entity<TinhNang>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100)
                .IsUnicode(true);
            });

            modelBuilder.Entity<Hang>(entity =>
            {
                entity.Property(e=> e.Name).IsRequired().HasMaxLength(100).IsUnicode(true);
            });

            modelBuilder.Entity<Loaixe>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);

                entity.HasOne(h => h.Hang)
                .WithMany(m => m.Loaixe)
                .HasForeignKey(h => h.HangId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<InfoXe>(entity =>
            {
                entity.Property(e => e.Bienso).HasMaxLength(10).IsRequired();

                entity.Property(e => e.Soghe).IsRequired();

                entity.Property(e=> e.Truyendong).HasMaxLength(20).IsRequired();

                entity.Property(e=>e.LoaiNl).HasMaxLength(30).IsRequired();

                entity.Property(e => e.Mota).HasMaxLength(500);

                entity.HasOne(h => h.Hang)
                .WithMany(x => x.InfoXe)
                .HasForeignKey(h => h.IdHang)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(l => l.Loaixe)
                .WithMany(x => x.InfoXe)
                .HasForeignKey(l => l.IdLoaiXe)
                .OnDelete(DeleteBehavior.ClientSetNull);

                

                entity.HasOne(u => u.User)
                .WithMany(x => x.InfoXe)
                .HasForeignKey(u => u.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull);



            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.Property(e => e.Loinhan).HasMaxLength(500).IsUnicode(true);

                entity.Property(e => e.Diachixe).IsRequired().HasMaxLength(100).IsUnicode(true);

                entity.Property(e => e.LimitXechay).IsRequired();

                entity.Property(e => e.GiaVuot).IsRequired();

                entity.Property(e =>e.Img).IsRequired().HasMaxLength(200);
                entity.Property(e => e.GioiHankmgiaoxe).IsRequired();
                entity.Property(e => e.Gia).IsRequired();

                entity.HasOne(u => u.InfoXe)
                    .WithOne(x => x.SanPham)
                    .HasForeignKey<SanPham>(x => x.IdInfo);
                

                entity.HasOne(u => u.InfoUser)
                .WithMany(s => s.sanPhams)
                .HasForeignKey(s => s.IdChuXe)
                .OnDelete(DeleteBehavior.ClientSetNull);


                
                
            });

            modelBuilder.Entity<User>(entity =>
            {
            entity.Property(e => e.UserName).HasMaxLength(50).IsRequired().IsUnicode(true);

            entity.Property(e => e.Password).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Phone).IsRequired().HasMaxLength(10);

            entity.HasOne(r => r.role)
            .WithMany(u => u.Users)
            .HasForeignKey(u => u.IdRole)
            .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.Property(e => e.Noidung).HasMaxLength(200).IsRequired().IsUnicode(true);
                entity.Property(e => e.Danhgia).IsRequired();
                entity.Property(e => e.Date)
                .HasColumnType("date")
                .IsRequired();

                entity.HasOne(u => u.InfoUserCus)
                .WithMany(f => f.FeedbacksCus)
                .HasForeignKey(f => f.IdCus)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(u => u.InfoUserOwn)
                .WithMany(f => f.FeedbacksOwner)
                .HasForeignKey(f => f.IdCarOwner)
                .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.NameRole).HasMaxLength(50).IsRequired().IsUnicode(true);

            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.Property(e => e.Paymentdate)
                .HasColumnType("date")
                .IsRequired();

                entity.Property(e => e.Total).IsRequired();

                entity.HasOne(u => u.infoUser)
               .WithMany(f => f.HoaDoncs)
               .HasForeignKey(f => f.IdCus)
               .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(u => u.infoUser)
               .WithMany(f => f.HoaDoncs)
               .HasForeignKey(f => f.IdOwner)
               .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<CTHD>(entity =>
            {
            entity.Property(e => e.Gia).IsRequired();

            entity.Property(e => e.Checkin)
           .HasColumnType("date")
           .IsRequired();

            entity.Property(e => e.Checkout)
           .HasColumnType("date")
           .IsRequired();

            entity.HasOne(h => h.HoaDoncs)
            .WithMany(c => c.cTHDs)
            .HasForeignKey(c => c.IDHD)
            .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(h => h.SanPham)
            .WithMany(c => c.CTHDs)
            .HasForeignKey(c => c.IdSp)
            .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(e => e.IdSp).IsRequired();
               
            });

            modelBuilder.Entity<DonDatXe>(entity =>
            {
                entity.Property(e => e.State).IsRequired();

                entity.Property(e => e.ngayDat).IsRequired();

                

                entity.Property(e => e.checkin)
              .HasColumnType("date")
              .IsRequired();

                entity.Property(e => e.checkout)
               .HasColumnType("date")
               .IsRequired();

                entity.HasOne(i => i.InfoUserCus)
                .WithMany(d => d.DonDatXesCus)
                .HasForeignKey(d => d.IdCus)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(i => i.infoUserOwner)
                .WithMany(d => d.DonDatXesOwner)
                .HasForeignKey(d => d.IdOwner)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(i => i.SanPham)
                .WithMany(d => d.DonDatXes)
                .HasForeignKey(d => d.IdSp)
                .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<InfoUser>(entity =>
            {
                entity.Property(e => e.IdUser).IsRequired();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100).IsUnicode(true);
                entity.Property(e => e.CCCD).IsRequired().HasMaxLength(15);
                entity.Property(e => e.GPLX).IsRequired().HasMaxLength(20);

                entity.Property(e => e.ImgGplx).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Img).IsRequired().HasMaxLength(200);
                entity.Property(e => e.GioiTinh).IsRequired();
                entity.Property(e => e.Ngaysinh)
               .HasColumnType("date")
               .IsRequired();

                



            });


            //modelBuilder.ApplyConfiguration(new CarRentalUserEntityConfiguration());

        }
        

        public DbSet<CarRental.Areas.Admin.Models.ViewModel.XeTinhNangViewModel> XeTinhNangViewModel { get; set; } = default!;

    }

    //public class CarRentalUserEntityConfiguration : IEntityTypeConfiguration<CarRentalUser>
    //{
    //    public void Configure(EntityTypeBuilder<CarRentalUser> builder)
    //    {
    //        builder.Property(e => e.Firstname).HasMaxLength(100).IsRequired().IsUnicode(true);

    //        builder.Property(e => e.Lastname).IsRequired().HasMaxLength(100).IsUnicode(true);
            

    //    }
    //}
}
