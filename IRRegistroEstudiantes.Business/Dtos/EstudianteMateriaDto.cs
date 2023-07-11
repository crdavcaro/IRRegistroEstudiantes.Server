
namespace IRRegistroEstudiantes.Business.Dtos
{
    public class EstudianteMateriaDto
    {
        public int IdEstudiante { get; set; }
        public List<ProfesorMateriasDto> ProfesorMaterias { get; set; }
    }
}
