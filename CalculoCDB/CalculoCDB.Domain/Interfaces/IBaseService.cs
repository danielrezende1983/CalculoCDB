using CalculoCDB.Domain.Entities;
using FluentValidation;

namespace CalculoCDB.Domain.Interfaces
{
    public interface IBaseService
    {
        CertificadoDepositoBancario ResgatarAplicacao<TValidator>(Investimento investimento) where TValidator : AbstractValidator<Investimento>;
    }
}
