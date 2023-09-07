using TestePratico.Domain.Entities;
using TestePratico.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Design;

namespace TestePratico.Infra.Data.Context
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options){ }

        public DbSet<Usuario> Usuario { get; set; }

        //ESSA FUNÇÃO DEVE SER DELETADA EM PRODUÇÃO, POIS LIBERA MENSAGENS DE ERROS QUE SOMENTE O DESENVOLVEDOR DEVE TER ACESSO
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);
            
            modelBuilder.Entity<Vaga>(new VagaMap().Configure);
            
            modelBuilder.Entity<Empresa>(new EmpresaMap().Configure);
            
            modelBuilder.Entity<Candidatura>(new CandidaturaMap().Configure);

            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataDbContext).Assembly); 
            
            //Tratamento de deleção de tabelas referenciadas em outra
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                //1- Ao deletar uma entidade que seja referenciada em outra ele seta ela como null, evitando deleção em cascades

                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
                //2- Outro possibilidade é permitir que ao deletar uma entidade que seja referenciada em outra ele delete
                //ela em cascata

                //if (relationship.DeclaringEntityType.Name.Contains(".Menu") || relationship.DeclaringEntityType.Name.Contains(".SubMenu"))
                //{
                //    relationship.DeleteBehavior = DeleteBehavior.Cascade;
                //}
            }


            base.OnModelCreating(modelBuilder);
        }

        
    }
    
}
