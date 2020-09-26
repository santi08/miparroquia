using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiParroquia.API.Application.Errors;
using MiParroquia.API.Application.Interfaces;
using MiParroquia.API.Application.User.Dtos;
using MiParroquia.API.Dominio;
using MiParroquia.API.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiParroquia.API.Application.User
{
    public class Login
    {
        public class Query : IRequest<UserLogin>
        {
            public string Identificacion { get; set; }
            public string Password { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {

            public QueryValidator()
            {
                RuleFor(x => x.Identificacion).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Query, UserLogin>
        {
            private readonly UserManager<Usuario> _userManager;
            private readonly SignInManager<Usuario> _signInManager;
            private readonly IJwtGenerator _jwtGenerator;
            private readonly DataContext _context;

            public Handler(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IJwtGenerator jwtGenerator, DataContext context)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _jwtGenerator = jwtGenerator;
                _context = context;
            }

            public async Task<UserLogin> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Identificación == request.Identificacion);

                if (user == null)
                    throw new RestException(HttpStatusCode.Unauthorized);

                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

                if (result.Succeeded)
                {
                    return new UserLogin
                    {
                        UserName = user.UserName,
                        Token = _jwtGenerator.CreateToken(user),
                        Image = null
                    };
                }

                throw new RestException(HttpStatusCode.Unauthorized);
            }
        }
    }
}
