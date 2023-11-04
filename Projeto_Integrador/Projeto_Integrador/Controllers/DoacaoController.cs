using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto_Integrador.Models.Services;
using Projeto_Integrador.ViewModel;


namespace Projeto_Integrador.Controllers
{
    public class DoacaoController : Controller
    {
        private ServiceDoacao _ServiceDoacao;

        public DoacaoController()
        {
            _ServiceDoacao = new ServiceDoacao();
        }

        public IActionResult Index()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(DoacaoVM.ListarDoacao(userid));
        }

        public IActionResult Create(int id)
        {
            CarregaDadosViewBag();
            return View();
        }


        public void CarregaDadosViewBag()
        {
            ViewData["IdLocal"] = new SelectList(_ServiceDoacao.oRepositoryLocais.SelecionarTodos(), "Id", "Nome");
            ViewData["Status"] = new SelectList(_ServiceDoacao.oRepositoryStatus.SelecionarTodos(), "Id", "Descricao");
            //ViewBag.listalocal = _ServiceDoacao.oRepositoryLocais.SelecionarTodos();
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _ServiceDoacao.oRepositoryDoaco.ExcluirAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult Detail(string user)
        {
            user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(DoacaoVM.SelecionaDoacao(user));
        }
    }
}