using api.Lista.PRO.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace api.Lista.PRO.Context
{
    public class ContextData : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=ListaPro;Integrated Security=True;Trust server certificate=true");
        }

        public DbSet<Condominio>Condominios { get; set; }
        public DbSet<Preventiva>Preventivas { get; set; }
        public DbSet<Usuario>Usuarios { get; set; }
        public DbSet<Equipamento>Equipamentos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}
