using Microsoft.AspNetCore.Mvc;
using Projeto_Integrador.Models.Models;
using Projeto_Integrador.Models.Services;
using Projeto_Integrador.ViewModel;

namespace Projeto_Integrador.Controllers
{
    public class DoadorController : Controller
    {
        private ServiceDoador _ServiceDoador;
        public DoadorController(DOACAO_SANGUEContext context)
        {
            _ServiceDoador = new ServiceDoador();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Create(DoadorVM doadorVM)
        {
            var doador = new CadDoador();
            doador.Nome = doadorVM.Nome;
            doador.NomeMae = doadorVM.NomeMae;
            doador.NomePai = doadorVM.NomePai;
            doador.Cpf = doadorVM.Cpf;
            doador.Rg = doadorVM.Rg;
            doador.OrgExp = doadorVM.OrgExp;
            doador.Email = doadorVM.Email;
            doador.Telefone = doadorVM.Telefone;
            doador.Sexo = doadorVM.Sexo;

            var listarCred = new List<Credenciais>();

            var cred = new Credenciais()
            {
                Login = doadorVM.login,
                Senha = doadorVM.senha,
            };

            await _ServiceDoador.oRepositoryDoador.IncluirAsync(doador, cred);
            return View(doadorVM);
        }

    }
}
