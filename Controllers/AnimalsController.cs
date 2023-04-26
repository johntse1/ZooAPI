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
    public class AnimalsController : ControllerBase
    {
        private readonly ZooAPIContext _context;

        public AnimalsController(ZooAPIContext context)
        {
            _context = context;
        }

        // GET: api/Animals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimal()
        {
          if (_context.Animal == null)
          {
                return NotFound(new Response(404, "Error Not Found: Animal list does not exist", null));
          }
            return Ok(new Response(200, "Successful call", await _context.Animal.ToListAsync()));
        }

        // GET: api/Animals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(int id)
        {
          if (_context.Animal == null)
          {
                return NotFound(new Response(404, "Error Not Found: Animal does not exist", null));
            }
            var animal = await _context.Animal.FindAsync(id);

            if (animal == null)
            {
                return NotFound(new Response(404, "Error Not Found: Animal does not exist", null));
            }

            return Ok(new Response(200, "Successful call",animal));
        }

        // PUT: api/Animals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimal(int id, Animal animal)
        {
            if (id != animal.AnimalID)
            {
                return BadRequest(new Response(400,"Error: Invalid Request",null));
            }

            _context.Entry(animal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
                {
                    return NotFound(new Response(404,"Error Not Found: Animal does not exist",null));
                }
                else
                {
                    throw;
                }
            }

            return Ok(new Response(200, "Success: Change was posted.", CreatedAtAction("GetLinks",new {id = animal.AnimalID}, animal).Value));
        }

        // POST: api/Animals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Animal>> PostAnimal(Animal animal)
        {
          if (_context.Animal == null)
          {
              return NotFound(new Response(404, "Error Not Found: Animal does not exist.",null));
          }
            _context.Animal.Add(animal);
            await _context.SaveChangesAsync();

            return StatusCode(201, new Response(201, "Success: Animal added", CreatedAtAction("GetAnimals", new {id = animal.AnimalID},animal)));
        }

        // DELETE: api/Animals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            if (_context.Animal == null)
            {
                return NotFound(new Response(404, "Error Not Found: Animal does not exist", null));
            }
            var animal = await _context.Animal.FindAsync(id);
            if (animal == null)
            {
                return NotFound(new Response(404, "Error Not Found: Animal does not exist",null));
            }

            _context.Animal.Remove(animal);
            await _context.SaveChangesAsync();

            return Ok(new Response(200, "Success, Animal deleted :(",""));
        }

        private bool AnimalExists(int id)
        {
            return (_context.Animal?.Any(e => e.AnimalID == id)).GetValueOrDefault();
        }
    }
}
