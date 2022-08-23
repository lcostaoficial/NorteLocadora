using Locadora.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Locadora.Data
{
    public static class ModelBuilderExtension
    {
        public static void ConfigureModels(this ModelBuilder modelBuilder)
        {
            DefinirDeleteBehaviorRestricParaTodasAsModels(modelBuilder);
            AplicarConfiguracoesDeMapeamento(modelBuilder);
        }      

        private static void DefinirDeleteBehaviorRestricParaTodasAsModels(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        private static void AplicarConfiguracoesDeMapeamento(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
            modelBuilder.ApplyConfiguration(new LocacaoMap());
            modelBuilder.ApplyConfiguration(new MultaMap());
            modelBuilder.ApplyConfiguration(new VeiculoMap());
            modelBuilder.ApplyConfiguration(new AcessorioMap());
            modelBuilder.ApplyConfiguration(new ManutencaoMap());
            modelBuilder.ApplyConfiguration(new NotificacaoMap());
        }
    }
}