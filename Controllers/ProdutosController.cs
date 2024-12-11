using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ECommerce.Controllers
{
    public class ProdutosController : Controller
    {

        private readonly ProdutoService _service;

        public ProdutosController(ProdutoService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.FindAllAsync());
        }

        //GET Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _service.InsertAsync(produto);
            return RedirectToAction(nameof(Index));
            
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


		//GET Produtos/Error
		public IActionResult Error(string message)
		{
			var viewModel = new ErrorViewModel
			{
				Message = message,
				RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
			};
			return View(viewModel);
		}
	}
}
