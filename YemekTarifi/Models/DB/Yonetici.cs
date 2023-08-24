using System;
using System.Collections.Generic;

namespace YemekTarifi.Models.DB;

public partial class Yonetici
{
    public byte YoneticiId { get; set; }

    public string? Ad { get; set; }

    public string? Sıfre { get; set; }
}
