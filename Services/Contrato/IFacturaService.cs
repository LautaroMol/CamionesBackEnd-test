using CamionesBackEnd.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CamionesBackEnd.Services.Contrato
{
    public interface IFacturaService
    {
        Task<List<Factura>> GetFacturaList();
        Task<Factura> GetFactura(int id);
        Task<Factura> AddFactura(Factura factura);
        Task<bool> UpdateFactura(Factura factura);
        Task<bool> DeleteFactura(int id);
    }
}
