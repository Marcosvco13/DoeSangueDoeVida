using Projeto_Integrador.Models.Models;

namespace Projeto_Integrador.ViewModel
{
    public class DataVM
    {
        public object Data { get; private set; }
        public object IDLocal { get; private set; }
        public object Disponivel { get; private set; }

        public static DataVM SelecionarData(int id)
        {
            var db = new DOACAO_SANGUEContext();
            var data = db.Data.Find(id);
            var dataVM = new DataVM();
            return new DataVM()
            {
                dataVM.IDLocal = data.ID_LOCAL,
                dataVM.Data = data.Data,
                dataVM.Disponivel = data.Disponivel,
            };
        }

        public static List<DataVM> ListarTodasDatas()
        {
            var db = new DOACAO_SANGUEContext();
            var listaRetorno = new List <DataVM>();
            var listaDatasCadastradas = db.Data.ToList();
            foreach (var item in listaDatasCadastradas)
            {
                var data = new DataVM();
                data.Local = db.Local.FirstOrDefault(x => x.TipData == item.ProCodigoData).TipDescricao;
                data.Data = item.Data;
                data.Disponivel = item.Disponivel;
            }
            return listaRetorno;
        }
    }
}
