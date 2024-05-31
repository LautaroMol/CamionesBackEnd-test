using CamionesBackEnd.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CamionesBackEnd.Services.Contrato
{
    public interface IGastoService
    {
        Task<List<Gasto>> GetGastoList();
        Task<Gasto> GetGasto(int id);
        Task<Gasto> AddGasto(Gasto gasto);
        Task<bool> UpdateGasto(Gasto gasto);
        Task<bool> DeleteGasto(int id);
    }
}
