using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MiParroquia.API.Aplicacion.Iglesias.Dtos;
using MiParroquia.API.Application.Errors;
using MiParroquia.API.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MiParroquia.API.Aplicacion.Iglesias
{
    public class UpdateHorario
    {
        public class Command : IRequest<HorarioDto>
        {
            public Guid HorarioId { get; set; }
            public DateTime Hora { get; set; }
            public int Capacidad { get; set; }
            public string Transmision { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.HorarioId).NotEmpty();
                RuleFor(x => x.Hora).NotEmpty();
                RuleFor(x => x.Capacidad).NotEmpty();
            }
        }
        public class Handler : IRequestHandler<Command, HorarioDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<HorarioDto> Handle(Command request, CancellationToken cancellationToken)
            {

                var horario = await _context.Horarios.FirstOrDefaultAsync(c => c.HorarioId == request.HorarioId);
                if (horario == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { Horario = "Horario no encontrado" });
                }


                horario.Hora = request.Hora;
                horario.Capacidad = request.Capacidad;
                horario.Transmision = request.Transmision

                _context.Horarios.Update(horario);

                var success = await _context.SaveChangesAsync() > 0;

                var horarioDto = _mapper.Map<HorarioDto>(horario);
                if (success) return horarioDto;

                throw new Exception("Ha ocurrido un error");
            }
        }
    }
}
