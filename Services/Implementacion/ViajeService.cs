using Microsoft.EntityFrameworkCore;
using CamionesBackEnd.Models;
using CamionesBackEnd.Services.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamionesBackEnd.Services.Implementacion
{
    public class ViajeService : IViajeService
    {
        private readonly CamionesContext _dbcontext;

        public ViajeService(CamionesContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Viaje>> GetViajeList()
        {
            try
            {
                return await _dbcontext.Viajes
                    .Include(v => v.CargaNavigation)
                    .Include(v => v.GastosNavigation)
                    .Include(v => v.Usuarios)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de viajes", ex);
            }
        }

        public async Task<Viaje> GetViaje(int id)
        {
            try
            {
                var viaje = await _dbcontext.Viajes
                    .Include(v => v.CargaNavigation)
                    .Include(v => v.GastosNavigation)
                    .Include(v => v.Usuarios)
                    .FirstOrDefaultAsync(v => v.Idviaje == id);

                if (viaje == null)
                {
                    throw new Exception("Viaje no encontrado");
                }

                return viaje;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el viaje con id {id}", ex);
            }
        }

        public async Task<Viaje> AddViaje(Viaje viaje)
        {
            try
            {
                _dbcontext.Viajes.Add(viaje);
                await _dbcontext.SaveChangesAsync();
                return viaje;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el viaje", ex);
            }
        }

        public async Task<bool> UpdateViaje(Viaje viaje)
        {
            try
            {
                _dbcontext.Viajes.Update(viaje);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el viaje", ex);
            }
        }

        public async Task<bool> DeleteViaje(int id)
        {
            try
            {
                var viaje = await _dbcontext.Viajes.FindAsync(id);
                if (viaje == null)
                {
                    throw new Exception("Viaje no encontrado");
                }
                _dbcontext.Viajes.Remove(viaje);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el viaje con id {id}", ex);
            }
        }
    }
}
