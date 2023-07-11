using AutoMapper;
using IRRegistroEstudiantes.Business.Dtos;
using IRRegistroEstudiantes.Business.Helpers.Interfaces;
using IRRegistroEstudiantes.Business.Repositories.Interfaces;
using IRRegistroEstudiantes.Business.Services.Interfaces;
using IRRegistroEstudiantes.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IRRegistroEstudiantes.Business.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;
        private IJwtHelper _jwtHelper;
        private ILogger<UsuarioService> _logger;
        private IMapper _mapper;
        public UsuarioService(IUsuarioRepository UsuarioRepository,
                                ILogger<UsuarioService> logger,
                                IJwtHelper jwtHelper,
                                IMapper mapper)
        {
            _usuarioRepository = UsuarioRepository;
            _logger = logger;
            _mapper = mapper;
            _jwtHelper = jwtHelper;
        }
        public async Task<bool> DeleteAllAsync()
        {
            bool result = false;

            try
            {
                result = await _usuarioRepository.DeleteAllAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return result;
        }

        public async Task<bool> DeleteByIdlAsync(int id)
        {
            bool result = false;

            try
            {
                result = await _usuarioRepository.DeleteByIdlAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return result;
        }

        public async Task<List<UsuarioDto>> GetAll()
        {
            List<UsuarioDto> response = new List<UsuarioDto>();

            try
            {
                var result = _usuarioRepository.GetAll();
                response = await result.Select(user => _mapper.Map<UsuarioDto>(user))
                                        .ToListAsync() ?? new List<UsuarioDto>();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return response;
        }

        public async Task<UsuarioDto> GetByIdAsync(int id)
        {
            UsuarioDto response = new UsuarioDto();

            try
            {
                var result = await _usuarioRepository.GetByIdAsync(id) ?? new Usuario();
                response = _mapper.Map<UsuarioDto>(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return response;
        }

        public async Task<List<UsuarioDto>> GetByUserNameAsync(string user)
        {
            List<UsuarioDto> response = new List<UsuarioDto>();

            try
            {
                var result = _usuarioRepository.GetByUsername(user);
                response = await result.Select(user => _mapper.Map<UsuarioDto>(user))
                                        .ToListAsync() ?? new List<UsuarioDto>();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return response;
        }

        public async Task<UsuarioDto> GetByUsernameAndPasswordAsync(UsuarioDto login)
        {
            UsuarioDto response = new UsuarioDto();

            try
            {
                var result = await _usuarioRepository.GetByUsernameAndPassword(login.UserName, login.Password) ?? new Usuario();
                response = _mapper.Map<UsuarioDto>(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return response;

        }

        public async Task<UsuarioDto> InsertAsync(UsuarioDto usuario)
        {
            UsuarioDto response = new UsuarioDto();

            try
            {
                Usuario user = _mapper.Map<Usuario>(usuario);
                // Default
                user.Role = "student";
                var result = await _usuarioRepository.InsertAsync(user);
                response = _mapper.Map<UsuarioDto>(result);
                response.Password = null;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return response;
        }

        public async Task<UsuarioDto> LoginAsync(UsuarioDto usuario)
        {
            var response = new UsuarioDto();
            var result = await GetByUsernameAndPasswordAsync(usuario);

            if (result.Id > 0)
            {
                var jwtOptions = _jwtHelper.GetJwtOptions();
                var claims = new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, new Guid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, jwtOptions.Subject),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", result.Id.ToString()),
                    new Claim("UserName", result.UserName),
                    new Claim(ClaimTypes.Role, result.Role)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                                    jwtOptions.Issuer, 
                                    jwtOptions.Audience, 
                                    claims, 
                                    expires: DateTime.Now.AddHours(1), 
                                    signingCredentials: credentials
                                );

                result.Token = new JwtSecurityTokenHandler().WriteToken(token);

                response = result;
            }

            return response;
        }

        public void UpdateAsync(UsuarioDto entity)
        {
            try
            {
                Usuario user = _mapper.Map<Usuario>(entity);
                _usuarioRepository.UpdateAsync(user);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        }

    }
}
