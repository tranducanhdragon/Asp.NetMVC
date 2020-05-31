namespace HoaTuoi.Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HoaTuoiDBContext : DbContext
    {
        public HoaTuoiDBContext()
            : base("name=HoaTuoiDBContext")
        {
        }

        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<GioHang> GioHangs { get; set; }
        public virtual DbSet<Hoa> Hoas { get; set; }
        public virtual DbSet<Mua> Muas { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<SlideHoa> SlideHoas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.DonHangs)
                .WithRequired(e => e.NguoiDung)
                .WillCascadeOnDelete(false);
        }
    }
}
