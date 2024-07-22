using System;
using System.Collections.Generic;

namespace WebPerpustakaan.Models.EF;

public partial class Pinjaman
{
    public int IdPinjaman { get; set; }

    public int? IdAnggota { get; set; }

    public int? IdBuku { get; set; }

    public DateOnly TanggalPinjam { get; set; }

    public DateOnly? TanggalKembali { get; set; }

    public string Status { get; set; } = null!;

    public virtual Anggotum? IdAnggotaNavigation { get; set; }

    public virtual Buku? IdBukuNavigation { get; set; }
}
