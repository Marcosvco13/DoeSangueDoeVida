using System.ComponentModel.DataAnnotations;
using Projeto_Integrador.Models.Models;

namespace Projeto_Integrador.ViewModel
{
    public class DoacaoVM
    {
        [Display(Name = "Código Doação")]
        public int IdDoa { get; set; }
        [Display(Name = "Status")]
        public string? status { get; set; }
        [Display(Name = "Nome")]
        public string? NomeDoador { get; set; }
        [Display(Name = "Data da Doação")]
        public DateTime? DataDisp { get; set; }
        [Display(Name = "Local")]
        public string? NomeLocal { get; set; }

        public DoacaoVM()
        {

        }

        public static List<DoacaoVM> ListarDoacao(string userid)
        {
            using (var db = new DOACAO_SANGUEContext())
            {
                var doacoes = db.CadDoacao.Where(x => x.IdFichaUsuario == userid).ToList();
                var retorno = new List<DoacaoVM>();
                foreach (var doacao in doacoes)
                {
                    var doa = new DoacaoVM();

                    doa.IdDoa = doacao.Id;
                    doa.NomeDoador = db.FichaDoacao.Find(doacao.IdFichaUsuario)!.Nome;
                    doa.DataDisp = db.CadDataHoraDisp.Find(doacao.IdData)!.DataDisp;
                    doa.status = db.StatusDoacao.Find(doacao.IdStatus)!.Descricao;
                    doa.NomeLocal = db.CadLocalDoacao.Find(doacao.IdLocal)!.Nome;
                    
                    retorno.Add(doa);
                }
                return retorno;
            }
        }

        public static DoacaoVM SelecionaDoacao(string userid)
        {
            var db = new DOACAO_SANGUEContext();
            var doacao = db.CadDoacao.FirstOrDefault(x => x.IdFichaUsuario == userid);

            return new DoacaoVM()
            {
                IdDoa = doacao.Id,
                NomeDoador = db.FichaDoacao.Find(doacao.IdFichaUsuario)!.Nome,
                DataDisp = db.CadDataHoraDisp.Find(doacao.IdData)!.DataDisp,
                status = db.StatusDoacao.Find(doacao.IdStatus)!.Descricao,
                NomeLocal = db.CadLocalDoacao.Find(doacao.IdLocal)!.Nome,
            };
        }
    }
}
