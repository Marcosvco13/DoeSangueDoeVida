using Projeto_Integrador.Models.Models;

namespace Projeto_Integrador.Models.Repositories
{
    public class RepositoryStatus : RepositoryBase<StatusDoacao>
    {
        public RepositoryStatus(bool saveChanges = true) : base(saveChanges)
        {
        }
    }
}
