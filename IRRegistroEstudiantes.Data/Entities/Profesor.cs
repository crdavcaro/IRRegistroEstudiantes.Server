
namespace IRRegistroEstudiantes.Model.Entities;

public partial class Profesor
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<ProfesorMaterias> ProfesorMateria { get; set; } = new List<ProfesorMaterias>();
}
