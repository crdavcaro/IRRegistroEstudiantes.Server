
namespace IRRegistroEstudiantes.Business.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
