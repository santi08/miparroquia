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
    public class Register
    {
        public class Command : IRequest<UserLogin>
        {
            public string PrimerNombre { get; set; }
            public string SegundoNombre { get; set; }
            public string PrimerApellido { get; set; }
            public string SegundoApellido { get; set; }
            public string TipoIdentificacion { get; set; }
            public string Identificación { get; set; }
            public DateTime FechaNacimiento { get; set; }
            public string Direccion { get; set; }
            public string Telefono { get; set; }
            public string Genero { get; set; }
            public string EstadoCivil { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.PrimerNombre).NotEmpty();
                RuleFor(x => x.PrimerApellido).NotEmpty();
                RuleFor(x => x.Identificación).NotEmpty();
                RuleFor(x => x.FechaNacimiento).NotEmpty();
                RuleFor(x => x.UserName).NotEmpty();
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                
            }
        }

        public class Handler : IRequestHandler<Command, UserLogin>
        {
            private readonly DataContext _context;
            private readonly UserManager<Usuario> _userManager;
            private readonly IJwtGenerator _jwtGenerator;

            public Handler(DataContext context, UserManager<Usuario> userManager, IJwtGenerator jwtGenerator)
            {
                _context = context;
                _userManager = userManager;
                _jwtGenerator = jwtGenerator;
            }

            public async Task<UserLogin> Handle(Command request, CancellationToken cancellationToken)
            {

                if (await _context.Users.Where(x => x.Email == request.Email).AnyAsync())
                    throw new RestException(HttpStatusCode.BadRequest, new { Email = "Email already exists" });

                if (await _context.Users.Where(x => x.UserName == request.UserName).AnyAsync())
                    throw new RestException(HttpStatusCode.BadRequest, new { Username = "Username already exists" });

                var user = new Usuario
                {
                    PrimerNombre = request.PrimerNombre,
                    SegundoNombre = request.SegundoNombre,
                    PrimerApellido = request.PrimerApellido,
                    SegundoApellido = request.SegundoApellido,
                    TipoIdentificacion = request.TipoIdentificacion,
                    Identificación = request.Identificación,
                    Direccion = request.Direccion,
                    Telefono = request.Telefono,
                    Genero = request.Genero,
                    EstadoCivil = request.EstadoCivil,
                    FechaNacimiento = request.FechaNacimiento,
                    Email = request.Email,
                    UserName = request.UserName
                };

                //var result = await _userManager.CreateAsync(user, request.Password);
                var result = await _userManager.CreateAsync(user, "Pa$$w0rd");
                if (result.Succeeded)
                {
                    return new UserLogin
                    {
                        UserName = user.UserName,
                        Token = _jwtGenerator.CreateToken(user),
                        Image = null
                    };
                }

                throw new Exception("Problem creating user");
            }
        }
    }
}
