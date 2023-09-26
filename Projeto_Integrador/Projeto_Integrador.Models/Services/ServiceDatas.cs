using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Integrador.Models.Repositories;

namespace Projeto_Integrador.Controllers
{
    public class ServiceDatas
    {
        public RepositoryDatas oRepositoryDatas { get; set; }

        public RepositoryLocais oRepositoryLocais { get; set; }

        public ServiceDatas() 
        {
            oRepositoryDatas = new RepositoryDatas();

            oRepositoryLocais = new RepositoryLocais();
        }
    }
}