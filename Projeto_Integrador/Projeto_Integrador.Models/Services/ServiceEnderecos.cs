using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Integrador.Models.Repositories;

namespace Projeto_Integrador.Models.Services
{
    public class ServiceEnderecos
    {
        public RepositoryEnderecos oRepositoryEnderecos { get; set; }

        public ServiceEnderecos()
        {
            oRepositoryEnderecos = new RepositoryEnderecos();
        }
    }
}
