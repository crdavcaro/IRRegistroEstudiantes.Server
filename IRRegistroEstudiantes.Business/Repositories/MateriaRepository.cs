

using IRRegistroEstudiantes.Business.Repositories.Interfaces;
using IRRegistroEstudiantes.Model.Context;
using IRRegistroEstudiantes.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace IRRegistroEstudiantes.Business.Repositories
{
    public class MateriaRepository: IMateriaRepository
    {
        IRRegistroEstudiantesContext _context;
        public MateriaRepository(IRRegistroEstudiantesContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteAllAsync()
        {
            bool result = true;
            var materias = await GetAll().ToListAsync() ?? new List<Materia>();
            if (materias.Count > 0)
            {
                _context.Materia.RemoveRange(materias);
                result = await _context.SaveChangesAsync() > 0;
            }

            return result;
        }

        public async Task<bool> DeleteEstudianteMateriaByIdAsync(int idEstudiante)
        {
            var materias = await _context.EstudianteMateria.Where(em => em.IdEstudiante == idEstudiante).ToListAsync() ?? new List<EstudianteMaterias>();
            if (materias.Count > 0)
            {
                _context.EstudianteMateria.RemoveRange(materias);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteByIdlAsync(int id)
        {
            Materia materia = await GetByIdAsync(id);
            object value = _context.Materia.Remove(materia);
            return await _context.SaveChangesAsync() > 0;
        }

        public IQueryable<Materia> GetAll()
        {
            return _context.Materia.Select(e => e);
        }

        public async Task<Materia> GetByIdAsync(int id)
        {
            return await _context.Materia.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<ProfesorMaterias> GetProfesorMateriaByIds(int idMateria, int idProfesor)
        {
            return await _context.ProfesorMateria.FirstOrDefaultAsync(em => em.IdMateria == idMateria && em.IdProfesor == idProfesor);
        }

        public async Task<Materia> InsertAsync(Materia entity)
        {
            await _context.Materia.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<EstudianteMaterias> InsertEstudianteMateriaAsync(EstudianteMaterias materias)
        {
            await _context.EstudianteMateria.AddRangeAsync(materias);
            await _context.SaveChangesAsync();
            return materias;
        }

        public async Task UpdateAsync(Materia entity)
        {
            _context.Materia.Update(entity);
            await _context.SaveChangesAsync();

        }

        public async Task<EstudianteMaterias> GetEstudianteMateriaByEstudianteIdAsync(int idEstudiante)
        {
            return await _context.EstudianteMateria.FirstOrDefaultAsync(em => em.IdEstudiante == idEstudiante);
        }
    }
}
