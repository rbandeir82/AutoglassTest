using FluentValidation;
using AutoglassTest.Domain.Entities;
using System.Collections.Generic;

namespace AutoglassTest.Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        TOutputModel Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class;

        void Delete(int id);

       
        IEnumerable<TOutputModel> Get<TOutputModel>() where TOutputModel : class;

        IEnumerable<TOutputModel> GetPaged<TOutputModel>(int pagina, int ItensPorPagina) where TOutputModel : class;

        TOutputModel GetById<TOutputModel>(int id) where TOutputModel : class;

        TOutputModel Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class;
    }
}
