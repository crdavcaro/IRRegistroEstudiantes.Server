using IRRegistroEstudiantes.Model.Entities;
using System.Security.Cryptography;

namespace IRRegistroEstudiantes.Business.Repositories.Interfaces
{
    public interface IEstudianteRepository : IRepository<Estudiante, int>
    {
        Task<Estudiante> GetByUserId(int userId);
    }
}
