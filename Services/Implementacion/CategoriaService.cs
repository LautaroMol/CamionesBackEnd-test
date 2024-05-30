using CamionesBackEnd.Models;
using CamionesBackEnd.Services.Contrato;
using Microsoft.EntityFrameworkCore;


namespace CamionesBackEnd.Services.Implementacion
{
    public class CategoriaService : ICategoriaService
    {
        private CamionesContext _dbcontext;

        public CategoriaService(CamionesContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<Categoria>> GetCategorialist()
        {
            try
            {
                List<Categoria> lista = new List<Categoria>();
                lista = await _dbcontext.Categoria.ToListAsync();
                return lista;
            }catch (Exception ex) { throw ex; }
        }
        public async Task<Categoria> GetCategoria(int id)
        {
            try
            {
                Categoria? categoria = new Categoria();
                categoria = await _dbcontext.Categoria.Include(dpt => dpt.Idcategoria).Where(e => e.Idcategoria == id).FirstOrDefaultAsync();
                return categoria;
            }
            catch (Exception ex) { throw ex; }
        }
        public async Task<Categoria> AddCategoria(Categoria categoria)
        {
            try
            {
                _dbcontext.Categoria.Add(categoria);
                await _dbcontext.SaveChangesAsync();
                return categoria;
            }catch (Exception ex) { throw ex; }
        }

        public async Task<bool> DeleteCategoria(Categoria modelo)
        {
            try
            {
                _dbcontext.Categoria.Remove(modelo);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> UpdateCategoria(Categoria categoria)
        {
            try
            {
                _dbcontext.Categoria.Update(categoria);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
