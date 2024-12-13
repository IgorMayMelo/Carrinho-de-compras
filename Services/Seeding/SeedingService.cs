using ECommerce.Data;
using ECommerce.Models;

namespace ECommerce.Services.Seeding
{
    public class SeedingService
    {
        private readonly ECommerceContext _context;
        public SeedingService(ECommerceContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            if (_context.Produtos.Any())
            {
                return;
            }

            Produto p1 = new Produto(
            id: 1,
            name: "Camiseta de Algodão Premium",
            preco: 49.99,
            peso: "0,2",// em kg
            marca: "ModaVibe");


            Produto p2 = new Produto(
              id: 2,
              name: "Tênis Esportivo UltraConforto",
              preco: 199.99,
              peso: "0.8", // em kg
              marca: "RunnerFlex");



            Produto p3 = new Produto(
              id: 3,
              name: "Smartphone XPro Max 128GB",
              preco: 2299.90,
              peso: "0.4", // em kg
              marca: "TechMaster");



            Produto p4 = new Produto(
              id: 4,
              name: "Fone de Ouvido Bluetooth SoundX",
              preco: 149.99,
              peso: "0.3", // em kg
              marca: "SoundWave");



            Produto p5 = new Produto(
              id: 5,
              name: "Relógio Digital SportTime",
              preco: 99.99,
              peso: "0.15", // em kg
              marca: "TimeForce");
          


          Produto p6 = new Produto(
            id: 6,
            name: "Notebook Ultra Slim 15.6\"",
            preco: 3499.00,
            peso: "1.5", // em kg
            marca: "TechPro");



            Produto p7 = new Produto(
            id: 7,
            name: "Blender PowerMix 500W",
            preco: 179.90,
            peso: "2.0", // em kg
            marca: "MixMaster");



            Produto p8 = new Produto(
            id: 8,
            name: "Cadeira Gamer Turbo Comfort",
            preco: 899.90,
            peso: "10.0", // em kg
            marca: "GamerX");



            Produto p9 = new Produto(
            id: 9,
            name: "Mochila Impermeável AdventurePro",
            preco: 129.99,
            peso: "0.9", // em kg
            marca: "TrailGear");



            Produto p10 = new Produto(
            id: 10,
            name: "Kit de Maquiagem Glamour Set",
            preco: 89.99,
            peso: "0.5", // em kg
            marca: "BeautyEssence");


            await _context.Produtos.AddRangeAsync(
                p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);

            await _context.SaveChangesAsync();
        }


    }
}
