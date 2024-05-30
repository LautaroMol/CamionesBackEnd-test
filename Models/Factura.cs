using System;
using System.Collections.Generic;

namespace CamionesBackEnd.Models;

public partial class Factura
{
    public int Idfactura { get; set; }

    public int? Usuario { get; set; }

    public int? Cliente { get; set; }

    public int? Cargas { get; set; }

    public string Cuit { get; set; } = null!;

    public bool? Borrado { get; set; }

    public virtual Carga? CargasNavigation { get; set; }

    public virtual Cliente? ClienteNavigation { get; set; }

    public virtual Usuario? UsuarioNavigation { get; set; }
}
