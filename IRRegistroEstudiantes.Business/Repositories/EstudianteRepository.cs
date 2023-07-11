using IRRegistroEstudiantes.Business.Repositories.Interfaces;
using IRRegistroEstudiantes.Model.Context;
using IRRegistroEstudiantes.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace IRRegistroEstudiantes.Business.Repositories
{
    public class EstudianteRepository : IEstudianteRepository
    {
        IRRegistroEstudiantesContext _context;
        public EstudianteRepository(IRRegistroEstudiantesContext context) 
        { 
            _context = context;
        }
        public async Task<bool> DeleteAllAsync()
        {
            await _context.Estudiantes.ExecuteDeleteAsync();
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteByIdlAsync(int id)
        {
            Estudiante estudiante =  await GetByIdAsync(id);
            object value = _context.Estudiantes.Remove(estudiante);
            return await _context.SaveChangesAsync() > 0;
        }

        public IQueryable<Estudiante> GetAll()
        {
            return _context.Estudiantes.Select(e => e);
        }

        public async Task<Estudiante> GetByIdAsync(int id)
        {
            return await _context.Estudiantes.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Estudiante> GetByUserId(int userId)
        {
            return await _context.Estudiantes.FirstOrDefaultAsync(e => e.IdUsuario == userId);
        }

        public async Task<Estudiante> InsertAsync(Estudiante entity)
        {
            await _context.Estudiantes.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Estudiante entity)
        {
            _context.Estudiantes.Update(entity);
            await _context.SaveChangesAsync();

        }
    }
}
