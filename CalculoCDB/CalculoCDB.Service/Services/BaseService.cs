using CalculoCDB.Domain.Entities;
using CalculoCDB.Domain.Interfaces;
using FluentValidation;

namespace CalculoCDB.Service.Services
{
    public class BaseService : IBaseService
    {
        private readonly IBaseCalculoCdb _baseCalculoCdb;

        public BaseService()
        {
            _baseCalculoCdb = new CalculoCDB.CalculoCdb();
        }

        public CertificadoDepositoBancario ResgatarAplicacao<TValidator>(Investimento investimento) where TValidator : AbstractValidator<Investimento>
        {
            Validate(investimento, Activator.CreateInstance<TValidator>());
            var cdb = _baseCalculoCdb.ResgatarAplicacao(investimento);
            return cdb;
        }

        private static void Validate(Investimento investimento, AbstractValidator<Investimento> validator)
        {
            if (investimento == null)
            {
                Exception exception = new("Dados de investimento não detectado!");
                throw exception;
            }

            validator.ValidateAndThrow(investimento);
        }

    }
}
