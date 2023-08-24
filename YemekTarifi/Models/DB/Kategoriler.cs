using System;
using System.Collections.Generic;

namespace YemekTarifi.Models.DB;

public partial class Kategoriler
{
    public int KategoriId { get; set; }

    public string? Ad { get; set; }

    public short? Adet { get; set; }

    public string? Resim { get; set; }

    public virtual ICollection<Yemekler> Yemeklers { get; set; } = new List<Yemekler>();
}
