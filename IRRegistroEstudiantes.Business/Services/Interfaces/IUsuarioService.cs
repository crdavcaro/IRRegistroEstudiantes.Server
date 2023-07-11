
using IRRegistroEstudiantes.Business.Dtos;

namespace IRRegistroEstudiantes.Business.Services.Interfaces
{
    public interface IUsuarioService: IService<UsuarioDto, int>
    {
        public Task<UsuarioDto> LoginAsync(UsuarioDto usuario);
        public Task<UsuarioDto> GetByUsernameAndPasswordAsync(UsuarioDto usuario);
        public Task<List<UsuarioDto>> GetByUserNameAsync(string user);
    }
}
