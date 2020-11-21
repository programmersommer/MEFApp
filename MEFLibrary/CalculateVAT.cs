using MEFBaseLibrary;
using System.Composition;

namespace MEFLibrary
{
    [Export(typeof(ICalculateVAT))]
    public class CalculateVat : ICalculateVAT
    {
        public decimal CalcVAT(decimal amount)
        {
            return amount * (decimal)0.2;
        }
    }
}
