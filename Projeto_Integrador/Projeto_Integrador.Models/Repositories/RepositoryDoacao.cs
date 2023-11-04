using Projeto_Integrador.Models.Models;

namespace Projeto_Integrador.Models.Repositories
{
    public class RepositoryDoacao : RepositoryBase<CadDoacao>
    {
        public RepositoryDoacao(bool saveChanges = true) : base(saveChanges)
        {
        }
    }
}
