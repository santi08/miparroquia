using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiParroquia.API.Aplicacion.Extensions;
using MiParroquia.API.Aplicacion.Iglesias.Dtos;
using MiParroquia.API.Persistencia;

namespace MiParroquia.API.Aplicacion.Iglesias
{
    public class List
    {
        public class Query : IRequest<PagedList<IglesiaListDto>>
        {

            public int? PageSize { get; set; }
            public int? PageNumber { get; set; }

            public Query(int? pageSize, int? pageNumber)
            {
                PageSize = pageSize;
                PageNumber = pageNumber;
            }

        }
        public class Handler : IRequestHandler<Query, PagedList<IglesiaListDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PagedList<IglesiaListDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var queryable = _context.Iglesias.Include(a => a.Horarios).AsQueryable();

                var iglesias = await queryable.Skip((request.PageNumber - 1) ?? 0)
                                          .Take(request.PageSize ?? 5)
                                          .ProjectTo<IglesiaListDto>(_mapper.ConfigurationProvider)
                                          .ToListAsync(cancellationToken);

                return new PagedList<IglesiaListDto>
                {
                    Items = iglesias,
                    TotalItems = queryable.Count(),
                    PageNumber = request.PageNumber?? 1,
                    PageSize = request.PageSize?? 5

                };
            }
        }
    }
}
