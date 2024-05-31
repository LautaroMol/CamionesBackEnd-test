using Microsoft.EntityFrameworkCore;
using CamionesBackEnd.Models;
using CamionesBackEnd.Services.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CamionesBackEnd.Services.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly CamionesContext _dbcontext;

        public UsuarioService(CamionesContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Usuario>> GetUsuarioList()
        {
            try
            {
                return await _dbcontext.Usuarios
                    .Include(u => u.ViajesNavigation)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de usuarios", ex);
            }
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            try
            {
                var usuario = await _dbcontext.Usuarios
                    .Include(u => u.ViajesNavigation)
                    .FirstOrDefaultAsync(u => u.Idusuario == id);

                if (usuario == null)
                {
                    throw new Exception("Usuario no encontrado");
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el usuario con id {id}", ex);
            }
        }

        public async Task<Usuario> AddUsuario(Usuario usuario)
        {
            try
            {
                _dbcontext.Usuarios.Add(usuario);
                await _dbcontext.SaveChangesAsync();
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el usuario", ex);
            }
        }

        public async Task<bool> UpdateUsuario(Usuario usuario)
        {
            try
            {
                _dbcontext.Usuarios.Update(usuario);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el usuario", ex);
            }
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            try
            {
                var usuario = await _dbcontext.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    throw new Exception("Usuario no encontrado");
                }
                _dbcontext.Usuarios.Remove(usuario);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el usuario con id {id}", ex);
            }
        }
    }
}
