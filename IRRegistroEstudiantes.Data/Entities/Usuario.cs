using System;
using System.Collections.Generic;

namespace IRRegistroEstudiantes.Model.Entities;

public partial class Usuario
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual Estudiante? Estudiante { get; set; }
}
