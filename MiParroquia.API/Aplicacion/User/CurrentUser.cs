using MediatR;
using Microsoft.AspNetCore.Identity;
using MiParroquia.API.Application.Interfaces;
using MiParroquia.API.Application.User.Dtos;
using MiParroquia.API.Dominio;
using System.Threading;
using System.Threading.Tasks;

namespace MiParroquia.API.Application.User
{
    public class CurrentUser
    {
        public class Query : IRequest<UserLogin>
        {

        }

        public class Handler : IRequestHandler<Query, UserLogin>
        {
            private readonly UserManager<Usuario> _userManager;
            private readonly IJwtGenerator _jwtGenerator;
            private readonly IUserAccesor _userAccesor;

            public Handler(UserManager<Usuario> userManager, IJwtGenerator jwtGenerator, IUserAccesor userAccesor)
            {
                _userManager = userManager;
                _jwtGenerator = jwtGenerator;
                _userAccesor = userAccesor;
            }

            public async Task<UserLogin> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByNameAsync(_userAccesor.GetCurrentUserName());

                return new UserLogin
                {
                    Image = null,
                    UserName = user.UserName,
                    Token = _jwtGenerator.CreateToken(user)
                };

            }
        }
    }
}
