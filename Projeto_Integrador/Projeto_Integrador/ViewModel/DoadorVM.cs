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
        public string EmailLogin { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Religiao { get; set; }
        public string Profissao { get; set; }
        public string Sexo { get; set; }
        #endregion Doador

        #region Credencial
        public int CodCred { get; set; }
        public string login { get; set; }
        public string senha { get; set; }

        public byte[] salt { get; set; }

        #endregion Credencial

        public static DoadorVM SelecionarDoador(int id)
        {
            var db = new DOACAO_SANGUEContext();
            var doador = db.CadDoador.Find(id);
            var credencial = db.Credenciais.FirstOrDefault(x => x.IdUsuario == id);
            var doadorVM = new DoadorVM();
            doadorVM.CodCred = credencial.Id;

            doadorVM.EmailLogin = credencial.Login;
            doadorVM.senha = credencial.Senha;
            doadorVM.Cpf = doador.Cpf.Length < 14 ? doador.Cpf : "";
            doadorVM.Rg = doador.Rg;
            doadorVM.OrgExp = doador.OrgExp;
            doadorVM.Codigo = doador.Id;
            doadorVM.DataNascimento = doador.DataNasc;
            doadorVM.EmailLogin = doador.Email;
            doadorVM.Religiao = doador.Religiao;
            doadorVM.Profissao = doador.Profissao;
            doadorVM.Nome = doador.Nome;
            doadorVM.NomeMae = doador.NomeMae;
            doadorVM.NomePai = doador.NomePai;
            doadorVM.Sexo = doador.Sexo;
            doadorVM.Telefone = doador.Telefone;
            doadorVM.salt = credencial.Salt;
            return doadorVM;
        }
        public static List<DoadorVM> ListarTodosDoadores()
        {
            var db = new DOACAO_SANGUEContext();
            return (from doador in db.CadDoador
                    join credencial in db.Credenciais on doador.Id
                    equals credencial.IdUsuario
                    select new DoadorVM
                    {
                        CodCred = credencial.Id,
                        login = credencial.Login,
                        senha = credencial.Senha,
                        Cpf = doador.Cpf.Length < 14 ? doador.Cpf : "",
                        Rg = doador.Rg,
                        Codigo = doador.Id,
                        OrgExp = doador.OrgExp,
                        DataNascimento = doador.DataNasc,
                        Email = doador.Email,
                        Nome = doador.Nome,
                        NomeMae = doador.NomeMae,
                        NomePai = doador.NomePai,
                        Sexo = doador.Sexo,
                        Telefone = doador.Telefone,
                        Religiao = doador.Religiao,
                        Profissao = doador.Profissao,
                        salt = credencial.Salt
                    }).ToList();
        }
    }
}
