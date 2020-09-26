using AutoMapper;
using MiParroquia.API.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiParroquia.API.Aplicacion.Horarios.Dtos
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Reserva, ReservaListDto>()
                .ForMember(x => x.UsuarioId, opt => opt.MapFrom(i => i.UsuarioId))
                .ForMember(x => x.PrimerNombre, opt => opt.MapFrom(i => i.Usuario.PrimerNombre))
                .ForMember(x => x.SegundoNombre, opt => opt.MapFrom(i => i.Usuario.SegundoNombre))
                .ForMember(x => x.PrimerApellido, opt => opt.MapFrom(i => i.Usuario.SegundoApellido))
                .ForMember(x => x.SegundoApellido, opt => opt.MapFrom(i => i.Usuario.SegundoApellido))
                .ForMember(x => x.TipoIdentificacion, opt => opt.MapFrom(i => i.Usuario.TipoIdentificacion))
                .ForMember(x => x.Identificación, opt => opt.MapFrom(i => i.Usuario.Identificación))
                .ForMember(x => x.Invitado, opt => opt.MapFrom(i => false));

            CreateMap<ReservaInvitado, ReservaListDto>()
                .ForMember(x => x.UsuarioId, opt => opt.MapFrom(i => i.UsuarioInvitadoId))
                .ForMember(x => x.PrimerNombre, opt => opt.MapFrom(i => i.UsuarioInvitado.PrimerNombre))
                .ForMember(x => x.SegundoNombre, opt => opt.MapFrom(i => i.UsuarioInvitado.SegundoNombre))
                .ForMember(x => x.PrimerApellido, opt => opt.MapFrom(i => i.UsuarioInvitado.SegundoApellido))
                .ForMember(x => x.SegundoApellido, opt => opt.MapFrom(i => i.UsuarioInvitado.SegundoApellido))
                .ForMember(x => x.TipoIdentificacion, opt => opt.MapFrom(i => i.UsuarioInvitado.TipoIdentificacion))
                .ForMember(x => x.Identificación, opt => opt.MapFrom(i => i.UsuarioInvitado.Identificación))
                .ForMember(x => x.Invitado, opt => opt.MapFrom(i => true));

        }
    }
}
