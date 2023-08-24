using System;
using System.Collections.Generic;

namespace YemekTarifi.Models.DB;

public partial class GununYemegi
{
    public int GununYemegiId { get; set; }

    public string? Ad { get; set; }

    public string? Malzemeler { get; set; }

    public string? Tarif { get; set; }

    public DateTime? Tarih { get; set; }

    public int? YemekId { get; set; }

    public virtual Yemekler? Yemek { get; set; }
}
