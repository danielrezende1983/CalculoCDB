using CalculoCDB.Domain.Entities;
using CalculoCDB.Domain.Interfaces;
using CalculoCDB.Infra.CrossCutting.Globais;

namespace CalculoCDB.Service.CalculoCDB
{
    public class CalculoCdb : IBaseCalculoCdb
    {
        public CertificadoDepositoBancario ResgatarAplicacao(Investimento investimento)
        {
            if (!InvestimentoValido(investimento))
                return new CertificadoDepositoBancario();

            CertificadoDepositoBancario cdb = new()
            {
                Id = investimento.Id,
                ValorInicial = investimento.ValorInicial,
                ValorFinal = investimento.ValorInicial,
                MesesParaResgate = investimento.MesesParaResgate
            };

            for (int mes = 1; mes <= cdb.MesesParaResgate; mes++)
                cdb.ValorFinal = CalcularResgateAplicacaoMensal(cdb);

            cdb.ValorBruto = cdb.ValorFinal;
            cdb.ValorRendimentoBruto = cdb.ValorFinal - cdb.ValorInicial;
            cdb.ValorImposto = CalcularImposto(cdb);
            cdb.ValorLiquido = cdb.ValorBruto - cdb.ValorImposto;

            return cdb;
        }
        
        private static double CalcularResgateAplicacaoMensal(CertificadoDepositoBancario cdb)
        {
            if (!CdbValido(cdb))
                return 0;

            return cdb.ValorFinal * (1 + ((Constantes.CDI / 100) * (Constantes.TB / 100)));
        }

        private static double CalcularImposto(CertificadoDepositoBancario cdb)
        {
            if (!CdbValido(cdb))
                return 0;
                        
            var imposto = ImpostoRenda.GetImpostoRenda(cdb.MesesParaResgate);

            return cdb.ValorRendimentoBruto * (imposto.Percentual / 100);
        }

        private static bool InvestimentoValido(Investimento investimento)
        {
            if (investimento == null)
                return false;

            if (investimento.MesesParaResgate == 0)
                return false;

            return true;
        }

        private static bool CdbValido(CertificadoDepositoBancario cdb)
        {
            if (cdb == null)
                return false;

            if (cdb.MesesParaResgate == 0)
                return false;

            if (cdb.ValorFinal == 0)
                return false;

            return true;
        }

    }
}
