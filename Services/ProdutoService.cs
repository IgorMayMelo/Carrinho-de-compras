using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Services.Exceptions;
using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using System.Data;

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

        public async Task<Produto> FindByIdAsync(int id)
        {
            return await _context.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                Produto produto = await _context.Produtos.FindAsync(id);
                _context.Remove(produto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new IntegrityException(ex.Message);
            }
        }

        public async Task UpdateAsync(Produto produto)
        {
            bool hasAny = await _context.Produtos.AnyAsync(x => x.Id == produto.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(produto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }
    }
}
