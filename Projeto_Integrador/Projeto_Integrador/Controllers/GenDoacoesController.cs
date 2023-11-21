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
        private ServiceDoacao _ServiceDoacao;
        public GenDoacoesController()
        {
            _ServiceGenDoacoes = new ServiceGenDoacoes();
            _ServiceDoacao = new ServiceDoacao();
        }

        public IActionResult Index()
        {
            var listarDoacoes = GenDoacoesVM.ListarTodasDoacoes();
            return View(listarDoacoes);
        }

        public void CarregaDadosViewBag()
        {
            ViewData["IdDoa"] = new SelectList(_ServiceGenDoacoes.oRepositoryDoaco.SelecionarTodos(), "Id", "Nome");
            ViewData["IdStatus"] = new SelectList(_ServiceDoacao.oRepositoryStatus.SelecionarTodos(), "Id", "Descricao");
            ViewData["IdFichaUsuario"] = new SelectList(_ServiceDoacao.oRepositoryFichas.SelecionarTodos(), "IdUser", "Nome");
            ViewData["IdData"] = new SelectList(_ServiceDoacao.oRepositoryDatas.SelecionarTodos(), "Id", "DataDisp");
            ViewData["IdLocal"] = new SelectList(_ServiceDoacao.oRepositoryLocais.SelecionarTodos(), "Id", "Nome");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var doacao = await _ServiceGenDoacoes.oRepositoryDoaco.SelecionarPkAsync(id);
            CarregaDadosViewBag();
            return View(doacao);
        }

        public async Task<IActionResult> Edit(CadDoacao genDoacao)
        {
            if (ModelState.IsValid)
            {
                var doacao = await _ServiceDoacao.oRepositoryDoaco.AlterarAsync(genDoacao);
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