using System;
using System.Collections.Generic;

namespace CamionesBackEnd.Models;

public partial class Gasto
{
    public int Idgasto { get; set; }

    public string? Nombre { get; set; }

    public double Cantidad { get; set; }

    public int? Categoria { get; set; }

    public DateOnly Fecha { get; set; }

    public bool? Borrado { get; set; }

    public virtual Categoria? CategoriaNavigation { get; set; }

    public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
}
