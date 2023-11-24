using Projeto_Integrador.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Integrador.ViewModel
{
    public class GenDoacoesVM
    {

        public GenDoacoesVM()
        {

        }

        public int IdDoa { get; set; }
        public string status { get; set; }
        public string NomeDoador { get; set; }
        public DateTime? DataDisp { get; set; }
        public string NomeLocal { get; set; }
        public int IdStatus { get; set; }
        public int IdData { get; set; }
        public string IdFichaUsuario { get; set; }
        public int IdLocal { get; set; }


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

        public static GenDoacoesVM SelecionarDoacao(int idDoa)
        {
            var db = new DOACAO_SANGUEContext();
            var genDoacao = db.CadDoacao.Find(idDoa);
            var genDoacaoVM = new GenDoacoesVM();

            genDoacaoVM.IdDoa = genDoacao.Id;
            genDoacaoVM.NomeDoador = db.FichaDoacao.Find(genDoacao.IdFichaUsuario)!.Nome;
            genDoacaoVM.DataDisp = db.CadDataHoraDisp.Find(genDoacao.IdData)!.DataDisp;
            genDoacaoVM.status = db.StatusDoacao.Find(genDoacao.IdStatus)!.Descricao;
            genDoacaoVM.NomeLocal = db.CadLocalDoacao.Find(genDoacao.IdLocal)!.Nome;

            return genDoacaoVM;
        }

        public static GenDoacoesVM SelecionarEdita(int idDoa)
        {
            var db = new DOACAO_SANGUEContext();
            var genDoacao = db.CadDoacao.Find(idDoa);
            var genDoacaoVM = new GenDoacoesVM();

            genDoacaoVM.IdDoa = genDoacao.Id;
            genDoacaoVM.NomeDoador = db.FichaDoacao.Find(genDoacao.IdFichaUsuario)!.Nome;
            genDoacaoVM.DataDisp = db.CadDataHoraDisp.Find(genDoacao.IdData)!.DataDisp;
            genDoacaoVM.status = db.StatusDoacao.Find(genDoacao.IdStatus)!.Descricao;
            genDoacaoVM.NomeLocal = db.CadLocalDoacao.Find(genDoacao.IdLocal)!.Nome;
            genDoacaoVM.IdData = genDoacao.IdData;
            genDoacaoVM.IdLocal = genDoacao.IdLocal;
            genDoacaoVM.IdStatus = genDoacao.IdStatus;
            genDoacaoVM.IdFichaUsuario = genDoacao.IdFichaUsuario;

            return genDoacaoVM;
        }

        public static List<GenDoacoesVM> ListarTodasDoacoes()
        {
                
            var db = new DOACAO_SANGUEContext();
                var genDoacao = db.CadDoacao.ToList();
                var retorno = new List<GenDoacoesVM>();
                foreach (var doacao in genDoacao)
                {
                    var doa = new GenDoacoesVM();

                    doa.IdDoa = doacao.Id;
                    doa.status = db.StatusDoacao.Find(doacao.IdStatus)!.Descricao;
                    doa.NomeDoador = db.FichaDoacao.Find(doacao.IdFichaUsuario)!.Nome;
                    doa.DataDisp = db.CadDataHoraDisp.Find(doacao.IdData)!.DataDisp;
                    doa.NomeLocal = db.CadLocalDoacao.Find(doacao.IdLocal)!.Nome;

                    retorno.Add(doa);
                }
                return retorno;
        }

        public static GenDoacoesVM SelecionarFicha(int id)
        {
            var db = new DOACAO_SANGUEContext();
            var ficha = db.CadDoacao.Find(id);
            var genVM = new GenDoacoesVM();
            var estados = db.FichaDoacao.Find(ficha.IdFichaUsuario)!.IdEstado;

            return new GenDoacoesVM()
            {
                idUser = ficha.IdFichaUsuario,
                nome = db.FichaDoacao.Find(ficha.IdFichaUsuario)!.Nome,
                nomeMae = db.FichaDoacao.Find(ficha.IdFichaUsuario)!.NomeMae,
                nomePai = db.FichaDoacao.Find(ficha.IdFichaUsuario)!.NomePai,
                cpf = db.FichaDoacao.Find(ficha.IdFichaUsuario)!.Cpf,
                rg = db.FichaDoacao.Find(ficha.IdFichaUsuario)!.Rg,
                orgExp = db.FichaDoacao.Find(ficha.IdFichaUsuario)!.OrgExp,
                dataNasc = db.FichaDoacao.Find(ficha.IdFichaUsuario)!.DataNasc,
                sexo = db.FichaDoacao.Find(ficha.IdFichaUsuario)!.Sexo,
                peso = db.FichaDoacao.Find(ficha.IdFichaUsuario)!.Peso,
                tipoSangue = db.FichaDoacao.Find(ficha.IdFichaUsuario)!.TipoSangue,
                telefone = db.FichaDoacao.Find(ficha.IdFichaUsuario)!.Telefone,
                fumante = db.FichaDoacao.Find(ficha.IdFichaUsuario)!.Fumante,
                tempFumante = db.FichaDoacao.Find(ficha.IdFichaUsuario)!.TempFumante,
                religiao = db.FichaDoacao.Find(ficha.IdFichaUsuario)!.Religiao,
                ultimaDoacao = db.FichaDoacao.Find(ficha.IdFichaUsuario)!.UltimaDoacao,
                logradouro = db.FichaDoacao.Find(ficha.IdFichaUsuario)!.Logradouro,
                complemento = db.FichaDoacao.Find(ficha.IdFichaUsuario)!.Complemento,
                numero = db.FichaDoacao.Find(ficha.IdFichaUsuario)!.Numero,
                bairro = db.FichaDoacao.Find(ficha.IdFichaUsuario)!.Bairro,
                cidade = db.FichaDoacao.Find(ficha.IdFichaUsuario)!.Cidade,
                cep = db.FichaDoacao.Find(ficha.IdFichaUsuario)!.Cep,
                estado = db.TbEstados.Find(estados)!.NmEstado,
            };
        }
    }
}