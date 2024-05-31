using CamionesBackEnd.Models;

namespace CamionesBackEnd.DTOs
{
    public class UsuarioDTO
    {
        public int Idusuario { get; set; }

        public string Razon { get; set; } = null!;

        public string Domicilio { get; set; } = null!;

        public string Condicion { get; set; } = null!;

        public string Cuit { get; set; } = null!;

        public List<int> Viajes { get; set; }

        public bool? Borrado { get; set; }

        public List<int> Facturas { get; set; }

    }
}
