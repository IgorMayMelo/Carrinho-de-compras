using ECommerce.Data;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce
{
	public class ProdutoService
	{
        private readonly ECommerceContext _context;

        public ProdutoService(ECommerceContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> FindAllAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task InsertAsync(Produto produto)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();
        }
    }
}
