using System;
using System.Collections.Generic;

namespace YemekTarifi.Models.DB;

public partial class Kullanıcı
{
    public int KullanıcıId { get; set; }

    public string? KullanıcıAdı { get; set; }

    public string? Eposta { get; set; }

    public string? Sifre { get; set; }

    public bool? AdminMi { get; set; }

    public virtual ICollection<Yemekler> Yemeklers { get; set; } = new List<Yemekler>();

    public virtual ICollection<Yorumlar> Yorumlars { get; set; } = new List<Yorumlar>();
}
