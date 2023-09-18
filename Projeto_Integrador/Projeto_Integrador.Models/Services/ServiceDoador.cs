using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Integrador.Models.Repositories;

namespace Projeto_Integrador.Models.Services
{
    public class ServiceDoador
    {
        public RepositoryDoador oRepositoryDoador { get; set; }
        public RepositoryCredenciais oRepositoryCredenciais { get; set; }

        public ServiceDoador()
        {
            oRepositoryDoador = new RepositoryDoador();
            oRepositoryCredenciais = new RepositoryCredenciais();
        }
    }
}
