using AutoMapper;
using MiParroquia.API.Dominio;
using MiParroquia.API.Utils;
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

            CreateMap<Horario, HorarioListDto>()
                .ForMember(x => x.Dia, opt => opt.MapFrom(i => DateHelper.ObtenerNombreDia(i.Hora)))
                .ForMember(x => x.Disponible, opt => opt.MapFrom(i => i.Capacidad - i.Reservas
                                                                                        .Where(r=>r.Estado!="Cancelado")
                                                                                        .ToList().Count - i.ReservaInvitados
                                                                                                                .Where(r => r.Estado != "Cancelado")
                                                                                                                .ToList().Count));
        }
    }
}
