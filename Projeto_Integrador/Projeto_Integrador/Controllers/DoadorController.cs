using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
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
            // ... Resto do código ...

            // Gerar um salt aleatório para a senha
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Hash da senha usando bcrypt
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: doadorVM.senha,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            // Agora, você pode salvar 'hashedPassword' e 'salt' no banco de dados
            // Certifique-se de ajustar seu modelo de banco de dados para incluir essas informações

            var doador = new CadDoador();
            doador.Nome = doadorVM.Nome;
            doador.NomeMae = doadorVM.NomeMae;
            doador.NomePai = doadorVM.NomePai;
            doador.DataNasc = (DateTime)doadorVM.DataNascimento;
            doador.Cpf = doadorVM.Cpf;
            doador.Rg = doadorVM.Rg;
            doador.OrgExp = doadorVM.OrgExp;
            doador.Email = doadorVM.EmailLogin;
            doador.Telefone = doadorVM.Telefone;
            doador.Sexo = doadorVM.Sexo;
            doador.Religiao = doadorVM.Religiao;
            doador.Profissao = doadorVM.Profissao;

            var credencial = new Credenciais()
            {
                Login = doadorVM.EmailLogin,
                Senha = hashedPassword, // Salve o hash da senha
                Salt = Encoding.ASCII.GetBytes(Convert.ToBase64String(salt)) // Salve o salt
            };

            await _ServiceDoador.oRepositoryDoador.IncluirAsync(doador, credencial);

            return View(doadorVM);
        }

    }
}
