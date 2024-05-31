using CamionesBackEnd.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CamionesBackEnd.Services.Contrato
{
    public interface IClienteService
    {
        Task<List<Cliente>> GetClienteList();
        Task<Cliente> GetCliente(int id);
        Task<Cliente> AddCliente(Cliente cliente);
        Task<bool> UpdateCliente(Cliente cliente);
        Task<bool> DeleteCliente(int id);
    }
}
