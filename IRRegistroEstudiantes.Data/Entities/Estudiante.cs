
namespace IRRegistroEstudiantes.Model.Entities;

public partial class Estudiante
{
    public int Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public int Cedula { get; set; }

    public string Correo { get; set; } = null!;

    public string? Carrera { get; set; }

    public int IdUsuario { get; set; }

    public virtual ICollection<EstudianteMaterias> EstudianteMateria { get; set; } = new List<EstudianteMaterias>();

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
