using CamionesBackEnd.Models;

namespace CamionesBackEnd.Services.Contrato
{
    public interface ICargaService
    {
        Task<List<Carga>> GetCargaList();
        Task<Carga> GetCarga(int id);
        Task<Carga> AddCarga(Carga carga);
        Task<bool> UpdateCarga(Carga modelo);
        Task<bool> DeleteCarga(Carga modelo);
    }
}
