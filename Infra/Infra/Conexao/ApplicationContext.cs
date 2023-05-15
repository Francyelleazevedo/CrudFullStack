using CadastroCliente.Classes;
using Microsoft.EntityFrameworkCore;
using Infra.Map;
namespace Infra.Conexao
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(new ClienteMap().Configure);
        }
    }
}
