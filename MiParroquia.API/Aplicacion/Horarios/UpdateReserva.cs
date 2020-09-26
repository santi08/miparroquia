using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MiParroquia.API.Aplicacion.Horarios.Dtos;
using MiParroquia.API.Application.Errors;
using MiParroquia.API.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MiParroquia.API.Aplicacion.Horarios
{
    public class UpdateReserva

    {
        public class Command : IRequest<ReservaDto>
        {
            public Guid ReservaId { get; set; }
            public string Estado { get; set; }
            public bool Invitado { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Estado).NotEmpty();
                RuleFor(x => x.ReservaId).NotEmpty();
            }
        }
        public class Handler : IRequestHandler<Command, ReservaDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ReservaDto> Handle(Command request, CancellationToken cancellationToken)
            {
                if (request.Invitado)
                {
                    var reserva = await _context.ReservasInvitados.FirstOrDefaultAsync(r => r.ReservaInvitadoId == request.ReservaId);
                    if (reserva == null)
                    {
                        throw new RestException(HttpStatusCode.NotFound, new { Reserva = "Reserva no encontrada" });
                    }

                    reserva.Estado = request.Estado;


                    _context.ReservasInvitados.Update(reserva);

                    var success = await _context.SaveChangesAsync() > 0;

                    var reservaDto = _mapper.Map<ReservaDto>(reserva);
                    if (success) return reservaDto;
                }
                else
                {
                    var reserva = await _context.Reservas.FirstOrDefaultAsync(r => r.ReservaId == request.ReservaId);
                    if (reserva == null)
                    {
                        throw new RestException(HttpStatusCode.NotFound, new { Reserva = "Reserva no encontrada" });
                    }

                    reserva.Estado = request.Estado;

                    _context.Reservas.Update(reserva);

                    var success = await _context.SaveChangesAsync() > 0;

                    var reservaDto = _mapper.Map<ReservaDto>(reserva);
                    if (success) return reservaDto;
                }

                throw new Exception("Ha ocurrido un error");
            }
        }
    }
}
