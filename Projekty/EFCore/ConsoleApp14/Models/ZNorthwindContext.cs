using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ConsoleApp14.Models
{
    public partial class ZNorthwindContext : DbContext
    {
        public ZNorthwindContext()
        {
        }

        public ZNorthwindContext(DbContextOptions<ZNorthwindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdresyKlientow> AdresyKlientows { get; set; }
        public virtual DbSet<Dostawcy> Dostawcies { get; set; }
        public virtual DbSet<Kategorie> Kategories { get; set; }
        public virtual DbSet<Klienci> Kliencis { get; set; }
        public virtual DbSet<KlienciTest> KlienciTests { get; set; }
        public virtual DbSet<Liczby> Liczbies { get; set; }
        public virtual DbSet<PozycjeZamówienium> PozycjeZamówienia { get; set; }
        public virtual DbSet<Pracownicy> Pracownicies { get; set; }
        public virtual DbSet<Produkty> Produkties { get; set; }
        public virtual DbSet<ProduktyZFrancji> ProduktyZFrancjis { get; set; }
        public virtual DbSet<Spedytorzy> Spedytorzies { get; set; }
        public virtual DbSet<UsaKlient> UsaKlients { get; set; }
        public virtual DbSet<VWartoscFaktur> VWartoscFakturs { get; set; }
        public virtual DbSet<VWartośćFaktur> VWartośćFakturs { get; set; }
        public virtual DbSet<WartoscZamowienMiast> WartoscZamowienMiasts { get; set; }
        public virtual DbSet<Zamówienium> Zamówienia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-9SL4PUT;Database=ZNorthwind;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<AdresyKlientow>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("AdresyKlientow");

                entity.Property(e => e.Adres).HasMaxLength(60);

                entity.Property(e => e.Klient)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.KodPocztowy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Kod pocztowy")
                    .IsFixedLength(true);

                entity.Property(e => e.Kraj).HasMaxLength(15);

                entity.Property(e => e.Miejscowość).HasMaxLength(15);
            });

            modelBuilder.Entity<Dostawcy>(entity =>
            {
                entity.HasKey(e => e.Iddostawcy);

                entity.ToTable("Dostawcy", "mg");

                entity.Property(e => e.Iddostawcy)
                    .ValueGeneratedNever()
                    .HasColumnName("IDdostawcy");

                entity.Property(e => e.Adres).HasMaxLength(60);

                entity.Property(e => e.Faks).HasMaxLength(24);

                entity.Property(e => e.KodPocztowy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Kraj).HasMaxLength(15);

                entity.Property(e => e.Miasto).HasMaxLength(15);

                entity.Property(e => e.NazwaFirmy)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Przedstawiciel).HasMaxLength(30);

                entity.Property(e => e.Region).HasMaxLength(15);

                entity.Property(e => e.StanowiskoPrzedstawiciela).HasMaxLength(30);

                entity.Property(e => e.Telefon).HasMaxLength(24);
            });

            modelBuilder.Entity<Kategorie>(entity =>
            {
                entity.HasKey(e => e.Idkategorii);

                entity.ToTable("Kategorie", "mg");

                entity.Property(e => e.Idkategorii)
                    .ValueGeneratedNever()
                    .HasColumnName("IDkategorii");

                entity.Property(e => e.NazwaKategorii)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Rysunek).HasColumnType("image");
            });

            modelBuilder.Entity<Klienci>(entity =>
            {
                entity.HasKey(e => e.Idklienta)
                    .HasName("PK_IDKlienta");

                entity.ToTable("Klienci");

                entity.Property(e => e.Idklienta)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("IDklienta")
                    .IsFixedLength(true);

                entity.Property(e => e.Adres).HasMaxLength(60);

                entity.Property(e => e.Faks).HasMaxLength(24);

                entity.Property(e => e.KodPocztowy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Kraj).HasMaxLength(15);

                entity.Property(e => e.Miasto).HasMaxLength(15);

                entity.Property(e => e.NazwaFirmy)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Przedstawiciel).HasMaxLength(30);

                entity.Property(e => e.Region).HasMaxLength(15);

                entity.Property(e => e.StanowiskoPrzedstawiciela).HasMaxLength(35);

                entity.Property(e => e.Telefon).HasMaxLength(24);
            });

            modelBuilder.Entity<KlienciTest>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("KlienciTest");

                entity.Property(e => e.Idklienta)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("IDklienta")
                    .IsFixedLength(true);

                entity.Property(e => e.Kraj).HasMaxLength(15);

                entity.Property(e => e.NazwaFirmy)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Liczby>(entity =>
            {
                entity.HasKey(e => e.Digit)
                    .HasName("PK__Liczby__70DB44693993C312");

                entity.ToTable("Liczby");

                entity.Property(e => e.Digit)
                    .ValueGeneratedNever()
                    .HasColumnName("digit");
            });

            modelBuilder.Entity<PozycjeZamówienium>(entity =>
            {
                entity.HasKey(e => new { e.Idzamówienia, e.Idproduktu })
                    .HasName("PK_PozycjeZamowien");

                entity.Property(e => e.Idzamówienia).HasColumnName("IDzamówienia");

                entity.Property(e => e.Idproduktu).HasColumnName("IDproduktu");

                entity.Property(e => e.CenaJednostkowa).HasColumnType("money");

                entity.HasOne(d => d.IdproduktuNavigation)
                    .WithMany(p => p.PozycjeZamówienia)
                    .HasForeignKey(d => d.Idproduktu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PozycjeZamówienia_Produkty");

                entity.HasOne(d => d.IdzamówieniaNavigation)
                    .WithMany(p => p.PozycjeZamówienia)
                    .HasForeignKey(d => d.Idzamówienia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PozycjeZamówienia_Zamówienia");
            });

            modelBuilder.Entity<Pracownicy>(entity =>
            {
                entity.HasKey(e => e.Idpracownika);

                entity.ToTable("Pracownicy");

                entity.Property(e => e.Idpracownika)
                    .ValueGeneratedNever()
                    .HasColumnName("IDpracownika");

                entity.Property(e => e.Adres).HasMaxLength(60);

                entity.Property(e => e.DataUrodzenia).HasColumnType("datetime");

                entity.Property(e => e.DataZatrudnienia).HasColumnType("datetime");

                entity.Property(e => e.Fotografia).HasColumnType("image");

                entity.Property(e => e.Imię)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.KodPocztowy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Kraj).HasMaxLength(15);

                entity.Property(e => e.Miasto).HasMaxLength(25);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Region).HasMaxLength(15);

                entity.Property(e => e.Stanowisko).HasMaxLength(40);

                entity.Property(e => e.TelefonDomowy).HasMaxLength(24);

                entity.Property(e => e.TelefonWewnętrzny).HasMaxLength(4);

                entity.Property(e => e.ZwrotGrzecznościowy).HasMaxLength(25);
            });

            modelBuilder.Entity<Produkty>(entity =>
            {
                entity.HasKey(e => e.Idproduktu);

                entity.ToTable("Produkty", "mg");

                entity.Property(e => e.Idproduktu)
                    .ValueGeneratedNever()
                    .HasColumnName("IDproduktu");

                entity.Property(e => e.CenaJednostkowa).HasColumnType("money");

                entity.Property(e => e.Iddostawcy).HasColumnName("IDdostawcy");

                entity.Property(e => e.Idkategorii).HasColumnName("IDkategorii");

                entity.Property(e => e.IlośćJednostkowa).HasMaxLength(255);

                entity.Property(e => e.NazwaProduktu)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.HasOne(d => d.IddostawcyNavigation)
                    .WithMany(p => p.Produkties)
                    .HasForeignKey(d => d.Iddostawcy)
                    .HasConstraintName("FK_Produkty_Dostawcy");

                entity.HasOne(d => d.IdkategoriiNavigation)
                    .WithMany(p => p.Produkties)
                    .HasForeignKey(d => d.Idkategorii)
                    .HasConstraintName("FK_Produkty_Kategorie");
            });

            modelBuilder.Entity<ProduktyZFrancji>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Produkty_z_Francji");

                entity.Property(e => e.NazwaProduktu)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Spedytorzy>(entity =>
            {
                entity.HasKey(e => e.Idspedytora);

                entity.ToTable("Spedytorzy");

                entity.Property(e => e.Idspedytora)
                    .ValueGeneratedNever()
                    .HasColumnName("IDspedytora");

                entity.Property(e => e.NazwaFirmy)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Telefon).HasMaxLength(24);
            });

            modelBuilder.Entity<UsaKlient>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("UsaKlient");

                entity.Property(e => e.KrajOdbiorcy).HasMaxLength(15);

                entity.Property(e => e.Suma).HasColumnType("money");
            });

            modelBuilder.Entity<VWartoscFaktur>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWartoscFaktur");

                entity.Property(e => e.Idzamówienia).HasColumnName("IDzamówienia");
            });

            modelBuilder.Entity<VWartośćFaktur>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vWartośćFaktur");

                entity.Property(e => e.Idzamówienia).HasColumnName("IDzamówienia");

                entity.Property(e => e.WartośćZ).HasColumnType("money");
            });

            modelBuilder.Entity<WartoscZamowienMiast>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("WartoscZamowienMiast");

                entity.Property(e => e.KrajOdbiorcy).HasMaxLength(15);

                entity.Property(e => e.MiastoOdbiorcy).HasMaxLength(15);

                entity.Property(e => e.WartoscZamowniea).HasColumnType("money");
            });

            modelBuilder.Entity<Zamówienium>(entity =>
            {
                entity.HasKey(e => e.Idzamówienia);

                entity.Property(e => e.Idzamówienia)
                    .ValueGeneratedNever()
                    .HasColumnName("IDzamówienia");

                entity.Property(e => e.AdresOdbiorcy).HasMaxLength(60);

                entity.Property(e => e.DataWymagana).HasColumnType("datetime");

                entity.Property(e => e.DataWysyłki).HasColumnType("datetime");

                entity.Property(e => e.DataZamówienia).HasColumnType("datetime");

                entity.Property(e => e.Fracht).HasColumnType("money");

                entity.Property(e => e.Idklienta)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("IDklienta")
                    .IsFixedLength(true);

                entity.Property(e => e.Idpracownika).HasColumnName("IDpracownika");

                entity.Property(e => e.Idspedytora).HasColumnName("IDspedytora");

                entity.Property(e => e.KodPocztowyOdbiorcy).HasMaxLength(10);

                entity.Property(e => e.KrajOdbiorcy).HasMaxLength(15);

                entity.Property(e => e.MiastoOdbiorcy).HasMaxLength(15);

                entity.Property(e => e.NazwaOdbiorcy).HasMaxLength(40);

                entity.Property(e => e.RegionOdbiorcy).HasMaxLength(15);

                entity.HasOne(d => d.IdklientaNavigation)
                    .WithMany(p => p.Zamówienia)
                    .HasForeignKey(d => d.Idklienta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Zamówienia_Klienci");

                entity.HasOne(d => d.IdpracownikaNavigation)
                    .WithMany(p => p.Zamówienia)
                    .HasForeignKey(d => d.Idpracownika)
                    .HasConstraintName("FK_Zamówienia_Pracownicy");

                entity.HasOne(d => d.IdspedytoraNavigation)
                    .WithMany(p => p.Zamówienia)
                    .HasForeignKey(d => d.Idspedytora)
                    .HasConstraintName("FK_Zamówienia_Spedytorzy");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
