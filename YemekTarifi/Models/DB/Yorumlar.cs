using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;

namespace YemekTarifi.Models.DB;

public partial class Yorumlar
{
    public string YorumId { get; set; } = null!;
    [Required]
    public string? Icerik { get; set; }

    public DateTime? Tarih { get; set; }

    public bool? Onay { get; set; }

    public int? YemekId { get; set; }

    public int? KullanıcıId { get; set; }

    public virtual Kullanıcı? Kullanıcı { get; set; }

    public virtual Yemekler? Yemek { get; set; }
}
