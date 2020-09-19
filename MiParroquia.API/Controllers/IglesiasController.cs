using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiParroquia.API.Persistencia;

namespace MiParroquia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IglesiasController : ControllerBase
    {
        private readonly DataContext _context;

        public IglesiasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var lista = await _context.Iglesias.ToListAsync();
            return Ok(lista);
            //return await Mediator.Send(new List.Query(pageSize, pageNumber));
        }
    }
}
