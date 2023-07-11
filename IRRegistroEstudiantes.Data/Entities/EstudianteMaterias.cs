namespace IRRegistroEstudiantes.Model.Entities;

public partial class EstudianteMaterias
{
    public int Id { get; set; }

    public int IdEstudiante { get; set; }

    public int IdProfesorMateria { get; set; }

    public virtual Estudiante IdEstudianteNavigation { get; set; } = null!;

    public virtual ProfesorMaterias IdProfesorMateriaNavigation { get; set; } = null!;
}
