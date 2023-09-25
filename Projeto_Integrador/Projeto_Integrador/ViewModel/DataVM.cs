using Projeto_Integrador.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Projeto_Integrador.ViewModel
{
    public class DataVM
    {
        public DateTime Data { get; set; }
        public int IDLocal { get; set; }
        public int Disponivel { get; set; }

        public static DataVM SelecionarData(int id)
        {
            var db = new DOACAO_SANGUEContext();
            var data = db.Data.Find(id);
            var dataVM = new DataVM();
            return new DataVM()
            {
                dataVM.IDLocal = data.IdLocal,
                dataVM.Data = data.Date,
                dataVM.Disponivel = data.Disp,
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
                data.IDLocal = db.Local.FirstOrDefault(x => x.TipData == item.ProCodigoData).TipDescricao;
                data.Data = item.Data;
                data.Disponivel = item.Disponivel;
            }
            return listaRetorno;
        }
    }
}
