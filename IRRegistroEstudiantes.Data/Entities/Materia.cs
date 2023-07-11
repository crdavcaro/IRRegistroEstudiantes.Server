namespace IRRegistroEstudiantes.Model.Entities;

public partial class Materia
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Creditos { get; set; }

    public virtual ICollection<ProfesorMaterias> ProfesorMateria { get; set; } = new List<ProfesorMaterias>();
}
