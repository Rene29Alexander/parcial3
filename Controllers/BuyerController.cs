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
    /// <sumary>
    /// Web API para gestión de Comprador
    /// </sumary>
    [ApiController]
    [Route("[controller]")]


    public class BuyerController:Controller
    {
        private DatabaseContext _context;

        public BuyerController(DatabaseContext context)
        {
            _context=context;
        }
           
        /// <sumary>
        /// Registros de Comprador 
        /// </sumary>
        /// <remarks>
        /// Obtiene todos los compradores registrados
        /// </remarks>
        /// <response code="200"> OK, Devuelve el objeto solicitado </response>
        /// <response code="404"> NOT FOUND, No se ha encontrado el objeto solicitado </response>
        [HttpGet]
        public async Task<ActionResult<List<Buyer>>> GetBuyer()
        {
            var Buyer = await _context.Buyers.ToListAsync();
            return  Buyer;
        }

        /// <sumary>
        /// Registros de comprador por id
        /// </sumary>
        /// <remarks>
        /// Para obtener los datos de la comprador se debe especificar el Id
        /// </remarks>
        /// <param name= "id"> Id (idcomprador) del objeto </param>
        /// <response code="200"> OK, Devuelve el objeto solicitado </response>
        /// <response code="404"> NOT FOUND, No se ha encontrado el objeto solicitado </response>
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
          /// <sumary>
        ///Post all Shoes shop
        /// </sumary>
        /// <response code="200"> OK, Devuelve el objeto solicitado </response>
        /// <response code="404"> NOT FOUND, No se ha encontrado el objeto solicitado </response>
        [HttpPost]
        public async Task<ActionResult<Buyer>> PostBuyer(Buyer buyer)
        {
            _context.Buyers.Add(buyer);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetBuyerByID",new{IDbContextFactory=buyer.BuyerID},buyer); //este metodo aun no existe por eso muestra ese error

        }
        /// <sumary>
        /// Post all Buyer for id
        /// </sumary>
        /// <remarks>
        /// To obtain all the post of the shoe store, the Id must be specified
        /// </remarks>
        /// <response code="200"> OK, Devuelve el objeto solicitado </response>
        /// <response code="404"> NOT FOUND, No se ha encontrado el objeto solicitado </response>
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
        
         /// <sumary>
        ///Delete all Buyer
        /// </sumary>
        /// <remarks>
        /// To obtain all the delete of the shoe store, the Id must be specified 
        /// </remarks>
        /// <param name= "id"> Id (idBuyer) del objeto </param>
        /// <response code="200"> OK, Devuelve el objeto solicitado </response>
        /// <response code="404"> NOT FOUND, No se ha encontrado el objeto solicitado </response>

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