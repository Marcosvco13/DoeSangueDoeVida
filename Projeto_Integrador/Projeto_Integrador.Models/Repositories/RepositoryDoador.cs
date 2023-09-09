using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_Integrador.Models.Models;

namespace Projeto_Integrador.Models.Repositories
{
    public class RepositoryDoador : RepositoryBase<CadDoador>
    {
        public RepositoryDoador(bool saveChanges = true) : base(saveChanges) 
        { 
        }
        public async Task IncluirAsync(CadDoador doador, Credenciais credenciais)
        {
            _context.Entry(doador).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            doador.Id = credenciais.IdUsuario;
            _context.Entry(credenciais).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
        }
    }
}
