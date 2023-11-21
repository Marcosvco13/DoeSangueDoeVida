using Projeto_Integrador.Models.Models;

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
    }
}