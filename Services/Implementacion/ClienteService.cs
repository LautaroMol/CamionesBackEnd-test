using Microsoft.EntityFrameworkCore;
using CamionesBackEnd.Models;
using CamionesBackEnd.Services.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamionesBackEnd.Services.Implementacion
{
    public class ClienteService : IClienteService
    {
        private readonly CamionesContext _dbcontext;

        public ClienteService(CamionesContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Cliente>> GetClienteList()
        {
            try
            {
                return await _dbcontext.Clientes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de clientes", ex);
            }
        }

        public async Task<Cliente> GetCliente(int id)
        {
            try
            {
                var cliente = await _dbcontext.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    throw new Exception("Cliente no encontrado");
                }
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el cliente con id {id}", ex);
            }
        }

        public async Task<Cliente> AddCliente(Cliente cliente)
        {
            try
            {
                _dbcontext.Clientes.Add(cliente);
                await _dbcontext.SaveChangesAsync();
                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el cliente", ex);
            }
        }

        public async Task<bool> UpdateCliente(Cliente cliente)
        {
            try
            {
                _dbcontext.Clientes.Update(cliente);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el cliente", ex);
            }
        }

        public async Task<bool> DeleteCliente(int id)
        {
            try
            {
                var cliente = await _dbcontext.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    throw new Exception("Cliente no encontrado");
                }
                _dbcontext.Clientes.Remove(cliente);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el cliente con id {id}", ex);
            }
        }
    }
}
