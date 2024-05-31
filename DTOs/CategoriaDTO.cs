namespace CamionesBackEnd.DTOs
{
    public class CategoriaDTO
    {
        public int Idcategoria { get; set; }

        public string Nombre { get; set; } = null!;

        public bool? Borrado { get; set; }

        public List<int> Gastos { get; set; }
    }
}
