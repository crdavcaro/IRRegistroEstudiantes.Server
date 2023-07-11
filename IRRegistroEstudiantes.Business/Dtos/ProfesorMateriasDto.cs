
namespace IRRegistroEstudiantes.Business.Dtos
{
    public class ProfesorMateriasDto
    {
        public int Id { get; set; }

        public ProfesorDto Profesor { get; set; }

        public MateriaDto Materia { get; set; }

    }
}