using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VacationTool.DAL;
using VacationTool.Models;

namespace VacationTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationsController : ControllerBase
    {
        private readonly CompanyContext2 _context;

        public VacationsController(CompanyContext2 context)
        {
            _context = context;
        }

        // GET: api/Vacations
        [HttpGet]
        [EnableCors("AllowAll")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Vacation>>> GetVacations()
        {
            return await _context.Vacations.ToListAsync();
        }

        // GET: api/Vacations/5
        [HttpGet("{id}")]
        [EnableCors("AllowAll")]
        [Authorize]
        public async Task<ActionResult<Vacation>> GetVacation(int id)
        {
            var vacation = await _context.Vacations.FindAsync(id);

            if (vacation == null)
            {
                return NotFound();
            }

            return vacation;
        }

        // PUT: api/Vacations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [EnableCors("AllowAll")]
        [Authorize]
        public async Task<IActionResult> PutVacation(int id, Vacation vacation)
        {
            if (id != vacation.ID)
            {
                return BadRequest();
            }

            _context.Entry(vacation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vacations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [EnableCors("AllowAll")]
        [Authorize]
        public async Task<ActionResult<Vacation>> PostVacation(Vacation vacation)
        {
            _context.Vacations.Add(vacation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVacation", new { id = vacation.ID }, vacation);
        }

        // DELETE: api/Vacations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacation(int id)
        {
            var vacation = await _context.Vacations.FindAsync(id);
            if (vacation == null)
            {
                return NotFound();
            }

            _context.Vacations.Remove(vacation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VacationExists(int id)
        {
            return _context.Vacations.Any(e => e.ID == id);
        }
    }
}
