using Microsoft.EntityFrameworkCore;
using CamionesBackEnd.Models;
using CamionesBackEnd.Services.Contrato;

namespace CamionesBackEnd.Services.Implementacion
{
    public class CargaService :ICargaService
    {
        private CamionesContext _dbcontext;

        public CargaService(CamionesContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Carga>> GetCargaList()
        {
            try
            {
                List<Carga> list = new List<Carga>();
                list = await _dbcontext.Cargas.ToListAsync();
                return list;
            }catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Carga> GetCarga(int id)
        {
            try
            {
                Carga? carga = new Carga();
                carga = await _dbcontext.Cargas.Include(dpt => dpt.Idcarga).Where(e => e.Idcarga == id).FirstOrDefaultAsync();
                return carga;
            }catch(Exception ex) { throw ex; }
            
        }

        public async Task<Carga> AddCarga(Carga carga)
        {
            try
            {
                _dbcontext.Cargas.Add(carga);
                await _dbcontext.SaveChangesAsync();
                return carga;
            }
            catch(Exception ex) { throw ex; }
            
        }
        public async Task<bool> UpdateCarga(Carga modelo)
        {
            try
            {
                _dbcontext.Cargas.Update(modelo);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<bool> DeleteCarga(Carga modelo)
        {
            try
            {
                _dbcontext.Cargas.Remove(modelo);
                await _dbcontext.SaveChangesAsync();
                return true;
            }catch (Exception ex) { throw ex; }
        }
        
    }
}
