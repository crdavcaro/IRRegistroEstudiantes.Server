using IRRegistroEstudiantes.Business.Dtos;
using IRRegistroEstudiantes.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IRRegistroEstudiantes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesorService _profesorService;

        public ProfesorController(IProfesorService ProfesorService)
        {
            _profesorService = ProfesorService;
        }

        // GET: api/<ProfesorsController>
        [HttpGet]
        public async Task<List<ProfesorDto>> GetAsync()
        {
            return await _profesorService.GetAll();
        }

        // GET api/<ProfesorsController>/5
        [HttpGet("{id}")]
        public async Task<ProfesorDto> GetAsync(int id)
        {
            return await _profesorService.GetByIdAsync(id);
        }

        [HttpGet("materia/{materiaId}")]
        public async Task<List<ProfesorDto>> GetByMateriaIdAsync(int materiaId)
        {
            return await _profesorService.GetByMateriaIdAsync(materiaId);
        }

        // POST api/<ProfesorsController>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ProfesorDto> Post([FromBody] ProfesorDto Profesor)
        {
            return await _profesorService.InsertAsync(Profesor);
        }

        // PUT api/<ProfesorsController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProfesorsController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<bool> DeleteAsync(int id)
        {
            return await _profesorService.DeleteByIdlAsync(id);
        }
    }
}