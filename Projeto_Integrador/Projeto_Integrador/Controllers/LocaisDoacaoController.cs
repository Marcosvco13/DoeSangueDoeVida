using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto_Integrador.Areas.Identity;
using Projeto_Integrador.Models.Models;
using Projeto_Integrador.Models.Services;
using Projeto_Integrador.ViewModel;

namespace Projeto_Integrador.Controllers
{
    public class LocaisDoacaoController : Controller
    {
        private ServiceLocais _ServiceLocais;
        
        public LocaisDoacaoController()
        {
            _ServiceLocais = new ServiceLocais();
        }
        //[Authorize(Roles = Roles.Hemocentro)]
        public IActionResult Index()
        {
            var listarLocais = LocalDoacaoVM.ListarTodosLocais();
            return View(listarLocais);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(LocalDoacaoVM localDoacaoVM)
        {
            var local = new CadLocalDoacao();
            local.Nome = localDoacaoVM.nome;
            local.Email = localDoacaoVM.email;
            local.Telefone = localDoacaoVM.telefone;
            local.Logradouro = localDoacaoVM.rua;
            local.Numero = localDoacaoVM.num;
            local.Bairro = localDoacaoVM.bairro;
            local.Cidade = localDoacaoVM.cidade;
            local.Estado = localDoacaoVM.estado;
            local.Cep = localDoacaoVM.cep;
            local.Complemento = localDoacaoVM.comple;
            local.Ativo = (char)localDoacaoVM.ativo;

            await _ServiceLocais.oRepositoryLocais.IncluirAsync(local);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var local = await _ServiceLocais.oRepositoryLocais.SelecionarPkAsync(id);
            return View(local);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CadLocalDoacao localDoacao)
        {
            if (ModelState.IsValid)
            {
                var local = await _ServiceLocais.oRepositoryLocais.AlterarAsync(localDoacao);
                return RedirectToAction("Index");
            }
            ViewData["MensagemErro"] = "Ocorreu um erro";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _ServiceLocais.oRepositoryLocais.ExcluirAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var local = LocalDoacaoVM.SelecionarLocal(id);
            return View(local);
        }
    }
}
