namespace Data_Access.DTO
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLKS : DbContext
    {
        public QLKS()
            : base("name=QLKS1")
        {
        }

        public virtual DbSet<CHITIETPHONG> CHITIETPHONGs { get; set; }
        ///public virtual DbSet<CHITIETTHUEPHONG> CHITIETTHUEPHONGs { get; set; }
        public virtual DbSet<DICHVU> DICHVUs { get; set; }
        public virtual DbSet<LOAIPHONG> LOAIPHONGs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<PHONG> PHONGs { get; set; }
        public virtual DbSet<SDDV> SDDVs { get; set; }
        public virtual DbSet<TAISAN> TAISANs { get; set; }
        public virtual DbSet<THUEPHONG> THUEPHONGs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETPHONG>()
                .Property(e => e.CMND)
                .IsFixedLength();

            //modelBuilder.Entity<CHITIETTHUEPHONG>()
            //    .HasMany(e => e.CHITIETPHONGs)
            //    .WithRequired(e => e.CHITIETTHUEPHONG)
            //    .HasForeignKey(e => e.IDCT)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<CHITIETTHUEPHONG>()
            //    .HasMany(e => e.SDDVs)
            //    .WithRequired(e => e.CHITIETTHUEPHONG)
            //    .HasForeignKey(e => e.IDCT)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<DICHVU>()
            //    .HasMany(e => e.SDDVs)
            //    .WithRequired(e => e.DICHVU)
            //    .HasForeignKey(e => e.IDDV)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOAIPHONG>()
                .HasMany(e => e.PHONGs)
                .WithRequired(e => e.LOAIPHONG)
                .HasForeignKey(e => e.IDLOAI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.THUEPHONGs)
                .WithRequired(e => e.NHANVIEN)
                .HasForeignKey(e => e.IDNHANVIEN)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<PHONG>()
            //    .HasMany(e => e.CHITIETTHUEPHONGs)
            //    .WithRequired(e => e.PHONG)
            //    .HasForeignKey(e => e.IDPHONG)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHONG>()
                .HasMany(e => e.TAISANs)
                .WithRequired(e => e.PHONG)
                .HasForeignKey(e => e.IDPHONG)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<THUEPHONG>()
            //    .Property(e => e.CMND)
            //    .IsFixedLength();

            //modelBuilder.Entity<THUEPHONG>()
            //    .HasMany(e => e.CHITIETTHUEPHONGs)
            //    .WithRequired(e => e.THUEPHONG)
            //    .HasForeignKey(e => e.IDMATHUE)
            //    .WillCascadeOnDelete(false);
        }
    }
}
