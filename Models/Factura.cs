using System;
using System.Collections.Generic;

namespace CamionesBackEnd.Models;

public partial class Factura
{
    public int Idfactura { get; set; }

    public List<int> Usuarios { get; set; }

    public List<int> Clientes { get; set; }

    public List<int> Cargas { get; set; }

    public string Cuit { get; set; } = null!;

    public bool? Borrado { get; set; }

    public virtual Carga? CargasNavigation { get; set; }

    public virtual Cliente? ClienteNavigation { get; set; }

    public virtual Usuario? UsuarioNavigation { get; set; }
}
