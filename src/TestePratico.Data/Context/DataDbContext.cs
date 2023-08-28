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
            //Força o tamanho especifico para colunas mão mapeadas
            //foreach (var property in modelBuilder.Model.GetEntityTypes()
            //    .SelectMany(e => e.GetProperties()
            //        .Where(p => p.ClrType == typeof(string))))
            //    property.Relational().ColumnType = "varchar(100)";
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);
            
            modelBuilder.Entity<Vaga>(new VagaMap().Configure);
            
            modelBuilder.Entity<Empresa>(new EmpresaMap().Configure);
            
            modelBuilder.Entity<Candidatura>(new CandidaturaMap().Configure);

            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataDbContext).Assembly); 
            //Desabilita todos os cascades das tabelas
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
                //if (relationship.DeclaringEntityType.Name.Contains(".Menu") || relationship.DeclaringEntityType.Name.Contains(".SubMenu"))
                //{
                //    relationship.DeleteBehavior = DeleteBehavior.Cascade;
                //}
            }


            base.OnModelCreating(modelBuilder);
        }

        
    }
    
}
