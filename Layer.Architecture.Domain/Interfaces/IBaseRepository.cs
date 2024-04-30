using AutoglassTest.Domain.Entities;
using System.Collections.Generic;

namespace AutoglassTest.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity obj);

        void Update(TEntity obj);

        void Delete(int id);

        IList<TEntity> Select();

        IList<TEntity> SelectPaged(int pagina, int ItensPorPagina);

        TEntity Select(int id);
    }
}
