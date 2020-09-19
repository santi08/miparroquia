using Microsoft.AspNetCore.Mvc;
using MiParroquia.API.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiParroquia.API.Controllers
{
    public class HorariosController : BaseController
    {
        private readonly DataContext _context;

        public HorariosController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("{idHorario}/reservas")]
        public async Task<IActionResult> CreateReserva(Guid idHorario)
        {
            return Ok();
        }

        [HttpGet("{id}/reservas")]
        public async Task<IActionResult> ListReservas(Guid idHorario, [FromQuery] int? pageSize, [FromQuery] int? pageNumber)
        {
            return Ok();
        }

        [HttpPut("{id}/reservas/{idReserva}")]
        public async Task<IActionResult> UpdateReserva(Guid idHorario, Guid idReserva)
        {
            return Ok();
        }

        [HttpPost("{idHorario}/reservas-invitados")]
        public async Task<IActionResult> CreateReservaInvitado(Guid idHorario)
        {
            return Ok();
        }

        [HttpGet("{id}/reservas-invitados")]
        public async Task<IActionResult> ListReservasInvitados(Guid idHorario, [FromQuery] int? pageSize, [FromQuery] int? pageNumber)
        {
            return Ok();
        }

        [HttpPut("{id}/reservas-invitados/{idReserva}")]
        public async Task<IActionResult> UpdateReservaInvitado(Guid idHorario, Guid idReserva)
        {
            return Ok();
        }
    }
}
