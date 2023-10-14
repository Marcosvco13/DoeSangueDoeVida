using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projeto_Integrador.Areas.Identity;
using Projeto_Integrador.Models.Models;
using Projeto_Integrador.Models.Services;
using Projeto_Integrador.ViewModel;

namespace Projeto_Integrador.Controllers
{
    public class DatasController : Controller
    {
        private ServiceDatas _ServiceDatas;

        public DatasController()
        {
            _ServiceDatas = new ServiceDatas();
        }
        //[Authorize(Roles = Roles.Hemocentro)]
        public IActionResult Index()
        {
            var listarDatas = DataVM.ListarTodasDatas();
            return View(listarDatas);
        }
        public void CarregaDadosViewBag()
        {
            ViewData["IdLocais"] = new SelectList(_ServiceDatas.oRepositoryLocais.SelecionarTodos(), "Id", "Nome");
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarregaDadosViewBag();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DataVM dataVM)
        {
            CarregaDadosViewBag();
            var data = new CadDataHoraDisp();
            data.IdLocal = dataVM.IDLocal;
            data.Disp = dataVM.Disponivel;
            data.DataDisp = dataVM.Data;

            await _ServiceDatas.oRepositoryDatas.IncluirAsync(data);
            return View(dataVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            CarregaDadosViewBag();
            var data = await _ServiceDatas.oRepositoryDatas.SelecionarPkAsync(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CadDataHoraDisp data)
        {
            CarregaDadosViewBag();
            if (ModelState.IsValid)
            {
                var selecData = await _ServiceDatas.oRepositoryDatas.AlterarAsync(data);
                return View(selecData);
            }
            ViewData["MensagemErro"] = "Ocorreu um erro";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete (int id)
        {
            await _ServiceDatas.oRepositoryDatas.ExcluirAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var data = DataVM.SelecionarData(id);
            return View(data);
        }
    }
}
