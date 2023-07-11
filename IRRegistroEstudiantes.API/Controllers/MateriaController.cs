using IRRegistroEstudiantes.Business.Dtos;
using IRRegistroEstudiantes.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IRRegistroEstudiantes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaService _materiaService;

        public MateriaController(IMateriaService materiaService)
        {
            _materiaService = materiaService;
        }

        // GET: api/<MateriasController>
        [HttpGet]
        public async Task<List<MateriaDto>> GetAsync()
        {
            return await _materiaService.GetAll();
        }

        // GET api/<MateriasController>/5
        [HttpGet("{id}")]
        public async Task<MateriaDto> GetASync(int id)
        {
            return await _materiaService.GetByIdAsync(id);
        }

        // POST api/<MateriasController>
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<MateriaDto> Post([FromBody] MateriaDto materia)
        {
            return await _materiaService.InsertAsync(materia);
        }

        [HttpPost]
        [Route("Inscribir-Materias")]
        public async Task<EstudianteMateriaDto> Post([FromBody] EstudianteMateriaDto materias)
        {
            return await _materiaService.InscribirMateriasAsync(materias);
        }

        // PUT api/<MateriasController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MateriasController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<bool> DeleteAsync(int id)
        {
            return await _materiaService.DeleteByIdlAsync(id);
        }
    }
}
