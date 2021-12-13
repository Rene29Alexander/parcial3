using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;


namespace WebAPI.Controllers
{
    /// <sumary>
    /// Web API para gestión de Zapatería
    /// </sumary>

    [ApiController]
    [Route("[controller]")]

    public class ShoesShopController: Controller
    {
        private DatabaseContext _context;

        public ShoesShopController(DatabaseContext context)
        {
            _context=context;
        }
        
        /// <sumary>
        /// Registros de Zapatería 
        /// </sumary>
        /// <remarks>
        /// Obtiene todos los zapatos registrados
        /// </remarks>
        /// <response code="200"> OK, Devuelve el objeto solicitado </response>
        /// <response code="404"> NOT FOUND, No se ha encontrado el objeto solicitado </response>
        [HttpGet]
        public async Task<ActionResult<List<ShoesShop>>> GetShoesShop()
        {
            var ShoesShops = await _context.ShoesShops.ToListAsync();
            return ShoesShops;
        }

        /// <sumary>
        /// Registros de Zapatería por id
        /// </sumary>
        /// <remarks>
        /// Para obtener los datos de la zapatería se debe especificar el Id
        /// </remarks>
        /// <param name= "id"> Id (idShoeShops) del objeto </param>
        /// <response code="200"> OK, Devuelve el objeto solicitado </response>
        /// <response code="404"> NOT FOUND, No se ha encontrado el objeto solicitado </response>
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoesShop>> GetShoesShopByID(int id)
        {
            var shoesShops = await _context.ShoesShops.FindAsync(id);
            if (shoesShops == null)
            {
                return NotFound();
            }
            return shoesShops;
        }

        /// <sumary>
        ///Post all Shoes shop
        /// </sumary>
        /// <param name= "shoesshop">  </param>
        /// <response code="200"> OK, Devuelve el objeto solicitado </response>
        /// <response code="404"> NOT FOUND, No se ha encontrado el objeto solicitado </response>
        [HttpPost]
        public async Task<ActionResult<ShoesShop>> PostShoesShop(ShoesShop shoesshop)
        {
            _context.ShoesShops.Add(shoesshop);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetShoesShopByID",new{IDbContextFactory=shoesshop.ShoesID},shoesshop); //este metodo aun no existe por eso muestra ese error

        }

        /// <sumary>
        /// Post all ShoesShop for id
        /// </sumary>
        /// <remarks>
        /// To obtain all the post of the shoe store, the Id must be specified
        /// </remarks>
        /// <response code="200"> OK, Devuelve el objeto solicitado </response>
        /// <response code="404"> NOT FOUND, No se ha encontrado el objeto solicitado </response>
        [HttpPut("{id}")]
        public async Task<ActionResult<ShoesShop>> putShoesShop(int id, ShoesShop shoesShop)
        {
            if(id != shoesShop.ShoesID)
            {
                return BadRequest();
            }
            _context.Entry(shoesShop).State= EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(!ShoesShopExists(id))
                {
                    return NotFound();

                }
                else
                {
                    throw;

                }
            }
            return CreatedAtAction("GeShoesShopByID",new{IDbContextFactory=shoesShop.ShoesID},shoesShop);

        }

          /// <sumary>
        ///Delete all Shoes shop
        /// </sumary>
        /// <remarks>
        /// To obtain all the delete of the shoe store, the Id must be specified 
        /// </remarks>
        /// <param name= "id"> Id (idShoeShops) del objeto </param>
        /// <response code="200"> OK, Devuelve el objeto solicitado </response>
        /// <response code="404"> NOT FOUND, No se ha encontrado el objeto solicitado </response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShoesShop>> DeleteShoesShop(int id)
        {
            var shoesShop = await _context.ShoesShops.FindAsync(id);
            if(shoesShop==null)
            {
                return NotFound();
            }

            _context.ShoesShops.Remove(shoesShop);
            await _context.SaveChangesAsync();
            return shoesShop;

        }
        private bool ShoesShopExists(int id) 
        {
            return _context.ShoesShops.Any(d=>d.ShoesID==id);
        }

 
    }


       
 
    
}