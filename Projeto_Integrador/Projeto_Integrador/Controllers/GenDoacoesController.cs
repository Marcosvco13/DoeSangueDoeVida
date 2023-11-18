using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto_Integrador.Models.Models;
using Projeto_Integrador.Models.Services;
using Projeto_Integrador.ViewModel;

namespace Projeto_Integrador.Controllers
{
    public class GenDoacoesController : Controller
    {
        private ServiceGenDoacoes _ServiceGenDoacoes;
        public GenDoacoesController()
        {
            _ServiceGenDoacoes = new ServiceGenDoacoes();
        }

        public IActionResult Index()
        {
            var listarDoacoes = GenDoacoesVM.ListarTodasDoacoes(); // Certifique-se de que retorne GenDoacoesVM
            return View(listarDoacoes);
        }

        public void CarregaDadosViewBag()
        {
            ViewData["IdDoa"] = new SelectList(_ServiceGenDoacoes.oRepositoryDoaco.SelecionarTodos(), "Id", "Nome");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var doacao = await _ServiceGenDoacoes.oRepositoryDoaco.SelecionarPkAsync(id);
            return View(doacao);
        }

        public async Task<IActionResult> Edit(CadDoacao genDoacao)
        {
            if (ModelState.IsValid)
            {
                var doacao = await _ServiceGenDoacoes.oRepositoryDoaco.AlterarAsync(genDoacao);
                return RedirectToAction("Index");
            }
            ViewData["MensagemErro"] = "Ocorreu um erro";
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            var doacao = GenDoacoesVM.SelecionarDoacao(id);
            return View(doacao);
        }
    }
}