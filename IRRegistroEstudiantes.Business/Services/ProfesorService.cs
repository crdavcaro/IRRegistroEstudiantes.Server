using AutoMapper;
using IRRegistroEstudiantes.Business.Dtos;
using IRRegistroEstudiantes.Business.Repositories.Interfaces;
using IRRegistroEstudiantes.Business.Services.Interfaces;
using IRRegistroEstudiantes.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IRRegistroEstudiantes.Business.Services
{
    public class ProfesorService: IProfesorService
    {
        private IProfesorRepository _ProfesorRepository;
        private ILogger<ProfesorService> _logger;
        private IMapper _mapper;
        public ProfesorService(IProfesorRepository ProfesorRepository,
                                ILogger<ProfesorService> logger,
                                IMapper mapper)
        {
            _ProfesorRepository = ProfesorRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<bool> DeleteAllAsync()
        {
            bool result = false;

            try
            {
                result = await _ProfesorRepository.DeleteAllAsync();
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
                result = await _ProfesorRepository.DeleteByIdlAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return result;
        }

        public async Task<List<ProfesorDto>> GetAll()
        {
            List<ProfesorDto> response = new List<ProfesorDto>();

            try
            {
                var result = _ProfesorRepository.GetAll();
                response = await result.Select(teacher => _mapper.Map<ProfesorDto>(teacher))
                                        .ToListAsync() ?? new List<ProfesorDto>();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return response;
        }

        public async Task<ProfesorDto> GetByIdAsync(int id)
        {
            ProfesorDto response = new ProfesorDto();

            try
            {
                var result = await _ProfesorRepository.GetByIdAsync(id) ?? new Profesor();
                response = _mapper.Map<ProfesorDto>(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return response;
        }

        public async Task<List<ProfesorDto>> GetByMateriaIdAsync(int materiaId)
        {
            List<ProfesorDto> response = new List<ProfesorDto>();

            try
            {
                var result = _ProfesorRepository.GetByMateriaId(materiaId);
                response = await result.Select(teacher => _mapper.Map<ProfesorDto>(teacher))
                                        .ToListAsync() ?? new List<ProfesorDto>();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return response;
        }

        public async Task<ProfesorDto> InsertAsync(ProfesorDto entity)
        {
            ProfesorDto response = new ProfesorDto();

            try
            {
                Profesor teacher = _mapper.Map<Profesor>(entity);
                var result = await _ProfesorRepository.InsertAsync(teacher);
                response = _mapper.Map<ProfesorDto>(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return response;

        }

        public void UpdateAsync(ProfesorDto entity)
        {
            try
            {
                Profesor teacher = _mapper.Map<Profesor>(entity);
                _ProfesorRepository.UpdateAsync(teacher);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        }
    }
}
