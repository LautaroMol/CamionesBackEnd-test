using CamionesBackEnd.Models;

namespace CamionesBackEnd.DTOs
{
    public class ViajesDTO
    {
        public int Idviaje { get; set; }

        public string Inicio { get; set; } = null!;

        public string Final { get; set; } = null!;

        public int? Carga { get; set; }

        public DateOnly Fecha { get; set; }

        public int? Cp { get; set; }

        public bool Facturado { get; set; }

        public int Distancia { get; set; }

        public bool? Borrado { get; set; }

        public List<Gasto> Gastos { get; set; }

        public int Usuario { get; set; }
    }
}
