using CamionesBackEnd.Models;

namespace CamionesBackEnd.DTOs
{
    public class FacturaDTO
    {
        public int Idfactura { get; set; }

        public List<int> Usuarios { get; set; }

        public List<int> Clientes { get; set; }

        public List<int> Cargas { get; set; }

        public string Cuit { get; set; } = null!;

        public bool? Borrado { get; set; }
    }
}
