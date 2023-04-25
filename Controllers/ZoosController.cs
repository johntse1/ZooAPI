using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooAPI.Models;

namespace ZooAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoosController : ControllerBase
    {
        private readonly ZooAPIContext _context;

        public ZoosController(ZooAPIContext context)
        {
            _context = context;
        }

        // GET: api/Zoos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zoo>>> GetZoo()
        {
          if (_context.Zoo == null)
          {
              return NotFound();
          }
            return await _context.Zoo.ToListAsync();
        }

        // GET: api/Zoos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zoo>> GetZoo(int id)
        {
          if (_context.Zoo == null)
          {
              return NotFound();
          }
            var zoo = await _context.Zoo.FindAsync(id);

            if (zoo == null)
            {
                return NotFound();
            }

            return zoo;
        }

        // PUT: api/Zoos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZoo(int id, Zoo zoo)
        {
            if (id != zoo.ZooID)
            {
                return BadRequest();
            }

            _context.Entry(zoo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZooExists(id))
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

        // POST: api/Zoos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Zoo>> PostZoo(Zoo zoo)
        {
          if (_context.Zoo == null)
          {
              return Problem("Entity set 'ZooAPIContext.Zoo'  is null.");
          }
            _context.Zoo.Add(zoo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZoo", new { id = zoo.ZooID }, zoo);
        }

        // DELETE: api/Zoos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZoo(int id)
        {
            if (_context.Zoo == null)
            {
                return NotFound();
            }
            var zoo = await _context.Zoo.FindAsync(id);
            if (zoo == null)
            {
                return NotFound();
            }

            _context.Zoo.Remove(zoo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ZooExists(int id)
        {
            return (_context.Zoo?.Any(e => e.ZooID == id)).GetValueOrDefault();
        }
    }
}
