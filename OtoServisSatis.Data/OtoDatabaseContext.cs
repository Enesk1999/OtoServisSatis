using Microsoft.EntityFrameworkCore;
using OtoServisSatis.Entities;

namespace OtoServisSatis.Data
{
    public class OtoDatabaseContext:DbContext
    {
        public DbSet<Arac> Araclar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Marka> Markalar { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<Servis> Servisler { get; set; }
        public DbSet<Slider> Sliderlar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server =LAPTOP-LESH9FO5; database=OtoServisSatis; integrated security=True; MultipleActiveResultSets=True; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Fluent api ile seed data ve validationlar
            modelBuilder.Entity<Marka>().Property(m => m.Adi).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Rol>().Property(m => m.Adi).IsRequired().HasColumnType("varchar(50)");
            modelBuilder.Entity<Rol>().HasData(new Rol
            {
                Id =1,
                Adi="Admin"
            });
            modelBuilder.Entity<Kullanici>().HasData(new Kullanici
            {
                Id=1,
                Adi="Enes",
                Soyadi="Kaya",
                Telefon="55544455454",
                AktifMi =true,
                EklenmeTarihi = DateTime.Now,
                EMail= "admin@otoservis.com",
                KullaniciAdi="admin",
                Sifre="12345",
                //Rol = new Rol { Id=1},
                RolId =1
            });
            modelBuilder.Entity<Musteri>().HasData(new Musteri
            {
                Id =1,
                Adi="Ahmet",
                Soyadi="Sayılı",
                TcNo="32419392922",
                Mail="ahmet4554@gmail.com",
                Adres="İstanbul BeylikDüzü Gaziosmanpaşa bulvarı no:32/11",
                Aciklama="Yok",
                Telefon="5554442134",
            });
            base.OnModelCreating(modelBuilder);
        }


    }
}
