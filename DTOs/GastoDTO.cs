}namespace CamionesBackEnd.DTOs
{
    public class GastoDTO
    {
        public int Idgasto { get; set; }

        public string? Nombre { get; set; }

        public double Cantidad { get; set; }

        public int? Categoria { get; set; }

        public DateOnly Fecha { get; set; }

        public bool? Borrado { get; set; }

        public int Viaje { get; set; }
    }
}
