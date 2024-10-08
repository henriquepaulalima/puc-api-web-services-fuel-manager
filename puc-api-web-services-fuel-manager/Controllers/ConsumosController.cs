﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using puc_api_web_services_fuel_manager.Models;

namespace puc_api_web_services_fuel_manager.Controllers
{
    [Authorize(Roles = "Administrador,Usuario")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConsumosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var model = await _context.Consumos.ToListAsync();

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Consumo model)
        {
            _context.Consumos.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetById", new { id = model.Id }, model);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var model = await _context.Consumos
                .Include(table => table.Veiculo)
                .FirstOrDefaultAsync(consumo => consumo.Id == id);

            if (model == null) return NotFound();

            GerarLinks(model);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Consumo model)
        {
            if (id != model.Id) return BadRequest();

            var modelDb = await _context.Consumos
                .AsNoTracking()
                .FirstOrDefaultAsync(consumo => consumo.Id == id);

            if (modelDb == null) return NotFound();

            _context.Consumos.Update(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _context.Consumos.FindAsync(id);

            if (model == null) return NotFound();

            _context.Consumos.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private void GerarLinks(Consumo model)
        {
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "self", metodo: "GET"));
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "update", metodo: "PUT"));
            model.Links.Add(new LinkDto(model.Id, Url.ActionLink(), rel: "delete", metodo: "DELETE"));
        }
    }
}
