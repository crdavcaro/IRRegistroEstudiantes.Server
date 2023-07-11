using IRRegistroEstudiantes.Business.Dtos;

namespace IRRegistroEstudiantes.Business.Services.Interfaces
{
    public interface IMateriaService: IService<MateriaDto, int>
    {
        public Task<EstudianteMateriaDto> InscribirMateriasAsync(EstudianteMateriaDto entity);
    }
}
