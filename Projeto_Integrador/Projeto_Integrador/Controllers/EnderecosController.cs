using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Projeto_Integrador.Models.Models;
using Projeto_Integrador.Models.Services;
using Projeto_Integrador.ViewModel;

namespace Projeto_Integrador.Controllers
{
    [Authorize]
    public class EnderecosController : Controller
    {
        private ServiceEnderecos _ServiceEnderecos;

        public EnderecosController()
        {
            _ServiceEnderecos = new ServiceEnderecos();
        }
        public IActionResult Index()
        {
            var listarEndereco = EnderecoVM.ListarTodosEnderecos();
            return View(listarEndereco);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create (EnderecoVM enderecoVM)
        {
            var endereco = new CadEndereco();
            endereco.Id = enderecoVM.id;
            endereco.IdUser = enderecoVM.idUser;
            endereco.Logradouro = enderecoVM.logradouro;
            endereco.Numero = enderecoVM.numero;
            endereco.Complemento = enderecoVM.complemento;
            endereco.Cep = enderecoVM.cep;
            endereco.Bairro = enderecoVM.bairro;
            endereco.Cidade = enderecoVM.cidade;
            endereco.Estado = enderecoVM.estado;

            await _ServiceEnderecos.oRepositoryEnderecos.IncluirAsync(endereco);
            return View(endereco);
        }

        [HttpGet]
        public async Task <IActionResult> Edit (int id)
        {
            var endereco = await _ServiceEnderecos.oRepositoryEnderecos.SelecionarPkAsync(id);
            return View(endereco);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CadEndereco cadEndereco)
        {
            if(ModelState.IsValid)
            {
                var endereco = await _ServiceEnderecos.oRepositoryEnderecos.AlterarAsync(cadEndereco);
                return View(endereco);
            }
            ViewData["MensagemErro"] = "Ocorreu um erro";
            return View();
        }

        [HttpGet]
        public async Task <IActionResult> Delete (int id)
        {
            await _ServiceEnderecos.oRepositoryEnderecos.ExcluirAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details (int id)
        {
            var endereco = EnderecoVM.SelecionarEndereco(id);
            return View(endereco);
        }        
    }
}
