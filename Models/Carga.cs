using System;
using System.Collections.Generic;

namespace CamionesBackEnd.Models;

public partial class Carga
{
    public int Idcarga { get; set; }

    public int Codigo { get; set; }

    public string Producto { get; set; } = null!;

    public double Cantidad { get; set; }

    public string UnidadDeMedida { get; set; } = null!;

    public double PrecioUnit { get; set; }

    public double Bonif { get; set; }

    public double Subtotal { get; set; }

    public double Iva { get; set; }

    public string? SubtotalString { get; set; }

    public bool? Borrado { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
}
