using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiParroquia.API.Aplicacion.Extensions;
using MiParroquia.API.Aplicacion.Iglesias;
using MiParroquia.API.Aplicacion.Iglesias.Dtos;
using MiParroquia.API.Persistencia;

namespace MiParroquia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IglesiasController : BaseController
    {
        private readonly DataContext _context;

        public IglesiasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<PagedList<IglesiaListDto>> List([FromQuery] int? pageSize, [FromQuery] int? pageNumber)
        {
            return await Mediator.Send(new List.Query(pageSize, pageNumber));
        }

        [HttpPost("{iglesiaId}/horarios")]
        public async Task<HorarioDto> CreateHorario(Guid iglesiaId, CreateHorario.Command command)
        {
            command.IglesiaId = iglesiaId;
            return await Mediator.Send(command);
        }

        [HttpGet("{iglesiaId}/horarios")]
        public async Task<PagedList<HorarioListDto>> ListHorarios(Guid iglesiaId, [FromQuery] int? pageSize, [FromQuery] int? pageNumber)
        {
            return await Mediator.Send(new ListHorarios.Query(iglesiaId, pageSize, pageNumber));
        }

        [HttpPut("{idIglesia}/horarios/{idHorario}")]

        public async Task<IActionResult> UpdateHorario(Guid iglesiaId, Guid idHorario)
        {
            return Ok();
        }
    }
}
