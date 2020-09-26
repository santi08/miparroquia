using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MiParroquia.API.Aplicacion.Extensions;
using MiParroquia.API.Aplicacion.Iglesias.Dtos;
using MiParroquia.API.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MiParroquia.API.Aplicacion.Iglesias
{
    public class ListHorarios
    {
        public class Query : IRequest<PagedList<HorarioListDto>>
        {
            public int? PageSize { get; set; }
            public int? PageNumber { get; set; }
            public Guid IglesiaId { get; set; }

            public Query(Guid iglesiaId, int? pageSize, int? pageNumber)
            {
                IglesiaId = iglesiaId;
                PageSize = pageSize;
                PageNumber = pageNumber;
            }
        }

        public class Handler : IRequestHandler<Query, PagedList<HorarioListDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PagedList<HorarioListDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var queryable = _context.Horarios.Include(h => h.Reservas)
                                                 .Include(h => h.ReservaInvitados)
                                                 .Where(h => h.IglesiaId == request.IglesiaId && h.Hora >= DateTime.Now)
                                        .AsQueryable();

                var horarios = await queryable.Skip((request.PageNumber - 1) ?? 0)
                                          .Take(request.PageSize ?? 5)
                                          .ProjectTo<HorarioListDto>(_mapper.ConfigurationProvider)
                                          .ToListAsync(cancellationToken);

                return new PagedList<HorarioListDto>
                {
                    Items = horarios,
                    TotalItems = queryable.Count(),
                    PageNumber = request.PageNumber ?? 1,
                    PageSize = request.PageSize ?? 5

                };
            }
        }
    }
}
