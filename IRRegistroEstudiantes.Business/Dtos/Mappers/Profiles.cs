using AutoMapper;
using IRRegistroEstudiantes.Business.Dtos;
using IRRegistroEstudiantes.Model.Entities;

namespace IRRegistroEstudiantes.Business.Mappers
{
    public class Profiles : Profile
    {
        public Profiles()
        {

            CreateMap<Usuario, UsuarioDto>().ReverseMap()
                .ForMember(
                    dest => dest.Username,
                    src => src.MapFrom(mf => mf.UserName.ToLower())
                    );

            CreateMap<EstudianteDto, Estudiante>().ReverseMap();
            CreateMap<ProfesorDto, Profesor>().ReverseMap();
            CreateMap<MateriaDto, Materia>().ReverseMap();
            CreateMap<ProfesorMaterias, MateriaDto>()
                .ForMember(
                    dest => dest.Id, 
                    src => src.MapFrom(mf => mf.IdMateria)
                    ).ReverseMap();
            CreateMap<ProfesorMaterias, ProfesorDto>()
                .ForMember(
                    dest => dest.Id,
                    src => src.MapFrom(mf => mf.IdProfesor)
                    ).ReverseMap();
            CreateMap<ProfesorMateriasDto, ProfesorMaterias>().IncludeMembers(dest => dest.Materia, dest => dest.Profesor)
                .ForMember(
                    dest => dest.Id,
                    src => src.MapFrom(mf => mf.Id)
                    )
                .ForMember(
                    dest => dest.IdMateria,
                    src => src.MapFrom(mf => mf.Materia.Id)
                    )
                .ForMember(
                    dest => dest.IdProfesor,
                    src => src.MapFrom(mf => mf.Profesor.Id)
                    ).ReverseMap();
            CreateMap<EstudianteMateriaDto,EstudianteMaterias>().ReverseMap();
        }
    }
}
