using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Integrador.Models.Models;

namespace Projeto_Integrador.Models.Repositories
{
    public class RepositoryLocais : RepositoryBase<CadLocalDoacao>
    {
        public RepositoryLocais(bool saveChanges = true) : base(saveChanges) 
        { 
        }
    }
}
