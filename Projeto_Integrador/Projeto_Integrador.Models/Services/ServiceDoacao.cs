using Projeto_Integrador.Models.Repositories;

namespace Projeto_Integrador.Models.Services
{
    public class ServiceDoacao
    {
        public RepositoryDoacao oRepositoryDoaco { get; set; }
        public RepositoryLocais oRepositoryLocais { get; set; }
        public RepositoryFichas oRepositoryFichas { get; set; }
        public RepositoryStatus oRepositoryStatus { get; set; }

        public ServiceDoacao()
        {
            oRepositoryDoaco = new RepositoryDoacao();
            oRepositoryFichas = new RepositoryFichas();
            oRepositoryLocais = new RepositoryLocais();
            oRepositoryStatus = new RepositoryStatus();
        }
    }
}
