using IRRegistroEstudiantes.Model.Context;
using IRRegistroEstudiantes.Business.Repositories.Interfaces;
using IRRegistroEstudiantes.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace IRRegistroEstudiantes.Business.Repositories
{
    public class ProfesorRepository : IProfesorRepository
    {
        IRRegistroEstudiantesContext _context;
        public ProfesorRepository(IRRegistroEstudiantesContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteAllAsync()
        {
            var profesores = await GetAll().ToListAsync() ?? new List<Profesor>();
            _context.Profesores.RemoveRange(profesores);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteByIdlAsync(int id)
        {
            Profesor Profesor = await GetByIdAsync(id);
            object value = _context.Profesores.Remove(Profesor);
            return await _context.SaveChangesAsync() > 0;
        }

        public IQueryable<Profesor> GetAll()
        {
            return _context.Profesores.Select(e => e);
        }

        public async Task<Profesor> GetByIdAsync(int id)
        {
            return await _context.Profesores.FirstOrDefaultAsync(e => e.Id == id);
        }

        public IQueryable<Profesor> GetByMateriaId(int materiaId)
        {
            var query = from profesor in _context.Profesores
                        join profMateria in _context.ProfesorMateria
                        on profesor.Id equals profMateria.IdProfesor
                        where profMateria.IdMateria == materiaId
                        select profesor;
            return query;
        }

        public async Task<Profesor> InsertAsync(Profesor entity)
        {
            await _context.Profesores.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Profesor entity)
        {
            _context.Profesores.Update(entity);
            await _context.SaveChangesAsync();

        }
    }
}
