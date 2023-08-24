using System;
using System.Collections.Generic;

namespace YemekTarifi.Models.DB;

public partial class Yemekler
{
    public int YemekId { get; set; }

    public string? YemekAd { get; set; }

    public string? Malzeme { get; set; }

    public string? Tarif { get; set; }

    public string? Resim { get; set; }

    public DateTime? Tarih { get; set; }

    public byte? Puan { get; set; }

    public string? Yorum { get; set; }

    public int? KategoriId { get; set; }

    public int? KullanıcıId { get; set; }

    public virtual ICollection<GununYemegi> GununYemegis { get; set; } = new List<GununYemegi>();

    public virtual Kategoriler? Kategori { get; set; }

    public virtual Kullanıcı? Kullanıcı { get; set; }

    public virtual ICollection<Yorumlar> Yorumlars { get; set; } = new List<Yorumlar>();

    internal static object Where(Func<object, bool> value)
    {
        throw new NotImplementedException();
    }
}
