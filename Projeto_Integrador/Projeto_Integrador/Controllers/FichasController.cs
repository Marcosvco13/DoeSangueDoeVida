using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto_Integrador.Models.Models;
using Projeto_Integrador.Models.Services;
using Projeto_Integrador.ViewModel;

namespace Projeto_Integrador.Controllers
{
    [Authorize]
    public class FichasController : Controller
    {
        private ServiceFichas _ServiceFichas;

        public FichasController()
        {
            _ServiceFichas = new ServiceFichas();
        }
        public IActionResult Index()
        {
            var listarFicha = FichaVM.ListarTodasFichas();
            return View(listarFicha);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create (FichaVM fichaVM)
        {
            var ficha = new FichaDoacao();
            ficha.IdUser = fichaVM.idUser;
            ficha.TipoSangue = fichaVM.tipoSangue;
            ficha.UltimaDoacao = fichaVM.ultimaDoacao;
            ficha.Peso = fichaVM.peso;
            ficha.Fumante = fichaVM.fumante;
            ficha.Sexo = fichaVM.sexo;
            ficha.Cpf = fichaVM.cpf;
            ficha.Rg = fichaVM.rg;
            ficha.OrgExp = fichaVM.orgExp;
            ficha.Profissao = fichaVM.profissao;
            ficha.Religiao = fichaVM.religiao;
            ficha.TempFumante = fichaVM.tempFumante;
            ficha.DataNasc = fichaVM.dataNasc;
            ficha.NomeMae = fichaVM.nomeMae;
            ficha.NomePai = fichaVM.nomePai;

            await _ServiceFichas.oRepositoryFichas.IncluirAsync(ficha);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ficha = await _ServiceFichas.oRepositoryFichas.SelecionarPkAsync(id);
            return View(ficha);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FichaDoacao fichaDoacao)
        {
            if(ModelState.IsValid)
            {
                var ficha = await _ServiceFichas.oRepositoryFichas.AlterarAsync(fichaDoacao);
                return RedirectToAction("Index");
            }
            ViewData["MensagemErro"] = "Ocorreu um erro";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _ServiceFichas.oRepositoryFichas.ExcluirAsync(id);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var ficha = FichaVM.SelecionarFicha(id);
            return View(ficha);
        }
    }
}
