using CalculoCDB.Domain.Entities;

namespace CalculoCDB.Domain.Interfaces
{
    public interface IBaseCalculoCdb
    {
        CertificadoDepositoBancario ResgatarAplicacao(Investimento investimento);
    }
}
