using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Integrador.Models.Models;

namespace Projeto_Integrador.Models.Repositories
{
    public class RepositoryCredenciais : RepositoryBase<Credenciais>
    {
        public RepositoryCredenciais(bool saveChanges = true) : base(saveChanges)
        {

        }
    }
}
