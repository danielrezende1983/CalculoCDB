namespace CalculoCDB.Domain.Entities
{
    public class CertificadoDepositoBancario : BaseEntitie
    {
        public double ValorFinal { get; set; }
        public double ValorInicial { get; set; }
        public int MesesParaResgate { get; set; }
        public double ValorBruto { get; set; }
        public double ValorRendimentoBruto { get; set; }
        public double ValorImposto { get; set; }
        public double ValorLiquido { get; set; }
    }
}
