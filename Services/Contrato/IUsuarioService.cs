using CamionesBackEnd.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CamionesBackEnd.Services.Contrato
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> GetUsuarioList();
        Task<Usuario> GetUsuario(int id);
        Task<Usuario> AddUsuario(Usuario usuario);
        Task<bool> UpdateUsuario(Usuario usuario);
        Task<bool> DeleteUsuario(int id);
    }
}
