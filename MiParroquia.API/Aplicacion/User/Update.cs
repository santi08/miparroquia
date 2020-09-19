using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiParroquia.API.Application.Errors;
using MiParroquia.API.Dominio;
using MiParroquia.API.Persistencia;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MiParroquia.API.Application.User
{
    public class Update
    {

        public class Command : IRequest
        {
            public string Id { get; set; }
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
            public string Email { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.PrimerNombre).NotEmpty();
                RuleFor(x => x.PrimerApellido).NotEmpty();
                RuleFor(x => x.Email).NotEmpty().EmailAddress();

            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly UserManager<Usuario> _userManager;

            public Handler(DataContext context, UserManager<Usuario> userManager)
            {
                _context = context;
                _userManager = userManager;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.Id);

                if (user == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, new { User = "Not Fund" });

                }

                if (await _context.Users.AnyAsync(u => u.Email == request.Email && u.Id != request.Id)) 
                { 
                    throw new RestException(HttpStatusCode.BadRequest, new { Email = "Email already exists" });
                }

                user.PrimerNombre = request.PrimerNombre;
                user.SegundoNombre = request.SegundoNombre;
                user.PrimerApellido = request.PrimerApellido;
                user.SegundoApellido= request.SegundoApellido;
                user.FechaNacimiento = request.FechaNacimiento;
                user.TipoIdentificacion = request.TipoIdentificacion; 
                user.Identificación = request.Identificación;
                user.Direccion = request.Direccion;
                user.Telefono= request.Telefono;
                user.Genero= request.Genero;
                user.EstadoCivil= request.EstadoCivil;
                
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return Unit.Value;
                }

                throw new Exception("Problem creating user");
            }
        }
    }
}
