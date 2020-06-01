using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTAPI.Models;

namespace RESTAPI.Controllers
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
        public IEnumerable<Bil> GetbilItems()
        {
            return _context.bilItems;
        }

        // GET: api/Bils/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBil([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bil = await _context.bilItems.FindAsync(id);

            if (bil == null)
            {
                return NotFound();
            }

            return Ok(bil);
        }

        // PUT: api/Bils/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBil([FromRoute] int id, [FromBody] Bil bil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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
        [HttpPost]
        public async Task<IActionResult> PostBil([FromBody] Bil bil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.bilItems.Add(bil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBil", new { id = bil.Id }, bil);
        }

        // DELETE: api/Bils/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBil([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bil = await _context.bilItems.FindAsync(id);
            if (bil == null)
            {
                return NotFound();
            }

            _context.bilItems.Remove(bil);
            await _context.SaveChangesAsync();

            return Ok(bil);
        }

        private bool BilExists(int id)
        {
            return _context.bilItems.Any(e => e.Id == id);
        }
    }
}