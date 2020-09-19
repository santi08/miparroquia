using AutoMapper;
using MiParroquia.API.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiParroquia.API.Aplicacion.Iglesias.Dtos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Iglesia, IglesiaListDto>()
                .ForMember(x => x.Parroco, opt => opt.MapFrom(i => $"{i.Parroco.PrimerNombre} {i.Parroco.PrimerApellido}"));
        }
    }
}
