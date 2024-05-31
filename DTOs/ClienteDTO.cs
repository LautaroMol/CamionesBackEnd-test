using CamionesBackEnd.Models;

namespace CamionesBackEnd.DTOs
{
    public class ClienteDTO
    {
        public int Idcliente { get; set; }

        public string RazonSoc { get; set; } = null!;

        public string Domicilio { get; set; } = null!;

        public string Condicion { get; set; } = null!;

        public string Cuit { get; set; } = null!;

        public bool? Borrado { get; set; }

        public List<int> Facturas { get; set; }
    }
}
