using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MiParroquia.API.Aplicacion.Horarios.Dtos;
using MiParroquia.API.Application.Errors;
using MiParroquia.API.Dominio;
using MiParroquia.API.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MiParroquia.API.Aplicacion.Horarios
{
    public class CreateReserva

    {
        public class Command : IRequest<ReservaListDto>
        {
            public Guid HorarioId { get; set; }
            public string UsuarioId { get; set; }
            public bool Invitado { get; set; }
            public bool IgnoraLimite { get; set; } = false;
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.HorarioId).NotEmpty();
                RuleFor(x => x.UsuarioId).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command, ReservaListDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ReservaListDto> Handle(Command request, CancellationToken cancellationToken)
            {
                var horario = await _context.Horarios.Include(h => h.Reservas)
                                                     .Include(h => h.ReservaInvitados)
                                                     .FirstOrDefaultAsync(i => i.HorarioId == request.HorarioId);

                if (horario is null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { Horario = "Not Found" });
                }

                int reservado = horario.Reservas.Where(r => r.Estado == "Activa").Count() +
                                horario.ReservaInvitados.Where(r => r.Estado == "Activa").Count();

                if (!request.IgnoraLimite && reservado >= horario.Capacidad)
                {
                    throw new RestException(HttpStatusCode.Conflict, new { Horario = "No hay espacios disponibles para el horario" });
                }

                ReservaListDto reservaDto = null;

                if (request.Invitado)
                {

                    var reserva = new ReservaInvitado
                    {
                        Horario = horario,
                        UsuarioInvitadoId = new Guid(request.UsuarioId),
                        Fecha = DateTime.UtcNow,
                        Estado = "Activa"
                    };

                    var r = await _context.ReservasInvitados.AddAsync(reserva, cancellationToken);
                    reservaDto = _mapper.Map<ReservaListDto>(r);
                }
                else
                {
                    var reserva = new Reserva
                    {
                        Horario = horario,
                        UsuarioId = request.UsuarioId,
                        Fecha = DateTime.UtcNow,
                        Estado = "Activa"
                    };

                    var r = await _context.Reservas.AddAsync(reserva, cancellationToken);
                    reservaDto = _mapper.Map<ReservaListDto>(r);
                }

                return reservaDto;

            }
        }
    }
}
