using IRRegistroEstudiantes.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRRegistroEstudiantes.Business.Helpers.Interfaces
{
    public interface IJwtHelper
    {
        public JwtDto GetJwtOptions();
    }
}
