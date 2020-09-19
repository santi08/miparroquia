using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MiParroquia.API.Application.Errors;
using MiParroquia.API.Application.User.Dtos;
using MiParroquia.API.Persistencia;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MiParroquia.API.Application.User
{
    public class Details
    {

        public class Query : IRequest<UserDetailsDto>
        {
            public string Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, UserDetailsDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UserDetailsDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var usuario = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.Id);

                if (usuario == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { Usuario = "Not Found" });
                }

                var usuarioDto = _mapper.Map<UserDetailsDto>(usuario);
                return usuarioDto;
            }
        }

    }
}
