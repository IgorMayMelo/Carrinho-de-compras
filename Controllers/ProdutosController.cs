using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Models.ViewModels;
using ECommerce.Services.Exceptions;
using Humanizer.Localisation;
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

        //GET Produtos/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido"});
            }
            Produto produto = await _service.FindByIdAsync(id.Value);
            if (produto is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi encontrado" });
            }
            return View(produto);
        }

        //POST Produtos/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
        }

        //GET Produtos/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi fornecido" });
            }
            Produto produto = await _service.FindByIdAsync(id.Value);
            if (produto is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não foi encontrado." });
            }

            return View(produto);
        }

        // POST Produtos/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (id != produto.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id's não condizentes" });
            }

            try
            {
                await _service.UpdateAsync(produto);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
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
