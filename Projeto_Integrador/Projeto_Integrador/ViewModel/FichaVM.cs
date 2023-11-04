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
        public int? fumante { get; set; }
        public string sexo { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public string orgExp { get; set; }
        public string profissao { get; set; }
        public string religiao { get; set; }
        public string tempFumante { get; set; }
        public DateTime? dataNasc { get; set; }
        public string nomeMae { get; set; }
        public string nomePai { get; set; }

        #endregion

        public static FichaVM SelecionarFicha(int id)
        {
            var db = new DOACAO_SANGUEContext();
            var ficha = db.FichaDoacao.Find(id);
            var fichaVM = new FichaVM();

            fichaVM.idUser = ficha.IdUser;
            fichaVM.tipoSangue = ficha.TipoSangue;
            fichaVM.ultimaDoacao = ficha.UltimaDoacao;
            fichaVM.peso = ficha.Peso;
            fichaVM.fumante = ficha.Fumante;
            fichaVM.sexo = ficha.Sexo;
            fichaVM.cpf = ficha.Cpf;
            fichaVM.rg = ficha.Rg;
            fichaVM.orgExp = ficha.OrgExp;
            fichaVM.profissao = ficha.Profissao;
            fichaVM.religiao = ficha.Religiao;
            fichaVM.tempFumante = ficha.TempFumante;
            fichaVM.dataNasc = ficha.DataNasc;
            fichaVM.nomeMae = ficha.NomeMae;
            fichaVM.nomePai = ficha.NomePai;

            return fichaVM;
        }

        public static List<FichaVM> ListarTodasFichas()
        {
            var db = new DOACAO_SANGUEContext();
            return(from ficha in db.FichaDoacao
                   select new FichaVM
                   {
                       idUser = ficha.IdUser,
                       tipoSangue = ficha.TipoSangue,
                       ultimaDoacao = ficha.UltimaDoacao,
                       peso = ficha.Peso,
                       fumante = ficha.Fumante,
                       sexo = ficha.Sexo,
                       cpf = ficha.Cpf,
                       rg = ficha.Rg,
                       orgExp = ficha.OrgExp,
                       profissao = ficha.Profissao,
                       religiao = ficha.Religiao,
                       tempFumante = ficha.TempFumante,
                       dataNasc = ficha.DataNasc,
                       nomeMae = ficha.NomeMae,
                       nomePai = ficha.NomePai,
                    }).ToList();
        }

    }

}
