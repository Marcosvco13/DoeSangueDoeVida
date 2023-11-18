using Projeto_Integrador.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Integrador.Models.Services
{
    public class ServiceGenDoacoes
    {
        public RepositoryDoacao oRepositoryDoaco { get; set; }
        public RepositoryLocais oRepositoryLocais { get; set; }
        public RepositoryFichas oRepositoryFichas { get; set; }
        public RepositoryStatus oRepositoryStatus { get; set; }
        public RepositoryDatas oRepositoryDatas { get; set; }

        public ServiceGenDoacoes()
        {
            oRepositoryDoaco = new RepositoryDoacao();
            oRepositoryFichas = new RepositoryFichas();
            oRepositoryLocais = new RepositoryLocais();
            oRepositoryStatus = new RepositoryStatus();
            oRepositoryDatas = new RepositoryDatas();
        }
    }
}