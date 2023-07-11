using AutoMapper;
using IRRegistroEstudiantes.Business.Dtos;
using IRRegistroEstudiantes.Business.Repositories.Interfaces;
using IRRegistroEstudiantes.Business.Services.Interfaces;
using IRRegistroEstudiantes.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IRRegistroEstudiantes.Business.Services
{
    public class EstudianteService : IEstudianteService
    {
        IEstudianteRepository _EstudianteRepository;
        ILogger<EstudianteService> _logger;
        IMapper _mapper;
        public EstudianteService(IEstudianteRepository EstudianteRepository,
                                ILogger<EstudianteService> logger,
                                IMapper mapper)
        {
            _EstudianteRepository = EstudianteRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<bool> DeleteAllAsync()
        {
            bool result = false;

            try
            {
                result = await _EstudianteRepository.DeleteAllAsync();
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
                result = await _EstudianteRepository.DeleteByIdlAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return result;
        }

        public async Task<List<EstudianteDto>> GetAll()
        {
            List<EstudianteDto> response = new List<EstudianteDto>();

            try
            {
                var result = _EstudianteRepository.GetAll();
                response = await result.Select(student => _mapper.Map<EstudianteDto>(student))
                                        .ToListAsync() ?? new List<EstudianteDto>();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return response;
        }

        public async Task<EstudianteDto> GetByIdAsync(int id)
        {
            EstudianteDto response = new EstudianteDto();

            try
            {
                var result = await _EstudianteRepository.GetByIdAsync(id) ?? new Estudiante();
                response = _mapper.Map<EstudianteDto>(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return response;
        }

        public async Task<EstudianteDto> GetByUserId(int userId)
        {
            EstudianteDto response = new EstudianteDto();

            try
            {
                var result = await _EstudianteRepository.GetByUserId(userId) ?? new Estudiante();
                response = _mapper.Map<EstudianteDto>(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return response;
        }

        public async Task<EstudianteDto> InsertAsync(EstudianteDto entity)
        {
            EstudianteDto response = new EstudianteDto();

            try
            {
                Estudiante student = _mapper.Map<Estudiante>(entity);
                var result = await _EstudianteRepository.InsertAsync(student);
                response = _mapper.Map<EstudianteDto>(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return response;

        }

        public void UpdateAsync(EstudianteDto entity)
        {
            try
            {
                Estudiante student = _mapper.Map<Estudiante>(entity);
                _EstudianteRepository.UpdateAsync(student);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        }
    }
}
