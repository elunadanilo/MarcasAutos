using AutoMapper;
using MarcasAutos.Domain;
using MarcasAutos.Domain.DTO;

namespace MarcasAutos.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        #region Public Constructors

        public AutomapperProfile()
        {
            CreateMap<MarcasAuto, MarcasAutosDto>();
            CreateMap<MarcasAutosDto, MarcasAuto>();
        }

        #endregion Public Constructors
    }
}
