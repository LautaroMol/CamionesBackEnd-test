using Microsoft.EntityFrameworkCore;
using CamionesBackEnd.Models;
using CamionesBackEnd.Services.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamionesBackEnd.Services.Implementacion
{
    public class FacturaService : IFacturaService
    {
        private readonly CamionesContext _dbcontext;

        public FacturaService(CamionesContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Factura>> GetFacturaList()
        {
            try
            {
                return await _dbcontext.Facturas
                    .Include(f => f.CargasNavigation)
                    .Include(f => f.ClienteNavigation)
                    .Include(f => f.UsuarioNavigation)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de facturas", ex);
            }
        }

        public async Task<Factura> GetFactura(int id)
        {
            try
            {
                var factura = await _dbcontext.Facturas
                    .Include(f => f.CargasNavigation)
                    .Include(f => f.ClienteNavigation)
                    .Include(f => f.UsuarioNavigation)
                    .FirstOrDefaultAsync(f => f.Idfactura == id);

                if (factura == null)
                {
                    throw new Exception("Factura no encontrada");
                }

                return factura;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la factura con id {id}", ex);
            }
        }

        public async Task<Factura> AddFactura(Factura factura)
        {
            try
            {
                _dbcontext.Facturas.Add(factura);
                await _dbcontext.SaveChangesAsync();
                return factura;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la factura", ex);
            }
        }

        public async Task<bool> UpdateFactura(Factura factura)
        {
            try
            {
                _dbcontext.Facturas.Update(factura);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la factura", ex);
            }
        }

        public async Task<bool> DeleteFactura(int id)
        {
            try
            {
                var factura = await _dbcontext.Facturas.FindAsync(id);
                if (factura == null)
                {
                    throw new Exception("Factura no encontrada");
                }
                _dbcontext.Facturas.Remove(factura);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar la factura con id {id}", ex);
            }
        }
    }
}
