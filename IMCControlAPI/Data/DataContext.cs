
using IMCControlAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace IMCControlAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options){

        }

        public DbSet<IMCOption> IMCOptions {get;set;}
        public DbSet<IMCUser> IMCUsers {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IMCOption>().HasData(
                new IMCOption { Id=1, Description = "Peso inferior al normal", Min=0, Max=18.4, Color="#DAD82A"},
                new IMCOption { Id=2,Description = "Peso normal", Min=18.5, Max=24.9, Color="#24BD21"},
                new IMCOption { Id=3,Description = "Peso superior al normal", Min=25.0, Max=29.9, Color="#CB740B"},
                new IMCOption { Id=4,Description = "Obesidad", Min=30.0, Max=99.0, Color="#D50C0C"}
            );
        }
    }
}