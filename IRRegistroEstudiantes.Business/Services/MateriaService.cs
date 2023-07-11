
using AutoMapper;
using IRRegistroEstudiantes.Business.Dtos;
using IRRegistroEstudiantes.Business.Repositories.Interfaces;
using IRRegistroEstudiantes.Business.Services.Interfaces;
using IRRegistroEstudiantes.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IRRegistroEstudiantes.Business.Services
{
    public class MateriaService : IMateriaService
    {
        private IMateriaRepository _materiaRepository;
        private ILogger<MateriaService> _logger;
        private IMapper _mapper;
        public MateriaService(IMateriaRepository MateriaRepository,
                                ILogger<MateriaService> logger,
                                IMapper mapper)
        {
            _materiaRepository = MateriaRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<bool> DeleteAllAsync()
        {
            bool result = false;

            try
            {
                result = await _materiaRepository.DeleteAllAsync();
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
                result = await _materiaRepository.DeleteByIdlAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return result;
        }

        public async Task<List<MateriaDto>> GetAll()
        {
            List<MateriaDto> response = new List<MateriaDto>();

            try
            {
                var result = _materiaRepository.GetAll();
                response = await result.Select(subject => _mapper.Map<MateriaDto>(subject))
                                        .ToListAsync() ?? new List<MateriaDto>();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return response;
        }

        public async Task<MateriaDto> GetByIdAsync(int id)
        {
            MateriaDto response = new MateriaDto();

            try
            {
                var result = await _materiaRepository.GetByIdAsync(id) ?? new Materia();
                response = _mapper.Map<MateriaDto>(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return response;
        }

        public async Task<EstudianteMateriaDto> InscribirMateriasAsync(EstudianteMateriaDto entity)
        {
            EstudianteMateriaDto response = new EstudianteMateriaDto();

            try
            {
                var deleteResult = await _materiaRepository.DeleteEstudianteMateriaByIdAsync(entity.IdEstudiante);

                if (deleteResult)
                {
                    List<ProfesorMaterias> profesorMateriaList = entity.ProfesorMaterias.Select(pm => _mapper.Map<ProfesorMaterias>(pm)).ToList();
                    
                    EstudianteMaterias inserMaterias = new EstudianteMaterias()
                    {
                        IdEstudiante = entity.IdEstudiante,
                        IdProfesorMateria = profesorMateriaList.Select(pm => _materiaRepository.GetProfesorMateriaByIds(pm.IdMateria, pm.IdProfesor))
                                                                .FirstOrDefault()
                                                                .Id
                    };

                    var result = await _materiaRepository.InsertEstudianteMateriaAsync(inserMaterias);
                    response = _mapper.Map<EstudianteMateriaDto>(result);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return response;

        }
        public async Task<MateriaDto> InsertAsync(MateriaDto entity)
        {
            MateriaDto response = new MateriaDto();

            try
            {
                Materia subject = _mapper.Map<Materia>(entity);
                // default;
                subject.Creditos = 3;
                var result = await _materiaRepository.InsertAsync(subject);
                response = _mapper.Map<MateriaDto>(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return response;

        }

        public void UpdateAsync(MateriaDto entity)
        {
            try
            {
                Materia subject = _mapper.Map<Materia>(entity);
                _materiaRepository.UpdateAsync(subject);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        }
    }
}
