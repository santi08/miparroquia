using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MiParroquia.API.Aplicacion.Iglesias.Dtos;
using MiParroquia.API.Application.Errors;
using MiParroquia.API.Dominio;
using MiParroquia.API.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MiParroquia.API.Aplicacion.Iglesias
{
    public class CreateHorario
    {
        public class Command : IRequest<HorarioDto>
        {
            public Guid IglesiaId { get; set; }
            public DateTime Fecha { get; set; }
            public int Capacidad { get; set; }
            public string Transmision { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Fecha).NotEmpty();
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
                var iglesia = await _context.Iglesias.FirstOrDefaultAsync(i => i.IglesiaId == request.IglesiaId);

                if (iglesia is null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { Iglesia = "Not Found" });
                }

                var horario = new Horario
                {
                    Iglesia = iglesia,
                    Hora = request.Fecha,
                    Capacidad = request.Capacidad,
                    Transmision = request.Transmision
                };

                var h = await _context.Horarios.AddAsync(horario, cancellationToken);
                var horarioDto = _mapper.Map<HorarioDto>(h);

                return horarioDto;

            }
        }
    }
}
