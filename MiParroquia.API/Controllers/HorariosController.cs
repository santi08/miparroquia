using Microsoft.AspNetCore.Mvc;
using MiParroquia.API.Aplicacion.Extensions;
using MiParroquia.API.Aplicacion.Horarios;
using MiParroquia.API.Aplicacion.Horarios.Dtos;
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

        [HttpPost("{horarioId}/reservas")]
        public async Task<ReservaListDto> CreateReserva(Guid horarioId, CreateReserva.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("{horarioId}/reservas")]
        public async Task<PagedList<ReservaListDto>> ListReservas(Guid horarioId, [FromQuery] int? pageSize, [FromQuery] int? pageNumber)
        {
            return await Mediator.Send(new ListReservas.Query(horarioId, pageSize, pageNumber));
        }

        [HttpPut("{horarioId}/reservas/{idReserva}")]
        public async Task<IActionResult> UpdateReserva(Guid horarioId, Guid idReserva)
        {
            return Ok();
        }
    }
}
