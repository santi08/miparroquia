using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MiParroquia.API.Aplicacion.Extensions;
using MiParroquia.API.Aplicacion.Horarios.Dtos;
using MiParroquia.API.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MiParroquia.API.Aplicacion.Horarios
{
    public class ListReservas
    {
        public class Query : IRequest<PagedList<ReservaListDto>>
        {
            public int? PageSize { get; set; }
            public int? PageNumber { get; set; }
            public Guid HorarioId { get; set; }

            public Query(Guid horarioId, int? pageSize, int? pageNumber)
            {
                PageSize = pageSize;
                PageNumber = pageNumber;
                HorarioId = horarioId;
            }
        }

        public class Handler : IRequestHandler<Query, PagedList<ReservaListDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PagedList<ReservaListDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var queryable = _context.Reservas.Include(h => h.Usuario)
                                                 .Include(h => h.Horario)
                                                 .Where(h => h.HorarioId == request.HorarioId)
                                        .AsQueryable();

                var queryable2 = _context.ReservasInvitados.Include(r=>r.UsuarioInvitado)
                                          .Include(r=>r.Horario)
                                          .Where(h => h.HorarioId == request.HorarioId)
                                        .AsQueryable();

                //if (request.PageNumber != null && request.PageSize != null)
                //{
                //    queryable = queryable.Skip((request.PageNumber - 1) ?? 0)
                //                          .Take(request.PageSize ?? 5);
                //}

                var reservas = await queryable.ProjectTo<ReservaListDto>(_mapper.ConfigurationProvider)
                                              .ToListAsync(cancellationToken);

                var reservas2 = await queryable2.ProjectTo<ReservaListDto>(_mapper.ConfigurationProvider)
                                              .ToListAsync(cancellationToken);

                reservas.AddRange(reservas2);

                return new PagedList<ReservaListDto>
                {
                    Items = reservas,
                    TotalItems = queryable.Count(),
                    PageNumber = request.PageNumber ?? 1,
                    PageSize = request.PageSize ?? 5

                };
            }
        }
    }
}
