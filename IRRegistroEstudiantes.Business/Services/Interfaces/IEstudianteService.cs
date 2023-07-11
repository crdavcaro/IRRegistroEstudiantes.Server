
using IRRegistroEstudiantes.Business.Dtos;

namespace IRRegistroEstudiantes.Business.Services.Interfaces
{
    public interface IEstudianteService: IService<EstudianteDto, int>
    {
        Task<EstudianteDto> GetByUserId(int userId);
    }
}
