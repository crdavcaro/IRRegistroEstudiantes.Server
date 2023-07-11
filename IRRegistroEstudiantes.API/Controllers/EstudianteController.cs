using IRRegistroEstudiantes.Business.Services.Interfaces;
using IRRegistroEstudiantes.Business.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IRRegistroEstudiantes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteService _estudianteService;

        public EstudianteController(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        // GET: api/<EstudiantesController>
        [HttpGet]
        public async Task<List<EstudianteDto>> GetAsync()
        {
            return await _estudianteService.GetAll();
        }

        // GET api/<EstudiantesController>/5
        [HttpGet("{id}")]
        public async Task<EstudianteDto> GetAsync(int id)
        {
            return await _estudianteService.GetByIdAsync(id);
        }
        // GET api/<EstudiantesController>/5
        [HttpGet("user/{id}")]
        public async Task<EstudianteDto> GetByUserIdAsync(int id)
        {
            return await _estudianteService.GetByUserId(id);
        }

        // POST api/<EstudiantesController>
        [HttpPost]
        public async Task<EstudianteDto> Post([FromBody] EstudianteDto estudiante)
        {
            return await _estudianteService.InsertAsync(estudiante);
        }

        // PUT api/<EstudiantesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EstudiantesController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<bool> DeleteAsync(int id)
        {
            return await _estudianteService.DeleteByIdlAsync(id);
        }
    }
}
