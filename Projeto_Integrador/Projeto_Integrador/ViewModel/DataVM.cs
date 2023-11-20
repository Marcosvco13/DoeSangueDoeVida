using Projeto_Integrador.Models.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Projeto_Integrador.ViewModel
{
    public class DataVM
    {
        [Display (Name = "Codigo Data")]
        public int id { get; set; }

        [Display (Name = "Data")]
        public DateTime Data { get; set; }

        [Display(Name = "Local")]
        public int IDLocal { get; set; }

        [Display(Name = "Data Disponivel?")]
        public int Disponivel { get; set; }

        [Display(Name = "Local")]
        public string nomeLocal {  get; set; }

        public static DataVM SelecionarData(int id)
        {
            var db = new DOACAO_SANGUEContext();
            return (from caddata in db.CadDataHoraDisp
                    join local in db.CadLocalDoacao on caddata.IdLocal
                    equals local.Id
                    select new DataVM
                    {
                        id = caddata.Id,
                        Data = caddata.DataDisp,
                        IDLocal = caddata.IdLocal,
                        Disponivel = caddata.Disp,
                        nomeLocal = local.Nome,
                    }).FirstOrDefault();
        }

        public static List<DataVM> ListarTodasDatas()
        {
            var db = new DOACAO_SANGUEContext();
            return (from caddata in  db.CadDataHoraDisp
                    join local in db.CadLocalDoacao on caddata.IdLocal 
                    equals local.Id 
                    select new DataVM
                    {
                        id = caddata.Id,
                        Data = caddata.DataDisp,
                        IDLocal = caddata.IdLocal,
                        Disponivel = caddata.Disp,
                        nomeLocal = local.Nome,
                    }).ToList();
        }
    }
}
