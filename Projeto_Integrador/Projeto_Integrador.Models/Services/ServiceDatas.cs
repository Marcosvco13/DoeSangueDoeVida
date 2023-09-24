using Projeto_Integrador.Models.Repositories;

namespace Projeto_Integrador.Controllers
{
    public class ServiceDatas
    {
        public RepositoryDatas oRepositoryDatas { get; set; }

        public ServiceDatas() 
        {
            oRepositoryDatas = new RepositoryDatas();
        }
    }
}