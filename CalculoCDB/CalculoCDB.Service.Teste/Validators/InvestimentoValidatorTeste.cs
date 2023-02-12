using CalculoCDB.Domain.Entities;
using CalculoCDB.Service.Validators;
using FluentValidation;

namespace CalculoCDB.Service.Teste.Validators
{
    public class InvestimentoValidatorTeste
    {
        public InvestimentoValidatorTeste()
        {
        }

        [SetUp]
        public void Setup()
        {
            // Method intentionally left empty.
        }

        private static string Validate(Investimento investimento)
        {
            try
            {
                AbstractValidator<Investimento> validator = Activator.CreateInstance<InvestimentoValidator>();
                validator.ValidateAndThrow(investimento);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Test]
        public void TesteCamposConsistentes()
        {
            Investimento investimento = new()
            {
                Id = 1,
                MesesParaResgate = 10,
                ValorInicial = 1000
            };

            string mensagem = Validate(investimento);

            Assert.That(mensagem, Is.EqualTo(string.Empty));
        }

        [Test]
        public void TesteIdZero()
        {
            Investimento investimento = new()
            {
                Id = 0,
                MesesParaResgate = 10,
                ValorInicial = 1000
            };

            string mensagem = Validate(investimento);

            Assert.That(mensagem, Is.Not.EqualTo(string.Empty));
        }

        [Test]
        public void TesteMesesParaResgateZero()
        {
            Investimento investimento = new()
            {
                Id = 1,
                MesesParaResgate = 0,
                ValorInicial = 1000
            };

            string mensagem = Validate(investimento);

            Assert.That(mensagem, Is.Not.EqualTo(string.Empty));
        }

        [Test]
        public void TesteMesesParaResgateUm()
        {
            Investimento investimento = new()
            {
                Id = 1,
                MesesParaResgate = 1,
                ValorInicial = 1000
            };

            string mensagem = Validate(investimento);

            Assert.That(mensagem, Is.Not.EqualTo(string.Empty));
        }

        [Test]
        public void TesteValorInicialZero()
        {
            Investimento investimento = new()
            {
                Id = 1,
                MesesParaResgate = 10,
                ValorInicial = 0
            };

            string mensagem = Validate(investimento);

            Assert.That(mensagem, Is.Not.EqualTo(string.Empty));
        }
    }
}
