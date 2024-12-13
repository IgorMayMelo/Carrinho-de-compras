using ECommerce.Models;
using Microsoft.EntityFrameworkCore;


namespace ECommerce.Data
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
