using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace WebPerpustakaan.Models.EF;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anggotum> Anggota { get; set; }

    public virtual DbSet<Buku> Bukus { get; set; }

    public virtual DbSet<Kategori> Kategoris { get; set; }

    public virtual DbSet<Pinjaman> Pinjamen { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=perpustakaan;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Anggotum>(entity =>
        {
            entity.HasKey(e => e.IdAnggota).HasName("PRIMARY");

            entity.ToTable("anggota");

            entity.Property(e => e.IdAnggota).HasColumnName("id_anggota");
            entity.Property(e => e.Alamat)
                .HasMaxLength(255)
                .HasColumnName("alamat");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Nama)
                .HasMaxLength(255)
                .HasColumnName("nama");
            entity.Property(e => e.NomorTelepon)
                .HasMaxLength(20)
                .HasColumnName("nomor_telepon");
        });

        modelBuilder.Entity<Buku>(entity =>
        {
            entity.HasKey(e => e.IdBuku).HasName("PRIMARY");

            entity.ToTable("buku");

            entity.HasIndex(e => e.KategoriId, "kategori_id");

            entity.Property(e => e.IdBuku).HasColumnName("id_buku");
            entity.Property(e => e.Judul)
                .HasMaxLength(255)
                .HasColumnName("judul");
            entity.Property(e => e.Jumlah).HasColumnName("jumlah");
            entity.Property(e => e.KategoriId).HasColumnName("kategori_id");
            entity.Property(e => e.Penerbit)
                .HasMaxLength(255)
                .HasColumnName("penerbit");
            entity.Property(e => e.Penulis)
                .HasMaxLength(255)
                .HasColumnName("penulis");
            entity.Property(e => e.TahunTerbit)
                .HasColumnType("year")
                .HasColumnName("tahun_terbit");

            entity.HasOne(d => d.Kategori).WithMany(p => p.Bukus)
                .HasForeignKey(d => d.KategoriId)
                .HasConstraintName("buku_ibfk_1");
        });

        modelBuilder.Entity<Kategori>(entity =>
        {
            entity.HasKey(e => e.IdKategori).HasName("PRIMARY");

            entity.ToTable("kategori");

            entity.Property(e => e.IdKategori).HasColumnName("id_kategori");
            entity.Property(e => e.NamaKategori)
                .HasMaxLength(255)
                .HasColumnName("nama_kategori");
        });

        modelBuilder.Entity<Pinjaman>(entity =>
        {
            entity.HasKey(e => e.IdPinjaman).HasName("PRIMARY");

            entity.ToTable("pinjaman");

            entity.HasIndex(e => e.IdAnggota, "id_anggota");

            entity.HasIndex(e => e.IdBuku, "id_buku");

            entity.Property(e => e.IdPinjaman).HasColumnName("id_pinjaman");
            entity.Property(e => e.IdAnggota).HasColumnName("id_anggota");
            entity.Property(e => e.IdBuku).HasColumnName("id_buku");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.TanggalKembali).HasColumnName("tanggal_kembali");
            entity.Property(e => e.TanggalPinjam).HasColumnName("tanggal_pinjam");

            entity.HasOne(d => d.IdAnggotaNavigation).WithMany(p => p.Pinjamen)
                .HasForeignKey(d => d.IdAnggota)
                .HasConstraintName("pinjaman_ibfk_1");

            entity.HasOne(d => d.IdBukuNavigation).WithMany(p => p.Pinjamen)
                .HasForeignKey(d => d.IdBuku)
                .HasConstraintName("pinjaman_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
