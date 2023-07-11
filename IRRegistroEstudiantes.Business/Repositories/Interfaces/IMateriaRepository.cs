using IRRegistroEstudiantes.Model.Entities;

namespace IRRegistroEstudiantes.Business.Repositories.Interfaces
{
    public interface IMateriaRepository: IRepository<Materia, int>
    {
        public Task<bool> DeleteEstudianteMateriaByIdAsync(int idEstudiante);

        public Task<ProfesorMaterias> GetProfesorMateriaByIds(int idMateria, int idProfesor);

        public Task<EstudianteMaterias> InsertEstudianteMateriaAsync(EstudianteMaterias materias);

        public Task<EstudianteMaterias> GetEstudianteMateriaByEstudianteIdAsync(int idEstudiante);
    }
}
