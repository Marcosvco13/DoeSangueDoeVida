using Projeto_Integrador.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Integrador.ViewModel
{
    public class LocalDoacaoVM
    {
        public LocalDoacaoVM()
        {

        }

        #region LocalDoacao
        [Display(Name = "Código Local")]
        public int id { get; set; }
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Display(Name = "E-mail")]
        public string email { get; set; }
        [Display(Name = "Telefone")]
        public string telefone { get; set; }
        [Display(Name = "Rua")]
        public string rua { get; set; }
        [Display(Name = "Número")]
        public string num {  get; set; }
        [Display(Name = "Complemento")]
        public string comple {  get; set; }
        [Display(Name = "CEP")]
        public string cep { get; set; }
        [Display(Name = "Bairro")]
        public string bairro { get; set; }
        [Display(Name = "Cidade")]
        public string cidade { get; set; }
        [Display(Name = "Estado")]
        public string estado { get; set; }
        [Display(Name = "Local Ativo?")]
        public int ativo { get; set; }
        #endregion

        public static LocalDoacaoVM SelecionarLocal(int id)
        {
            var db = new DOACAO_SANGUEContext();
            var local = db.CadLocalDoacao.Find(id);
            var localVM = new LocalDoacaoVM();

            localVM.id = local.Id;
            localVM.nome = local.Nome;
            localVM.email = local.Email;
            localVM.telefone = local.Telefone;
            localVM.rua = local.Logradouro;
            localVM.num = local.Numero;
            localVM.comple = local.Complemento;
            localVM.cep = local.Cep;
            localVM.bairro = local.Bairro;
            localVM.cidade = local.Cidade;
            localVM.estado = local.Estado;
            localVM.ativo = local.Ativo; 

            return localVM;
        }

        public static List<LocalDoacaoVM> ListarTodosLocais()
        {
            var db = new DOACAO_SANGUEContext();
            return (from local in db.CadLocalDoacao
                    select new LocalDoacaoVM
                    {
                        id = local.Id,
                        nome = local.Nome,
                        email = local.Email,
                        telefone = local.Telefone,
                        rua = local.Logradouro,
                        num = local.Numero,
                        bairro = local.Bairro,
                        cidade = local.Cidade,
                        estado = local.Estado,
                        ativo = local.Ativo,
                        cep = local.Cep,
                        comple = local.Complemento,
                    }).ToList();
        }
    }
}
