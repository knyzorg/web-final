using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vknyazev_C50A03Services.Models;

namespace vknyazev_C50A03Services.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly vkC50A03DBContext _context;

        public ShoppingCartsController(vkC50A03DBContext context)
        {
            _context = context;
        }

        // GET: api/ShoppingCarts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingCart>>> GetShoppingCart()
        {
            return await _context.ShoppingCart.ToListAsync();
        }

        // GET: api/ShoppingCarts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingCart>> GetShoppingCart(int id)
        {
            var Shoppingcart = await _context.ShoppingCart.FindAsync(id);

            if (Shoppingcart == null)
            {
                return NotFound();
            }

            return Shoppingcart;
        }

        // PUT: api/ShoppingCarts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingCart(int id, ShoppingCart Shoppingcart)
        {
            if (id != Shoppingcart.CartId)
            {
                return BadRequest();
            }

            _context.Entry(Shoppingcart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingCartExists(id))
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

        // POST: api/ShoppingCarts
        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> PostShoppingCart(ShoppingCart Shoppingcart)
        {
            _context.ShoppingCart.Add(Shoppingcart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoppingCart", new { id = Shoppingcart.CartId }, Shoppingcart);
        }

        // DELETE: api/ShoppingCarts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShoppingCart>> DeleteShoppingCart(int id)
        {
            var Shoppingcart = await _context.ShoppingCart.FindAsync(id);
            if (Shoppingcart == null)
            {
                return NotFound();
            }

            _context.ShoppingCart.Remove(Shoppingcart);
            await _context.SaveChangesAsync();

            return Shoppingcart;
        }

        private bool ShoppingCartExists(int id)
        {
            return _context.ShoppingCart.Any(e => e.CartId == id);
        }
    }
}
