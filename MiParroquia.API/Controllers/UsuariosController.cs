using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiParroquia.API.Application.User;
using MiParroquia.API.Application.User.Dtos;
using MiParroquia.API.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiParroquia.API.Controllers
{
    public class UsuariosController : BaseController
    {
        private readonly DataContext _context;

        public UsuariosController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserLogin>> Login(Login.Query query)
        {
            return await Mediator.Send(query);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserLogin>> Register(Register.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("current")]
        public async Task<ActionResult<UserLogin>> CurrentUser()
        {
            var query = new CurrentUser.Query { };
            return await Mediator.Send(query);
        }

        [HttpGet("{usuarioId}")]
        public async Task<ActionResult<UserDetailsDto>> Details(string usuarioId)
        {
            return await Mediator.Send(new Details.Query { Id = usuarioId });
        }

        [HttpPut("{usuarioId}")]
        public async Task<ActionResult<Unit>> Update(string usuarioId, Update.Command command)
        {
            command.Id = usuarioId;
            return await Mediator.Send(command);
        }

        //[HttpGet()]
        //public async Task<IActionResult> List(Guid idHorario, [FromQuery] int? pageSize, [FromQuery] int? pageNumber)
        //{
        //    return Ok();
        //}

        [HttpPost("{usuarioId}/invitados")]
        public async Task<IActionResult> CreateInvitado(Guid usuarioId)
        {
            return Ok();
        }

        [HttpGet("{usuarioId}/invitados")]
        public async Task<IActionResult> ListInvitados(Guid usuarioId, [FromQuery] int? pageSize, [FromQuery] int? pageNumber)
        {
            return Ok();
        }

        [HttpPut("{usuarioId}/invitados/{idInvitado}")]
        public async Task<IActionResult> UpdateInvitado(Guid usuarioId, Guid idInvitado)
        {
            return Ok();
        }

        [HttpGet("{usuarioId}/reservas")]
        public async Task<IActionResult> ListReservas(Guid usuarioId, [FromQuery] int? pageSize, [FromQuery] int? pageNumber)
        {
            return Ok();
        }

        [HttpGet("{usuarioId}/invitados/{idInvitado}/reservas")]
        public async Task<IActionResult> ListReservasInvitados(Guid usuarioId, [FromQuery] int? pageSize, [FromQuery] int? pageNumber)
        {
            return Ok();
        }
    }
}
