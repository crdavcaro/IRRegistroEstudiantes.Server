using IRRegistroEstudiantes.Business.Dtos;
using IRRegistroEstudiantes.Business.Services;
using IRRegistroEstudiantes.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IRRegistroEstudiantes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService UsuarioService)
        {
            _usuarioService = UsuarioService;
        }

        [HttpPost]
        public async Task<UsuarioDto> CreateUserAsync([FromBody] UsuarioDto login)
        {
            return await _usuarioService.InsertAsync(login);
        }


        [HttpPost]
        [Route("Login")]
        public async Task<UsuarioDto> LogInAsync([FromBody] UsuarioDto login)
        {
            return await _usuarioService.LoginAsync(login);
        }

        [HttpGet(("{id}"))]
        [Authorize]
        public async Task<UsuarioDto> GetUsuarioById(int id)
        {
            return await _usuarioService.GetByIdAsync(id);
        }

        [HttpGet(("username/{username}"))]
        [Authorize]
        public async Task<List<UsuarioDto>> GetUsuarioByUserName(string username)
        {
            return await _usuarioService.GetByUserNameAsync(username);
        }

    }
}
