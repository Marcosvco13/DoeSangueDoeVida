using Projeto_Integrador.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Integrador.Models.Services
{
    public class ServiceFichas
    {
        public RepositoryFichas oRepositoryFichas { get; set; }
        public RepositoryEstados oRepositoryEstados { get; set; }

        public ServiceFichas()
        {
            oRepositoryFichas = new RepositoryFichas();
            oRepositoryEstados = new RepositoryEstados();
        }
    }
}
