using System.ComponentModel.DataAnnotations;
using NuGet.Configuration;
using Projeto_Integrador.Models;
using Projeto_Integrador.Models.Models;

namespace Projeto_Integrador.ViewModel
{
    public class FichaVM
    {
        public FichaVM() { 
        }

        #region FichaDoacao
        [Display(Name = "Cod. Usuário")]
        public string idUser { get; set; }
        [Display(Name = "Tipo Sanguíneo")]
        public string tipoSangue { get; set; }
        [Display(Name = "Última Doação")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ultimaDoacao { get; set; }
        [Display(Name = "Peso")]
        public decimal? peso { get; set; }
        [Display(Name = "Gênero")]
        public int? sexo { get; set; }
        [Display(Name = "CPF")]
        public string cpf { get; set; }
        [Display(Name = "RG")]
        public string rg { get; set; }
        [Display(Name = "Orgão Expeditor")]
        public string orgExp { get; set; }
        [Display(Name = "Profissão")]
        public string profissao { get; set; }
        [Display(Name = "Religião")]
        public string religiao { get; set; }
        [Display(Name = "Fumante?")]
        public int? fumante { get; set; }
        [Display(Name = "Quanto tempo?")]
        public int? tempFumante { get; set; }
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? dataNasc { get; set; }
        [Display(Name = "Nome da Mãe")]
        public string nomeMae { get; set; }
        [Display(Name = "Nome do Pai")]
        public string nomePai { get; set; }
        [Display(Name = "Logradouro")]
        public string logradouro { get; set; }
        [Display(Name = "Número")]
        public string numero { get; set; }
        [Display(Name = "Complemento")]
        public string complemento { get; set; }
        [Display(Name = "CEP")]
        public string cep { get; set; }
        [Display(Name = "Bairro")]
        public string bairro { get; set; }
        [Display(Name = "Cidade")]
        public string cidade { get; set; }
        [Display(Name = "Estado")]
        public string estado { get; set; }
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Display(Name = "Telefone")]
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
                estado = db.TbEstados.Find(ficha.IdEstado)!.NmEstado,
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
                    doador.cpf = ficha.Cpf;
                    doador.dataNasc = ficha.DataNasc;
                    doador.sexo = ficha.Sexo;
                    doador.tipoSangue = ficha.TipoSangue;

                    retorno.Add(doador);
                }
                return retorno;
            }

        }

    }

}
