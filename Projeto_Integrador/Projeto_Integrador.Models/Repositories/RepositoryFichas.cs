using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Integrador.Models.Models;

namespace Projeto_Integrador.Models.Repositories
{
    public class RepositoryFichas : RepositoryBase<FichaDoacao>
    {
        public RepositoryFichas(bool saveChanges = true) :base(saveChanges)
        {
        }
    }
}
