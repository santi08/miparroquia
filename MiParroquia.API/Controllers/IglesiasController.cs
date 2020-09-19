using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost("{idIglesia}/horarios")]
        public async Task<IActionResult> CreateHorario(Guid idIglesia)
        {
            return Ok();
        }

        [HttpGet("{idIglesia}/horarios")]
        public async Task<IActionResult> ListHorarios(Guid idIglesia, [FromQuery] int? pageSize, [FromQuery] int? pageNumber)
        {
            return Ok();
        }

        [HttpPut("{idIglesia}/horarios/{idHorario}")]
        public async Task<IActionResult> UpdateHorario(Guid idIglesia, Guid idHorario)
        {
            return Ok();
        }
    }
}
