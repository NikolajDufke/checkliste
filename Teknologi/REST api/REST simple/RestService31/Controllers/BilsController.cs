using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestService31.Models;

namespace RestService31.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BilsController : ControllerBase
    {
        private readonly BilContext _context;

        public BilsController(BilContext context)
        {
            _context = context;
        }

        // GET: api/Bils
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bil>>> GetbilItems()
        {
            return await _context.bilItems.ToListAsync();
        }

        // GET: api/Bils/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bil>> GetBil(int id)
        {
            var bil = await _context.bilItems.FindAsync(id);

            if (bil == null)
            {
                return NotFound();
            }

            return bil;
        }

        // PUT: api/Bils/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBil(int id, Bil bil)
        {
            if (id != bil.Id)
            {
                return BadRequest();
            }

            _context.Entry(bil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BilExists(id))
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

        // POST: api/Bils
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Bil>> PostBil(Bil bil)
        {
            _context.bilItems.Add(bil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBil", new { id = bil.Id }, bil);
        }

        // DELETE: api/Bils/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bil>> DeleteBil(int id)
        {
            var bil = await _context.bilItems.FindAsync(id);
            if (bil == null)
            {
                return NotFound();
            }

            _context.bilItems.Remove(bil);
            await _context.SaveChangesAsync();

            return bil;
        }

        private bool BilExists(int id)
        {
            return _context.bilItems.Any(e => e.Id == id);
        }
    }
}
