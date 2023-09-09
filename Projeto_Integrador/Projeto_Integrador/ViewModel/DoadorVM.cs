using System.Globalization;
using System.Net.Mail;
using Projeto_Integrador.Models.Models;

namespace Projeto_Integrador.ViewModel
{
    public class DoadorVM
    {
        public DoadorVM() 
        {
        }

        #region Doador
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string OrgExp { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }

        public string Sexo { get; set; }
        #endregion Doador
        #region Credencial
        public int CodCred { get; set; }
        public string login { get; set; }
        public string senha { get; set; }

        #endregion Credencial

        public static DoadorVM SelecionarDoador(int id)
        {
            var db = new DOACAO_SANGUEContext();
            var doador = db.CadDoador.Find(id);
            var credDoador = db.Credenciais.FirstOrDefault(x => x.IdUsuario == id);
            var doadorVM = new DoadorVM();
            doadorVM.CodCred = credDoador.Id;
            doadorVM.login = credDoador.Login;
            doadorVM.senha = credDoador.Senha;
            doadorVM.Cpf = doador.Cpf.Length < 14 ? doador.Cpf : "";
            doadorVM.Rg = doador.Rg;
            doadorVM.OrgExp = doador.OrgExp;
            doadorVM.Codigo = doador.Id;
            doadorVM.DataNascimento = doador.DataNasc;
            doadorVM.Email = doador.Email;
            doadorVM.Nome = doador.Nome;
            doadorVM.NomeMae = doador.NomeMae;
            doadorVM.NomePai = doador.NomePai;
            doadorVM.Sexo = doador.Sexo;
            doadorVM.Telefone = doador.Telefone;
            return doadorVM;
        }
        public static List<DoadorVM> ListarTodosDoadores()
        {
            var db = new DOACAO_SANGUEContext();
            return (from doador in db.CadDoador
                    join cred in db.Credenciais on doador.Id
                    equals cred.IdUsuario
                    select new DoadorVM
                    {
                        CodCred = cred.Id,
                        login = cred.Login,
                        senha = cred.Senha,
                        Cpf = doador.Cpf.Length < 14 ? doador.Cpf : "",
                        Rg = doador.Rg,
                        OrgExp = doador.OrgExp,
                        Codigo = doador.Id,
                        DataNascimento = doador.DataNasc,
                        Email = doador.Email,
                        Nome = doador.Nome,
                        NomeMae = doador.NomeMae,
                        NomePai = doador.NomePai,
                        Sexo = doador.Sexo,
                        Telefone = doador.Telefone
                    }).ToList();
        }
    }
}
