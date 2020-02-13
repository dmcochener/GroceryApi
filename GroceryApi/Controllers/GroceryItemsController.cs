using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroceryApi.Models;

namespace GroceryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryItemsController : ControllerBase
    {
        private readonly GroceryContext _context;

        public GroceryItemsController(GroceryContext context)
        {
            _context = context;
        }

        // GET: api/GroceryItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroceryItem>>> GetGroceryItems()
        {
            return await _context.GroceryItems.ToListAsync();
        }

        // GET: api/GroceryItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroceryItem>> GetGroceryItem(int id)
        {
            var groceryItem = await _context.GroceryItems.FindAsync(id);

            if (groceryItem == null)
            {
                return NotFound();
            }

            return groceryItem;
        }

        // PUT: api/GroceryItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroceryItem(int id, GroceryItem groceryItem)
        {
            if (id != groceryItem.GroceryId)
            {
                return BadRequest();
            }

            _context.Entry(groceryItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceryItemExists(id))
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

        // POST: api/GroceryItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<GroceryItem>> PostGroceryItem(GroceryItem groceryItem)
        {
            _context.GroceryItems.Add(groceryItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGroceryItem), new { id = groceryItem.GroceryId }, groceryItem);
        }

        // DELETE: api/GroceryItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroceryItem>> DeleteGroceryItem(int id)
        {
            var groceryItem = await _context.GroceryItems.FindAsync(id);
            if (groceryItem == null)
            {
                return NotFound();
            }

            _context.GroceryItems.Remove(groceryItem);
            await _context.SaveChangesAsync();

            return groceryItem;
        }

        private bool GroceryItemExists(int id)
        {
            return _context.GroceryItems.Any(e => e.GroceryId == id);
        }
    }
}
