using System;
using System.Collections.Generic;

namespace WebPerpustakaan.Models.EF;

public partial class Kategori
{
    public int IdKategori { get; set; }

    public string NamaKategori { get; set; } = null!;

    public virtual ICollection<Buku> Bukus { get; set; } = new List<Buku>();
}
