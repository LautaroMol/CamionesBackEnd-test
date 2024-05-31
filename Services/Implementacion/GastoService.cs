using Microsoft.EntityFrameworkCore;
using CamionesBackEnd.Models;
using CamionesBackEnd.Services.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamionesBackEnd.Services.Implementacion
{
    public class GastoService : IGastoService
    {
        private readonly CamionesContext _dbcontext;

        public GastoService(CamionesContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Gasto>> GetGastoList()
        {
            try
            {
                return await _dbcontext.Gastos
                    .Include(g => g.CategoriaNavigation)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de gastos", ex);
            }
        }

        public async Task<Gasto> GetGasto(int id)
        {
            try
            {
                var gasto = await _dbcontext.Gastos
                    .Include(g => g.CategoriaNavigation)
                    .FirstOrDefaultAsync(g => g.Idgasto == id);

                if (gasto == null)
                {
                    throw new Exception("Gasto no encontrado");
                }

                return gasto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el gasto con id {id}", ex);
            }
        }

        public async Task<Gasto> AddGasto(Gasto gasto)
        {
            try
            {
                _dbcontext.Gastos.Add(gasto);
                await _dbcontext.SaveChangesAsync();
                return gasto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el gasto", ex);
            }
        }

        public async Task<bool> UpdateGasto(Gasto gasto)
        {
            try
            {
                _dbcontext.Gastos.Update(gasto);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el gasto", ex);
            }
        }

        public async Task<bool> DeleteGasto(int id)
        {
            try
            {
                var gasto = await _dbcontext.Gastos.FindAsync(id);
                if (gasto == null)
                {
                    throw new Exception("Gasto no encontrado");
                }
                _dbcontext.Gastos.Remove(gasto);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el gasto con id {id}", ex);
            }
        }
    }
}
