using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace YemekTarifi.Models.DB;

public partial class YemekTarifiContext : DbContext
{
    public YemekTarifiContext()
    {
    }

    public YemekTarifiContext(DbContextOptions<YemekTarifiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GununYemegi> GununYemegis { get; set; }

    public virtual DbSet<Kategoriler> Kategorilers { get; set; }

    public virtual DbSet<Kullanıcı> Kullanıcıs { get; set; }

    public virtual DbSet<Yemekler> Yemeklers { get; set; }

    public virtual DbSet<Yonetici> Yoneticis { get; set; }

    public virtual DbSet<Yorumlar> Yorumlars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SELMAN;Initial Catalog=YemekTarifi;User Id =sa;Password=Password1;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GununYemegi>(entity =>
        {
            entity.ToTable("GununYemegi");

            entity.Property(e => e.GununYemegiId).HasColumnName("GununYemegiID");
            entity.Property(e => e.Ad)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Malzemeler)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Tarif)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Tarih)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.YemekId).HasColumnName("YemekID");

            entity.HasOne(d => d.Yemek).WithMany(p => p.GununYemegis)
                .HasForeignKey(d => d.YemekId)
                .HasConstraintName("FK_GununYemegi_Yemekler");
        });

        modelBuilder.Entity<Kategoriler>(entity =>
        {
            entity.HasKey(e => e.KategoriId);

            entity.ToTable("Kategoriler");

            entity.Property(e => e.KategoriId).HasColumnName("KategoriID");
            entity.Property(e => e.Ad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Resim)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Kullanıcı>(entity =>
        {
            entity.ToTable("kullanıcıs");

            entity.Property(e => e.KullanıcıId)
                .ValueGeneratedNever()
                .HasColumnName("KullanıcıID");
            entity.Property(e => e.AdminMi)
                .HasDefaultValueSql("((0))")
                .HasColumnName("AdminMi?");
            entity.Property(e => e.Eposta)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.KullanıcıAdı)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Sifre)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Yemekler>(entity =>
        {
            entity.HasKey(e => e.YemekId);

            entity.ToTable("Yemekler");

            entity.Property(e => e.YemekId).HasColumnName("YemekID");
            entity.Property(e => e.KategoriId).HasColumnName("KategoriID");
            entity.Property(e => e.KullanıcıId).HasColumnName("KullanıcıID");
            entity.Property(e => e.Malzeme)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Resim)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Tarif).IsUnicode(false);
            entity.Property(e => e.Tarih)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.YemekAd)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Yorum)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.Kategori).WithMany(p => p.Yemeklers)
                .HasForeignKey(d => d.KategoriId)
                .HasConstraintName("FK_Yemekler_Kategoriler");

            entity.HasOne(d => d.Kullanıcı).WithMany(p => p.Yemeklers)
                .HasForeignKey(d => d.KullanıcıId)
                .HasConstraintName("FK_Yemekler_kullanıcıs");
        });

        modelBuilder.Entity<Yonetici>(entity =>
        {
            entity.ToTable("Yonetici");

            entity.Property(e => e.YoneticiId)
                .ValueGeneratedOnAdd()
                .HasColumnName("YoneticiID");
            entity.Property(e => e.Ad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sıfre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Yorumlar>(entity =>
        {
            entity.HasKey(e => e.YorumId);

            entity.ToTable("Yorumlar");

            entity.Property(e => e.YorumId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("YorumID");
            entity.Property(e => e.Icerik)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.KullanıcıId).HasColumnName("KullanıcıID");
            entity.Property(e => e.Onay).HasDefaultValueSql("((0))");
            entity.Property(e => e.Tarih)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime");
            entity.Property(e => e.YemekId).HasColumnName("YemekID");

            entity.HasOne(d => d.Kullanıcı).WithMany(p => p.Yorumlars)
                .HasForeignKey(d => d.KullanıcıId)
                .HasConstraintName("FK_Yorumlar_kullanıcıs");

            entity.HasOne(d => d.Yemek).WithMany(p => p.Yorumlars)
                .HasForeignKey(d => d.YemekId)
                .HasConstraintName("FK_Yorumlar_Yemekler");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
