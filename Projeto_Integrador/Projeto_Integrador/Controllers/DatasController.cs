using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            var listarDatas = DataVM.ListarTodasDatas();
            return View(listarDatas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DataVM dataVM)
        {
            var data = new CadDataHoraDisp();
            data.IdLocal = dataVM.IdLocal;
            data.Disp = dataVM.Disp;
            data.Date = dataVM.Date;

            await _ServiceDatas.oRepositoryDatas.IncluirAsync(data);
            return View(dataVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _ServiceDatas.oRepositoryDatas.SelecionarPkAsync(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CadDataHoraDisp data)
        {
            if(ModelState.IsValid)
            {
                var data = await _ServiceDatas.oRepositoryDatas.AlterarAsync(data);
                return View(data);
            }
            ViewData["MensagemErro"] = "Ocorreu um erro";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete (int id)
        {
            await _ServiceDatas.oRepositoyDatas.ExcluirAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var data = DataVM.SelecionarData(id);
            return View(data);
        }
    }
}
