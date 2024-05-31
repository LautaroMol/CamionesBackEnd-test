using CamionesBackEnd.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CamionesBackEnd.Services.Contrato
{
    public interface IViajeService
    {
        Task<List<Viaje>> GetViajeList();
        Task<Viaje> GetViaje(int id);
        Task<Viaje> AddViaje(Viaje viaje);
        Task<bool> UpdateViaje(Viaje viaje);
        Task<bool> DeleteViaje(int id);
    }
}
