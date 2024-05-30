using System;
using System.Collections.Generic;

namespace CamionesBackEnd.Models;

public partial class Usuario
{
    public int Idusuario { get; set; }

    public string Razon { get; set; } = null!;

    public string Domicilio { get; set; } = null!;

    public string Condicion { get; set; } = null!;

    public string Cuit { get; set; } = null!;

    public int? Viajes { get; set; }

    public bool? Borrado { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual Viaje? ViajesNavigation { get; set; }
}
