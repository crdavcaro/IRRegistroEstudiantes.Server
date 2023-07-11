using IRRegistroEstudiantes.Model.Entities;

namespace IRRegistroEstudiantes.Business.Repositories.Interfaces
{
    public interface IProfesorRepository: IRepository<Profesor, int>
    {
        IQueryable<Profesor> GetByMateriaId(int materiaId);
    }
}
