using Projeto_Integrador.Models.Models;

namespace Projeto_Integrador.ViewModel
{
    public class LocalDoacaoVM
    {
        public LocalDoacaoVM()
        {

        }

        #region LocalDoacao
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string rua { get; set; }
        public string num {  get; set; }
        public string comple {  get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public char ativo { get; set; }
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
