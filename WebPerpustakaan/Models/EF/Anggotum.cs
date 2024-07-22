using System;
using System.Collections.Generic;

namespace WebPerpustakaan.Models.EF;

public partial class Anggotum
{
    public int IdAnggota { get; set; }

    public string Nama { get; set; } = null!;

    public string Alamat { get; set; } = null!;

    public string? NomorTelepon { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Pinjaman> Pinjamen { get; set; } = new List<Pinjaman>();
}
