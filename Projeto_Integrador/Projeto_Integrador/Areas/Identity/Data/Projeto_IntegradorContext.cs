using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projeto_Integrador.Areas.Identity.Data;

namespace Projeto_Integrador.Data;

public class Projeto_IntegradorContext : IdentityDbContext<UsuarioModel>
{
    public Projeto_IntegradorContext(DbContextOptions<Projeto_IntegradorContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

=> optionsBuilder.UseSqlServer("data source=.\\SQLEXPRESS;Initial Catalog=DOACAO_SANGUE;User Id=sa;Password=22102001da;TrustserverCertificate=True");


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
