using System;
using System.Collections.Generic;

namespace CamionesBackEnd.Models;

public partial class Cliente
{
    public int Idcliente { get; set; }

    public string RazonSoc { get; set; } = null!;

    public string Domicilio { get; set; } = null!;

    public string Condicion { get; set; } = null!;

    public string Cuit { get; set; } = null!;

    public bool? Borrado { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
