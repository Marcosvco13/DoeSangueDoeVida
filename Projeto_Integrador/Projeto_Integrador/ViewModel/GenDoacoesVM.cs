using Projeto_Integrador.Models.Models;

namespace Projeto_Integrador.ViewModel
{
    public class GenDoacoesVM
    {

        public GenDoacoesVM()
        {

        }

        public int IdDoa { get; set; }
        public int status { get; set; }
        public string NomeDoador { get; set; }
        public int DataDisp { get; set; }
        public int NomeLocal { get; set; }


        public string StatusDescricao
        {
            get
            {
                if (status == 1)
                {
                    return "Pendente";
                }
                else if (status == 2)
                {
                    return "Efetuado";
                }
                else if (status == 3)
                {
                    return "Cancelado";
                }
                else
                {
                    return "Status Desconhecido";
                }
            }
        }

        public static GenDoacoesVM SelecionarDoacao(int idDoa)
        {
            var db = new DOACAO_SANGUEContext();
            var genDoacao = db.CadDoacao.Find(idDoa);
            var genDoacaoVM = new GenDoacoesVM();

            genDoacaoVM.IdDoa = genDoacao.Id;
            genDoacaoVM.NomeDoador = genDoacao.IdFichaUsuario;
            genDoacaoVM.DataDisp = genDoacao.IdData;
            genDoacaoVM.status = genDoacao.IdStatus;
            genDoacaoVM.NomeLocal = genDoacao.IdLocal;

            return genDoacaoVM;
        }

        public static List<GenDoacoesVM> ListarTodasDoacoes()
        {
            var db = new DOACAO_SANGUEContext();
            return (from genDoacao in db.CadDoacao
                    select new GenDoacoesVM
                    {
                        IdDoa = genDoacao.Id,
                        status = genDoacao.IdStatus,
                        NomeDoador = genDoacao.IdFichaUsuario,
                        DataDisp = genDoacao.IdData,
                        NomeLocal = genDoacao.IdLocal,
                    }).ToList();
        }
    }
}