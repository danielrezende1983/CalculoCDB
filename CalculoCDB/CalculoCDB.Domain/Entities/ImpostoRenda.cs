namespace CalculoCDB.Domain.Entities
{
    public class ImpostoRenda : BaseEntitie
    {
        public int Meses { get; private set; }
        public double Percentual { get; private set; }

        public ImpostoRenda(int id, int meses, double percentual)
        {
            Id = id;
            Meses = meses;
            Percentual = percentual;
        }

        public readonly static ImpostoRenda Ate6Meses = new(1, 6, 22.5);
        public readonly static ImpostoRenda Ate12Meses = new(2, 12, 20);
        public readonly static ImpostoRenda Ate24Meses = new(3, 24, 17.5);
        public readonly static ImpostoRenda Acima24Meses = new(4, 10000, 15);

        public static ImpostoRenda GetImpostoRenda(int meses)
        {
            if(meses > 24)
            {
                return Acima24Meses;
            }
            else if(meses > 12)
            {
                return Ate24Meses;
            }
            else if (meses > 6)
            {
                return Ate12Meses;
            }

            return Ate6Meses;
        }

    }
}
