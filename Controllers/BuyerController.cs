using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]


    public class BuyerController:Controller
    {
        private DatabaseContext _context;

        public BuyerController(DatabaseContext context)
        {
            _context=context;
        }
           
        
        [HttpGet]
        public async Task<ActionResult<List<Buyer>>> GetBuyer()
        {
            var Buyer = await _context.Buyers.ToListAsync();
            return  Buyer;
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Buyer>> GetBuyerByID(int id)
        {
            var buyers = await _context.Buyers.FindAsync(id);
            if (buyers == null)
            {
                return NotFound();
            }
            return buyers;
        }
     
        [HttpPost]
        public async Task<ActionResult<Buyer>> PostBuyer(Buyer buyer)
        {
            _context.Buyers.Add(buyer);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetBuyerByID",new{IDbContextFactory=buyer.BuyerID},buyer); //este metodo aun no existe por eso muestra ese error

        }
      
        [HttpPut("{id}")]
        public async Task<ActionResult<Buyer>> putBuyer(int id, Buyer buyer)
        {
            if(id != buyer.BuyerID)
            {
                return BadRequest();
            }
            _context.Entry(buyer).State= EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!BuyerExists(id))
                {
                    return NotFound();

                }
                else
                {
                    throw;

                }
            }
            return CreatedAtAction("GetBuyerByID",new{IDbContextFactory=buyer.BuyerID},buyer);

        }
        


        [HttpDelete("{id}")]
        public async Task<ActionResult<Buyer>> DeleteBuyer(int id)
        {
            var buyer = await _context.Buyers.FindAsync(id);
            if(buyer==null)
            {
                return NotFound();
            }

            _context.Buyers.Remove(buyer);
            await _context.SaveChangesAsync();
            return buyer;

        }
        private bool BuyerExists(int id) 
        {
            return _context.Buyers.Any(d=>d.BuyerID==id);
        }

 
    }
}