﻿using Locadora.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Locadora.Data
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions options) : base(options) {}

        public DbSet<FotoDeGaragem> FotosDeGaragem { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
        public DbSet<Manutencao> Manutencoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string)))
            {
                property.SetColumnType("varchar(200)");
            }

            modelBuilder.ConfigureModels();
        }
    }
}