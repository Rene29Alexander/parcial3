using Microsoft.EntityFrameworkCore;
using WebAPI;

namespace WebAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() {}
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base (options) { }
        
       public DbSet<Buyer> Buyers {get;set;}
       public DbSet<ShoesShop> ShoesShops {get;set;}

   

    }
}