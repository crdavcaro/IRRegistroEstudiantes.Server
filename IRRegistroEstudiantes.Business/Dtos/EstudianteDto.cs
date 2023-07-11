
namespace IRRegistroEstudiantes.Business.Dtos
{
    public class EstudianteDto
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Cedula { get; set; }
        public string Correo { get; set; }
        public string Carrera { get; set; }
        public string? Password { get; set; }
        public int IdUsuario { get; set; }
    }
}
