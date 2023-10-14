using Projeto_Integrador.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Integrador.Models.Repositories
{
    public class RepositoryEnderecos : RepositoryBase<CadEndereco>
    {
        public RepositoryEnderecos(bool saveChanges = true) :base(saveChanges) 
        {
        }
    }
}
