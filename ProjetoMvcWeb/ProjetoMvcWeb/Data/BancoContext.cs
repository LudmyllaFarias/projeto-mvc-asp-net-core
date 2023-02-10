using Microsoft.EntityFrameworkCore;
using ProjetoMvcWeb.Models;

namespace ProjetoMvcWeb.Data
{
    public class BancoContext : DbContext
    {

        public DbSet<Contato> contatos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(@"Data Source=C:\Users\ludmylla.farias\Downloads\SQLiteDatabaseBrowserPortable\contato.db");
    }

    //Add-Migration InitalCreate
    // add-migration secondCreate 
    // update-database
}
