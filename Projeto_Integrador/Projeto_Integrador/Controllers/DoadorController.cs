using Microsoft.AspNetCore.Mvc;
using Projeto_Integrador.Models.Models;
using Projeto_Integrador.Models.Services;
using Projeto_Integrador.ViewModel;

namespace Projeto_Integrador.Controllers
{
    public class DoadorController : Controller
    {
        private ServiceDoador _ServiceDoador;
        public DoadorController()
        {
            _ServiceDoador = new ServiceDoador();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DoadorVM doadorVM)
        {
            var doador = new CadDoador();
            doador.Nome = doadorVM.Nome;
            doador.NomeMae = doadorVM.NomeMae;
            doador.NomePai = doadorVM.NomePai;
            doador.DataNasc = (DateTime)doadorVM.DataNascimento;
            doador.Cpf = doadorVM.Cpf;
            doador.Rg = doadorVM.Rg;
            doador.OrgExp = doadorVM.OrgExp;
            doador.Email = doadorVM.Email;
            doador.Telefone = doadorVM.Telefone;
            doador.Sexo = doadorVM.Sexo;
            doador.Religiao = doadorVM.Religiao;
            doador.Profissao = doadorVM.Profissao;

            var listarCred = new List<Credenciais>();

            var credencial = new Credenciais()
            {
                Login = doadorVM.login,
                Senha = doadorVM.senha,
                IdUsuario = doadorVM.Codigo,
            };

            await _ServiceDoador.oRepositoryDoador.IncluirAsync(doador, credencial);

            return View(doadorVM);
        }

    }
}
