using IRRegistroEstudiantes.Business.Dtos;

namespace IRRegistroEstudiantes.Business.Services.Interfaces
{
    public interface IProfesorService: IService<ProfesorDto, int>
    {
        Task<List<ProfesorDto>> GetByMateriaIdAsync(int materiaId);
    }
}
