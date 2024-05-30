using CamionesBackEnd.Models;

namespace CamionesBackEnd.Services.Contrato
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> GetCategorialist();
        Task<Categoria> GetCategoria(int id);
        Task<Categoria> AddCategoria(Categoria categoria);
        Task<bool> UpdateCategoria(Categoria categoria);
        Task<bool> DeleteCategoria(Categoria modelo);
    }
}
