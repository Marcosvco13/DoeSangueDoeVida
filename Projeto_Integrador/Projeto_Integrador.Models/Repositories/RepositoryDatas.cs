using Projeto_Integrador.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Integrador.Models.Repositories
{
    public class RepositoryDatas : RepositoryBase<CadDataHoraDisp>
    {
        public RepositoryDatas(bool saveChanges = true) : base(saveChanges) 
        { 
        }
    }
}
