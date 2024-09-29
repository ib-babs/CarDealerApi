using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarDealerApi.Models;

namespace CarDealerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarItemsController(CarDbContext context) : ControllerBase
    {
        private readonly CarDbContext _context = context;
        
        // GET: api/CarItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarItem>>> GetCarItems()
        {
            return await _context.CarItems.ToListAsync();
        }

        // GET: api/CarItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarItem>> GetCarItem(int id)
        {
            var carItem = await _context.CarItems.FindAsync(id);

            if (carItem == null)
            {
                return NotFound();
            }

            return carItem;
        }

        // PUT: api/CarItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarItem(int id, CarItem carItem)
        {
            if (id != carItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(carItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarItemExists(id))
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

        // POST: api/CarItems
        [HttpPost]
        public async Task<ActionResult<CarItem>> PostCarItem(CarItem carItem)
        {
            _context.CarItems.Add(carItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarItem", new { id = carItem.Id }, carItem);
        }

        // DELETE: api/CarItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarItem(int id)
        {
            var carItem = await _context.CarItems.FindAsync(id);
            if (carItem == null)
            {
                return NotFound();
            }

            _context.CarItems.Remove(carItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarItemExists(int id)
        {
            return _context.CarItems.Any(e => e.Id == id);
        }
    }
}
