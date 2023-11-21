using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto_Integrador.Areas.Identity;
using Projeto_Integrador.Models.Models;
using Projeto_Integrador.Models.Services;
using Projeto_Integrador.ViewModel;


namespace Projeto_Integrador.Controllers
{
    [Authorize]
    public class DoacaoController : Controller
    {
        private ServiceDoacao _ServiceDoacao;

        public DoacaoController()
        {
            _ServiceDoacao = new ServiceDoacao();
        }
        public void CarregaDadosViewBag()
        {
            var db = new DOACAO_SANGUEContext();
            ViewData["IdLocal"] = new SelectList(_ServiceDoacao.oRepositoryLocais.SelecionarTodos(), "Id", "Nome");
            var datas = db.CadDataHoraDisp.Where(d => d.Disp != 2).ToList();
            ViewData["IdData"] = new SelectList(datas, "Id", "DataDisp");
            ViewData["IdStatus"] = new SelectList(_ServiceDoacao.oRepositoryStatus.SelecionarTodos(), "Id", "Descricao");
        }

        public IActionResult Index()
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(DoacaoVM.ListarDoacao(userid));
        }

        public IActionResult Create()
        {
            CarregaDadosViewBag();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CadDoacao doacao)
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var db = new DOACAO_SANGUEContext();

            var fichaExists = db.FichaDoacao.Any(x => x.IdUser == userid);

            if (ModelState.IsValid)
            {
                if (fichaExists)
                {
                    doacao = await _ServiceDoacao.oRepositoryDoaco.IncluirAsync(doacao);
                    var data = await _ServiceDoacao.oRepositoryDatas.SelecionarPkAsync(doacao.IdData);
                    data.Disp = 2;
                    await _ServiceDoacao.oRepositoryDatas.AlterarAsync(data);

                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Erro: Você não tem uma ficha cadastrada no sistema, favor realizar o cadastro da ficha para poder agendar uma doação.");
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var doacao = await _ServiceDoacao.oRepositoryDoaco.SelecionarPkAsync(id);
            CarregaDadosViewBag();
            return View(doacao);
        }

        public async Task<IActionResult> Edit(CadDoacao doacao)
        {
            if (ModelState.IsValid)
            {
                doacao = await _ServiceDoacao.oRepositoryDoaco.AlterarAsync(doacao);
                CarregaDadosViewBag();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var db = new DOACAO_SANGUEContext();
            var doacao = db.CadDoacao.FirstOrDefault(x => x.Id == id);
            var data = await _ServiceDoacao.oRepositoryDatas.SelecionarPkAsync(doacao.IdData);
            if (data != null)
            {
                data.Disp = 1;
                await _ServiceDoacao.oRepositoryDatas.AlterarAsync(data);
            }
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