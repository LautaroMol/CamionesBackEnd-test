using System;
using System.Collections.Generic;

namespace CamionesBackEnd.Models;

public partial class Viaje
{
    public int Idviaje { get; set; }

    public string Inicio { get; set; } = null!;

    public string Final { get; set; } = null!;

    public int? Gastos { get; set; }

    public int? Carga { get; set; }

    public DateOnly Fecha { get; set; }

    public int? Cp { get; set; }

    public bool Facturado { get; set; }

    public int Distancia { get; set; }

    public bool? Borrado { get; set; }

    public virtual Carga? CargaNavigation { get; set; }

    public virtual Gasto? GastosNavigation { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
