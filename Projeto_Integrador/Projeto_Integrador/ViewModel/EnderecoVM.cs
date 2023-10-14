using Projeto_Integrador.Models.Models;

namespace Projeto_Integrador.ViewModel
{
    public class EnderecoVM
    {
        public EnderecoVM() 
        { 
        }

        #region CadEndereco
        public int id { get; set; }
        public string idUser { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string cep { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        #endregion

        public static EnderecoVM SelecionarEndereco(int id)
        {
            var db = new DOACAO_SANGUEContext();
            var endereco = db.CadEndereco.Find(id);
            var enderecoVM = new EnderecoVM();

            enderecoVM.id = endereco.Id;
            enderecoVM.idUser = endereco.IdUser;
            enderecoVM.logradouro = endereco.Logradouro;
            enderecoVM.numero = endereco.Numero;
            enderecoVM.complemento = endereco.Complemento;
            enderecoVM.cep = endereco.Cep;
            enderecoVM.bairro = endereco.Bairro;
            enderecoVM.cidade = endereco.Cidade;
            enderecoVM.estado = endereco.Estado;

            return enderecoVM;
        }

        public static List<EnderecoVM> ListarTodosEnderecos()
        {
            var db = new DOACAO_SANGUEContext();
            return(from endereco in db.CadEndereco
                    select new EnderecoVM
                    {
                        id = endereco.Id,
                        idUser = endereco.IdUser,
                        logradouro = endereco.Logradouro,
                        numero = endereco.Numero,
                        complemento = endereco.Complemento,
                        cep = endereco.Cep,
                        bairro = endereco.Bairro,
                        cidade = endereco.Cidade,
                        estado = endereco.Estado,
                
                    }).ToList();                    
                    
        }
    }
}
