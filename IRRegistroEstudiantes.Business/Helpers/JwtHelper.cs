using IRRegistroEstudiantes.Business.Dtos;
using IRRegistroEstudiantes.Business.Helpers.Interfaces;
using IRRegistroEstudiantes.Business.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRRegistroEstudiantes.Business.Helpers
{
    public class JwtHelper: IJwtHelper
    {
        private IConfiguration _configuration;
        private ILogger<UsuarioService> _logger;
        public JwtHelper(IConfiguration configuration,
                         ILogger<UsuarioService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public JwtDto GetJwtOptions()
        {
            JwtDto response = new JwtDto();

            try
            {
                response = _configuration.GetSection("Jwt").Get<JwtDto>();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return response;
        }
    }
}
