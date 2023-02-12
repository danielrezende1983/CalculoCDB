using CalculoCDB.Domain.Entities;
using CalculoCDB.Domain.Interfaces;
using CalculoCDB.Service.CalculoCDB;

namespace CalculoCDB.Service.Teste.CalculoCDB
{
    public class CalculoCdbTeste
    {
        private readonly IBaseCalculoCdb _baseCalculoCdb;

        public CalculoCdbTeste()
        {
            _baseCalculoCdb = new CalculoCdb();
        }

        [SetUp]
        public void Setup()
        {
            // Method intentionally left empty.
        }

        [Test]
        public void TesteResgatarAplicacao()
        {
            Investimento investimento = new()
            {
                Id = 1,
                MesesParaResgate = 10,
                ValorInicial = 1000
            };

            CertificadoDepositoBancario cdbExperado = new()
            {
                Id = 1,
                ValorInicial = 1000,
                MesesParaResgate = 10,
                ValorFinal = 1101.5636241432533,
                ValorBruto = 1101.5636241432533,
                ValorRendimentoBruto = 101.56362414325326,
                ValorImposto = 20.312724828650655,
                ValorLiquido = 1081.2508993146025
            };

            CertificadoDepositoBancario cdb = _baseCalculoCdb.ResgatarAplicacao(investimento);

            Assert.Multiple(() =>
            {
                Assert.That(cdbExperado.Id, Is.EqualTo(cdb.Id));
                Assert.That(cdbExperado.ValorInicial, Is.EqualTo(cdb.ValorInicial));
                Assert.That(cdbExperado.MesesParaResgate, Is.EqualTo(cdb.MesesParaResgate));
                Assert.That(cdbExperado.ValorFinal, Is.EqualTo(cdb.ValorFinal));
                Assert.That(cdbExperado.ValorBruto, Is.EqualTo(cdb.ValorBruto));
                Assert.That(cdbExperado.ValorRendimentoBruto, Is.EqualTo(cdb.ValorRendimentoBruto));
                Assert.That(cdbExperado.ValorImposto, Is.EqualTo(cdb.ValorImposto));
                Assert.That(cdbExperado.ValorLiquido, Is.EqualTo(cdb.ValorLiquido));
            });
        }
    }
}
