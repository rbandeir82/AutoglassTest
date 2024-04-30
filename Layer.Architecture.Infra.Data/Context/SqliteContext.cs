using AutoglassTest.Domain.Entities;
using AutoglassTest.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AutoglassTest.Infra.Data.Context
{
    public class SqliteContext : DbContext
    {
        public SqliteContext(DbContextOptions<SqliteContext> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>(new ProdutoMap().Configure);
            modelBuilder.Entity<Fornecedor>(new FornecedorMap().Configure);
        }
    }
}
