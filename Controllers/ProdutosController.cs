using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            List<Produto> produtos = new List<Produto>
            {
                new Produto
                {
                    Id = 1,
                    Name = "test",
                },
                new Produto
                {
                    Id = 2,
                    Name = "safsf",
                }
            };
            return View(produtos);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
