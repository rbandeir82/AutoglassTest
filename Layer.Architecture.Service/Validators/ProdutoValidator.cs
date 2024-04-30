using FluentValidation;
using AutoglassTest.Domain.Entities;

namespace AutoglassTest.Service.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(c => c.DataValidade)
                .GreaterThanOrEqualTo(c => c.DataFabricacao).WithMessage("Data de Fabricação não pode ser maior ou igual a data de validade.");
                //.NotEmpty().WithMessage("Informe a Data de Fabricação.")
                //.NotNull().WithMessage("Informe a Data de Fabricação.");

            RuleFor(c => c.DataValidade)
                .NotEmpty().WithMessage("Informe a Data de Validade.")
                .NotNull().WithMessage("Informe a Data de Validade.");

            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("Informe a descrição do Produto.")
                .NotNull().WithMessage("Informe a descrição do Produto.");
        }
    }
}
