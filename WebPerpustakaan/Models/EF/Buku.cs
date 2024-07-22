using System;
using System.Collections.Generic;

namespace WebPerpustakaan.Models.EF;

public partial class Buku
{
    public int IdBuku { get; set; }

    public string Judul { get; set; } = null!;

    public string Penulis { get; set; } = null!;

    public string Penerbit { get; set; } = null!;

    public short TahunTerbit { get; set; }

    public int? KategoriId { get; set; }

    public int Jumlah { get; set; }

    public virtual Kategori? Kategori { get; set; }

    public virtual ICollection<Pinjaman> Pinjamen { get; set; } = new List<Pinjaman>();
}
