using NuGet.Configuration;
using Projeto_Integrador.Models.Models;

namespace Projeto_Integrador.ViewModel
{
    public class FichaVM
    {
        public FichaVM() { 
        }

        #region FichaDoacao
        public string idUser { get; set; }
        public string tipoSangue { get; set; }
        public DateTime? ultimaDoacao { get; set; }
        public decimal? peso { get; set; }
        public string sexo { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public string orgExp { get; set; }
        public string profissao { get; set; }
        public string religiao { get; set; }
        public int? fumante { get; set; }
        public string tempFumante { get; set; }
        public DateTime? dataNasc { get; set; }
        public string nomeMae { get; set; }
        public string nomePai { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }

        #endregion

        public static FichaVM SelecionarFicha(string userid)
        {
            var db = new DOACAO_SANGUEContext();
            var ficha = db.FichaDoacao.FirstOrDefault(x => x.IdUser == userid);
            var fichaVM = new FichaVM();

            return new FichaVM()
            {
                idUser = ficha.IdUser,
                nome = ficha.Nome,
                nomeMae = ficha.NomeMae,
                nomePai = ficha.NomePai,
                cpf = ficha.Cpf,
                rg = ficha.Rg,
                orgExp = ficha.OrgExp,
                dataNasc = ficha.DataNasc,
                sexo = ficha.Sexo,
                peso = ficha.Peso,
                tipoSangue = ficha.TipoSangue,
                telefone = ficha.Telefone,
                fumante = ficha.Fumante,
                tempFumante = ficha.TempFumante,
                religiao = ficha.Religiao,
                ultimaDoacao = ficha.UltimaDoacao,
                logradouro = ficha.Logradouro,
                complemento = ficha.Complemento,
                numero = ficha.Numero,
                bairro = ficha.Bairro,
                cidade = ficha.Cidade,
                cep = ficha.Cep,
                estado = ficha.Estado,
            };
        }

        public static List<FichaVM> ListarFicha(string userid)
        {
            using (var db = new DOACAO_SANGUEContext())
            {
                var fichas = db.FichaDoacao.Where(x => x.IdUser == userid).ToList();
                var retorno = new List<FichaVM>();
                foreach (var ficha in fichas)
                {
                    var doador = new FichaVM();

                    doador.idUser = ficha.IdUser;
                    doador.nome = ficha.Nome;
                    doador.nomeMae = ficha.NomeMae;
                    doador.nomePai = ficha.NomePai;
                    doador.cpf = ficha.Cpf;
                    doador.rg = ficha.Rg;
                    doador.orgExp = ficha.OrgExp;
                    doador.dataNasc = ficha.DataNasc;
                    doador.sexo = ficha.Sexo;
                    doador.peso = ficha.Peso;
                    doador.tipoSangue = ficha.TipoSangue;
                    doador.telefone = ficha.Telefone;
                    doador.fumante = ficha.Fumante;
                    doador.tempFumante = ficha.TempFumante;
                    doador.religiao = ficha.Religiao;
                    doador.ultimaDoacao = ficha.UltimaDoacao;
                    doador.logradouro = ficha.Logradouro;
                    doador.complemento = ficha.Complemento;
                    doador.numero = ficha.Numero;
                    doador.bairro = ficha.Bairro;
                    doador.cidade = ficha.Cidade;
                    doador.cep = ficha.Cep;
                    doador.estado = ficha.Estado;

                    retorno.Add(doador);
                }
                return retorno;
            }

        }

    }

}
