using CalculoCDB.Domain.Entities;
using FluentValidation;

namespace CalculoCDB.Service.Validators
{
    public class InvestimentoValidator : AbstractValidator<Investimento>
    {
        public InvestimentoValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Por favor, o código de identificação do investimento.")
                .NotNull().WithMessage("Por favor, o código de identificação do investimento.")
                .Must(IdPositivo)
                .WithMessage("Por favor, insira a quantidade de meses para resgate maior do que 1.");

            bool IdPositivo(int id)
            {
                if (id > 0)
                    return true;
                return false;
            }

            RuleFor(c => c.MesesParaResgate)
                .NotEmpty().WithMessage("Por favor, insira a quantidade de meses para resgate.")
                .NotNull().WithMessage("Por favor, insira a quantidade de meses para resgate.")
                .Must(MesesPositivo)
                .WithMessage("Por favor, insira a quantidade de meses para resgate maior do que 1.");

            bool MesesPositivo(int mesesParaResgate)
            {
                if (mesesParaResgate > 1)
                    return true;
                return false;
            }

            RuleFor(c => c.ValorInicial)
                .NotEmpty().WithMessage("Por favor, insira o valor inicial.")
                .NotNull().WithMessage("Por favor, insira o valor inicial.")
                .Must(ValorMonetarioPositivo)
                .WithMessage("Por favor, insira o valor inicial maior do que zero.");

            bool ValorMonetarioPositivo(double valorInicial)
            {
                if (valorInicial > 0)
                    return true;
                return false;
            }
        }
    }
}
