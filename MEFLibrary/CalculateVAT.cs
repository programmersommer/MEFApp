using MEFBaseLibrary;
using System.Composition;

namespace MEFLibrary
{
    [Export(typeof(ICalculateVAT))]
    public class CalculateVAT : ICalculateVAT
    {
        public decimal CalcVAT(decimal amount)
        {
            return amount * (decimal)0.2;
        }
    }
}
