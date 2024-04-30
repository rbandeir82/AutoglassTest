using AutoglassTest.Domain.Entities;
using AutoglassTest.Domain.Interfaces;
using AutoglassTest.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace AutoglassTest.Infra.Data.Repository
{
    public class ProdutoRepository<TEntity> : BaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly SqliteContext _SqliteContext;

        public ProdutoRepository(SqliteContext mySqlContext) : base(mySqlContext)
        {
            _SqliteContext = mySqlContext;
        }


        public override IList<TEntity> Select()
        {
            return _SqliteContext.Set<TEntity>().Include("Fornecedor").ToList();
        }

        public override IList<TEntity> SelectPaged(int pagina, int ItensPorPagina)
        {
            return _SqliteContext.Set<TEntity>().Include("Fornecedor").OrderBy(p => p.Id).ToPagedList(pagina, ItensPorPagina).ToList();
        }

        public override TEntity Select(int id) =>
            _SqliteContext.Set<TEntity>().Include("Fornecedor").FirstOrDefault(c => c.Id == id);

        public override void Delete(int id)
        {
            //_SqliteContext.Set<TEntity>().Update(((Produto)Select(id)).Situacao = "I");

            var obj = Select(id);

            _SqliteContext.Entry(obj).Property("Situacao").CurrentValue = char.Parse("I");

            _SqliteContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _SqliteContext.SaveChanges();
            
        }

    }
}
