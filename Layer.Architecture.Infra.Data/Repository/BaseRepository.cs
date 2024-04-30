using AutoglassTest.Domain.Entities;
using AutoglassTest.Domain.Interfaces;
using AutoglassTest.Infra.Data.Context;
using PagedList;
using System.Collections.Generic;
using System.Linq;

namespace AutoglassTest.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly SqliteContext _SqliteContext;

        public BaseRepository(SqliteContext mySqlContext)
        {
            _SqliteContext = mySqlContext;
        }

        public void Insert(TEntity obj)
        {
            _SqliteContext.Set<TEntity>().Add(obj);
            _SqliteContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _SqliteContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _SqliteContext.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            _SqliteContext.Set<TEntity>().Remove(Select(id));
            _SqliteContext.SaveChanges();
        }

        public virtual IList<TEntity> Select() =>
            _SqliteContext.Set<TEntity>().ToList();

        public virtual IList<TEntity> SelectPaged(int pagina, int ItensPorPagina) =>
            _SqliteContext.Set<TEntity>().ToPagedList(pagina, ItensPorPagina).ToList();

        public virtual TEntity Select(int id) =>
            _SqliteContext.Set<TEntity>().Find(id);

    }
}
