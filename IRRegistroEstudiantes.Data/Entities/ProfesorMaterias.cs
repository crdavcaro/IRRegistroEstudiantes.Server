namespace IRRegistroEstudiantes.Model.Entities;

public partial class ProfesorMaterias
{
    public int Id { get; set; }

    public int IdProfesor { get; set; }

    public int IdMateria { get; set; }

    public virtual ICollection<EstudianteMaterias> EstudianteMateria { get; set; } = new List<EstudianteMaterias>();

    public virtual Materia IdMateriaNavigation { get; set; } = null!;

    public virtual Profesor IdProfesorNavigation { get; set; } = null!;
}
